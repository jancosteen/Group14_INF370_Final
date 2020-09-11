import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {MenuItem} from '../../../_interfaces/menumange/MenuItem/menuitem.model';
import { MenuItemCategory } from 'src/app/_interfaces/menumange/menuitemcategory/menuitemcategory.model';

@Component({
  selector: 'app-menuitem-update',
  templateUrl: './menuitem-update.component.html',
  styleUrls: ['./menuitem-update.component.css']
})
export class MenuitemUpdateComponent implements OnInit {
  categories : MenuItemCategory[];
  selectedCat: MenuItemCategory;

  public errorMessage: string = '';
 
  public menuItemForm: FormGroup; 

  public menuItem: MenuItem; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.getCategories()

    this.menuItemForm = new FormGroup({
      menuItemId: new FormControl(''),
      menuItemName: new FormControl('',[Validators.required, Validators.maxLength(50)]), 
      menuItemCategoryIdFk: new FormControl('',[Validators.required, Validators.maxLength(50)]), 
      menuItemDescription: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
    });
    this.getById();
  }

  private getById = () => {
    let ProductCategoryId: string = this.activeRoute.snapshot.params['id'];
      
    let productCategoryIdByIdUrl: string = 'api/menuitem/'+ProductCategoryId;
   
    this.repository.getData(productCategoryIdByIdUrl)
      .subscribe(res => {
        this.menuItem = res as MenuItem;
     
        this.menuItemForm.patchValue(this.menuItem);

      },
      (error) => { 
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
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

  public redirectToList(){
    this.router.navigate(['/menuitem/list']);
  }

  public update = (Value) => {
    if (this.menuItemForm.valid) {
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => { 
  
    this.menuItem.menuItemId =  Value.menuItemId,
    this.menuItem.menuItemName =  Value.menuItemName,
      this.menuItem.menuIdFk =  Value.menu,
      this.menuItem.menuItemCategoryIdFk =  Value.menuItemCategory
    
   
    let apiUrl = 'api/menuitem/' + this.menuItem.menuItemId;
    this.repository.update(apiUrl, this.menuItem)
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
