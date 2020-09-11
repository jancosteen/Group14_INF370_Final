import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import { ProductCategory } from '../../../_interfaces/Product/ProductCategory/productCategory.model';

@Component({
  selector: 'app-productcategory-delete',
  templateUrl: './productcategory-delete.component.html',
  styleUrls: ['./productcategory-delete.component.css']
})
export class ProductcategoryDeleteComponent implements OnInit {
  public errorMessage: string = '';
  public productcategory: ProductCategory; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getProductCategoryDetails();
    }
  
  
    getProductCategoryDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/prodCategory/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.productcategory = res as ProductCategory;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }


    public deleteProductCategory = () => {
      const deleteUrl: string = 'api/productcategory/' + this.productcategory.ProductCategoryId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public redirectToProductCategoryList(){
      this.router.navigate(['/productcategory/list']);
    }

}
