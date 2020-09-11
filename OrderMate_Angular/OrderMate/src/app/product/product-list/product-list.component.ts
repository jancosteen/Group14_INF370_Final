import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../shared/services/repository.service';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import { Product } from '../../_interfaces/Product/product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnDestroy,OnInit {

  public products: Product[];
  public errorMessage: string = '';
  dtTrigger: Subject<any>  =  new Subject();
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective;
  min:number;
  max:number;

  constructor(private repository :  RepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router) { }

    dtOptions: DataTables.Settings = {};

    ngOnInit(): void {
   
      this.dtOptions = {
        pagingType: 'full_numbers',
        pageLength: 5
      };
        let apiAddress: string = "api/product";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.products = res as Product[];
          
          this.dtTrigger.next();
        });
  
        $.fn['dataTable'].ext.search.push((settings, data, dataIndex) => {
        const id = parseFloat(data[0]) || 0; // use data for the id column
        if ((isNaN(this.min) && isNaN(this.max)) ||
          (isNaN(this.min) && id <= this.max) ||
          (this.min <= id && isNaN(this.max)) ||
          (this.min <= id && id <= this.max)) {
          return true;
        }
        return false;
      });
  
    }
  
  
    ngOnDestroy(): void {
      this.dtTrigger.unsubscribe();
      $.fn.dataTable.ext.errMode = 'throw';
    }






  public getProductDetails = (productId) => { 
    const detailsUrl: string = '/product/details/' + productId; 
    this.router.navigate([detailsUrl]); 
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
