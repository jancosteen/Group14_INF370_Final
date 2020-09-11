import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import {Menu} from '../../../_interfaces/menumange/Menu/menu.model'

@Component({
  selector: 'app-menu-delete',
  templateUrl: './menu-delete.component.html',
  styleUrls: ['./menu-delete.component.css']
})
export class MenuDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public menu: Menu; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails();  
    }
  
  
    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/menu/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.menu = res as Menu;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }



  public delete = () => {
    const deleteUrl: string = 'api/menu/' + this.menu.menuId ;

    this.repository.delete(deleteUrl)
      .subscribe(res => {
 
        $('#successModal').modal();
      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }

  public redirectToList(){
    this.router.navigate(['/menu/list']);
  }

}
