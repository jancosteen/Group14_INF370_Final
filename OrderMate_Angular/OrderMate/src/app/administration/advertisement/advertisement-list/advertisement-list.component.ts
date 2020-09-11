import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from '../../../shared/services/repository.service';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {Advertisement} from '../../../_interfaces/Administration/Advertisements/advertisement.model';

@Component({
  selector: 'app-advertisement-list',
  templateUrl: './advertisement-list.component.html',
  styleUrls: ['./advertisement-list.component.css']
})
export class AdvertisementListComponent implements OnDestroy, OnInit {

  public advertisement: Advertisement[];
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
        let apiAddress: string = "api/advertisement";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.advertisement = res as Advertisement[];
          
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



  public getDetailsPage = (advertisementId) => { 
      const detailsUrl: string = '/advertisement/details/' + advertisementId; 
      this.router.navigate([detailsUrl]); 
    }
    
    public redirectToUpdatePage = (advertisementId) => { 
      const updateUrl: string = '/advertisement/update/' + advertisementId; 
      this.router.navigate([updateUrl]); 
    }
  
    public redirectToDeletePage = (advertisementId) => { 
      const deleteUrl: string = '/advertisement/delete/' + advertisementId; 
      this.router.navigate([deleteUrl]);  
    }

}
