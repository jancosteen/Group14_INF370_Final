import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {OrderLine} from '../../../_interfaces/Order/Orderline/orderline.model'

@Component({
  selector: 'app-orderline-list',
  templateUrl: './orderline-list.component.html',
  styleUrls: ['./orderline-list.component.css']
})
export class OrderlineListComponent implements OnInit, OnDestroy {

  public orderline: OrderLine[];

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
        let apiAddress: string = "api/orderline";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.orderline = res as OrderLine[];
          
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

    public getDetails = (orderlineId) => { 
      const detailsUrl: string = '/orderline/details/' + orderlineId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (orderlineId) => { 
      const updateUrl: string = '/orderline/details/' + orderlineId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (orderlineId) => { 
      const deleteUrl: string = '/orderline/details/' + orderlineId; 
      this.router.navigate([deleteUrl]);  
    }

}
