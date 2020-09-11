import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {MenuItemType} from '../../../../_interfaces/menumange/menuitemtype/menuitemtype.model'

@Component({
  selector: 'app-menuitemtype-list',
  templateUrl: './menuitemtype-list.component.html',
  styleUrls: ['./menuitemtype-list.component.css']
})
export class MenuitemtypeListComponent implements OnInit, OnDestroy {


  public menuitemtypes: MenuItemType[];
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
      let apiAddress: string = "api/menuItemType";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.menuitemtypes = res as MenuItemType[];
        
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

  public getDetailsPage = (menuItemTypeId) => { 
    const detailsUrl: string = '/menuitemtype/details/' + menuItemTypeId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (menuItemTypeId) => { 
    const updateUrl: string = '/menuitemtype/update/' + menuItemTypeId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (menuItemTypeId) => { 
    const deleteUrl: string = '/menuitemtype/delete/' + menuItemTypeId; 
    this.router.navigate([deleteUrl]); 
  }

}
