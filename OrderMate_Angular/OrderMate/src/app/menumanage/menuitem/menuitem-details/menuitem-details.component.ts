import { MenuItemCategory } from './../../../_interfaces/menumange/menuitemcategory/menuitemcategory.model';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';


import { MenuItem } from '../../../_interfaces/menumange/MenuItem/menuitem.model'

@Component({
  selector: 'app-menuitem-details',
  templateUrl: './menuitem-details.component.html',
  styleUrls: ['./menuitem-details.component.css']
})
export class MenuitemDetailsComponent implements OnInit {

  public menuItem: MenuItem;
  Item:MenuItem;
  public errorMessage: string = '';  
  cats : MenuItemCategory[];

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }


  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/menuItem/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.menuItem = res as MenuItem;
      let catAddress: string = "api/menuitemcategory";
      this.repository.getData(catAddress)
      .subscribe(res => {
        this.cats = res as MenuItemCategory[]
        this.cats.forEach(cat=>{
          if(cat.menuItemCategoryId == this.menuItem.menuItemCategoryIdFk){
            this.menuItem.menuItemCategoryName = cat.menuItemCategory1
            this.Item = this.menuItem
          }
        })
      })
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (menuId) => { 
    const updateUrl: string = '/menuitem/update/' + menuId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = () => { 
    const deleteUrl: string = '/menuitem/list'
    this.router.navigate([deleteUrl]); 
  } 
 
}
 