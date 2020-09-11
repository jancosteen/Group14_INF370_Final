import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';   

import {Restaurant} from '../../../_interfaces/Administration/Restaurant/restaurant.model';

@Component({
  selector: 'app-restaurant-update',
  templateUrl: './restaurant-update.component.html',
  styleUrls: ['./restaurant-update.component.css']
})
export class RestaurantUpdateComponent implements OnInit {

  public errorMessage: string = '';

  public restaurantForm: FormGroup; 
public restaurant: Restaurant;

constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
  private activeRoute: ActivatedRoute) { }

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

  this.getrestaurantById();
}

private getrestaurantById = () => {
  let restaurantId: string = this.activeRoute.snapshot.params['id'];
    
  let restaurantIdByIdUrl: string = 'api/restaurant/'+restaurantId;
 
  this.repository.getData(restaurantIdByIdUrl)
    .subscribe(res => {
      this.restaurant = res as Restaurant;
   
      this.restaurantForm.patchValue(this.restaurant); 

    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
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


public redirectToList(){
  this.router.navigate(['/restaurant/list']);
}


public updaterestaurant = (restaurantFormValue) => {
  if (this.restaurantForm.valid) {
    this.executerestaurantUpdate(restaurantFormValue);
  }
}


private executerestaurantUpdate = (restaurantFormValue) => {
  this.restaurant.restaurantId =  restaurantFormValue.restaurantId,
  this.restaurant.restaurantUrl = restaurantFormValue.restaurantUrl,
  this.restaurant.restaurantDescription = restaurantFormValue.restaurantDescription,
  this.restaurant.restaurantCoordinates = restaurantFormValue.restaurantCoordinates,
  this.restaurant.restaurantDateCreated = restaurantFormValue.restaurantDateCreated,
  this.restaurant.restaurantAddressLine1 = restaurantFormValue.restaurantAddressLine1,
  this.restaurant.restaurantAddressLine2 = restaurantFormValue.restaurantAddressLine2,
  this.restaurant.restaurantAddressLine3 = restaurantFormValue.restaurantAddressLine3,
  this.restaurant.restaurantCity = restaurantFormValue.restaurantCity,
  this.restaurant.restaurantPostalCode = restaurantFormValue.restaurantPostalCode,
  this.restaurant.restaurantCountry = restaurantFormValue.restaurantCountry,
  this.restaurant.restaurantStatus = restaurantFormValue.restaurantStatus

 
  let apiUrl = 'api/restaurant/' + this.restaurant.restaurantId;
  this.repository.update(apiUrl, this.restaurant)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error => {
      this.errorHandler.handleError(error); 
      this.errorMessage = this.errorHandler.errorMessage;
    })
  )
} 

}
