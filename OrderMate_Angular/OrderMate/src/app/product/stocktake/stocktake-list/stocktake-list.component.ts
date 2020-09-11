import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import { StockTake} from 'src/app/_interfaces/Product/StockTake/stocktake.model'; 


@Component({
  selector: 'app-stocktake-list',
  templateUrl: './stocktake-list.component.html',
  styleUrls: ['./stocktake-list.component.css']
})
export class StocktakeListComponent implements OnDestroy, OnInit {
  public errorMessage: string = '';
 
  public Stocktakes: StockTake[];
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
        let apiAddress: string = "api/stocktake";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.Stocktakes = res as StockTake[];
          
          this.dtTrigger.next();
        },
        (error) =>{
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
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

    public getDetailsPage = (stocktakeId) => { 
      const detailsUrl: string = '/stocktake/details/' + stocktakeId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (stocktakeId) => { 
      const updateUrl: string = '/stocktake/update/' + stocktakeId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (stocktakeId) => { 
      const deleteUrl: string = '/stocktake/delete/' + stocktakeId; 
      this.router.navigate([deleteUrl]); 
    }



}
