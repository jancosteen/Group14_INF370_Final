import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {OrderLine} from '../../../_interfaces/Order/Orderline/orderline.model'

@Component({
  selector: 'app-orderline-delete',
  templateUrl: './orderline-delete.component.html',
  styleUrls: ['./orderline-delete.component.css']
})
export class OrderlineDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public orderLine: OrderLine; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails(); 
    }
  
  
    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/orderline/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.orderLine = res as OrderLine;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }

    public delete = () => {
      const deleteUrl: string = 'api/orderline/' + this.orderLine.orderLineId ;

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
      this.router.navigate(['/orderline/list']);
    }


}
