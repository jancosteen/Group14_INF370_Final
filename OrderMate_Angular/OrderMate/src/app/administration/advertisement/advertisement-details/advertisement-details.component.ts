import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from './../../../shared/services/repository.service';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';

import {Advertisement} from '../../../_interfaces/Administration/Advertisements/advertisement.model'

@Component({
  selector: 'app-advertisement-details',
  templateUrl: './advertisement-details.component.html',
  styleUrls: ['./advertisement-details.component.css']
})
export class AdvertisementDetailsComponent implements OnInit { 

  public advertisement: Advertisement;
  public errorMessage: string = '';

  constructor(private repository: RepositoryService, private router: Router, 
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }
  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    //console.log('id',id);
    let apiUrl: string = 'api/advertisement/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.advertisement = res as Advertisement;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (advertisementId) => { 
    const updateUrl: string = '/advertisement/update/' + advertisementId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (advertisementId) => { 
    const deleteUrl: string = '/advertisement/delete/' + advertisementId; 
    this.router.navigate([deleteUrl]); 
  }

}
