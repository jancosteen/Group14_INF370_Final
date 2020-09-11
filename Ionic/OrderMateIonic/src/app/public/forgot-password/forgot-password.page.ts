import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { User } from 'src/app/_interfaces/ForCreation/user.model';
import { FullUser } from 'src/app/_interfaces/fullUser.model';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { CreateUser } from 'src/app/_interfaces/ForCreation/createUser.model';
import { NavController } from '@ionic/angular';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.page.html',
  styleUrls: ['./forgot-password.page.scss'],
})
export class ForgotPasswordPage implements OnInit {

  forgotPasswordForm: FormGroup;
  userId;
  userToken:User;
  loggedInUser: FullUser;
  public errorMessage: string = '';
  token;

  constructor(private fb: FormBuilder,
    private repo:RepositoryService,
    private errorHandler: ErrorHandlerService,
    private nav:NavController) { }

  ngOnInit() {
    this.forgotPasswordForm = this.fb.group({
      username : new FormControl('',[Validators.required]),
      password : new FormControl('',[Validators.required])      
    });

    this.getUserDetails();
  }

  resetPassword(value){
    this.userId = localStorage.getItem('userId');

    const apiUrl = `user/${this.userId}`;

    const updateUser:CreateUser = {
      userName : this.loggedInUser.userName,
      email : this.loggedInUser.email,
      password : value.password,
      confirmPassword : value.password,
      user_Name : this.loggedInUser.user_Name,
      user_Surname : this.loggedInUser.user_Surname,
      user_Contact_Number : this.loggedInUser.user_Contact_Number,
      userRoleName : this.loggedInUser.userRoleName,
      userRoleIdFk : this.loggedInUser.userRoleIdFk
    }
    this.repo.update(apiUrl, updateUser)
      .subscribe(res => {
        console.log(res);
        this.nav.navigateRoot('login');
      })
  }

  getUserDetails(){
    this.token = localStorage.getItem('token');
    
    const helper= new JwtHelperService();
    this.userToken = helper.decodeToken(this.token) as User; 
    let apiUrl: string = `api/user/detail/${this.userToken.userName}`;
    
    this.repo.getData(apiUrl)
      .subscribe(res=>{        
        this.loggedInUser = res as FullUser;
        localStorage.setItem('userId',this.loggedInUser.id);
        console.log(this.loggedInUser.id);
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })   
  }

}
