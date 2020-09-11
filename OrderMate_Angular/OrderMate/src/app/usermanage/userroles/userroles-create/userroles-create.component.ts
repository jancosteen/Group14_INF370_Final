import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';


import {CreateUserRoles} from 'src/app/_interfaces/UserManage/UserRoles/userrolescreate.model'

@Component({
  selector: 'app-userroles-create',
  templateUrl: './userroles-create.component.html',
  styleUrls: ['./userroles-create.component.css']
})
export class UserrolesCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public userRoleForm: FormGroup; 
  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
    private router: Router ) { }

  ngOnInit(): void {

    this.userRoleForm = new FormGroup({

      name: new FormControl('',[Validators.required, Validators.maxLength(50)]), 
    });

  }

  public validateControl = (controlName: string) => {
    if (this.userRoleForm.controls[controlName].invalid && this.userRoleForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.userRoleForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public createUserRole = (userRoleFormValue) => {
    if (this.userRoleForm.valid) {
      this.executeUserRoleCreation(userRoleFormValue);
    }
  }
  private executeUserRoleCreation = (userRoleFormValue) => {

    const userRole: CreateUserRoles = {
    //supplierId: supplierFormValue.Id,
 
    name:userRoleFormValue.name,
    normalizedName:userRoleFormValue.name
    
    }
 
    const apiUrl = 'api/userRole/create';
    console.log('motho asu', userRole);
    this.repository.create(apiUrl, userRole)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }


  
  public redirectToUserRoleList(){
    this.router.navigate(['/userroles/list']);
  }

}
 