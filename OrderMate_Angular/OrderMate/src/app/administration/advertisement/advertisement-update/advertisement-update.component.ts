import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {Advertisement} from '../../../_interfaces/Administration/Advertisements/advertisement.model'

@Component({
  selector: 'app-advertisement-update',
  templateUrl: './advertisement-update.component.html',
  styleUrls: ['./advertisement-update.component.css']
})
export class AdvertisementUpdateComponent implements OnInit {

  public errorMessage: string = '';

  public advertisementForm: FormGroup; 
  public advertisement: Advertisement;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.advertisementForm = new FormGroup({
        advertisementId: new FormControl(''),
        advertisementName: new FormControl('',[Validators.required, Validators.maxLength(50)]),
        advertisementDescription: new FormControl('',[Validators.required, Validators.maxLength(50)]),
        advertisementFile: new FormControl('',[Validators.required, Validators.maxLength(50)])
      }); 
    
      this.getadvertisementById();
    }

    private getadvertisementById = () => {
      let advertisementId: string = this.activeRoute.snapshot.params['id'];
        
      let IdByIdUrl: string = 'api/restaurant/'+advertisementId;
     
      this.repository.getData(IdByIdUrl)
        .subscribe(res => {
          this.advertisement = res as Advertisement;
       
          this.advertisementForm.patchValue(this.advertisement); 
    
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        })
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

    public redirectToList(){
      this.router.navigate(['/advertisement/list']);
    }
    
    
    public updateadvertisement = (Value) => {
      if (this.advertisementForm.valid) {
        this.executeadvertisementUpdate(Value);
      }
    }
    private executeadvertisementUpdate = (Value) => {
      this.advertisement.advertisementId =  Value.advertisementId,
      this.advertisement.advertisementName = Value.advertisementName,
      this.advertisement.advertisementDescription = Value.advertisementDescription,
      this.advertisement.advertisementFile = Value.advertisementFile
    
     
      let apiUrl = 'api/restaurant/' + this.advertisement.advertisementId;
      this.repository.update(apiUrl, this.advertisement)
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
