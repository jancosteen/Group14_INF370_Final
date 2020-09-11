import { OrderStatus } from './../../../_interfaces/Order/OrderStatus/orderstatus.model';
import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  


import {Order} from '../../../_interfaces/Order/Order/order.model'

@Component({
  selector: 'app-order-update',
  templateUrl: './order-update.component.html',
  styleUrls: ['./order-update.component.css']
})
export class OrderUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public orderForm: FormGroup;

  public order: Order; 
  selectedStatus: OrderStatus;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.getStatuses();
    this.orderForm = new FormGroup({
      orderId: new FormControl(''),
      orderDateCreated: new FormControl(''),
      orderStatus1: new FormControl('',[Validators.required])
    });

    this.getById();
  }
  private getById = () => {
    let orderId: string = this.activeRoute.snapshot.params['id'];
      
    let IdUrl: string = 'api/order/'+orderId;
   
    this.repository.getData(IdUrl)
      .subscribe(res => {
        this.order = res as Order;
     
        this.orderForm.patchValue(this.order);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public validateControl = (controlName: string) => {
    if (this.orderForm.controls[controlName].invalid && this.orderForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.orderForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectToList(){
    this.router.navigate(['/ordermanage']);
  }

  public update = (Value) => {
    if (this.orderForm.valid) {
      this.executeUpdate(Value);
    }
  }

  statuses : OrderStatus[]
  getStatuses(){
    let statusurl = 'api/orderstatus';
    this.repository.getData(statusurl)
      .subscribe(res =>{
        this.statuses = res  as OrderStatus[]
        console.log('statuses',this.statuses)
      })
  }

  private executeUpdate = (Value) => {
    let statusId : number;
    this.statuses.forEach(status =>{
      if(status.orderStatus1 == Value.orderStatus1){
        statusId = status.orderStatusId
      }
    })
   
    this.order.orderId =  Value.orderId,
    this.order.orderDateCreated = Value.orderDateCreated,
    this.order.orderStatus1 = statusId
    
    let apiUrl = 'api/order/' + this.order.orderId;
    this.repository.update(apiUrl, this.order)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error); 
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  } 

}
