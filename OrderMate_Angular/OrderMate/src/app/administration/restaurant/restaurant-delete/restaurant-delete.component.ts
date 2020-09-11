import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 
 

import { Restaurant } from '../../../_interfaces/Administration/Restaurant/restaurant.model'

@Component({
  selector: 'app-restaurant-delete',
  templateUrl: './restaurant-delete.component.html', 
  styleUrls: ['./restaurant-delete.component.css']
})
export class RestaurantDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public restaurant: Restaurant; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getRestaurantDetails(); 
    }

    getRestaurantDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
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


    public deleteRestaurant = () => {
      const deleteUrl: string = 'api/restaurant/' + this.restaurant.restaurantId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public redirectToRestaurantList(){
      this.router.navigate(['/restaurant/list']);
    }

}
