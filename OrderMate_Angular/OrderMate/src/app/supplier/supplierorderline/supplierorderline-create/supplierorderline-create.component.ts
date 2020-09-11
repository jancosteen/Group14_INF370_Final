import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateSupplierOrderLine} from '../../../_interfaces/Supplier/SupplierOrderLine/supplierorderlinecreate.model'

@Component({
  selector: 'app-supplierorderline-create',
  templateUrl: './supplierorderline-create.component.html',
  styleUrls: ['./supplierorderline-create.component.css']
})
export class SupplierorderlineCreateComponent implements OnInit {public errorMessage: string = '';
 
public supplierOrderLineForm: FormGroup;
  
  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

    ngOnInit() {
    
      this.supplierOrderLineForm = new FormGroup({
        supplierOrder: new FormControl('',[Validators.required, Validators.maxLength(20)]),
        deliveryLeadTime: new FormControl('', [Validators.required, Validators.maxLength(50)]),
        productStandardPrice: new FormControl('', [Validators.required, Validators.maxLength(30)]),
        discountAgreement: new FormControl('', [Validators.required, Validators.maxLength(10)]),
        orderedQty: new FormControl('', [Validators.required, Validators.maxLength(50)]),
        product: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      });
  
      
    }
    public createSupplierOrderLine = (Value) => {
      if (this.supplierOrderLineForm.valid) {
        this.executeCreation(Value);
      }
    }
    private executeCreation = (Value) => {
  
      const supplierOrderLine: CreateSupplierOrderLine = {
      supplierOrder: Value.supplierOrder,
      deliveryLeadTime: Value.deliveryLeadTime,
      productStandardPrice: Value.productStandardPrice,
      discountAgreement: Value.discountAgreement,
      orderedQty: Value.orderedQty,
      product: Value.product,

      }
   
      const apiUrl = 'api/supplierorderline';
      this.repository.create(apiUrl, supplierOrderLine)
        .subscribe(res => {
          $('#successModal').modal();
        },
        (error => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
      )
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

}
