import { MenuItemCategory } from './../../../_interfaces/menumange/menuitemcategory/menuitemcategory.model';
import { Component, OnInit,  OnDestroy, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import { MenuItem } from '../../../_interfaces/menumange/MenuItem/menuitem.model'

import { DataTableDirective } from 'angular-datatables';
import { Subject } from 'rxjs';
import { IfStmt } from '@angular/compiler';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-menuitems',
  templateUrl: './menuitems.component.html',
  styleUrls: ['./menuitems.component.css']
})
export class MenuitemsComponent implements OnInit, OnDestroy {
   public menuItems: MenuItem[];
  public errorMessage: string = ''; 
  public items: MenuItem[];
  public x: MenuItem[];
  menuitemcategories: MenuItemCategory[];
  categories: MenuItemCategory[];
 
  dtTrigger: Subject<any>  =  new Subject();
  @ViewChild(DataTableDirective, {static: false})
  datatableElement: DataTableDirective; 
  min:number;
  max:number; 
  itemsformenu : MenuItem[];

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

    dtOptions: DataTables.Settings = {};
  ngOnInit(): void {
    

    
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5
    };

    this.itemsformenu = []
    this.items = []
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiAddress: string = "api/menuItem/";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.menuItems = res as MenuItem[];
        let categoryAddress: string ='api/menuitemcategory/';
          this.repository.getData(categoryAddress)
            .subscribe(res => {
            this.menuitemcategories = res as MenuItemCategory[]
            this.menuitemcategories.forEach(category => {
              this.menuItems.forEach(item =>{
                if(item.menuItemId == id && category.menuItemCategoryId == item.menuItemCategoryIdFk)
                {
                  item.menuItemCategoryName = category.menuItemCategory1
                  this.itemsformenu.push(item)
                }
              
            })
            console.log(this.menuitemcategories)
        }) 
        
          
        })

        
        
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
  getDetailsPage(value){ 
      const updateUrl: string = '/menuitem/details/' + value; 
      this.router.navigate([updateUrl]); 
  }
  getDeletePage(value){ 
    const updateUrl: string = '/menuitem/delete/' + value; 
    this.router.navigate([updateUrl]); 
  }
  getUpdatePage(value){ 
    const updateUrl: string = '/menuitem/update/' + value; 
    this.router.navigate([updateUrl]); 
  }


 




  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
    $.fn.dataTable.ext.errMode = 'throw'; 
  }

   

 
 
}
