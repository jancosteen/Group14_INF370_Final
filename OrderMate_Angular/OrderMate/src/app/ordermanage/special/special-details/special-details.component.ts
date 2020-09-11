import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import {Special} from '../../../_interfaces/Order/Special/special.model';

@Component({
  selector: 'app-special-details',
  templateUrl: './special-details.component.html', 
  styleUrls: ['./special-details.component.css']
})
export class SpecialDetailsComponent implements OnInit {
  public special: Special;
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/special/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.special = res as Special;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (specialId) => { 
    const updateUrl: string = '/special/update/' + specialId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (specialId) => { 
    const deleteUrl: string = '/special/delete/' + specialId; 
    this.router.navigate([deleteUrl]); 
  }


}
