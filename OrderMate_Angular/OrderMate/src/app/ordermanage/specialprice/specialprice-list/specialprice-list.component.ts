import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {SpecialPrice} from 'src/app/_interfaces/Order/SpecialPrice/specialprice.model';


@Component({
  selector: 'app-specialprice-list',
  templateUrl: './specialprice-list.component.html',
  styleUrls: ['./specialprice-list.component.css']
})
export class SpecialpriceListComponent implements OnInit {
  public specialPrices: SpecialPrice[];
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
      let apiAddress: string = "api/specialprice";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.specialPrices = res as SpecialPrice[];
        
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




  public getDetailsPage = (specialPriceId) => { 
    const detailsUrl: string = '/specialprice/details/' + specialPriceId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (specialPriceId) => { 
    const updateUrl: string = '/specialprice/update/' + specialPriceId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (specialPriceId) => { 
    const deleteUrl: string = '/specialprice/delete/' + specialPriceId; 
    this.router.navigate([deleteUrl]); 
  }
}
