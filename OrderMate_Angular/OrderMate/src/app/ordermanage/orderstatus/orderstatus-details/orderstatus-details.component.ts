import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import {OrderStatus} from '../../../_interfaces/Order/OrderStatus/orderstatus.model'

@Component({
  selector: 'app-orderstatus-details',
  templateUrl: './orderstatus-details.component.html',
  styleUrls: ['./orderstatus-details.component.css'] 
})
export class OrderstatusDetailsComponent implements OnInit {
  public orderStatus: OrderStatus; 
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/orderstatus/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.orderStatus = res as OrderStatus;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (orderStatusId) => { 
    const updateUrl: string = '/orderstatus/update/' + orderStatusId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (orderStatusId) => { 
    const deleteUrl: string = '/orderstatus/delete/' + orderStatusId; 
    this.router.navigate([deleteUrl]); 
  }

}
