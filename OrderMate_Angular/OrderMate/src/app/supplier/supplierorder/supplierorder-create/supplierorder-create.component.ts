import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import { CreateSupplierOrder } from 'src/app/_interfaces/Supplier/SupplierOrder/supplierordercreate.model';

@Component({
  selector: 'app-supplierorder-create',
  templateUrl: './supplierorder-create.component.html',
  styleUrls: ['./supplierorder-create.component.css']
})
export class SupplierorderCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public supplierorderForm: FormGroup;

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

  ngOnInit(): void { 
    this.supplierorderForm = new FormGroup({
      SupplierOrderId: new FormControl(''),
      SupplierOrderDate: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      supplierId: new FormControl(''),
      
    });
  }
  public validateControl = (controlName: string) => {
    if (this.supplierorderForm.controls[controlName].invalid && this.supplierorderForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.supplierorderForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public createSupplierOrder = (supplierorderFormValue) => {
    if (this.supplierorderForm.valid) {
    
      this.executeSupplierOrderCreation(supplierorderFormValue);
    }
  }

  private executeSupplierOrderCreation = (supplierFormValue) => {

    const supplierorder: CreateSupplierOrder = {
      SupplierOrderDate:  supplierFormValue.SupplierOrderDate,
      supplierId: supplierFormValue.supplierId

    }
    
   
    let apiUrl = 'api/supplierorder/' ;
    this.repository.update(apiUrl, supplierorder)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }

  public redirectToSupplierOrderList(){
    this.router.navigate(['/supplierorder/list']);
  }

}
