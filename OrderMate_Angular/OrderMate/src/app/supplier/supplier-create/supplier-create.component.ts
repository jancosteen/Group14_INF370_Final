import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router } from '@angular/router';
 
import { CreateSupplier } from '../../_interfaces/Supplier/suppliercreate.model';


@Component({
  selector: 'app-supplier-create',
  templateUrl: './supplier-create.component.html',
  styleUrls: ['./supplier-create.component.css']
})
export class SupplierCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public supplierForm: FormGroup;

  

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
     private router: Router ) { }

  ngOnInit() {
    
    this.supplierForm = new FormGroup({
      Name: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      Description: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      Email: new FormControl('', [Validators.required, Validators.maxLength(30)]),
      ContactNumber: new FormControl('', [Validators.required, Validators.maxLength(10)]),
      address1: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      address2: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      address3: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      City: new FormControl('', [Validators.required, Validators.maxLength(25)]),
      PostalCode: new FormControl('', [Validators.required, Validators.maxLength(5)]),
      Country: new FormControl('', [Validators.required, Validators.maxLength(25)])
    });

    
  }

  public validateControl = (controlName: string) => {
    if (this.supplierForm.controls[controlName].invalid && this.supplierForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.supplierForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

 
  public createSupplier = (supplierFormValue) => {
    if (this.supplierForm.valid) {
      this.executeSupplierCreation(supplierFormValue);
    }
  }
  private executeSupplierCreation = (supplierFormValue) => {

    const supplier: CreateSupplier = {
    //supplierId: supplierFormValue.Id,
    supplierName: supplierFormValue.Name,
    supplierDescription: supplierFormValue.Description,
    supplierEmail: supplierFormValue.Email,
    supplierContactNumber: supplierFormValue.ContactNumber,
    supplierAddressLine1: supplierFormValue.address1,
    supplierAddressLine2: supplierFormValue.address2,
    supplierAddressLine3: supplierFormValue.address3,
    supplierCity: supplierFormValue.City,
    supplierPostalCode: supplierFormValue.PostalCode,
    supplierCountry: supplierFormValue.Country
    }
 
    const apiUrl = 'api/supplier';
    this.repository.create(apiUrl, supplier)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }


  public redirectToSupplierList(){
    this.router.navigate(['/supplier/list']);
  }
  

}
