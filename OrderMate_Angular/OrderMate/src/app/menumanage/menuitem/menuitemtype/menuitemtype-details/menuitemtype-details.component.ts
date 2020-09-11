import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';

import {MenuItemType} from '../../../../_interfaces/menumange/menuitemtype/menuitemtype.model'


@Component({
  selector: 'app-menuitemtype-details',
  templateUrl: './menuitemtype-details.component.html',
  styleUrls: ['./menuitemtype-details.component.css']
})
export class MenuitemtypeDetailsComponent implements OnInit {

  public menuItemType: MenuItemType;
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiUrl: string = 'api/menuitemtype/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.menuItemType = res as MenuItemType;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }


  public redirectToUpdatePage = (menuItemTypeId) => { 
    const updateUrl: string = '/menuitemtype/update/' + menuItemTypeId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (menuItemTypeId) => { 
    const deleteUrl: string = '/menuitemtype/delete/' + menuItemTypeId; 
    this.router.navigate([deleteUrl]); 
  }

}
