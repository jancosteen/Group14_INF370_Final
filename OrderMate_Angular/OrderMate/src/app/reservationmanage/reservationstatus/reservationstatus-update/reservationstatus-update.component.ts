import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model'

@Component({
  selector: 'app-reservationstatus-update',
  templateUrl: './reservationstatus-update.component.html',
  styleUrls: ['./reservationstatus-update.component.css']
})
export class ReservationstatusUpdateComponent implements OnInit { 

  public errorMessage: string = '';
 
  public reservationstatusForm: FormGroup;

  public reservationStatus: ReservationStatus; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void { 
    this.reservationstatusForm = new FormGroup({
      reservationStatusId: new FormControl(''),
      reservationStatus1: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });

    this.getById();
  }


  private getById = () => {
    let reservationStatusId: string = this.activeRoute.snapshot.params['id'];
      
    let IdByIdUrl: string = 'api/reservationstatus/'+reservationStatusId;
   
    this.repository.getData(IdByIdUrl)
      .subscribe(res => {
        this.reservationStatus = res as ReservationStatus;
     
        this.reservationstatusForm.patchValue(this.reservationStatus);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;  
      })
  }

  public validateControl = (controlName: string) => {
    if (this.reservationstatusForm.controls[controlName].invalid && this.reservationstatusForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.reservationstatusForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectToList(){
    this.router.navigate(['/reservationstatus/list']);
  }


  public update = (FormValue) => {
    if (this.reservationstatusForm.valid) {
      this.executeUpdate(FormValue);
    }
  }

  private executeUpdate = (FormValue) => {
  
    this.reservationStatus.reservationStatusId =  FormValue.reservationStatusId,
    this.reservationStatus.reservationStatus1 = FormValue.reservationStatus1
    
   
    let apiUrl = 'api/reservationstatus/' + this.reservationStatus.reservationStatusId;
    this.repository.update(apiUrl, this.reservationStatus)
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
