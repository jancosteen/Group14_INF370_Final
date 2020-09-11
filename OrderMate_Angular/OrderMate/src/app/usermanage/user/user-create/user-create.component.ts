import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';
import {CreateUser} from '../../../_interfaces/UserManage/User/usercreate.model';
import { UserRoles } from 'src/app/_interfaces/UserManage/UserRoles/userroles.model';

@Component({
  selector: 'app-user-create', 
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit { 
  public errorMessage: string = '';
  selected: UserRoles;
 userRoles: UserRoles[];
  public userForm: FormGroup; 
  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

  ngOnInit(): void {

    this.userForm = new FormGroup({
      userName: new FormControl('',[Validators.required, Validators.maxLength(50)]),
      email:new FormControl('',[Validators.required, Validators.email]),
      password:new FormControl('',[Validators.required, Validators.maxLength(50)]),
      confirmPassword:new FormControl('',[Validators.required, Validators.maxLength(50)]),

      user_Name:new FormControl('',[Validators.required, Validators.maxLength(50)]),
      user_Surname:new FormControl('',[Validators.required, Validators.maxLength(50)]),
      user_Contact_Number:new FormControl('',[Validators.required, Validators.maxLength(50)]),
      userRoleIdFk:new FormControl(''),



    });

    
    
    this.getRoles();
  }
getRoles(){
  let apiAddress: string = "api/userrole";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.userRoles = res as UserRoles[];
          console.log('roles', this.userRoles)
          
         
        });
}

  public validateControl = (controlName: string) => {
    if (this.userForm.controls[controlName].invalid && this.userForm.controls[controlName].touched){
    
      
      return true;
    }
      
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.userForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public createuser = (userFormValue) => {
    console.log('someone', userFormValue)
   
    if (this.userForm.valid) {  
    }
    
   this.executeuserCreation(userFormValue);
  }
  private executeuserCreation = (userFormValue) => {
         let   userRole: string;
       
            //formet 
            //call method and pass reservation here

            this.userRoles.forEach(x=>{
              if(userFormValue.userRoleIdFk == x.name){ 
                userRole = x.id
              }
            })
      console.log('us', userRole) 
 
    const user: CreateUser = {
   
      userName: userFormValue.userName, 
      email:userFormValue.email,
      password: userFormValue.password,
      confirmPassword: userFormValue.confirmPassword,
      user_Name : userFormValue.user_Name,
      user_Surname : userFormValue.user_Surname,
      user_Contact_Number : userFormValue.user_Contact_Number,
      userRoleIdFk : userRole,
    
        
    }
    console.log('motho asshuu',user) 
    const apiUrl = 'api/user/create';
    this.repository.create(apiUrl, user)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }


  
  public redirectTouserList(){
    this.router.navigate(['/user/list']);
  }

}
 