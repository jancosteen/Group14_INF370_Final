import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
 

import {WrittenOffStock} from 'src/app/_interfaces/Product/writtenoffstock/writtenoffstock.model';


@Component({
  selector: 'app-writtenoffstock-list',
  templateUrl: './writtenoffstock-list.component.html',
  styleUrls: ['./writtenoffstock-list.component.css']
})
export class WrittenoffstockListComponent implements OnDestroy, OnInit {

  public WrittenOffStocks: WrittenOffStock[];
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
        let apiAddress: string = "api/writtenoffstock";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.WrittenOffStocks = res as WrittenOffStock[];
          
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








  public getDetailsPage = (WrittenOfStockId) => { 
    const detailsUrl: string = '/writtenoffstock/details/' + WrittenOfStockId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (WrittenOfStockId) => { 
    const updateUrl: string = '/writtenoffstock/update/' + WrittenOfStockId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (WrittenOfStockId) => { 
    const deleteUrl: string = '/writtenoffstock/delete/' + WrittenOfStockId; 
    this.router.navigate([deleteUrl]); 
  }
}
