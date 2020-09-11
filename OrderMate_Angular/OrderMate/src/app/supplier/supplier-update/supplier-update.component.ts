import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';


import { Supplier } from './../../_interfaces/supplier/supplier.model';


@Component({
  selector: 'app-supplier-update',
  templateUrl: './supplier-update.component.html',
  styleUrls: ['./supplier-update.component.css']
})

export class SupplierUpdateComponent implements OnInit {
  public errorMessage: string = '';
 
  public supplierForm: FormGroup;

  public supplier: Supplier;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
 
    this.supplierForm = new FormGroup({
      supplierId: new FormControl(''),
      supplierName: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      supplierDescription: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      supplierEmail: new FormControl('', [Validators.required, Validators.maxLength(20)]),
      supplierContactNumber: new FormControl('', [Validators.required, Validators.maxLength(10)]),
      supplierAddressLine1: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      supplierAddressLine2: new FormControl('', [Validators.required, Validators.maxLength(50)]),
      supplierAddressLine3: new FormControl('', [Validators.maxLength(50)]),
      supplierCity: new FormControl('', [Validators.required, Validators.maxLength(25)]),
      supplierPostalCode: new FormControl('', [Validators.required, Validators.maxLength(5)]),
      supplierCountry: new FormControl('', [Validators.required, Validators.maxLength(25)]),
    });

    this.getSupplierById();
    
  }



  private getSupplierById = () => {
    let supplierId: string = this.activeRoute.snapshot.params['id'];
      
    let supplierByIdUrl: string = 'api/supplier/'+supplierId;
   
    this.repository.getData(supplierByIdUrl)
      .subscribe(res => {
        this.supplier = res as Supplier;
     
        this.supplierForm.patchValue(this.supplier);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
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

  public redirectToSupplierList(){
    this.router.navigate(['/supplier/list']);
  }

  public updateSupplier = (supplierFormValue) => {
    if (this.supplierForm.valid) {
      console.log('supplierFormValue', supplierFormValue);
      this.executeSupplierUpdate(supplierFormValue);
    }
  }
   
  private executeSupplierUpdate = (supplierFormValue) => {
    console.log('supplierFormValue', supplierFormValue);
    this.supplier.supplierId =  supplierFormValue.supplierId,
    this.supplier.supplierName = supplierFormValue.supplierName,
    this.supplier.supplierDescription = supplierFormValue.supplierDescription,
    this.supplier.supplierEmail = supplierFormValue.supplierEmail,
    this.supplier.supplierContactNumber = supplierFormValue.supplierContactNumber,
    this.supplier.supplierAddressLine1 = supplierFormValue.supplierAddressLine1,
    this.supplier.supplierAddressLine2 = supplierFormValue.supplierAddressLine2,
    this.supplier.supplierAddressLine3 = supplierFormValue.supplierAddressLine3,
    this.supplier.supplierCity = supplierFormValue.supplierCity,
    this.supplier.supplierPostalCode = supplierFormValue.supplierPostalCode,
    this.supplier.supplierCountry = supplierFormValue.supplierCountry
    console.log('supplier', this.supplier);
    let apiUrl = 'api/supplier/' + this.supplier.supplierId;
    this.repository.update(apiUrl, this.supplier)
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
