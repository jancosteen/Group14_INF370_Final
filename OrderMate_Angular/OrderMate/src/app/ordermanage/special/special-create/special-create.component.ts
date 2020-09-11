import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateSpecial} from '../../../_interfaces/Order/Special/specialcreate.model';


@Component({
  selector: 'app-special-create',
  templateUrl: './special-create.component.html',
  styleUrls: ['./special-create.component.css']
})
export class SpecialCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public specialForm: FormGroup;

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

  ngOnInit(): void { 

   this.specialForm = new FormGroup({
    specialStartDate: new FormControl('',[Validators.required]), 
    specialEndDate: new FormControl('',[Validators.required]), 
    specialName: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
    specialDescription: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
    specialPrice: new FormControl('',[Validators.required, Validators.maxLength(100)])
   });

 }

 public validateControl = (controlName: string) => {
   if (this.specialForm.controls[controlName].invalid && this.specialForm.controls[controlName].touched)
     return true;

   return false;
 }

 public hasError = (controlName: string, errorName: string) => {
   if (this.specialForm.controls[controlName].hasError(errorName))
     return true;

   return false;
 }

 public create = (specialFormValue) => {
  if (this.specialForm.valid) {
    this.executeCreation(specialFormValue);
  }
}
private executeCreation = (specialFormValue) => {

  const special: CreateSpecial = {

  specialStartDate: specialFormValue.specialStartDate,
    specialEndDate: specialFormValue.specialEndDate, 
    specialName: specialFormValue.specialName, 
    specialDescription: specialFormValue.specialDescription,
      
  }

  const apiUrl = 'api/special';
  this.repository.create(apiUrl, special)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  )
  
}



public redirectToSpecialList(){
  this.router.navigate(['/special/list']);
}

}
