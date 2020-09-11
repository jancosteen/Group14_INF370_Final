import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router'; 

import { MenuItemType} from '../../../../_interfaces/menumange/menuitemtype/menuitemtype.model'

@Component({
  selector: 'app-menuitemtype-delete',
  templateUrl: './menuitemtype-delete.component.html',
  styleUrls: ['./menuitemtype-delete.component.css']
})
export class MenuitemtypeDeleteComponent implements OnInit {

  public errorMessage: string = '';
  public menuItemType: MenuItemType; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

    ngOnInit(): void {
      this.getDetails(); 
    }

    getDetails = () => {
      let id: string = this.activeRoute.snapshot.params['id'];
      
      let apiUrl: string = 'api/menuItemType/'+id;
   
      this.repository.getData(apiUrl)
      .subscribe(res => {
        this.menuItemType = res as MenuItemType;
      },
      (error) =>{
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
    }

    public delete = () => {
      const deleteUrl: string = 'api/menuItemType/' + this.menuItemType.menuItemTypeId ;
  
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
      this.router.navigate(['/menuItemType/list']);
    }


} 
