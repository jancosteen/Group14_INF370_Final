import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from '../../../shared/services/repository.service';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {Restaurant} from '../../../_interfaces/Administration/Restaurant/restaurant.model';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.css']
})
export class RestaurantListComponent implements OnDestroy, OnInit {

  public restaurant: Restaurant[];
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
        let apiAddress: string = "api/restaurant";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.restaurant = res as Restaurant[];
          
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


    public getDetailsPage = (restaurantId) => { 
      const detailsUrl: string = '/restaurant/details/' + restaurantId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (restaurantId) => { 
      const updateUrl: string = '/restaurant/update/' + restaurantId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (restaurantId) => { 
      const deleteUrl: string = '/restaurant/delete/' + restaurantId; 
      this.router.navigate([deleteUrl]);  
    }

}
