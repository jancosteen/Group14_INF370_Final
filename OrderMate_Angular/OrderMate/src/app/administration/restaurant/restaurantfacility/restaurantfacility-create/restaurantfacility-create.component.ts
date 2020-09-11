import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateRestaurantFacility} from 'src/app/_interfaces/Administration/restaurantfacility/restaurantfacilitycreate.model';


@Component({
  selector: 'app-restaurantfacility-create',
  templateUrl: './restaurantfacility-create.component.html',
  styleUrls: ['./restaurantfacility-create.component.css']
})
export class RestaurantfacilityCreateComponent implements OnInit {

  public errorMessage: string = '';
 
  public restaurantfacilityForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

 ngOnInit(): void {

   this.restaurantfacilityForm = new FormGroup({
    restaurantFacility: new FormControl('',[Validators.required, Validators.maxLength(50)])
   });

 }

 public validateControl = (controlName: string) => {
   if (this.restaurantfacilityForm.controls[controlName].invalid && this.restaurantfacilityForm.controls[controlName].touched)
     return true;

   return false;
 }

 public hasError = (controlName: string, errorName: string) => {
   if (this.restaurantfacilityForm.controls[controlName].hasError(errorName))
     return true;

   return false;
 }

 public createRestaurantFacility = (RestaurantFacilityValue) => {
  if (this.restaurantfacilityForm.valid) {
    this.executeRestaurantFacilityCreation(RestaurantFacilityValue);
  }
}
private executeRestaurantFacilityCreation = (RestaurantFacilityValue) => {

  const restaurantfacility: CreateRestaurantFacility = {
    restaurantFacility: RestaurantFacilityValue.restaurantFacility
  
  }

  const apiUrl = 'api/restaurantfacility';
  this.repository.create(apiUrl, restaurantfacility)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  )
}



public redirectTorestaurantfacilityList(){
  this.router.navigate(['/restaurantfacility/list']);
}

}
