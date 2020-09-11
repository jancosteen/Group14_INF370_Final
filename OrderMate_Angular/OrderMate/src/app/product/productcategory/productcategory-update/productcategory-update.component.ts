import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 


import { ProductCategory } from '../../../_interfaces/Product/ProductCategory/productCategory.model';

@Component({
  selector: 'app-productcategory-update',
  templateUrl: './productcategory-update.component.html',
  styleUrls: ['./productcategory-update.component.css'] 
})
export class ProductcategoryUpdateComponent implements OnInit {
  public errorMessage: string = '';
 
  public productcategoryForm: FormGroup;

  public productcategory: ProductCategory;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.productcategoryForm = new FormGroup({
      ProductCategoryId: new FormControl(''),
      ProductCategory1: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });

    this.getProductCategoryById();
  }


  private getProductCategoryById = () => {
    let ProductCategoryId: string = this.activeRoute.snapshot.params['id'];
      
    let productCategoryIdByIdUrl: string = 'api/prodCategory/'+ProductCategoryId;
   
    this.repository.getData(productCategoryIdByIdUrl)
      .subscribe(res => {
        this.productcategory = res as ProductCategory;
     
        this.productcategoryForm.patchValue(this.productcategory);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
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

  public redirectToList(){
    this.router.navigate(['/prodCategory/list']);
  }


  public updateProductCategory = (productcategoryFormValue) => {
    if (this.productcategoryForm.valid) {
      this.executeProductCategoryUpdate(productcategoryFormValue);
    }
  }

  private executeProductCategoryUpdate = (productcategoryFormValue) => {
  
    this.productcategory.ProductCategoryId =  productcategoryFormValue.ProductCategoryId,
    this.productcategory.ProductCategory1 = productcategoryFormValue.ProductCategory1
    
   
    let apiUrl = 'api/prodCategory/' + this.productcategory.ProductCategoryId;
    this.repository.update(apiUrl, this.productcategory)
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
