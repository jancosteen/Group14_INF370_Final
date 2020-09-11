import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {MenuItemType} from '../../../../_interfaces/menumange/menuitemtype/menuitemtype.model'

@Component({
  selector: 'app-menuitemtype-update',
  templateUrl: './menuitemtype-update.component.html',
  styleUrls: ['./menuitemtype-update.component.css']
})
export class MenuitemtypeUpdateComponent implements OnInit {
  public errorMessage: string = '';
 
  public menuItemTypeForm: FormGroup; 

  public menuItemType: MenuItemType; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.menuItemTypeForm = new FormGroup({
      menuItemType: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
    });
    this.getById();
  }


  private getById = () => {
    let ProductCategoryId: string = this.activeRoute.snapshot.params['id'];
      
    let productCategoryIdByIdUrl: string = 'api/menuItemType/'+ProductCategoryId;
   
    this.repository.getData(productCategoryIdByIdUrl)
      .subscribe(res => {
        this.menuItemType = res as MenuItemType;
     
        this.menuItemTypeForm.patchValue(this.menuItemType);

      },
      (error) => { 
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
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

  public redirectToList(){
    this.router.navigate(['/menuItemType/list']);
  }

  public update = (Value) => {
    if (this.menuItemTypeForm.valid) {
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => { 
  
    this.menuItemType.menuItemTypeId =  Value.menuItemTypeId,
    this.menuItemType.menuItemType = Value.menuItemType
    
   
    let apiUrl = 'api/menuItemType/' + this.menuItemType.menuItemTypeId;
    this.repository.update(apiUrl, this.menuItemType)
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
