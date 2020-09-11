import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import { OrderLine} from '../../../_interfaces/Order/Orderline/orderline.model'

@Component({
  selector: 'app-orderline-details',
  templateUrl: './orderline-details.component.html',
  styleUrls: ['./orderline-details.component.css']
})


export class OrderlineDetailsComponent implements OnInit {
  public orderLine: OrderLine;
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
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

  public redirectToUpdatePage = (orderLineId) => { 
    const updateUrl: string = '/orderline/update/' + orderLineId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (orderLineId) => { 
    const deleteUrl: string = '/orderline/delete/' + orderLineId; 
    this.router.navigate([deleteUrl]); 
  }
}
