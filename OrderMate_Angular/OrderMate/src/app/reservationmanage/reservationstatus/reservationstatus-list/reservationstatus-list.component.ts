import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs'; 

import {ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model'

@Component({
  selector: 'app-reservationstatus-list',
  templateUrl: './reservationstatus-list.component.html',
  styleUrls: ['./reservationstatus-list.component.css']
})
export class ReservationstatusListComponent implements OnInit, OnDestroy {

  public reservationStatus: ReservationStatus[];

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
        let apiAddress: string = "api/reservationstatus";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.reservationStatus = res as ReservationStatus[];
          
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


  public getDetails = (reservationStatusId) => { 
    const detailsUrl: string = '/reservationstatus/details/' + reservationStatusId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (reservationStatusId) => { 
    const updateUrl: string = '/reservationstatus/details/' + reservationStatusId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (reservationStatusId) => { 
    const deleteUrl: string = '/reservationstatus/details/' + reservationStatusId; 
    this.router.navigate([deleteUrl]);  
  }

}
