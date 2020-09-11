import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  
 
import {RestaurantStatus} from 'src/app/_interfaces/Administration/RestaurantStatus/restaurantstatus.model';


@Component({
  selector: 'app-restaurantstatus-update',
  templateUrl: './restaurantstatus-update.component.html',
  styleUrls: ['./restaurantstatus-update.component.css']
})
export class RestaurantstatusUpdateComponent implements OnInit {
  public errorMessage: string = '';
 
  public restaurantstatusForm: FormGroup; 
  public restaurantStatus: RestaurantStatus;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.restaurantstatusForm = new FormGroup({
      restaurantstatusId: new FormControl(''),
      restaurantstatus: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    });

    this.getrestaurantstatusById();
  }

  private getrestaurantstatusById = () => {
    let restaurantstatusId: string = this.activeRoute.snapshot.params['id'];
      
    let restaurantstatusIdByIdUrl: string = 'api/restaurantstatus/'+restaurantstatusId;
   
    this.repository.getData(restaurantstatusIdByIdUrl)
      .subscribe(res => {
        this.restaurantStatus = res as RestaurantStatus;
     
        this.restaurantstatusForm.patchValue(this.restaurantStatus);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
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

  public redirectTorestaurantstatusList(){
    this.router.navigate(['/restaurantstatus/list']);
  }


  public updaterestaurantstatus = (restaurantstatusFormValue) => {
    if (this.restaurantstatusForm.valid) {
      this.executerestaurantstatusUpdate(restaurantstatusFormValue);
    }
  }

  private executerestaurantstatusUpdate = (restaurantstatusFormValue) => {
  
    this.restaurantStatus.restaurantstatusId =  restaurantstatusFormValue.restaurantstatusId,
    this.restaurantStatus.restaurantStatus = restaurantstatusFormValue.restaurantStatus
    
   
    let apiUrl = 'api/restaurantstatus/' + this.restaurantStatus.restaurantstatusId;
    this.repository.update(apiUrl, this.restaurantStatus)
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
