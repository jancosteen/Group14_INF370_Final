import { User } from './../../../_interfaces/UserManage/User/user.model';
import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router } from '@angular/router'; 
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model';
import {Reservation} from '../../../_interfaces/Reservationmanage/Reservation/reservation.model';

@Component({
  selector: 'app-reservation-list',
  templateUrl: './reservation-list.component.html',
  styleUrls: ['./reservation-list.component.css']
})
export class ReservationListComponent implements OnInit, OnDestroy {
  public users : User[];
  public reservationsFromServer: Reservation[];
  reservations:Reservation[];
  xreservations:Reservation[];
  public statuses: ReservationStatus[];

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
     

      let apiAddress: string = "api/reservation";
      this.repository.getData(apiAddress)
        .subscribe(res => {
          this.reservationsFromServer = res as Reservation[];

          //iterate through the list, for each statusId find match in status list and retrive status name
          this.reservations =[];
          this.reservationsFromServer.forEach(resevation=>{
            //formet date here
            //call method and pass reservation here
            let apiAddress: string = "api/reservationstatus";
              this.repository.getData(apiAddress)
                .subscribe(res => {
                  this.statuses = res as ReservationStatus[];
                  this.statuses.forEach(status=>{
                    if(resevation.reservationStatusIdFk == status.reservationStatusId){
                      //match found              
                     resevation.reservationStatusName = status.reservationStatus1;
     
                    }
                  })
            });
         
            let userAddress: string = "api/user";
              this.repository.getData(userAddress)
                .subscribe(res => {
                  this.users = res as User[];
                  this.users.forEach(user=>{
                    if(resevation.userIdFk == user.id){
                      resevation.userName = user.userName;
                      this.reservations.push(resevation);
                      console.log('users',this.reservations)
                    }
                  })
            });
            
         
          
            
        
            
          })

          this.dtTrigger.next();
            
        });


  

        //search list
        this.searchReservationList();

      
  
    } 

  private searchReservationList() {
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


  public getDetails = (reservationId) => { 
    const detailsUrl: string = '/reservation/details/' + reservationId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (reservationId) => { 
    const updateUrl: string = '/reservation/update/' + reservationId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (reservationId) => { 
    const deleteUrl: string = '/reservation/delete/' + reservationId; 
    this.router.navigate([deleteUrl]);  
  }

}
