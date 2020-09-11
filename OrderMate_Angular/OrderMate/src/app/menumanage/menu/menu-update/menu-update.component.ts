import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {Menu} from '../../../_interfaces/menumange/Menu/menu.model';

@Component({
  selector: 'app-menu-update',
  templateUrl: './menu-update.component.html',
  styleUrls: ['./menu-update.component.css']
})
export class MenuUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public menuForm: FormGroup; 

  public menu: Menu; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.menuForm = new FormGroup({
      menuId: new FormControl(''), 
      menuName: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
      menuDescription: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
      menuDateCreated: new FormControl('',[Validators.required, ]), 
      menuTimeActiveFrom: new FormControl('',[Validators.required]), 
      menuTimeActiveTo: new FormControl('',[Validators.required]), 
      restaurant: new FormControl('',[Validators.required, Validators.maxLength(100)]), 
    });
    this.getById();
  }

  private getById = () => {
    let ProductCategoryId: string = this.activeRoute.snapshot.params['id'];
      
    let productCategoryIdByIdUrl: string = 'api/menu/'+ProductCategoryId;
   
    this.repository.getData(productCategoryIdByIdUrl)
      .subscribe(res => {
        this.menu = res as Menu;
     
        this.menuForm.patchValue(this.menu);

      },
      (error) => { 
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
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

  public redirectToList(){
    this.router.navigate(['/menu/list']);
  }

  public update = (Value) => {
    if (this.menuForm.valid) {
      this.executeUpdate(Value);
    }
  }

  private executeUpdate = (Value) => { 
  
    this.menu.menuName =  Value.menuName,
    this.menu.menuDescription = Value.menuDescription,
    this.menu.menuDateCreated = Value.menuDateCreated,
    this.menu.menuTimeActiveFrom = Value.menuTimeActiveFrom,
    this.menu.menuTimeActiveTo = Value.menuTimeActiveTo,
    this.menu.restaurant = Value.restaurant
    
   
    let apiUrl = 'api/menu/' + this.menu.menuId;
    this.repository.update(apiUrl, this.menu)
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
