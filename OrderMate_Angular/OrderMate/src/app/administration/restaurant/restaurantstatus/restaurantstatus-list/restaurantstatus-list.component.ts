import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from '../../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {RestaurantStatus} from 'src/app/_interfaces/Administration/RestaurantStatus/restaurantstatus.model';

@Component({
  selector: 'app-restaurantstatus-list',
  templateUrl: './restaurantstatus-list.component.html',
  styleUrls: ['./restaurantstatus-list.component.css']
})
export class RestaurantstatusListComponent implements OnDestroy, OnInit {
  public restaurantstatus: RestaurantStatus[];
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
        let apiAddress: string = "api/restaurantstatus";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.restaurantstatus = res as RestaurantStatus[];
          
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


    public getDetailsPage = (restaurantstatusId) => { 
      const detailsUrl: string = '/restaurantstatus/details/' + restaurantstatusId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (restaurantstatusId) => { 
      const updateUrl: string = '/restaurantstatus/update/' + restaurantstatusId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (restaurantstatusId) => { 
      const deleteUrl: string = '/restaurantstatus/delete/' + restaurantstatusId; 
      this.router.navigate([deleteUrl]);  
    }

}
