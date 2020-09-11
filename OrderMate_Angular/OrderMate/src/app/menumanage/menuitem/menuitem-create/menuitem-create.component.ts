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

  public errorMessage: string = '';
 
  public menuItemForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
     private router: Router ) { }

  ngOnInit(): void {
 
    this.menuItemForm = new FormGroup({
      menuItemName: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
      menu: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
      menuItemCategory: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
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

  public create = (Value) => {
    if (this.menuItemForm.valid) {
      this.executeCreation(Value);
    }
  }
  private executeCreation = (Value) => {

    const MenuItemCategory: CreateMenuItem = {
    //supplierId: supplierFormValue.Id,
  
      menuItemName: Value.menuItemName,
      menu:Value.menu,
      menuItemCategory: Value.menuItemCategory
    
    }
 
    const apiUrl = 'api/menuitem';
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
    this.router.navigate(['/menuitem/list']);
  }

}
 