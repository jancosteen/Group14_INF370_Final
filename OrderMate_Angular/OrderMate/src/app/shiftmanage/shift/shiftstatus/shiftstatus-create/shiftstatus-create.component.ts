import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from '../../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../../shared/services/repository.service';
import { Router } from '@angular/router';


import {CreateShiftStatus} from 'src/app/_interfaces/EmployeeManage/ShiftStatus/shiftstatuscreate.model';

@Component({
  selector: 'app-shiftstatus-create',
  templateUrl: './shiftstatus-create.component.html',
  styleUrls: ['./shiftstatus-create.component.css']
})
export class ShiftstatusCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public shiftstatusForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

 ngOnInit(): void {

   this.shiftstatusForm = new FormGroup({
    shiftstatus: new FormControl('',[Validators.required, Validators.maxLength(50)]), 
   });

 }

 public validateControl = (controlName: string) => {
   if (this.shiftstatusForm.controls[controlName].invalid && this.shiftstatusForm.controls[controlName].touched)
     return true;

   return false;
 }

 public hasError = (controlName: string, errorName: string) => {
   if (this.shiftstatusForm.controls[controlName].hasError(errorName))
     return true;

   return false;
 }

 public createShiftStatus = (shiftstatusValue) => {
  if (this.shiftstatusForm.valid) {
    this.executeShiftStatusCreation(shiftstatusValue);
  }
}
private executeShiftStatusCreation = (shiftstatusValue) => {

  const Shiftstatus: CreateShiftStatus = {
  //supplierId: supplierFormValue.Id,
  shiftstatus :shiftstatusValue.shiftstatus

  }

  const apiUrl = 'api/shiftstatus';
  this.repository.create(apiUrl, Shiftstatus)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  )
}



public redirectToShiftStatusList(){
  this.router.navigate(['/Shiftstatus/list']);
}


}
