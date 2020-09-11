import { Component, OnInit } from '@angular/core'; 
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router } from '@angular/router';

import {CreateMenu} from '../../../_interfaces/menumange/Menu/menucreate.model'

@Component({
  selector: 'app-menu-create',
  templateUrl: './menu-create.component.html',
  styleUrls: ['./menu-create.component.css']
})
export class MenuCreateComponent implements OnInit {

  public errorMessage: string = '';
 
  public menuForm: FormGroup; 

  constructor( private errorHandler: ErrorHandlerService, private repository: RepositoryService,
     private router: Router ) { }

  ngOnInit(): void {
 
    this.menuForm = new FormGroup({
      menuName: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
      menuDescription: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
      menuDateCreated: new FormControl('',[Validators.required, ]), 
      menuTimeActiveFrom: new FormControl('',[Validators.required]), 
      menuTimeActiveTo: new FormControl('',[Validators.required]), 
      restaurant: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
    });

  }

  public validateControl = (controlName: string) => {
    if (this.menuForm.controls[controlName].invalid && this.menuForm.controls[controlName].touched)
      return true;
 
    return false; 
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.menuForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public create = (Value) => {
    if (this.menuForm.valid) {
      this.executeCreation(Value);
    }
  }
  private executeCreation = (Value) => {

    const MenuItemCategory: CreateMenu = {
    //supplierId: supplierFormValue.Id,
   
    menuName: Value.menuName,
    menuDescription: Value.menuDescription,
      menuDateCreated: Value.menuTimeActiveFrom,
      menuTimeActiveFrom: Value.menuTimeActiveFrom,
      menuTimeActiveTo: Value.menuTimeActiveTo,
      restaurant: Value.restaurant,
    
    }
 
    const apiUrl = 'api/menu';
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
    this.router.navigate(['/menu/list']);
  }

}
