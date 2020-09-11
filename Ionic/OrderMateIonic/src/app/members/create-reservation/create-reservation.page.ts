import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { Restaurant } from 'src/app/_interfaces/restaurant.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from 'src/app/_interfaces/ForCreation/user.model';
import { CreateUser } from 'src/app/_interfaces/ForCreation/createUser.model';
import { reservationForCreation } from 'src/app/_interfaces/ForCreation/reservationForCreation.model';
import { formatDate } from '@angular/common';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
//import { MatDatePicker} from '@angular/material/datepicker';


@Component({
  selector: 'app-create-reservation',
  templateUrl: './create-reservation.page.html',
  styleUrls: ['./create-reservation.page.scss'],
})
export class CreateReservationPage implements OnInit {

  reservationDetails:reservationForCreation;
  userToken:User;
  user;
  token;
  loggedInUser;
  reservationForm:FormGroup;
  restaurants: Restaurant[];
  currentDate: string;
  correctDateTime:string;
  dateTime:string;
  nrOfBills:string;
  partyQty:string;
  resId;
  resIdFlg : boolean = false;
  resName;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private fb:FormBuilder,
    private authService: AuthenticationService
    ,private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getAllRestaurants();
    this.checkRestaurantId();
    this.currentDate = formatDate(new Date(), 'yyyy-MM-dd', 'en');

    this.reservationForm = this.fb.group({
      restaurantId: new FormControl('',[Validators.required]),
      dateTime:  new FormControl('', [Validators.required]),
      partyAmount: new FormControl('',[Validators.required]),
      bills: new FormControl('',[Validators.required])     
    });
  }

  getAllRestaurants = () =>{
    let apiAddress: string = "api/restaurantr";
    //this.showLoader();
    this.repository.getData(apiAddress)
      .subscribe(res => {
        this.restaurants = res as Restaurant[];
        //this.hideLoader();
      })
  }

  logout() {
    this.authService.logout();
  }

  createReservation(reservationFormValue){
    this.dateTime = reservationFormValue.dateTime;
    this.correctDateTime = this.dateTime+":00.00";
    this.partyQty = reservationFormValue.partyAmount;
    this.nrOfBills = reservationFormValue.bills;
    const createReservation:reservationForCreation ={
      reservationDateCreated: this.currentDate,
      reservationDateReserved: this.correctDateTime,
      userIdFk: localStorage.getItem('userId'),
      reservationStatusIdFk: 1,
      reservationNumberOfBills: `${this.nrOfBills}`,
      reservationPartyQty: `${this.partyQty}`
    };

    console.log(createReservation);
    
    const apiUrl ='api/reservation';
    this.repository.create(apiUrl,createReservation)
      .subscribe(res=>{
        console.log(res);
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  checkRestaurantId(){
    this.resId = localStorage.getItem('restaurantId');
    if(this.resId === null){
      this.resIdFlg = false;
    }else{
      this.resIdFlg = true
      this.resName = localStorage.getItem('restaurantName');
    }
  }

  getUserDetails(){
    let apiUrl: string = `api/user/detail/${this.userToken.userName}`;
    
    this.repository.getData(apiUrl)
      .subscribe(res=>{        
        this.loggedInUser = res as CreateUser;
               
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })    
  }

}
