import { Component, OnInit, ViewChild } from '@angular/core';
import {RepositoryService} from './../../../shared/services/repository.service';
import {Restaurant} from '../../../_interfaces/restaurant.model';
import {AuthenticationService} from '../../../services/authentication.service';
import {LoaderService} from './../../../shared/services/loader.service';
import {NavController, IonInfiniteScroll} from '@ionic/angular';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.page.html',
  styleUrls: ['./restaurant-list.page.scss'],
})
export class RestaurantListPage implements OnInit {
  //Infinite Scroll
  @ViewChild(IonInfiniteScroll) infiniteScroll: IonInfiniteScroll;
  public restaurants: Restaurant[];
  lastId: number = null; //Keep track of last restarant Id
  public errorMessage: string = '';

  constructor(public nav: NavController, private repository: RepositoryService,
     private authService:AuthenticationService,
      private ionLoader: LoaderService, private errorHandler: ErrorHandlerService ) { }

  ngOnInit() {
    this.getAllRestaurants();
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

  getAllRestaurants = () =>{
    let apiAddress: string = "api/restaurantr";
    this.showLoader();
    this.repository.getData(apiAddress)
      .subscribe(res => {
        this.restaurants = res as Restaurant[];
        this.hideLoader();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  viewRestaurant(restaurantId){
    const detailsUrl: string =`/restaurant/${restaurantId}`;
    this.nav.navigateRoot(detailsUrl);
  }

  logout(){
    this.authService.logout()
  }

}
