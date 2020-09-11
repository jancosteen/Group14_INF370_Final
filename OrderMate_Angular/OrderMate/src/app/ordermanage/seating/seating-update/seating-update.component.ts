import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {Seating} from '../../../_interfaces/Order/Seating/seating.model'

@Component({
  selector: 'app-seating-update',
  templateUrl: './seating-update.component.html',
  styleUrls: ['./seating-update.component.css']
})
export class SeatingUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public seatingForm: FormGroup;

  public seating: Seating; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.seatingForm = new FormGroup({
      seatingId: new FormControl(''),
      seatingDate: new FormControl('',[Validators.required,Validators.maxLength(100)]),
      seatingTime: new FormControl('',[Validators.required,Validators.maxLength(100)]),
      reservation: new FormControl('',[Validators.required,Validators.maxLength(100)])
    });

    this.getById();
  }

  
  private getById = () => {
    let seatingId: string = this.activeRoute.snapshot.params['id'];
    let IdUrl: string = 'api/seating/'+seatingId;
   
    this.repository.getData(IdUrl)
      .subscribe(res => {
        this.seating = res as Seating;
     
        this.seatingForm.patchValue(this.seating);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
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

  public redirectToList(){
    this.router.navigate(['/seating/list']);
  }

  public update = (Value) => {
    if (this.seatingForm.valid) {
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => {
  
    this.seating.seatingId =  Value.seatingId,
    this.seating.seatingDate = Value.seatingDate,
    this.seating.seatingTime = Value.seatingTime,
    this.seating.reservation = Value.reservation
   
    let apiUrl = 'api/seating/' + this.seating.seatingId;
    this.repository.update(apiUrl, this.seating)
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
 