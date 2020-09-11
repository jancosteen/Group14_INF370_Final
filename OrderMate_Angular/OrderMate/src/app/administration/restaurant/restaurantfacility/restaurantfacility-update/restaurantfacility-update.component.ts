import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {RestaurantFacility} from 'src/app/_interfaces/Administration/RestaurantFacility/restaurantfacility.model';


@Component({
  selector: 'app-restaurantfacility-update',
  templateUrl: './restaurantfacility-update.component.html',
  styleUrls: ['./restaurantfacility-update.component.css']
})
export class RestaurantfacilityUpdateComponent implements OnInit {public errorMessage: string = '';
 
public restaurantfacilityForm: FormGroup; 
public restaurantFacility: RestaurantFacility;

constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
  private activeRoute: ActivatedRoute) { }

ngOnInit(): void {
  this.restaurantfacilityForm = new FormGroup({
    restaurantFacilityId: new FormControl(''),
    restaurantFacility: new FormControl('',[Validators.required, Validators.maxLength(50)]),
  });

  this.getrestaurantFacilityById();
}

private getrestaurantFacilityById = () => {
  let restaurantFacilityId: string = this.activeRoute.snapshot.params['id'];
    
  let restaurantFacilityIdByIdUrl: string = 'api/restaurantfacility/'+restaurantFacilityId;
 
  this.repository.getData(restaurantFacilityIdByIdUrl)
    .subscribe(res => {
      this.restaurantFacility = res as RestaurantFacility;
   
      this.restaurantfacilityForm.patchValue(this.restaurantFacility); 

    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
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

public redirectTorestaurantfacilityList(){
  this.router.navigate(['/restaurantfacility/list']);
}


public updaterestaurantfacility = (restaurantfacilityFormValue) => {
  if (this.restaurantfacilityForm.valid) {
    this.executerestaurantfacilityUpdate(restaurantfacilityFormValue);
  }
}

private executerestaurantfacilityUpdate = (restaurantfacilityFormValue) => {

  this.restaurantFacility.restaurantFacilityId =  restaurantfacilityFormValue.restaurantFacilityId,
  this.restaurantFacility.restaurantFacility = restaurantfacilityFormValue.restaurantFacility
  
 
  let apiUrl = 'api/restaurantfacility/' + this.restaurantFacility.restaurantFacilityId;
  this.repository.update(apiUrl, this.restaurantFacility)
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
