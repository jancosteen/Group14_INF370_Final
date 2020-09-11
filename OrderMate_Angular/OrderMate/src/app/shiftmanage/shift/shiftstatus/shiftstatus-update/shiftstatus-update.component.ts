import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from '../../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {ShiftStatus} from 'src/app/_interfaces/EmployeeManage/ShiftStatus/shiftstatus.model' 

@Component({
  selector: 'app-shiftstatus-update',
  templateUrl: './shiftstatus-update.component.html',
  styleUrls: ['./shiftstatus-update.component.css']
})
export class ShiftstatusUpdateComponent implements OnInit {
  public errorMessage: string ='';
  public shiftstatus: ShiftStatus;
  public shiftstatusForm: FormGroup;
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {

   this.shiftstatusForm = new FormGroup({
      shiftstatusId: new FormControl(''),
      shiftstatus: new FormControl('',[Validators.required, Validators.maxLength(50)]), 
   });

   this.getshiftstatusById();

 }
 

 private getshiftstatusById = () => {
  let shiftstatusId: string = this.activeRoute.snapshot.params['id'];
    
  let shiftstatusIdByIdUrl: string = 'api/shiftstatus/'+shiftstatusId;
 
  this.repository.getData(shiftstatusIdByIdUrl)
    .subscribe(res => {
      this.shiftstatus = res as ShiftStatus;
   
      this.shiftstatusForm.patchValue(this.shiftstatus);

    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
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

public updateShiftStatus = (ShiftStatusValue) => {
  if (this.shiftstatusForm.valid) {
    this.executeShiftStatusUpdate(ShiftStatusValue);
  }
}
private executeShiftStatusUpdate = (ShiftStatusValue) => {
  
  this.shiftstatus.shiftstatusId =  ShiftStatusValue.shiftstatusId,
  this.shiftstatus.shiftstatus = ShiftStatusValue.shiftstatus
  
 
  let apiUrl = 'api/shiftstatus/' + this.shiftstatus.shiftstatusId;
  this.repository.update(apiUrl, this.shiftstatus)
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
  this.router.navigate(['/shiftstatus/list']);
}

}
