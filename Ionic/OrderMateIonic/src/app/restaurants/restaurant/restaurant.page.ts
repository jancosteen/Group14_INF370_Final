import { Component, OnInit } from '@angular/core';
import {AuthenticationService} from './../../services/authentication.service';
import { Restaurant } from 'src/app/_interfaces/restaurant.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { ActivatedRoute } from '@angular/router';
import { NavController } from '@ionic/angular';
import { LoaderService } from 'src/app/shared/services/loader.service';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';

@Component({
  selector: 'app-restaurant',
  templateUrl: './restaurant.page.html',
  styleUrls: ['./restaurant.page.scss'],
})
export class RestaurantPage implements OnInit {
  public restaurant: Restaurant;
  restaurantId;
  resName;
  public errorMessage: string = '';

  constructor(private authService: AuthenticationService, private repository: RepositoryService
              , private activeRoute: ActivatedRoute, 
              private nav: NavController, private ionLoader: LoaderService
              ,private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
    this.getRestaurantDetails();
  }

  logout() {
    this.authService.logout();
  }

  showLoader() {
    this.ionLoader.showLoader();

    setTimeout(() => {
      this.hideLoader();
    }, 2000);
  }

  hideLoader() {
    this.ionLoader.hideLoader();
  }

  getRestaurantDetails(){
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiUrl: string = `api/restaurantr/${id}`
    this.showLoader();
    this.repository.getData(apiUrl)
      .subscribe(res=>{
        this.hideLoader();
        this.restaurant = res as Restaurant;        
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  viewMenu(resId){
    const detailsUrl: string =`menu/${resId}`;
    this.nav.navigateRoot(detailsUrl);
  }

  toReservationPage(resId, restaurantName){
    this.restaurantId = localStorage.setItem('restaurantId',resId);
    this.resName = localStorage.setItem('restaurantName', restaurantName)
    this.nav.navigateRoot('members/create-reservation')
  }

}
