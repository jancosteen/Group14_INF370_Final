import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 


import {User} from '../../../_interfaces/UserManage/User/user.model';

@Component({
  selector: 'app-user-delete',
  templateUrl: './user-delete.component.html',
  styleUrls: ['./user-delete.component.css']
})
export class UserDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public user: User; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void { 
    this.getuserById();
  }


  private getuserById = () => {
    let userId: string = this.activeRoute.snapshot.params['id'];
      
    let userIdByIdUrl: string = 'api/user/'+userId;
   
    this.repository.getData(userIdByIdUrl)
      .subscribe(res => {
        this.user = res as User; 
     
       

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public deleteuser = () => {
    const deleteUrl: string = 'api/user/' + this.user.id ;

    this.repository.delete(deleteUrl)
      .subscribe(res => {
 
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public redirectTousersList(){
    this.router.navigate(['/user/list']);
  }

}
