import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { ErrorHandlerService } from '../shared/services/error-handler.service';
import { RepositoryService } from '../shared/services/repository.service';
import { Router } from '@angular/router'; 
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { Reservation } from '../_interfaces/Reservationmanage/Reservation/reservation.model';
import {ReservationStatus} from '../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model';
import { datepicker } from 'jquery';
import { ConvertActionBindingResult } from '@angular/compiler/src/compiler_util/expression_converter';

@Component({
  selector: 'app-reservationmanage',
  templateUrl: './reservationmanage.component.html',
  styleUrls: ['./reservationmanage.component.css']
})
export class ReservationmanageComponent implements OnInit {
  public reservations: Reservation[];
  public reservationsFromServer: Reservation[];
  public statuses: ReservationStatus[];
  selected: ReservationStatus;

  constructor(private repository :  RepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router) { }

  ngOnInit(): void {

    let apiAddress: string = "api/reservation";
    this.repository.getData(apiAddress)
      .subscribe(res => {
        this.reservationsFromServer = res as Reservation[];
        console.log('from serve', this.reservationsFromServer)
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
            this.reservations.push(resevation);
            console.log('reservations',this.reservations)
          }
        })
      });

          
        })
  
      });
   
  }

  getStatus(){
    let apiAddress: string = "api/reservationstatus";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.statuses = res as ReservationStatus[];
        
      });
  }

  goToReservation(id){
    const reservationUrl: string = '/reservation/details/' + id; 
    this.router.navigate([reservationUrl]); 
  }
 










}
