import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from '../../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 
 

import {RestaurantFacility} from 'src/app/_interfaces/Administration/RestaurantFacility/restaurantfacility.model';
 
@Component({
  selector: 'app-restaurantfacility-delete',
  templateUrl: './restaurantfacility-delete.component.html',
  styleUrls: ['./restaurantfacility-delete.component.css']
})
export class RestaurantfacilityDeleteComponent implements OnInit {
  public errorMessage: string = '';
  public restaurantFacility: RestaurantFacility; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getRestaurantFacilityDetails(); 
    }

    getRestaurantFacilityDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/restaurantfacility/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.restaurantFacility = res as RestaurantFacility;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }

    public deleterestaurantFacility = () => {
      const deleteUrl: string = 'api/restaurantfacility/' + this.restaurantFacility.restaurantFacilityId ;

      this.repository.delete(deleteUrl)
        .subscribe(res => {
   
          $('#successModal').modal();
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
    }

    public redirectTorestaurantFacilityList(){
      this.router.navigate(['/restaurantfacility/list']);
    }

}
