import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {SpecialPrice} from '../../../_interfaces/Order/SpecialPrice/specialprice.model'

@Component({
  selector: 'app-specialprice-delete',
  templateUrl: './specialprice-delete.component.html',
  styleUrls: ['./specialprice-delete.component.css']
}) 
export class SpecialpriceDeleteComponent implements OnInit {
  public errorMessage: string = '';
  public specialPrice: SpecialPrice; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails(); 
    }
  
  
    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/specialprice/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.specialPrice = res as SpecialPrice;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }


    public delete = () => {
      const deleteUrl: string = 'api/specialprice/' + this.specialPrice.specialPriceId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public redirectTospecialPriceList(){
      this.router.navigate(['/specialPrice/list']);
    }
}
 