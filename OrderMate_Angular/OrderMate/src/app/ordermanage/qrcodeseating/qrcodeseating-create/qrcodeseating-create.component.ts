import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router'; 

import { CreateQrCodeSeating} from '../../../_interfaces/Order/QRCodeSeating/qrcodeseatingcreate.model'

@Component({
  selector: 'app-qrcodeseating-create',
  templateUrl: './qrcodeseating-create.component.html',
  styleUrls: ['./qrcodeseating-create.component.css']
})
export class QrcodeseatingCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public QrCodeSeatingForm: FormGroup;

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

    ngOnInit(): void { 

      this.QrCodeSeatingForm = new FormGroup({
        numberOfPeople: new FormControl('',[Validators.required,Validators.maxLength(100)]),
        qrCode: new FormControl('',[Validators.required,Validators.maxLength(100)]),
        Seating: new FormControl('',[Validators.required,Validators.maxLength(100)]),
        Order: new FormControl('',[Validators.required,Validators.maxLength(100)]),
      });
   
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



    public create = (Value) => {
      if (this.QrCodeSeatingForm.valid) {
        this.executeCreation(Value);
      }
    }
    private executeCreation = (Value) => {
    
      const seating : CreateQrCodeSeating = {
        numberOfPeople: Value.seatingDate,
        qrCode: Value.seatingTime,
        Seating: Value.reservation,
        Order: Value.Order
      }
    
      const apiUrl = 'api/qrcodeseating';
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
      this.router.navigate(['/qrcodeseating/list']);
    }

}
