import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from '../../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';


import {RestaurantFacility} from 'src/app/_interfaces/Administration/RestaurantFacility/restaurantfacility.model';


@Component({
  selector: 'app-restaurantfacility-list',
  templateUrl: './restaurantfacility-list.component.html', 
  styleUrls: ['./restaurantfacility-list.component.css']
})
export class RestaurantfacilityListComponent implements OnDestroy, OnInit {
  public restaurantFacility: RestaurantFacility[];
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
        let apiAddress: string = "api/restaurantfacility";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.restaurantFacility = res as RestaurantFacility[];
          
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


    public getDetailsPage = (restaurantFacilityId) => { 
      const detailsUrl: string = '/restaurantfacility/details/' + restaurantFacilityId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (restaurantFacilityId) => { 
      const updateUrl: string = '/restaurantfacility/update/' + restaurantFacilityId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (restaurantFacilityId) => { 
      const deleteUrl: string = '/restaurantfacility/delete/' + restaurantFacilityId; 
      this.router.navigate([deleteUrl]);  
    }

}
