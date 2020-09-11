import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {Reservation} from '../../../_interfaces/Reservationmanage/Reservation/reservation.model'
import {ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model';

@Component({
  selector: 'app-reservation-delete',
  templateUrl: './reservation-delete.component.html',
  styleUrls: ['./reservation-delete.component.css']
})
export class ReservationDeleteComponent implements OnInit {

  public reservation: Reservation;
  public errorMessage: string = '';
  public statuses: ReservationStatus[];
  public x : number;
reserve: Reservation;


  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

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


    public delete = () => {
      const deleteUrl: string = 'api/reservation/' + this.reservation.reservationId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public redirectToList(){
      this.router.navigate(['/reservationmanage']);
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
