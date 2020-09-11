import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateReservation} from '../../../_interfaces/Reservationmanage/Reservation/reservationcreate.model'
import {ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model';
import { isNumeric } from 'jquery';
import { User } from 'src/app/_interfaces/UserManage/User/user.model';

@Component({
  selector: 'app-reservation-create',
  templateUrl: './reservation-create.component.html',
  styleUrls: ['./reservation-create.component.css']
})
export class ReservationCreateComponent implements OnInit {
  public statuses: ReservationStatus[];
  public errorMessage: string = '';
  selectedStatus: ReservationStatus;
  selectedUser: User;
  public users: User[];
 
  public reservationForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

 ngOnInit(): void {
  this.getStatus();
  this.getUsers();
  

  this.reservationForm = new FormGroup({
    reservationDateReserved: new FormControl('',[Validators.required]),
    reservationPartyQty: new FormControl('',[Validators.required, Validators.maxLength(2)]),
    reservationStatusName: new FormControl('',[Validators.required]),
    reservationNumberOfBills: new FormControl('',[Validators.required, Validators.maxLength(2)]),
    user: new FormControl('',[Validators.required])

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

  getStatus(){
    let apiAddress: string = "api/reservationstatus";
      this.repository.getData(apiAddress)
      .subscribe(res => { 
        this.statuses = res as ReservationStatus[];
      });
  }

  getUsers(){
    let apiAddress: string = "api/user";
      this.repository.getData(apiAddress)
      .subscribe(res => { 
        this.users = res as User[];
        console.log('users', this.users) 
      });
  }



  public create = (Value) => {
    if (this.reservationForm.valid) {

      


      this.executeCreation(Value);
    }
  }

  private executeCreation = (Value) => {

    let [month, date, year]    = ( new Date() ).toLocaleDateString().split("/")
    if (month.length < 2) 
        month = '0' + month;
    if (date.length < 2) 
        date = '0' + date;
    var currentDate =  year + '-' + month +'-'+ date


    let d3: string = Value.reservationDateReserved;
    var reserveDate = d3.slice(0,4) +'-'+d3.slice(5,7)+ '-'+  d3.slice(8,10) ;
 

    let userId: string;
    let status: number;

    this.getUsers();

    for(let x of this.users){
      if(Value.user == x.userName )
      userId = x.id
    }
    console.log('userid',userId)
  
    console.log('stststs',this.users)
    for(let x of this.statuses){
      if(Value.reservationStatusName == x.reservationStatus1){
        status = x.reservationStatusId
      }
    }
    let qty:number;
    qty= Value.reservationPartyQty
    let qty2 = parseInt(Value.reservationPartyQty)
    console.log('qty', qty2)




  
  
    const reservation: CreateReservation = {

      reservationStatusName :Value.reservationStatusName,
      reservationDateCreated : currentDate,
      reservationDateReserved : reserveDate,
      reservationPartyQty : qty,
      reservationNumberOfBills : Value.reservationNumberOfBills,
      reservationStatusIdFk: status, 
      userIdFk: userId,
  
    }
    console.log("reservation", reservation)
  
    const apiUrl = 'api/reservation';
    this.repository.create(apiUrl, reservation)
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
    this.router.navigate(['/reservation/list']);
  }

}
