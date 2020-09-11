import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router'; 

import { CreateOrderStatus} from '../../../_interfaces/Order/OrderStatus/orderstatuscreate.model';

@Component({
  selector: 'app-orderstatus-create',
  templateUrl: './orderstatus-create.component.html',
  styleUrls: ['./orderstatus-create.component.css']
}) 
export class OrderstatusCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public orderstatusForm: FormGroup;

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

    ngOnInit(): void { 

      this.orderstatusForm = new FormGroup({
        orderStatus: new FormControl('',[Validators.required]), 
        Order: new FormControl('',[Validators.required]), 
      });
   
    }
   
    public validateControl = (controlName: string) => {
     if (this.orderstatusForm.controls[controlName].invalid && this.orderstatusForm.controls[controlName].touched)
       return true;
   
     return false;
   }
   
   public hasError = (controlName: string, errorName: string) => {
     if (this.orderstatusForm.controls[controlName].hasError(errorName))
       return true;
   
     return false;
   }

   public create = (Value) => {
    if (this.orderstatusForm.valid) {
      this.executeCreation(Value);
    }
  }
  private executeCreation = (Value) => {
  
    const orderstatus : CreateOrderStatus = {
      orderStatus1: Value.orderStatus, 
      orderIdFk:Value.orderId
    }
  
    const apiUrl = 'api/orderstatus';
    this.repository.create(apiUrl, orderstatus)
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
    this.router.navigate(['/orderstatus/list']);
  }

}
