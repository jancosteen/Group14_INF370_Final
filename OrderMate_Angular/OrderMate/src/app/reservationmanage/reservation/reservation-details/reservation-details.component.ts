import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model';
import { Reservation} from '../../../_interfaces/Reservationmanage/Reservation/reservation.model';

@Component({  
  selector: 'app-reservation-details',
  templateUrl: './reservation-details.component.html',
  styleUrls: ['./reservation-details.component.css']
})
export class ReservationDetailsComponent implements OnInit { 

  public reservation: Reservation;
  public errorMessage: string = '';
  public statuses: ReservationStatus[];
  public x : number;
reserve: Reservation;
  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getStatus();
    this.getDetails();
    
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/reservation/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.reservation = res as Reservation;
      this.x = this.reservation.reservationStatusIdFk;
      this.statuses.forEach(status=>{
        if(status.reservationStatusId == this.x){
          this.reserve = this.reservation
          this.reserve.reservationStatusName = status.reservationStatus1
        } 
      })
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (reservationId) => { 
    const updateUrl: string = '/reservation/update/' + reservationId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (reservationId) => { 
    const deleteUrl: string = '/reservation/delete/' + reservationId; 
    this.router.navigate([deleteUrl]); 
  }

  getStatus(){
    console.log('cc',this.x)
    let apiAddress: string = "api/reservationstatus";
      this.repository.getData(apiAddress)
      .subscribe(res => { 
        this.statuses = res as ReservationStatus[];
      });
  }

}
