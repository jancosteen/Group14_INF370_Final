import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 


import {UserRoles} from 'src/app/_interfaces/UserManage/UserRoles/userroles.model';

@Component({
  selector: 'app-userroles-delete',
  templateUrl: './userroles-delete.component.html',
  styleUrls: ['./userroles-delete.component.css']
})
export class UserrolesDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public userRole: UserRoles; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void { 
    this.getuserRoleById();
  }


  private getuserRoleById = () => {
    let userRoleId: string = this.activeRoute.snapshot.params['id'];
      
    let userRoleIdByIdUrl: string = 'api/userrole/'+userRoleId;
   
    this.repository.getData(userRoleIdByIdUrl)
      .subscribe(res => {
        this.userRole = res as UserRoles; 
     
       

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public deleteUserRole = () => {
    const deleteUrl: string = 'api/userrole/' + this.userRole.id ;

    this.repository.delete(deleteUrl)
      .subscribe(res => {
 
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public redirectToUserRolesList(){
    this.router.navigate(['/userroles/list']);
  }

}
