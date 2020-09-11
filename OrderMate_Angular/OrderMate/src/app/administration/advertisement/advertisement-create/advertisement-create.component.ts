import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateAdvertisement} from '../../../_interfaces/Administration/Advertisements/advertisementcreate.model'

@Component({
  selector: 'app-advertisement-create',
  templateUrl: './advertisement-create.component.html',
  styleUrls: ['./advertisement-create.component.css']
})
export class AdvertisementCreateComponent implements OnInit {

  public errorMessage: string = '';
 
  public advertisementForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

 ngOnInit(): void {

   this.advertisementForm = new FormGroup({
    advertisementId: new FormControl(''),
    advertisementName: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    advertisementDescription: new FormControl('',[Validators.required, Validators.maxLength(50)]),
    advertisementFile: new FormControl('',[Validators.required, Validators.maxLength(50)])

   });


  }

  public validateControl = (controlName: string) => {
    if (this.advertisementForm.controls[controlName].invalid && this.advertisementForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.advertisementForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public create = (Value) => {
    if (this.advertisementForm.valid) {
      this.executeCreation(Value);
    }
  }
  private executeCreation = (Value) => {
  
    const advertisement: CreateAdvertisement = {
    //  advertisementId: RestaurantValue.advertisementId,
      advertisementName: Value.advertisementName,
      advertisementDescription: Value.advertisementDescription,
      advertisementFile: Value.advertisementFile

    }
  
    const apiUrl = 'api/advertisement';
    this.repository.create(apiUrl, advertisement)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }
  
  
  
  public redirectToList(){
    this.router.navigate(['/advertisement/list']);
  }

}
