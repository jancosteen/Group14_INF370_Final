import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatuscreate.model'

@Component({
  selector: 'app-reservationstatus-create',
  templateUrl: './reservationstatus-create.component.html',
  styleUrls: ['./reservationstatus-create.component.css']
})
export class ReservationstatusCreateComponent implements OnInit {

  public errorMessage: string = '';
 
  public reservationStatusForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

 ngOnInit(): void {

   this.reservationStatusForm = new FormGroup({
    ReservationStatus1: new FormControl('',[Validators.required, Validators.maxLength(50)]), 
   });

  }

  public validateControl = (controlName: string) => {
    if (this.reservationStatusForm.controls[controlName].invalid && this.reservationStatusForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.reservationStatusForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public create = (Value) => {
    if (this.reservationStatusForm.valid) {
      this.executeCreation(Value);
    }
  }
  private executeCreation = (Value) => {

    const reservationStatus: CreateReservationStatus = {
    //supplierId: supplierFormValue.Id,
    reservationStatus1 :Value.ReservationStatus1
  
    }
  
    const apiUrl = 'api/reservationstatus';
    this.repository.create(apiUrl, reservationStatus)
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
    this.router.navigate(['/reservationstatus/list']);
  }

}
