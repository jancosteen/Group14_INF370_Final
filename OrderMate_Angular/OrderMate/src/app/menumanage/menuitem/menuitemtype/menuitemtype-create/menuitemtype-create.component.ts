import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router } from '@angular/router';


import {CreateMenuItemType} from '../../../../_interfaces/menumange/menuitemtype/menuitemtypecreate.model'

@Component({
  selector: 'app-menuitemtype-create',
  templateUrl: './menuitemtype-create.component.html',
  styleUrls: ['./menuitemtype-create.component.css']
})
export class MenuitemtypeCreateComponent implements OnInit {

  public errorMessage: string = '';
 
  public menuItemTypeForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
     private router: Router ) { }

  ngOnInit(): void {
 
    this.menuItemTypeForm = new FormGroup({
      menuItemType: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
    });

  }

  public validateControl = (controlName: string) => {
    if (this.menuItemTypeForm.controls[controlName].invalid && this.menuItemTypeForm.controls[controlName].touched)
      return true;
 
    return false; 
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.menuItemTypeForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public create = (Value) => {
    if (this.menuItemTypeForm.valid) {
      this.executeCreation(Value);
    }
  }
  private executeCreation = (Value) => {

    const MenuItemType: CreateMenuItemType = {
    //supplierId: supplierFormValue.Id,
    menuItemType:Value.menuItemType
    
    }
 
    const apiUrl = 'api/menuitemtype';
    this.repository.create(apiUrl, MenuItemType)
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
    this.router.navigate(['/menuitemtype/list']); 
  }

}
