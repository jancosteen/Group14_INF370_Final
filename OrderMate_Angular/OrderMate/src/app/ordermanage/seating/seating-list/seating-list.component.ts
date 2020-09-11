import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs'; 

import {Seating} from  '../../../_interfaces/Order/Seating/seating.model'

@Component({
  selector: 'app-seating-list',
  templateUrl: './seating-list.component.html',
  styleUrls: ['./seating-list.component.css']
})
export class SeatingListComponent implements OnInit {

  public seating: Seating[];

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
        let apiAddress: string = "api/seating";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.seating = res as Seating[];
          
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

    public getDetailsPage = (seatingId) => { 
      const detailsUrl: string = '/seating/details/' + seatingId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (seatingId) => { 
      const updateUrl: string = '/seating/details/' + seatingId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (seatingId) => { 
      const deleteUrl: string = '/seating/details/' + seatingId; 
      this.router.navigate([deleteUrl]);  
    }

}
