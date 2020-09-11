import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {QrCodeSeating} from '../../../_interfaces/Order/QRCodeSeating/qrcodeseating.model'

@Component({
  selector: 'app-qrcodeseating-update',
  templateUrl: './qrcodeseating-update.component.html',
  styleUrls: ['./qrcodeseating-update.component.css']
})
export class QrcodeseatingUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public QrCodeSeatingForm: FormGroup;

  public qrCodeSeating: QrCodeSeating; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.QrCodeSeatingForm = new FormGroup({
      qrCodeSeatingId: new FormControl(''),
      numberOfPeople: new FormControl('',[Validators.required,Validators.maxLength(100)]),
      qrCode: new FormControl('',[Validators.required,Validators.maxLength(100)]),
      Seating: new FormControl('',[Validators.required,Validators.maxLength(100)]),
      Order: new FormControl('',[Validators.required,Validators.maxLength(100)]),
    });

    this.getById();
  }

  private getById = () => {
    let qrCodeSeatingId: string = this.activeRoute.snapshot.params['id'];
      
    let IdUrl: string = 'api/qrcodeseating/'+qrCodeSeatingId;
   
    this.repository.getData(IdUrl)
      .subscribe(res => {
        this.qrCodeSeating = res as QrCodeSeating;
     
        this.QrCodeSeatingForm.patchValue(this.qrCodeSeating);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public validateControl = (controlName: string) => {
    if (this.QrCodeSeatingForm.controls[controlName].invalid && this.QrCodeSeatingForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.QrCodeSeatingForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  } 

  public redirectToList(){
    this.router.navigate(['/qrcodeseating/list']);
  }


  public update = (Value) => {
    if (this.QrCodeSeatingForm.valid) {
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => {
  
    this.qrCodeSeating.qrCodeSeatingId =  Value.qrCodeSeatingId,
    this.qrCodeSeating.numberOfPeople = Value.numberOfPeople,
    this.qrCodeSeating.qrCode = Value.qrCode,
    this.qrCodeSeating.Seating = Value.Seating,
    this.qrCodeSeating.Order = Value.Order
   
    let apiUrl = 'api/qrcodeseating/' + this.qrCodeSeating.qrCodeSeatingId;
    this.repository.update(apiUrl, this.qrCodeSeating)
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
