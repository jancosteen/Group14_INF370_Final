import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from './../../services/authentication.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { CreateUser } from 'src/app/_interfaces/ForCreation/createUser.model';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from 'src/app/_interfaces/ForCreation/user.model';
import { LoaderService } from 'src/app/shared/services/loader.service';
import { NavController } from '@ionic/angular';
import { FullUser } from 'src/app/_interfaces/fullUser.model';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.page.html',
  styleUrls: ['./dashboard.page.scss'],
})
export class DashboardPage implements OnInit {
  userToken:User;
  user;
  token;
  loggedInUser;
  public errorMessage: string = '';

  constructor(private authService: AuthenticationService, private repository: RepositoryService
    ,private loader: LoaderService
    ,private nav: NavController
    ,private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getUserTokenDetails();
    this.getUserDetails();
  }

  logout() {
    this.authService.logout();
  }

  getUserTokenDetails(){
    this.token = localStorage.getItem('token');
    
    const helper= new JwtHelperService();
    this.userToken = helper.decodeToken(this.token) as User;   
    
    //api call    
    let apiUrl: string = `api/user/profile/${this.userToken.userName}`;
    
    this.repository.getData(apiUrl)
      .subscribe(res=>{               
        this.user = res as User;                
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
      
  }

  toReservationPage(){
    localStorage.removeItem('restaurantName');
    localStorage.removeItem('restaurantId');
    this.nav.navigateRoot('members/reservation-list');
  }

  toCheckInPage(){
    this.nav.navigateRoot('qr-scanner');
  }

  toCurrentOrders(){
    this.nav.navigateRoot('members/my-orders');
  }

  getUserDetails(){
    let apiUrl: string = `api/user/detail/${this.userToken.userName}`;
    
    this.repository.getData(apiUrl)
      .subscribe(res=>{        
        this.loggedInUser = res as FullUser;
        localStorage.setItem('userId',this.loggedInUser.id);
        console.log(this.loggedInUser.id);
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })   
  }


}
