import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {QrCodeSeating} from '../../../_interfaces/Order/QRCodeSeating/qrcodeseating.model'


@Component({
  selector: 'app-qrcodeseating-delete',
  templateUrl: './qrcodeseating-delete.component.html',
  styleUrls: ['./qrcodeseating-delete.component.css']
})
export class QrcodeseatingDeleteComponent implements OnInit {
  public errorMessage: string = '';
  public qrCodeSeating: QrCodeSeating; 
  

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

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


    public delete = () => {
      const deleteUrl: string = 'api/qrcodeseating/' + this.qrCodeSeating.qrCodeSeatingId ;

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
    this.router.navigate(['/qrcodeseating/list']);
  }

}
