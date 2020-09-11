import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {OrderStatus} from '../../../_interfaces/Order/OrderStatus/orderstatus.model'

@Component({
  selector: 'app-orderstatus-delete',
  templateUrl: './orderstatus-delete.component.html',
  styleUrls: ['./orderstatus-delete.component.css']
})
export class OrderstatusDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public orderStatus: OrderStatus; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails(); 
    }
  
  
    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/orderStatus/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.orderStatus = res as OrderStatus;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }

    public delete = () => {
      const deleteUrl: string = 'api/orderStatus/' + this.orderStatus.orderStatusId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage; 
        })
    }

    public redirectToList(){
      this.router.navigate(['/orderStatus/list']);
    }

}
