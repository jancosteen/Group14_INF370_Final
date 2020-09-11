import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {UserRoles} from 'src/app/_interfaces/UserManage/UserRoles/userroles.model'

@Component({
  selector: 'app-userroles-update',
  templateUrl: './userroles-update.component.html',
  styleUrls: ['./userroles-update.component.css']
})
export class UserrolesUpdateComponent implements OnInit { 
  public errorMessage: string = '';
 
  public userRoleForm: FormGroup;

  public userRole: UserRoles; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.userRoleForm = new FormGroup({
      id: new FormControl(''),
     
      name: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });

    this.getuserRoleById();
  }


  private getuserRoleById = () => {
    let userRoleId: string = this.activeRoute.snapshot.params['id'];
      
    let userRoleIdByIdUrl: string = 'api/userrole/'+userRoleId;
   
    this.repository.getData(userRoleIdByIdUrl)
      .subscribe(res => {
        this.userRole = res as UserRoles;
     
        this.userRoleForm.patchValue(this.userRole);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage; 
      })
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

  public redirectToUserRolesList(){
    this.router.navigate(['/userroles/list']);
  }


  public updateUserRoles = (userRoleFormValue) => {
    if (this.userRoleForm.valid) {
      this.executeUserRolesUpdate(userRoleFormValue);
    }
  }

  private executeUserRolesUpdate = (userRoleFormValue) => {
  
    this.userRole.id =  userRoleFormValue.id,

    this.userRole.normalizedName = userRoleFormValue.name
    
   
    let apiUrl = 'api/userrole/' + this.userRole.id;
    this.repository.update(apiUrl, this.userRole)
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
