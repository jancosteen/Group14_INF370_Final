import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';


import {UserRoles} from 'src/app/_interfaces/UserManage/UserRoles/userroles.model';

@Component({
  selector: 'app-userroles-details',
  templateUrl: './userroles-details.component.html',
  styleUrls: ['./userroles-details.component.css']
})
export class UserrolesDetailsComponent implements OnInit { 

  public userRole: UserRoles;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getuserRoleDetails();
  }


  getuserRoleDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
 
    let apiUrl: string = 'api/userrole/'+id;
    console.log('id',id);
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.userRole = res as UserRoles;
      console.log('user assuu',this.userRole)
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }




  public redirectToUpdatePage = (id) => { 
    const updateUrl: string = '/userroles/update/' + id; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (id) => { 
    const deleteUrl: string = '/userroles/delete/' + id; 
    this.router.navigate([deleteUrl]); 
  }

}
 