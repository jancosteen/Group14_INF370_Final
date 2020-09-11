import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';

import {MenuItemCategory} from '../../../../_interfaces/menumange/menuitemcategory/menuitemcategory.model'

@Component({
  selector: 'app-menuitemcategory-details',
  templateUrl: './menuitemcategory-details.component.html', 
  styleUrls: ['./menuitemcategory-details.component.css']
})
export class MenuitemcategoryDetailsComponent implements OnInit {

  public menuItemCategory: MenuItemCategory;
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/menuitemcategory/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.menuItemCategory = res as MenuItemCategory;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (menuItemCategoryId) => { 
    const updateUrl: string = '/menuitemcategory/update/' + menuItemCategoryId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = () => { 
    const deleteUrl: string = '/menuitemcategory/list' ;
    this.router.navigate([deleteUrl]); 
  }

}
