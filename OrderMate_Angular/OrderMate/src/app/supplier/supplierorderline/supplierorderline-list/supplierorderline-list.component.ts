import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {SupplierOrderLine} from '../../../_interfaces/Supplier/SupplierOrderLine/supplierorderline.model'

@Component({
  selector: 'app-supplierorderline-list',
  templateUrl: './supplierorderline-list.component.html',
  styleUrls: ['./supplierorderline-list.component.css']
})
export class SupplierorderlineListComponent implements OnInit, OnDestroy {

  public supplierorderline: SupplierOrderLine[];
  public errorMessage: string = '';
  public x:string;
  dtTrigger: Subject<any>  =  new Subject();
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective;
  min:number;
  max:number;

  dtOptions: DataTables.Settings = {};

  constructor(private repository :  RepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router) { }

  ngOnInit(): void {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5
    };
      let apiAddress: string = "api/supplierorderline";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.supplierorderline = res as SupplierOrderLine[];
        
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


  public getDetailsPage = (supplierOrderLineId) => { 
    const detailsUrl: string = '/supplierorderline/details/' + supplierOrderLineId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (supplierOrderLineId) => { 
    const updateUrl: string = '/supplierorderline/update/' + supplierOrderLineId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (supplierOrderLineId) => { 
    const deleteUrl: string = '/supplierorderline/delete/' + supplierOrderLineId; 
    this.router.navigate([deleteUrl]); 
  }

}
