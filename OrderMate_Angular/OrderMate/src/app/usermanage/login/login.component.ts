import { CurrentUser } from './../../shared/services/data-types';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { Router } from '@angular/router';
import { Toast, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  currentUser;

  public loginModel: FormGroup; 

  constructor(private respository: RepositoryService, private router: Router, private toast: ToastrService) { }

  ngOnInit(): void {
    if(localStorage.getItem('token') != null)
    this.router.navigateByUrl('/home');
    
    this.loginModel = new FormGroup ({
      Username : new FormControl('',[ Validators.required]),
      Password : new FormControl('',[ Validators.required]),
      
    });
  }

  public validateControl = (controlName: string) => {
    if (this.loginModel.controls[controlName].invalid && this.loginModel.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.loginModel.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }


  login(value){
    this.respository.login(value).subscribe(
      (res:any) => {
        this.currentUser = res as CurrentUser
        localStorage.setItem('token',this.currentUser.token)//do not delete
        this.router.navigateByUrl('/home');
        
      },
      err => {
        if(err.status == 404){
          this.toast.error('Incorrect Username Or Password.','Authentication Failed.');
        }else{
          this.toast.error('Incorrect Username Or Password.','Authentication Failed.');
          console.log(err);
        }
      }
      
    );
    
  }

}
