import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';


import {Menu} from '../../../_interfaces/menumange/Menu/menu.model';

@Component({
  selector: 'app-menu-list',
  templateUrl: './menu-list.component.html',
  styleUrls: ['./menu-list.component.css']
})
export class MenuListComponent implements OnInit, OnDestroy {
  public menu: Menu[];
  public errorMessage: string = '';
  public x:string;
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
      let apiAddress: string = "api/menu";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.menu = res as Menu[];
        
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

  public getDetailsPage = (menuItemCategoryId) => { 
    const detailsUrl: string = '/menu/details/' + menuItemCategoryId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (menuItemCategoryId) => { 
    const updateUrl: string = '/menu/update/' + menuItemCategoryId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (menuItemCategoryId) => { 
    const deleteUrl: string = '/menu/delete/' + menuItemCategoryId; 
    this.router.navigate([deleteUrl]); 
  }

}
 