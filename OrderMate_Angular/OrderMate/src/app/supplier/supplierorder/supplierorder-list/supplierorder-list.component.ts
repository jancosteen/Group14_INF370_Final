import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import { SupplierOrder } from 'src/app/_interfaces/Supplier/SupplierOrder/supplierorder.model';

@Component({
  selector: 'app-supplierorder-list',
  templateUrl: './supplierorder-list.component.html',
  styleUrls: ['./supplierorder-list.component.css']
})
export class SupplierorderListComponent implements OnDestroy, OnInit {
  public supplierorders: SupplierOrder[];
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
      let apiAddress: string = "api/supplierorder";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.supplierorders = res as SupplierOrder[];
        
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

  public getDetailsPage = (SupplierOrderId) => { 
    const detailsUrl: string = '/supplier/details/' + SupplierOrderId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (SupplierOrderId) => { 
    const updateUrl: string = '/supplier/update/' + SupplierOrderId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (SupplierOrderId) => { 
    const deleteUrl: string = '/supplier/delete/' + SupplierOrderId; 
    this.router.navigate([deleteUrl]); 
  }

}
