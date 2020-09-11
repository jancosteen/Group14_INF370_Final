import { MenuItemCategory } from './../../../_interfaces/menumange/menuitemcategory/menuitemcategory.model';
import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateMenuItem} from '../../../_interfaces/menumange/MenuItem/menuitemcreate.model'

@Component({
  selector: 'app-menuitem-create',
  templateUrl: './menuitem-create.component.html',
  styleUrls: ['./menuitem-create.component.css']
})
export class MenuitemCreateComponent implements OnInit {
  categories : MenuItemCategory[];
  selectedCat: MenuItemCategory;

  public errorMessage: string = '';
 
  public menuItemForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
     private router: Router ) { }

  ngOnInit(): void {
    this.getCategories()
 
    this.menuItemForm = new FormGroup({
      menuItemName: new FormControl('',[Validators.required, Validators.maxLength(50)]), 
      menuItemCategoryIdFk: new FormControl('',[Validators.required, Validators.maxLength(50)]), 
      menuItemDescription: new FormControl('',[Validators.required, Validators.maxLength(50)]), 
      

    });

  }

  public validateControl = (controlName: string) => {
    if (this.menuItemForm.controls[controlName].invalid && this.menuItemForm.controls[controlName].touched)
      return true;
 
    return false; 
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.menuItemForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  getCategories(){
    let apiAddress: string = "api/menuItemCategory";
      this.repository.getData(apiAddress)
      .subscribe(res => {
        this.categories = res as MenuItemCategory[];
        console.log('categories', this.categories)
      });
  }
 
  public create = (Value) => {
    if (this.menuItemForm.valid) {
      this.executeCreation(Value);
    }
  }
  private executeCreation = (Value) => {

    let cat : number;
    console.log('value', Value.menuItemCategoryIdFk)
    this.categories.forEach(x=>{
      console.log('x',x.menuItemCategory1)
      if(Value.menuItemCategoryIdFk == x.menuItemCategory1) 
      {
        console.log('id',x.menuItemCategoryId)
        cat = x.menuItemCategoryId
        console.log('cat',cat)
      } 
    })

    const menuitem: CreateMenuItem = {  
      menuItemName: Value.menuItemName,
      menuItemDescription: Value.menuItemDescription,
      menuIdFk: Value.menuIdFk,
      menuItemCategoryIdFk: cat,
    
    }
 
    const apiUrl = 'api/menuitem';
    this.repository.create(apiUrl, menuitem)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  }


  
  public redirectToList(){
    this.router.navigate(['/menuitem/list']);
  }

}
 