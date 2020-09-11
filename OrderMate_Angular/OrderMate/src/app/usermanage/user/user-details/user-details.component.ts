import { UserRoles } from './../../../_interfaces/UserManage/UserRoles/userroles.model';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';


import {User} from '../../../_interfaces/UserManage/User/user.model';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit { 

  public user: User;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getuserDetails();
  }
  roles : UserRoles[];
  Newuser: User;

  getuserDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
 
    let apiUrl: string = 'api/user/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.user = res as User;
      console.log('moto',this.user)
      let roleadr: string ='api/userrole';
      this.roles = []
      this.repository.getData(roleadr)
      .subscribe(res => {
        this.roles = res as UserRoles[]
        this.roles.forEach(role=>{
          if(this.user.userRoleIdFk == role.id){
            this.user.userRoleName = role.name
            this.Newuser = this.user
            console.log('new user', this.Newuser)
          }
        })
      })
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }





  public redirectToUpdatePage = (userId) => { 
    const updateUrl: string = '/user/update/' + userId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = () => { 
    const deleteUrl: string = '/user/list/'; 
    this.router.navigate([deleteUrl]); 
  }

}
 