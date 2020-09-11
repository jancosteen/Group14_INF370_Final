import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';


import {SupplierOrderLine} from '../../../_interfaces/Supplier/SupplierOrderLine/supplierorderline.model'

@Component({
  selector: 'app-supplierorderline-update',
  templateUrl: './supplierorderline-update.component.html',
  styleUrls: ['./supplierorderline-update.component.css']
})
export class SupplierorderlineUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public supplierOrderLineForm: FormGroup;

  public supplierOrderLine: SupplierOrderLine;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {

    this.supplierOrderLineForm = new FormGroup({
      supplierOrder: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      deliveryLeadTime: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      productStandardPrice: new FormControl('', [Validators.required, Validators.maxLength(30)]),
      discountAgreement: new FormControl('', [Validators.required, Validators.maxLength(10)]),
      orderedQty: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      product: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    });

    this.getById();
    
  }
  private getById = () => {
    let supplierOrderLineId: string = this.activeRoute.snapshot.params['id'];
      
    let ByIdUrl: string = 'api/supplierorderline/'+supplierOrderLineId;
   
    this.repository.getData(ByIdUrl)
      .subscribe(res => {
        this.supplierOrderLine = res as SupplierOrderLine;
     
        this.supplierOrderLineForm.patchValue(this.supplierOrderLine);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public validateControl = (controlName: string) => {
    if (this.supplierOrderLineForm.controls[controlName].invalid && this.supplierOrderLineForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.supplierOrderLineForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectToList(){
    this.router.navigate(['/supplierorderline/list']);
  }

  public update = (Value) => {
    if (this.supplierOrderLineForm.valid) {
  //    console.log('supplierFormValue', supplierFormValue);
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => {
 //   console.log('supplierFormValue', supplierFormValue);
    this.supplierOrderLine.supplierOrderLineId =  Value.supplierOrderLineId,
    this.supplierOrderLine.supplierOrder = Value.supplierOrder,
    this.supplierOrderLine.deliveryLeadTime = Value.deliveryLeadTime,
    this.supplierOrderLine.productStandardPrice = Value.productStandardPrice,
    this.supplierOrderLine.discountAgreement = Value.discountAgreement,
    this.supplierOrderLine.orderedQty = Value.orderedQty

    let apiUrl = 'api/supplierorderline/' + this.supplierOrderLine.supplierOrderLineId;
    this.repository.update(apiUrl, this.supplierOrderLine)
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
