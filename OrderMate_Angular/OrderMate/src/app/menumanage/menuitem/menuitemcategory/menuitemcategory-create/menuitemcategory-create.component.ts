import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router } from '@angular/router';


import { CreateMenuItemCategory} from '../../../../_interfaces/menumange/menuitemcategory/menuitemcategorycreate.model'

@Component({
  selector: 'app-menuitemcategory-create',
  templateUrl: './menuitemcategory-create.component.html', 
  styleUrls: ['./menuitemcategory-create.component.css'] 
})
export class MenuitemcategoryCreateComponent implements OnInit {
  public errorMessage: string = '';
 
  public menuItemCategoryForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
     private router: Router ) { }

  ngOnInit(): void {
 
    this.menuItemCategoryForm = new FormGroup({
      menuItemCategory: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
    });

  }

  public validateControl = (controlName: string) => {
    if (this.menuItemCategoryForm.controls[controlName].invalid && this.menuItemCategoryForm.controls[controlName].touched)
      return true;
 
    return false; 
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.menuItemCategoryForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public create = (Value) => {
    if (this.menuItemCategoryForm.valid) {
      this.executeCreation(Value);
    }
  }
  private executeCreation = (Value) => {

    const MenuItemCategory: CreateMenuItemCategory = {
    //supplierId: supplierFormValue.Id,
    menuItemCategory:Value.menuItemCategory
    
    }
 
    const apiUrl = 'api/menuitemcategory';
    this.repository.create(apiUrl, MenuItemCategory)
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
    this.router.navigate(['/menuitemcategory/list']);
  }



} 
