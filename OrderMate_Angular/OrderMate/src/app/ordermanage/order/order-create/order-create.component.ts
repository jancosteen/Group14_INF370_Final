import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateOrder} from '../../../_interfaces/Order/Order/ordercreate.model'

@Component({
  selector: 'app-order-create',
  templateUrl: './order-create.component.html',
  styleUrls: ['./order-create.component.css']
})
export class OrderCreateComponent implements OnInit {

  public errorMessage: string = '';
 
  public orderForm: FormGroup;

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

  ngOnInit(): void { 

   this.orderForm = new FormGroup({
    orderDateCreated: new FormControl('',[Validators.required]), 
    QrCodeSeating: new FormControl('',[Validators.required, Validators.maxLength(100)])
   });

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

public create = (Value) => {
  if (this.orderForm.valid) {
    this.executeCreation(Value);
  }
}
private executeCreation = (Value) => {

  const order: CreateOrder = {

    orderDateCreated: Value.orderDateCreated, 
    orderDateCompleted: Value.orderDateCompleted,
    qrCodeSeating: Value.qrCodeSeating
      
  }

  const apiUrl = 'api/order';
  this.repository.create(apiUrl, order)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  )
  
}



public redirectToList(){
  this.router.navigate(['/order/list']);
}

}
