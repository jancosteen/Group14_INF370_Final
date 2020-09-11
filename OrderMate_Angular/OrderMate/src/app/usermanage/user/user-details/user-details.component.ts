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


  getuserDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
 
    let apiUrl: string = 'api/user/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.user = res as User;
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

  public redirectToDeletePage = (userId) => { 
    const deleteUrl: string = '/user/delete/' + userId; 
    this.router.navigate([deleteUrl]); 
  }

}
 