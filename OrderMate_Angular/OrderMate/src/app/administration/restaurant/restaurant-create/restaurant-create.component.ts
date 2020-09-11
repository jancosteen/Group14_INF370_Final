import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateRestaurant} from '../../../_interfaces/Administration/Restaurant/restaurantcreate.model'

@Component({
  selector: 'app-restaurant-create',
  templateUrl: './restaurant-create.component.html',
  styleUrls: ['./restaurant-create.component.css']
})
export class RestaurantCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public restaurantForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

 ngOnInit(): void {

   this.restaurantForm = new FormGroup({
    restaurantId: new FormControl(''),
    restaurantUrl: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantDescription: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantCoordinates: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantDateCreated: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantAddressLine1: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantAddressLine2: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantAddressLine3: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantCity: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantPostalCode: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantCountry: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    restaurantStatus: new FormControl('',[Validators.required, Validators.maxLength(50)]),
   });


  }


   public validateControl = (controlName: string) => {
    if (this.restaurantForm.controls[controlName].invalid && this.restaurantForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.restaurantForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public createRestaurant = (RestaurantValue) => {
    if (this.restaurantForm.valid) {
      this.executeRestaurantCreation(RestaurantValue);
    }
  }
  private executeRestaurantCreation = (RestaurantValue) => {
  
    const restaurant: CreateRestaurant = {
      restaurantId: RestaurantValue.restaurantId,
      restaurantUrl: RestaurantValue.restaurantUrl,
      restaurantDescription: RestaurantValue.restaurantDescription,
      restaurantCoordinates: RestaurantValue.restaurantCoordinates,
      restaurantDateCreated: RestaurantValue.restaurantDateCreated,
      restaurantAddressLine1: RestaurantValue.restaurantAddressLine1,
      restaurantAddressLine2: RestaurantValue.restaurantAddressLine2,
      restaurantAddressLine3: RestaurantValue.restaurantAddressLine3,
      restaurantCity: RestaurantValue.restaurantCity,
      restaurantPostalCode: RestaurantValue.restaurantPostalCode,
      restaurantCountry: RestaurantValue.restaurantCountry,
      restaurantProvince: RestaurantValue.restaurantProvince,
      restaurantStatus: RestaurantValue.restaurantStatus,
    }
  
    const apiUrl = 'api/restaurant';
    this.repository.create(apiUrl, restaurant)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }
  
  
  
  public redirectTorestaurantList(){
    this.router.navigate(['/restaurant/list']);
  }
  

 } 

 

