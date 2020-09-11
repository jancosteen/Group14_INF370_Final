import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 


import {User} from '../../../_interfaces/UserManage/User/user.model';
import { Reservation} from '../../../_interfaces/Reservationmanage/Reservation/reservation.model';
import {ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model';

@Component({
  selector: 'app-reservation-update',
  templateUrl: './reservation-update.component.html',
  styleUrls: ['./reservation-update.component.css']
}) 
export class ReservationUpdateComponent implements OnInit {
  public users: User[];
  public populate: User[];
  public errorMessage: string = '';
 
  public reservationForm: FormGroup;

  public reservation: Reservation;
  public statuses: ReservationStatus[];
  public x : number;
  public userId : string;
  selected: User;
  selectedStatus: ReservationStatus;
  reserve: Reservation;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.reservationForm = new FormGroup({
      reservationId: new FormControl(''),
      reservationDateCreated: new FormControl('',[Validators.required]),
      reservationDateReserved: new FormControl('',[Validators.required]),
      reservationPartyQty: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      reservationStatusName: new FormControl('',[Validators.required, Validators.maxLength(100)]),
      reservationNumberOfBills: new FormControl('',[Validators.required, Validators.maxLength(100)]),
     
  
    });

    
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/reservation/'+id;
    
    this.repository.getData(apiUrl)
    .subscribe(res => {
      //fetch the vihicle
      this.reservation = res as Reservation; 
      this.x = this.reservation.reservationStatusIdFk;
      this.userId = this.reservation.userIdFk;
      let apiAddress: string = "api/reservationstatus";
      this.repository.getData(apiAddress)
      .subscribe(res => { 
        //fetch the status
        this.statuses = res as ReservationStatus[];
        //foreach vehicle check where id vehicle == id status if true give vehicle status name = status
        this.statuses.forEach((status)=>{
          if(status.reservationStatusId == this.x){
            this.reserve = this.reservation;
            this.reserve.reservationStatusName = status.reservationStatus1;
            this.reservationForm.patchValue(this.reserve);
          } 
        }
        )
      });

      console.log('skedo',this.statuses)
      })
      
    ,
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    }
  }


  getUsers(){
    let apiAddress: string = "api/user";
      this.repository.getData(apiAddress)
      .subscribe(res => { 
        this.users = res as User[];
      });
  }


  getStatus(){
    let apiAddress: string = "api/reservationstatus";
      this.repository.getData(apiAddress)
      .subscribe(res => { 
        this.statuses = res as ReservationStatus[];
      });
  }

  public validateControl = (controlName: string) => {
    if (this.reservationForm.controls[controlName].invalid && this.reservationForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.reservationForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public update = (FormValue) => {
    if (this.reservationForm.valid) {
      this.executeUpdate(FormValue);
    }
  }
 
  private executeUpdate = (FormValue) => {

    let status : number;

    this.statuses.forEach(x=>{
      if(FormValue.reservationStatusName == x.reservationStatus1){ 
        status = x.reservationStatusId
      }
    })
    console.log('status', status)
    let id: string = this.activeRoute.snapshot.params['id'];
    this.reservation.reservationId =  FormValue.reservationId,
    this.reservation.reservationDateCreated = FormValue.reservationDateCreated,
    this.reservation.reservationDateReserved = FormValue.reservationDateReserved,
    this.reservation.reservationPartyQty = FormValue.reservationPartyQty,
    this.reservation.reservationStatusIdFk = status,
    this.reservation.reservationNumberOfBills = FormValue.reservationNumberOfBills
    console.log('id:',this.userId)
    this.reservation.userIdFk = this.userId
  
    
   
    let apiUrl = 'api/reservation/' + this.reservation.reservationId;
    this.repository.update(apiUrl, this.reservation)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }

  public redirectToList(){
    this.router.navigate(['/reservationmanage']);
  }

}
