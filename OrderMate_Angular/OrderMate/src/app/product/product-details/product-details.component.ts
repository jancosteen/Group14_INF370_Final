import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../shared/services/repository.service';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';

import { Product } from '../../_interfaces/Product/product.model';


@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  public product: Product;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getProductDetails();
  }

  getProductDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    console.log('id',id);
    let apiUrl: string = 'api/product/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.product = res as Product;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }



  public redirectToUpdatePage = (productId) => { 
    const updateUrl: string = '/product/update/' + productId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (productId) => { 
    const deleteUrl: string = '/product/delete/' + productId; 
    this.router.navigate([deleteUrl]); 
  }

}
