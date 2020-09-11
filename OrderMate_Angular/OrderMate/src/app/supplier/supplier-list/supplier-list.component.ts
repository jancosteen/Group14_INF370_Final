import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../shared/services/repository.service';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import { Supplier } from './../../_interfaces/supplier/supplier.model';



@Component({
  selector: 'app-supplier-list',
  templateUrl: './supplier-list.component.html',
  styleUrls: ['./supplier-list.component.css']
})
export class SupplierListComponent implements OnDestroy, OnInit {


  public suppliers: Supplier[];
  public errorMessage: string = '';
  public x:string;
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
      let apiAddress: string = "api/supplier";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.suppliers = res as Supplier[];
        
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

  public getAllSuppliers = () => {
    let apiAddress: string = "api/supplier";
    this.repository.getData(apiAddress)
    .subscribe(res => {
   //   this.dataSource.data = res as Supplier[];
     this.suppliers = res as Supplier[];
    //this.dtTrigger.next();
    
    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
      
  }

  public getSupplierDetails = (supplierId) => { 
    const detailsUrl: string = '/supplier/details/' + supplierId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (supplierId) => { 
    const updateUrl: string = '/supplier/update/' + supplierId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (supplierId) => { 
    const deleteUrl: string = '/supplier/delete/' + supplierId; 
    this.router.navigate([deleteUrl]); 
  }


}
