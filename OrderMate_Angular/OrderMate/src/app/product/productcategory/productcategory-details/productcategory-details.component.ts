import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import { ProductCategory } from '../../../_interfaces/Product/ProductCategory/productCategory.model';

@Component({
  selector: 'app-productcategory-details',
  templateUrl: './productcategory-details.component.html',
  styleUrls: ['./productcategory-details.component.css']
})
export class ProductcategoryDetailsComponent implements OnInit {
  public productcategory: ProductCategory;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getProductCategoryDetails();
  }


  getProductCategoryDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
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




  public redirectToUpdatePage = (ProductCategoryId) => { 
    const updateUrl: string = '/prodCategory/update/' + ProductCategoryId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (ProductCategoryId) => { 
    const deleteUrl: string = '/prodCategory/delete/' + ProductCategoryId; 
    this.router.navigate([deleteUrl]); 
  }
}
