import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {MenuItemCategory} from '../../../../_interfaces/menumange/menuitemcategory/menuitemcategory.model'

@Component({
  selector: 'app-menuitemcategory-update',
  templateUrl: './menuitemcategory-update.component.html',
  styleUrls: ['./menuitemcategory-update.component.css']
})

export class MenuitemcategoryUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public MenuItemCategoryForm: FormGroup;

  public menuItemCategory: MenuItemCategory; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.MenuItemCategoryForm = new FormGroup({
      menuItemCategoryId: new FormControl(''),
      menuItemCategory: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });

    this.getById();
  }


  private getById = () => {
    let ProductCategoryId: string = this.activeRoute.snapshot.params['id'];
      
    let productCategoryIdByIdUrl: string = 'api/menuitemcategory/'+ProductCategoryId;
   
    this.repository.getData(productCategoryIdByIdUrl)
      .subscribe(res => {
        this.menuItemCategory = res as MenuItemCategory;
     
        this.MenuItemCategoryForm.patchValue(this.menuItemCategory);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }


  public validateControl = (controlName: string) => {
    if (this.MenuItemCategoryForm.controls[controlName].invalid && this.MenuItemCategoryForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.MenuItemCategoryForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectToList(){
    this.router.navigate(['/menuitemcategory/list']);
  }


  public update = (Value) => {
    if (this.MenuItemCategoryForm.valid) {
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => { 
  
    this.menuItemCategory.menuItemCategoryId =  Value.menuItemCategoryId,
    this.menuItemCategory.menuItemCategory = Value.menuItemCategory
    
   
    let apiUrl = 'api/menuitemcategory/' + this.menuItemCategory.menuItemCategoryId;
    this.repository.update(apiUrl, this.menuItemCategory)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error); 
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  } 

}
