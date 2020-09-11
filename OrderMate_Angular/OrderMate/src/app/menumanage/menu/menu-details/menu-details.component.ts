import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import { Menu } from '../../../_interfaces/menumange/Menu/menu.model'

@Component({
  selector: 'app-menu-details',
  templateUrl: './menu-details.component.html',
  styleUrls: ['./menu-details.component.css']
})
export class MenuDetailsComponent implements OnInit {

  public menu: Menu;
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
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

  public redirectToUpdatePage = (menuId) => { 
    const updateUrl: string = '/menu/update/' + menuId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (menuId) => { 
    const deleteUrl: string = '/menu/delete/' + menuId; 
    this.router.navigate([deleteUrl]); 
  } 

} 
