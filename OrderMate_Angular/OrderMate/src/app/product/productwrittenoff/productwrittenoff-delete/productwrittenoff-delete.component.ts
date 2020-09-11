import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';

import { ProductWrittenOff } from '../../../_interfaces/Product/ProductWrittenOff/productwrittenoff.model';


@Component({
  selector: 'app-productwrittenoff-delete',
  templateUrl: './productwrittenoff-delete.component.html',
  styleUrls: ['./productwrittenoff-delete.component.css']
})
export class ProductwrittenoffDeleteComponent implements OnInit {
  public errorMessage: string = '';
 
  public productwrittenoff: ProductWrittenOff;
  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getProductWrittenOffDetails();
  }

  getProductWrittenOffDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    
    let apiUrl: string = 'api/prodWrittenOff/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.productwrittenoff = res as ProductWrittenOff;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public deleteProductWrittenOff = () => {
    const deleteUrl: string = 'api/prodWrittenOff/' + this.productwrittenoff.ProductWrittenOffId ;

    this.repository.delete(deleteUrl)
      .subscribe(res => {
 
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public redirectToProductWrittenOffList(){
    this.router.navigate(['/prodWrittenOff/list']);
  }

}
