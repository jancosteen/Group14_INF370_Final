import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import {Order} from '../../../_interfaces/Order/Order/order.model'

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  public order: Order;
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/order/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.order = res as Order;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (orderId) => { 
    const updateUrl: string = '/order/update/' + orderId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (orderId) => { 
    const deleteUrl: string = '/order/delete/' + orderId; 
    this.router.navigate([deleteUrl]);  
  }

}
