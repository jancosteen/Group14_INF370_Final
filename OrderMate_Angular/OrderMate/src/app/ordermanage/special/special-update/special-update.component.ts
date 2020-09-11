import { Component, OnInit } from '@angular/core'; 
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ErrorHandlerService } from './../../../shared/services/error-handler.service';
import { RepositoryService } from './../../../shared/services/repository.service';
import { Router, ActivatedRoute } from '@angular/router';  

import {Special} from '../../../../app/_interfaces/Order/Special/special.model'; 

@Component({
  selector: 'app-special-update',
  templateUrl: './special-update.component.html',
  styleUrls: ['./special-update.component.css']
})
export class SpecialUpdateComponent implements OnInit {

  public errorMessage: string = '';
 
  public specialForm: FormGroup;

  public special: Special; 

  constructor(private repository: RepositoryService, private errorHandler: ErrorHandlerService, private router: Router,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.specialForm = new FormGroup({
      specialId: new FormControl(''),
      specialStartDate: new FormControl('',[Validators.required]),
      specialEndDate: new FormControl('',[Validators.required]),
      specialDescription: new FormControl('',[Validators.required, Validators.maxLength(100)]),
    });

    this.getSpecialById();
  }

  private getSpecialById = () => {
    let specialId: string = this.activeRoute.snapshot.params['id'];
      
    let IdUrl: string = 'api/special/'+specialId;
   
    this.repository.getData(IdUrl)
      .subscribe(res => {
        this.special = res as Special;
     
        this.specialForm.patchValue(this.special);

      },
      (error) => {
        this.errorHandler.handleError(error);
        this.errorMessage = this.errorHandler.errorMessage;
      })
  }
  public validateControl = (controlName: string) => {
    if (this.specialForm.controls[controlName].invalid && this.specialForm.controls[controlName].touched)
      return true;
 
    return false;
  }
 
  public hasError = (controlName: string, errorName: string) => {
    if (this.specialForm.controls[controlName].hasError(errorName))
      return true;
 
    return false;
  }

  public redirectTospecialList(){
    this.router.navigate(['/special/list']);
  }


  public update = (specialPriceFormFormValue) => {
    if (this.specialForm.valid) {
      this.executeUpdate(specialPriceFormFormValue);
    }
  }

  private executeUpdate = (specialPriceFormFormValue) => {
  
    this.special.specialId =  specialPriceFormFormValue.specialId,
    this.special.specialStartDate = specialPriceFormFormValue.specialStartDate,
    this.special.specialEndDate = specialPriceFormFormValue.specialEndDate,
    this.special.specialDescription = specialPriceFormFormValue.specialDescription


    
   
    let apiUrl = 'api/special/' + this.special.specialId;
    this.repository.update(apiUrl, this.special)
      .subscribe(res => {
        $('#successModal').modal();
      },
      (error => {
        this.errorHandler.handleError(error); 
        this.errorMessage = this.errorHandler.errorMessage;
      })
    )
  } 

}
 