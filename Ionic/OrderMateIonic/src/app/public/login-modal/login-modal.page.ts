import { Component, OnInit } from '@angular/core';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { LoginUser } from 'src/app/_interfaces/login.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login-modal',
  templateUrl: './login-modal.page.html',
  styleUrls: ['./login-modal.page.scss'],
})
export class LoginModalPage implements OnInit {
  loginForm: FormGroup;

  constructor(private repository: RepositoryService,
    private router : Router,
    private toast: MatSnackBar,
    private fb: FormBuilder,
    private authService: AuthenticationService) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      username : new FormControl('',[Validators.required]),
      password : new FormControl('', [Validators.required])
    });
  }

  openToast(){    
    this.toast.open('Login details are incorrect','Ok',{duration:2000});    
  }

  toForgottenPassword(){
    this.router.navigateByUrl('forgot-password');
  }

  login(loginFormValue){
    const loginUser:LoginUser = {
      username : loginFormValue.username,
      password : loginFormValue.password
    }

    

    
    this.repository.login(loginUser).subscribe(
      (res:any) => {
        localStorage.setItem('token', res.token);
        this.authService.authenticationState.next(true);
        this.authService.checkedInState.next(false);        
       
      },
      err => {
        if(err.status == 400){
          this.openToast();
        }else{
          console.log(err);
        }
      }    
    ); 
    
    this.router.navigateByUrl('/members/dashboard');
  }

}
