import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';


import { MenuItem } from '../../../_interfaces/menumange/MenuItem/menuitem.model'

@Component({
  selector: 'app-menuitem-details',
  templateUrl: './menuitem-details.component.html',
  styleUrls: ['./menuitem-details.component.css']
})
export class MenuitemDetailsComponent implements OnInit {

  public menuItem: MenuItem;
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }


  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
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

  public redirectToUpdatePage = (menuId) => { 
    const updateUrl: string = '/menuItem/update/' + menuId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (menuId) => { 
    const deleteUrl: string = '/menuItem/delete/' + menuId; 
    this.router.navigate([deleteUrl]); 
  } 

}
 