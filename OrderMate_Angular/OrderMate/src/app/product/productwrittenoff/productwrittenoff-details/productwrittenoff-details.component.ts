import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';


import { ProductWrittenOff } from '../../../_interfaces/Product/ProductWrittenOff/productwrittenoff.model';

@Component({
  selector: 'app-productwrittenoff-details',
  templateUrl: './productwrittenoff-details.component.html',
  styleUrls: ['./productwrittenoff-details.component.css']
})
export class ProductwrittenoffDetailsComponent implements OnInit {
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

  public redirectToUpdatePage = (ProductWrittenOffId) => { 
    const updateUrl: string = '/prodWrittenOff/update/' + ProductWrittenOffId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (ProductWrittenOffId) => { 
    const deleteUrl: string = '/prodWrittenOff/delete/' + ProductWrittenOffId; 
    this.router.navigate([deleteUrl]); 
  }

}
