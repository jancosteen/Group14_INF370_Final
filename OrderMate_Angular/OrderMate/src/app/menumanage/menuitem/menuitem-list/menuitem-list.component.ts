import { Component, OnInit, OnDestroy, ViewChild  } from '@angular/core';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { Router } from '@angular/router';
import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';

import {MenuItem} from '../../../_interfaces/menumange/MenuItem/menuitem.model';
import { Menu} from '../../../_interfaces/menumange/Menu/menu.model';
import { MenuItemCategory } from 'src/app/_interfaces/menumange/menuitemcategory/menuitemcategory.model';

@Component({
  selector: 'app-menuitem-list',
  templateUrl: './menuitem-list.component.html',
  styleUrls: ['./menuitem-list.component.css']
})
export class MenuitemListComponent implements OnInit, OnDestroy {
  public menuItem: MenuItem[];
  public items: MenuItem[];
  public menu: Menu[];
  public errorMessage: string = '';
  public x:string;
  menuitemcategories : MenuItemCategory[]
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
    let Address: string = "api/menuItem";
      this.repository.getData(Address)
      .subscribe(res => {
        this.menuItem = res as MenuItem[];
        this.menuItem.forEach(item=>{
          this.items =  []
          
          let apiAddress: string = "api/menuitemcategory";
          this.repository.getData(apiAddress)
            .subscribe(res => {
              this.menuitemcategories = res as MenuItemCategory[];
              this.menuitemcategories.forEach(cat => {
                if(item.menuItemCategoryIdFk == cat.menuItemCategoryId){
                  item.menuItemCategoryName = cat.menuItemCategory1
                  this.items.push(item);
                }
              })
        
        
      });

    })
        
    
     
      });
      this.dtTrigger.next();
      

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
    const detailsUrl: string = '/menuitem/details/' + menuItemCategoryId; 
    this.router.navigate([detailsUrl]); 
  }
  
  public redirectToUpdatePage = (menuItemCategoryId) => { 
    const updateUrl: string = '/menuitem/update/' + menuItemCategoryId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (menuItemCategoryId) => { 
    const deleteUrl: string = '/menuitem/delete/' + menuItemCategoryId; 
    this.router.navigate([deleteUrl]); 
  }

}
 