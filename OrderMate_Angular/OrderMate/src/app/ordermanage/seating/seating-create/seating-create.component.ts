import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router'; 

import {CreateSeating} from '../../../_interfaces/Order/Seating/seatingcreate.model'

@Component({
  selector: 'app-seating-create',
  templateUrl: './seating-create.component.html',
  styleUrls: ['./seating-create.component.css']
})
export class SeatingCreateComponent implements OnInit { 

  public errorMessage: string = '';
 
  public seatingForm: FormGroup;

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

    ngOnInit(): void { 

      this.seatingForm = new FormGroup({
        seatingDate: new FormControl('',[Validators.required,Validators.maxLength(100)]),
        seatingTime: new FormControl('',[Validators.required,Validators.maxLength(100)]),
        reservation: new FormControl('',[Validators.required,Validators.maxLength(100)])
      });
   
    }

    public validateControl = (controlName: string) => {
      if (this.seatingForm.controls[controlName].invalid && this.seatingForm.controls[controlName].touched)
        return true;
    
      return false;
    }
    
    public hasError = (controlName: string, errorName: string) => {
      if (this.seatingForm.controls[controlName].hasError(errorName))
        return true;
    
      return false;
    }

    public create = (Value) => {
      if (this.seatingForm.valid) {
        this.executeCreation(Value);
      }
    }
    private executeCreation = (Value) => {
    
      const seating : CreateSeating = {
        seatingDate: Value.seatingDate,
        seatingTime: Value.seatingTime,
        reservation: Value.reservation
      }
    
      const apiUrl = 'api/seating';
      this.repository.create(apiUrl, seating)
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
      this.router.navigate(['/seating/list']);
    }
 
}
