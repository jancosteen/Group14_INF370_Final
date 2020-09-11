import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import { CreateProductCategory } from '../../../_interfaces/Product/ProductCategory/productCategoryCreate.model';

@Component({
  selector: 'app-productcategory-create',
  templateUrl: './productcategory-create.component.html',
  styleUrls: ['./productcategory-create.component.css']
})
export class ProductcategoryCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public productcategoryForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
     private router: Router ) { }

  ngOnInit(): void {

    this.productcategoryForm = new FormGroup({
      ProductCategory1: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });

  }

  public validateControl = (controlName: string) => {
    if (this.productcategoryForm.controls[controlName].invalid && this.productcategoryForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.productcategoryForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public createProductCategory = (productcategoryValue) => {
    if (this.productcategoryForm.valid) {
      this.executeProductCategoryCreation(productcategoryValue);
    }
  }
  private executeProductCategoryCreation = (supplierFormValue) => {

    const productcategory: CreateProductCategory = {
    //supplierId: supplierFormValue.Id,
    ProductCategory1:supplierFormValue.ProductCategory1
   
    }
 
    const apiUrl = 'api/prodCategory';
    this.repository.create(apiUrl, productcategory)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }


  
  public redirectToProductCategoryList(){
    this.router.navigate(['/prodCategory/list']);
  }

}
