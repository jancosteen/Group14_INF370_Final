import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import { Restaurant } from '../../../_interfaces/Administration/Restaurant/restaurant.model';

@Component({
  selector: 'app-restaurant-details',
  templateUrl: './restaurant-details.component.html',
  styleUrls: ['./restaurant-details.component.css']
})
export class RestaurantDetailsComponent implements OnInit { 

  public restaurant: Restaurant;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getRestaurantDetails();
  }

  getRestaurantDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/restaurant/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.restaurant = res as Restaurant;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (restaurantId) => { 
    const updateUrl: string = '/restaurant/update/' + restaurantId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (restaurantId) => { 
    const deleteUrl: string = '/restaurant/delete/' + restaurantId; 
    this.router.navigate([deleteUrl]); 
  }

}
