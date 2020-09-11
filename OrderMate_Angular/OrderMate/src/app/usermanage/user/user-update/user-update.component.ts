import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {User} from '../../../_interfaces/UserManage/User/user.model'
import { UserRoles } from 'src/app/_interfaces/UserManage/UserRoles/userroles.model';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.css']
})
export class UserUpdateComponent implements OnInit { 
  selected: UserRoles;
  userRoles: UserRoles[];
  public errorMessage: string = '';
 
  public userForm: FormGroup;

  public user: User; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void { 
    this.userForm = new FormGroup({
      id: new FormControl(''),
      userName: new FormControl('',[Validators.required, Validators.maxLength(50)]),
      email:new FormControl('',[Validators.required, Validators.maxLength(50), Validators.email]),
      password:new FormControl('',[Validators.required, Validators.maxLength(50)]),
      confirmPassword:new FormControl('',[Validators.required, Validators.maxLength(50)]),
      user_Name:new FormControl('',[Validators.required, Validators.maxLength(50)]),
      user_Surname:new FormControl('',[Validators.required, Validators.maxLength(50)]),
      user_Contact_Number:new FormControl('',[Validators.required, Validators.maxLength(50)]),
      userRoleIdFk:new FormControl('',[Validators.required, Validators.maxLength(50)]),
  
    
    });

    this.getuserById();
    this.getRoles()
  }

  getRoles(){
    let apiAddress: string = "api/userrole";
          this.repository.getData(apiAddress)
          .subscribe(res => {
            this.userRoles = res as UserRoles[];
            console.log('roles', this.userRoles)
            
           
          });
  }


  private getuserById = () => {
    let userId: string = this.activeRoute.snapshot.params['id'];
      
    let userIdByIdUrl: string = 'api/user/'+userId;
   
    this.repository.getData(userIdByIdUrl)
      .subscribe(res => {
        this.user = res as User;
     
        this.userForm.patchValue(this.user);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage; 
      })
  }


  public validateControl = (controlName: string) => {
    if (this.userForm.controls[controlName].invalid && this.userForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.userForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectTouserList(){
    this.router.navigate(['/user/list']);
  }


  public updateuser = (userFormValue) => {
    if (this.userForm.valid) {
      this.executeuserUpdate(userFormValue);
    }
  }

  private executeuserUpdate = (userFormValue) => {
    let   userRole: string;
       
            //formet 
            //call method and pass reservation here

            this.userRoles.forEach(x=>{
              if(userFormValue.userRoleIdFk == x.name){
                userRole = x.id
              }
            })
      console.log('us', userRole)
  
    this.user.id =  userFormValue.userId,
    this.user.userName = userFormValue.userName,
    this.user.email = userFormValue.email,
    this.user.password = userFormValue.password,
    this.user.confirmPassword = userFormValue.confirmPassword,
    this.user.user_Name = userFormValue.user_Name,
    this.user.user_Surname = userFormValue.user_Surname,
    this.user.user_Contact_Number = userFormValue.user_Contact_Number,
    this.user.userRoleIdFk = userRole

       
   
    let apiUrl = 'api/user/' + this.user.id;
    this.repository.update(apiUrl, this.user)
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
