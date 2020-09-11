import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateRestaurantStatus} from 'src/app/_interfaces/Administration/RestaurantStatus/restaurantstatuscreate.model';


@Component({
  selector: 'app-restaurantstatus-create',
  templateUrl: './restaurantstatus-create.component.html',
  styleUrls: ['./restaurantstatus-create.component.css']
})
export class RestaurantstatusCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public restaurantstatusForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

 ngOnInit(): void {

   this.restaurantstatusForm = new FormGroup({
    restaurantstatus: new FormControl('',[Validators.required, Validators.maxLength(50)])
   });

 }

 public validateControl = (controlName: string) => {
   if (this.restaurantstatusForm.controls[controlName].invalid && this.restaurantstatusForm.controls[controlName].touched)
     return true;

   return false;
 }

 public hasError = (controlName: string, errorName: string) => {
   if (this.restaurantstatusForm.controls[controlName].hasError(errorName))
     return true;

   return false;
 }

 public createRestaurantStatus = (RestaurantStatusValue) => {
  if (this.restaurantstatusForm.valid) {
    this.executeRestaurantStatusCreation(RestaurantStatusValue);
  }
}
private executeRestaurantStatusCreation = (RestaurantStatusValue) => {

  const restaurantstatus: CreateRestaurantStatus = {
    restaurantStatus : RestaurantStatusValue.restaurantStatus
  }

  const apiUrl = 'api/restaurantstatus';
  this.repository.create(apiUrl, restaurantstatus)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  )
}



public redirectTorestaurantstatusList(){
  this.router.navigate(['/restaurantstatus/list']);
}

}
