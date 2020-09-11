import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { RepositoryService } from '../../../shared/services/repository.service';
import { ErrorHandlerService } from '../../../shared/services/error-handler.service';

import {QrCodeSeating} from '../../../_interfaces/Order/QRCodeSeating/qrcodeseating.model'

@Component({  
  selector: 'app-qrcodeseating-details',
  templateUrl: './qrcodeseating-details.component.html',
  styleUrls: ['./qrcodeseating-details.component.css']
})
export class QrcodeseatingDetailsComponent implements OnInit {
  public qrCodeSeating: QrCodeSeating;
  public errorMessage: string = ''; 

  constructor(private repository: RepositoryService, private router: Router,  
    private activeRoute: ActivatedRoute, private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getDetails();
  }

  getDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];

    let apiUrl: string = 'api/qrcodeseating/'+id;
 
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.qrCodeSeating = res as QrCodeSeating;
    },
    (error) =>{
      this.errorHandler.handleError(error);
      this.errorMessage = this.errorHandler.errorMessage;
    })
  }

  public redirectToUpdatePage = (qrCodeSeatingId) => { 
    const updateUrl: string = '/qrcodeseating/update/' + qrCodeSeatingId; 
    this.router.navigate([updateUrl]); 
  }

  public redirectToDeletePage = (qrCodeSeatingId) => { 
    const deleteUrl: string = '/qrcodeseating/delete/' + qrCodeSeatingId; 
    this.router.navigate([deleteUrl]); 
  }

}
 