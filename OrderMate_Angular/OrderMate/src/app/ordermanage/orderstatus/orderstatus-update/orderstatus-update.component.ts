import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  


import {OrderStatus} from '../../../_interfaces/Order/OrderStatus/orderstatus.model'

@Component({
  selector: 'app-orderstatus-update',
  templateUrl: './orderstatus-update.component.html',
  styleUrls: ['./orderstatus-update.component.css']
})
export class OrderstatusUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public orderStatusForm: FormGroup;

  public orderStatus: OrderStatus; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.orderStatusForm = new FormGroup({
      orderStatusId: new FormControl(''),
      orderStatus: new FormControl('',[Validators.required,Validators.maxLength(100)]),
      Order: new FormControl('',[Validators.required,Validators.maxLength(100)])
    });

    this.getById();
  }

  private getById = () => {
    let orderStatusId: string = this.activeRoute.snapshot.params['id'];
      
    let IdUrl: string = 'api/orderstatus/'+orderStatusId;
   
    this.repository.getData(IdUrl)
      .subscribe(res => {
        this.orderStatus = res as OrderStatus;
     
        this.orderStatusForm.patchValue(this.orderStatus);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public validateControl = (controlName: string) => {
    if (this.orderStatusForm.controls[controlName].invalid && this.orderStatusForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.orderStatusForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectToList(){
    this.router.navigate(['/orderstatus/list']);
  }


  public update = (Value) => {
    if (this.orderStatusForm.valid) {
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => {
  
    this.orderStatus.orderStatusId =  Value.orderStatusId,
    this.orderStatus.orderStatus = Value.orderStatus,
    this.orderStatus.orderId = Value.orderId
   
    let apiUrl = 'api/orderstatus/' + this.orderStatus.orderStatusId;
    this.repository.update(apiUrl, this.orderStatus)
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
