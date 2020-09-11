import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import { CreateOrderLine} from '../../../_interfaces/Order/Orderline/orderlinecreate.model'

@Component({
  selector: 'app-orderline-create',
  templateUrl: './orderline-create.component.html',
  styleUrls: ['./orderline-create.component.css']
})
export class OrderlineCreateComponent implements OnInit {

  public errorMessage: string = '';
 
  public orderlineForm: FormGroup;

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

  ngOnInit(): void { 

   this.orderlineForm = new FormGroup({
    itemQuantity: new FormControl('',[Validators.required]), 
    special: new FormControl('',[Validators.required]), 
    menuItem: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    Order: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    Employee: new FormControl('',[Validators.required, Validators.maxLength(100)])
   });

 }

 public validateControl = (controlName: string) => {
  if (this.orderlineForm.controls[controlName].invalid && this.orderlineForm.controls[controlName].touched)
    return true;

  return false;
}

public hasError = (controlName: string, errorName: string) => {
  if (this.orderlineForm.controls[controlName].hasError(errorName))
    return true;

  return false;
}

public create = (Value) => {
  if (this.orderlineForm.valid) {
    this.executeCreation(Value);
  }
}
private executeCreation = (Value) => {

  const orderline : CreateOrderLine = {
    itemQuantity: Value.itemQuantity, 
    special:Value.special,
    menuItem: Value.menuItem,
    Order: Value.Order,
    Employee: Value.Employee
      
  }

  const apiUrl = 'api/orderline';
  this.repository.create(apiUrl, orderline)
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
  this.router.navigate(['/orderline/list']); 
}

}
