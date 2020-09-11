import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './.../../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  



import {MenuItemType} from '../../../_interfaces/menumange/menuitemtype/menuitemtype.model'


import { from } from 'rxjs';
@Component({
  selector: 'app-menuitemtype',
  templateUrl: './menuitemtype.component.html',
  styleUrls: ['./menuitemtype.component.css']
})
export class MenuitemtypeComponent implements OnInit {

  public errorMessage: string = '';
 
  public MenuItemTypeForm: FormGroup;

  public menuItemType: MenuItemType; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.MenuItemTypeForm = new FormGroup({
      menuItemTypeId: new FormControl(''),
      menuItemType: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });

    this.getById();
  }


  private getById = () => {
    let menuItemTypeId: string = this.activeRoute.snapshot.params['id'];
      
    let IdUrl: string = 'api/menuitemtype/'+menuItemTypeId;
   
    this.repository.getData(IdUrl)
      .subscribe(res => {
        this.menuItemType = res as MenuItemType;
     
        this.MenuItemTypeForm.patchValue(this.menuItemType);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public validateControl = (controlName: string) => {
    if (this.MenuItemTypeForm.controls[controlName].invalid && this.MenuItemTypeForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.MenuItemTypeForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectToList(){
    this.router.navigate(['/menuitemtype/list']);
  }

  public update = (Value) => {
    if (this.MenuItemTypeForm.valid) {
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => { 
  
    this.menuItemType.menuItemTypeId =  Value.menuItemTypeId,
    this.menuItemType.menuItemType = Value.menuItemType
    
   
    let apiUrl = 'api/menuitemtype/' + this.menuItemType.menuItemTypeId;
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
 