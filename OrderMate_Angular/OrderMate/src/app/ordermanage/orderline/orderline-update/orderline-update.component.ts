import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import{OrderLine} from '../../../_interfaces/Order/Orderline/orderline.model'

@Component({
  selector: 'app-orderline-update',
  templateUrl: './orderline-update.component.html',
  styleUrls: ['./orderline-update.component.css']
})
export class OrderlineUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public orderLineForm: FormGroup;

  public orderLine: OrderLine; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.orderLineForm = new FormGroup({
      orderLineId: new FormControl(''),
      itemQuantity: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      special: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      menuItem: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      Order: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      Employee: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });

    this.getById();
  }
  private getById = () => {
    let orderlineId: string = this.activeRoute.snapshot.params['id'];
      
    let IdUrl: string = 'api/orderline/'+orderlineId;
   
    this.repository.getData(IdUrl)
      .subscribe(res => {
        this.orderLine = res as OrderLine;
     
        this.orderLineForm.patchValue(this.orderLine);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }


  public validateControl = (controlName: string) => {
    if (this.orderLineForm.controls[controlName].invalid && this.orderLineForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.orderLineForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectToList(){
    this.router.navigate(['/orderline/list']);
  }

  public update = (Value) => {
    if (this.orderLineForm.valid) {
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => {
  
    this.orderLine.orderLineId =  Value.orderLineId,
    this.orderLine.itemQty = Value.itemQuantity,
    this.orderLine.specialIdFk = Value.special,
    this.orderLine.menuItemIdFk = Value.menuItemIdFk,
    this.orderLine.orderIdFk = Value.Order,
    this.orderLine.employeeIdFk = Value.Employee
   
    let apiUrl = 'api/orderline/' + this.orderLine.orderLineId;
    this.repository.update(apiUrl, this.orderLine)
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
