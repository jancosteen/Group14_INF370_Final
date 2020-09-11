import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { CreateUser } from 'src/app/_interfaces/ForCreation/createUser.model';
import { RepositoryService } from 'src/app/shared/services/repository.service';
import { NavController } from '@ionic/angular';

@Component({
  selector: 'app-register',
  templateUrl: './register.page.html',
  styleUrls: ['./register.page.scss'],
})
export class RegisterPage implements OnInit {

  userForm: FormGroup;

  constructor(private fb: FormBuilder,
    private repository: RepositoryService,
    private nav: NavController,){}

  ngOnInit() {
    this.userForm = this.fb.group({
      userName: new FormControl('',[Validators.required]),
      user_name: new FormControl('', [Validators.required]),
      user_surname:  new FormControl('', [Validators.required]),
      user_contact_number: new FormControl('',[Validators.required]),
      user_email: new FormControl('', [Validators.required]),
      password1: new FormControl('', [Validators.required, Validators.minLength(6)]),
      password2: new FormControl('', [Validators.required, Validators.minLength(6)])
    });
  }

  registerUser(userFormValue){
    const user: CreateUser = {
      userName: userFormValue.userName,
      user_Name: userFormValue.user_name,
      user_Surname: userFormValue.user_surname,
      user_Contact_Number: userFormValue.user_contact_number,
      email: userFormValue.user_email,
      password: userFormValue.password1,
      confirmPassword: userFormValue.password2,
      userRoleName: 'Ismael Singleton',
      userRoleIdFk: '11592'
    }

    console.log(user);
    const apiUrl='api/user/Create';
    this.repository.create(apiUrl,user)
      .subscribe(res => {        
        console.log(res);     
      }); 
      this.nav.navigateRoot('/login')     
  }

  

}
