import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import { ProductCategory } from '../../../_interfaces/Product/ProductCategory/productCategory.model';

@Component({
  selector: 'app-productcategory-list',
  templateUrl: './productcategory-list.component.html',
  styleUrls: ['./productcategory-list.component.css']
})
export class ProductcategoryListComponent implements OnDestroy, OnInit { 

  public productcategories: ProductCategory[];
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
        let apiAddress: string = "api/prodCategory";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.productcategories = res as ProductCategory[];
          
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






  public getDetailsPage = (ProductCategoryId) => { 
    const detailsUrl: string = '/prodCategory/details/' + ProductCategoryId; 
    this.router.navigate([detailsUrl]); 
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
