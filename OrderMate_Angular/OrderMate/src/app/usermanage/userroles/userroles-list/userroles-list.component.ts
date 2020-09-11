import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';


import {UserRoles} from '../../../../app/_interfaces/UserManage/UserRoles/userroles.model';

@Component({
  selector: 'app-userroles-list',
  templateUrl: './userroles-list.component.html',
  styleUrls: ['./userroles-list.component.css']
})
export class UserrolesListComponent implements OnDestroy, OnInit {

  public userRoles: UserRoles[];
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
        let apiAddress: string = "api/userrole";
        this.repository.getData(apiAddress)
        .subscribe(res => {
          this.userRoles = res as UserRoles[];
          console.log('list',this.userRoles)
          this.dtTrigger.next();
        });
  
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
   
  
    ngOnDestroy(): void {
      this.dtTrigger.unsubscribe();
      $.fn.dataTable.ext.errMode = 'throw';
    }





  public getDetailsPage = (userRoleId) => { 
    const detailsUrl: string = '/userroles/details/' + userRoleId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (userRoleId) => { 
    const updateUrl: string = '/userroles/update/' + userRoleId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (userRoleId) => { 
    const deleteUrl: string = '/userroles/delete/' + userRoleId; 
    this.router.navigate([deleteUrl]); 
  }

}
