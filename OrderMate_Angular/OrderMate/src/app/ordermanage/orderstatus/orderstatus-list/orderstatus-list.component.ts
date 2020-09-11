import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {OrderStatus} from '../../../_interfaces/Order/OrderStatus/orderstatus.model'

@Component({
  selector: 'app-orderstatus-list',
  templateUrl: './orderstatus-list.component.html',
  styleUrls: ['./orderstatus-list.component.css'] 
})
export class OrderstatusListComponent implements OnInit, OnDestroy {

  public orderStatus: OrderStatus[];

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
        let apiAddress: string = "api/orderstatus";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.orderStatus = res as OrderStatus[];
          
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

    public getDetailsPage = (orderStatusId) => { 
      const detailsUrl: string = '/orderstatus/details/' + orderStatusId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (orderStatusId) => { 
      const updateUrl: string = '/orderstatus/details/' + orderStatusId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (orderStatusId) => { 
      const deleteUrl: string = '/orderstatus/details/' + orderStatusId; 
      this.router.navigate([deleteUrl]);  
    }

}
