import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule, NgForm } from '@angular/forms'; 
import { CommonModule} from '@angular/common';
import { ErrorHandlerService } from './../../shared/services/error-handler.service';
import { RepositoryService } from './../../shared/services/repository.service';
import { Router } from '@angular/router';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';

 
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {

  public formModel: FormGroup; 

  constructor(private errorHandler: ErrorHandlerService, public repository: RepositoryService,
    private router: Router, private fb:FormBuilder ) {  }

  ngOnInit(): void {
    this.formModel = this.fb.group({
      Username : ['', Validators.required],
      User_Name : ['',Validators.required],
      User_Surname : ['',Validators.required],
      Email : ['',Validators.required, Validators.email],
      User_Contact_Number : ['',Validators.required],
      Passwords :this.fb.group({ 
        Password : ['',Validators.required],
        ConfirmPassword : ['',Validators.required],
      },{validators: this.ComparePasswords})
      
    });
  }
  

  

  ComparePasswords(fb: FormGroup)
  {
    let confirmPassCtrl = fb.get('ConfirmPassword')
    if(confirmPassCtrl.errors == null || 'passwordMismatch' in confirmPassCtrl.errors){
        if(fb.get('Password').value != confirmPassCtrl.value){
          confirmPassCtrl.setErrors({passwordMismatch: true});
        }else{
          confirmPassCtrl.setErrors(null);
        }
    }
  }

  public validateControl = (controlName: string) => {
    if (this.formModel.controls[controlName].invalid && this.formModel.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.formModel.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public Register(){
    var body = {
      UserName: this.formModel.value.UserName,
      User_Name: this.formModel.value.User_Name,
      User_Surname: this.formModel.value.User_Surname,
      Email: this.formModel.value.Email,
      User_Contact_Number: this.formModel.value.User_Contact_Number,
      Password: this.formModel.value.Passwords.Password,
      ConfirmPassword: this.formModel.value.Passwords.ConfirmPassword
    };
    this.repository.register(body)
    .subscribe(
      (res: any) => {
        if(res.succeeded){
          this.formModel.reset();
        }else{
        res.errors.forEach( el => {
          switch(el.code){
            case 'DuplicateUsername':
              break;
            default:
              break;
          }
            
          });
        }
      },
      err => {
        console.log(err);
      }
    )
    
  }



 



}
