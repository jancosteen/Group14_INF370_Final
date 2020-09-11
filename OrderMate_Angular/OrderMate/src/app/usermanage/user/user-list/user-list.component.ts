import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';


import {User} from '../../../_interfaces/UserManage/User/user.model';
import { UserRoles } from 'src/app/_interfaces/UserManage/UserRoles/userroles.model';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnDestroy, OnInit {
  usersfromserver: User[];
  xUsers: User[];
  userRoles: UserRoles[];

  public users: User[];
  public errorMessage: string = '';
  dtTrigger: Subject<any>  =  new Subject();
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective;
  min:number;
  max:number;

  constructor(private repository :  RepositoryService, private errorHandler: ErrorHandlerService, 
    private router: Router) { }

    dtOptions: DataTables.Settings = {};

    ngOnInit(): void {
    
      this.dtOptions = {
        pagingType: 'full_numbers',
        pageLength: 5
      };

        let apiAddress: string = "api/user";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.usersfromserver = res as User[];
          this.xUsers =[];
          this.usersfromserver.forEach(user=>{
            console.log(this.usersfromserver)
            let apiAddress: string = "api/userrole";
            this.repository.getData(apiAddress)
            .subscribe(res => {
              this.userRoles = res as UserRoles[];
              console.log('user',user.userRoleIdFk)
              this.userRoles.forEach(role=>{
                if(user.userRoleIdFk == role.id){
                 user.userRoleName = role.name;
                  this.xUsers.push(user);
                  console.log('xusers',this.xUsers)
                }
              })
             
            });
            
          })
          this.dtTrigger.next();
        });


     
  
        searchingfunction();
  
    }
   
  
    ngOnDestroy(): void {
      this.dtTrigger.unsubscribe();
      $.fn.dataTable.ext.errMode = 'throw';
    }

    getRoles(){
      let apiAddress: string = "api/userrole";
            this.repository.getData(apiAddress)
            .subscribe(res => {
              this.userRoles = res as UserRoles[];
              console.log('roles', this.userRoles)
              
             
            });
    }





  public getDetailsPage = (userId) => { 
    const detailsUrl: string = '/user/details/' + userId; 
    this.router.navigate([detailsUrl]); 
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
function searchingfunction() {
  $.fn['dataTable'].ext.search.push((settings, data, dataIndex) => {
    const id = parseFloat(data[0]) || 0; // use data for the id column
    if ((isNaN(this.min) && isNaN(this.max)) ||
      (isNaN(this.min) && id <= this.max) ||
      (this.min <= id && isNaN(this.max)) ||
      (this.min <= id && id <= this.max)) {
      return true;
    }
    return false;
  });
}



