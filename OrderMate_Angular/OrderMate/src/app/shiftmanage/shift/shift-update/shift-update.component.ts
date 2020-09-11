import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

 
import {Shift} from 'src/app/_interfaces/EmployeeManage/Shift/shift.model'; 

@Component({
  selector: 'app-shift-update',
  templateUrl: './shift-update.component.html',
  styleUrls: ['./shift-update.component.css']
})
export class ShiftUpdateComponent implements OnInit {
  public errorMessage: string ='';
  public shift: Shift;
  public shiftForm: FormGroup;

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {

   this.shiftForm = new FormGroup({
      shiftId: new FormControl(''),
      shiftStartDateTime: new FormControl('',[Validators.required]), 
      shiftEndDateTime: new FormControl('',[Validators.required]), 
      shiftCapacity: new FormControl('',[Validators.required]), 
      shiftName: new FormControl('',[Validators.required]), 
      shiftStatus: new FormControl('',[Validators.required]), 
   });

   this.getshiftById();

 }
 

 private getshiftById = () => {
  let shiftId: string = this.activeRoute.snapshot.params['id'];
    
  let shiftIdByIdUrl: string = 'api/shift/'+shiftId;
 
  this.repository.getData(shiftIdByIdUrl)
    .subscribe(res => {
      this.shift = res as Shift;
   
      this.shiftForm.patchValue(this.shift);

    },
    (error) => {
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
}

 public validateControl = (controlName: string) => {
  if (this.shiftForm.controls[controlName].invalid && this.shiftForm.controls[controlName].touched)
    return true;

  return false;
}

public hasError = (controlName: string, errorName: string) => {
  if (this.shiftForm.controls[controlName].hasError(errorName))
    return true;

  return false;
}

public updateShift = (ShiftValue) => {
  if (this.shiftForm.valid) {
    this.executeShiftUpdate(ShiftValue);
  }
}
private executeShiftUpdate = (ShiftValue) => {
  
  this.shift.shiftId =  ShiftValue.shiftId,
  this.shift.shiftStartDateTime = ShiftValue.shiftStartDateTime,
  this.shift.shiftEndDateTime = ShiftValue.shiftEndDateTime,
  this.shift.shiftCapacity = ShiftValue.shiftCapacity,
  this.shift.shiftName = ShiftValue.shiftName,
  this.shift.shiftStatus = ShiftValue.shiftStatus

  
  
 
  let apiUrl = 'api/shift/' + this.shift.shiftId;
  this.repository.update(apiUrl, this.shift)
    .subscribe(res => {
      $('#successModal').modal();
    },
    (error => {
      this.errorHandler.handleError(error); 
      this.errorMessage = this.errorHandler.errorMessage;
    })
  )
} 


public redirectToShiftList(){
  this.router.navigate(['/shift/list']);
}
}
