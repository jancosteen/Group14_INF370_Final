import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {MenuItem} from '../../../_interfaces/menumange/MenuItem/menuitem.model'

@Component({
  selector: 'app-menuitem-delete',
  templateUrl: './menuitem-delete.component.html',
  styleUrls: ['./menuitem-delete.component.css']
})
export class MenuitemDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public menuItem: MenuItem; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails();  
    }
  
  
    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/menuItem/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.menuItem = res as MenuItem;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }



  public delete = () => {
    const deleteUrl: string = 'api/menuItem/' + this.menuItem.menuItemId ;

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
    this.router.navigate(['/menuItem/list']);
  }

}
