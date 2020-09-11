import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import { ProductWrittenOff } from '../../../_interfaces/Product/ProductWrittenOff/productwrittenoff.model';


@Component({
  selector: 'app-productwrittenoff-list',
  templateUrl: './productwrittenoff-list.component.html',
  styleUrls: ['./productwrittenoff-list.component.css']
})
export class ProductwrittenoffListComponent implements OnDestroy, OnInit {

  public productswrittenoff: ProductWrittenOff[];
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
      let apiAddress: string = "api/prodWrittenOff";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.productswrittenoff = res as ProductWrittenOff[];
        
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

  public getDetailsPage = (ProductWrittenOffId) => { 
    const detailsUrl: string = '/prodWrittenOff/details/' + ProductWrittenOffId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (ProductWrittenOffId) => { 
    const updateUrl: string = '/prodWrittenOff/update/' + ProductWrittenOffId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (ProductWrittenOffId) => { 
    const deleteUrl: string = '/prodWrittenOff/delete/' + ProductWrittenOffId; 
    this.router.navigate([deleteUrl]); 
  }

}
