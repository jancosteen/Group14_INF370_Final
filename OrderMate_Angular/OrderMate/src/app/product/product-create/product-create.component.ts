import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CreateProduct } from '../../_interfaces/Product/productcreate.model';
import { ProductCategory } from '../../_interfaces/Product/ProductCategory/productCategory.model';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
  public errorMessage: string = '';
  public prodCategories: ProductCategory[];
 
  public productForm: FormGroup;

  constructor(private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

  ngOnInit(): void {
    this.productForm = new FormGroup({
      productName: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      productDescription: new FormControl('',[Validators.required, Validators.maxLength(50)]),
      productReorderLevel: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      productOnHand: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      productTypeIdFk: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      productCategoryIdFk: new FormControl('',[Validators.required, Validators.maxLength(20)]),
      productReorderFreqIdFk: new FormControl('',[Validators.required, Validators.maxLength(20)]),
    });


    this.patchchildren();
  }


  public validateControl = (controlName: string) => {
    if (this.productForm.controls[controlName].invalid && this.productForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.productForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }
  public createProduct = (productFormValue) => {
    if (this.productForm.valid) {
      this.executeProductCreation(productFormValue);
    }
  }

  private executeProductCreation = (productFormValue) => {

    const product: CreateProduct = {
    
    productName: productFormValue.productName,
    productDescription: productFormValue.productDescription,
    productReorderLevel: productFormValue.productReorderLevel,
    productOnHand: productFormValue.productOnHand,
    productTypeIdFk: productFormValue.ProductType,
    productCategoryIdFk: productFormValue.productCategory,
    productReorderFreqIdFk: productFormValue.ReorderFreq

    }
 
    const apiUrl = 'api/product';
    this.repository.create(apiUrl, product)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }

  private patchchildren(){
    const apiUrl = 'api/prodCategory';
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.prodCategories = res as ProductCategory[];
    },
    (error => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    }))

  }



  public redirectToProductList(){
    this.router.navigate(['/product/list']);
  }

}
