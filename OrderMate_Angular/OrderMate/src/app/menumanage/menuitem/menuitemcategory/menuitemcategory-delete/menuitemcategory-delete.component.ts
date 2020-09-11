import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {MenuItemCategory} from '../../../../_interfaces/menumange/menuitemcategory/menuitemcategory.model'

@Component({
  selector: 'app-menuitemcategory-delete',
  templateUrl: './menuitemcategory-delete.component.html',
  styleUrls: ['./menuitemcategory-delete.component.css'] 
})
export class MenuitemcategoryDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public menuItemCategory: MenuItemCategory; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails();  
    }
  
  
    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/menuItemCategory/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.menuItemCategory = res as MenuItemCategory;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }



  public delete = () => {
    const deleteUrl: string = 'api/menuItemCategory/' + this.menuItemCategory.menuItemCategoryId ;

    this.repository.delete(deleteUrl)
      .subscribe(res => {
 
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public redirectToList(){
    this.router.navigate(['/menuItemCategory/list']);
  }
 
}
