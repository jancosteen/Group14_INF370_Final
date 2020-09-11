import { ToastrService } from 'ngx-toastr';
import { RepositoryService } from '../../../shared/services/repository.service';
import { Component, OnInit } from '@angular/core';
import { ReturnfromOrdersBetween } from '../../../_interfaces/Administration/Reports/ordersbetween.model';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { jsPDF } from "jspdf";
import  html2canvas from 'html2canvas';  
import autoTable from 'jspdf-autotable';

@Component({
  selector: 'app-ordersbetween',
  templateUrl: './ordersbetween.component.html',
  styleUrls: ['./ordersbetween.component.css']
})
export class OrdersbetweenComponent implements OnInit {
  returnfromOrdersBetween: ReturnfromOrdersBetween[]
  ordersbetweenForm: FormGroup;
  constructor(private repository: RepositoryService, private toast: ToastrService) { }

  ngOnInit(): void {

    this.ordersbetweenForm = new FormGroup({
      menuItemId: new FormControl(''),
      dateFrom: new FormControl('',[Validators.required]),
      dateTo: new FormControl('',[Validators.required]),
    }); 
  }

  public validateControl = (controlName: string) => {
    if (this.ordersbetweenForm.controls[controlName].invalid && this.ordersbetweenForm.controls[controlName].touched)
      return true;
  
    return false;
  }
  
  public hasError = (controlName: string, errorName: string) => {
    if (this.ordersbetweenForm.controls[controlName].hasError(errorName))
      return true;
  
    return false;
  }


  report(value){
    
  
  
    this.repository.getOrdersBetween(value.dateFrom,value.dateTo) 
      .subscribe(res =>{
        this.returnfromOrdersBetween = res as ReturnfromOrdersBetween[]
        console.log('orders',this.returnfromOrdersBetween)
      },
      err =>{
        this.toast.error('No Orders Between selected Dates.','Report Retrieval Failed.');
      })
  }

  DownloadReport(){
   
    var data = document.getElementById('Content');
    html2canvas(data).then(canvas => {
      var imgWidth = 208;
      var pageHeight = 295;
      var imgHeight = canvas.height * imgWidth /canvas.width;
      var heightLeft = imgHeight;

      const contentDataUrl = canvas.toDataURL('image/png')
      let pdf = new jsPDF('p','mm','a4');
      
      var position = 0;
      pdf.text("Orders Between Two Dates", 80,20);
      autoTable(pdf, {html: '#menuItemsTable'})
      pdf.addImage(contentDataUrl,'PNG',0,position,imgWidth,imgHeight)
      pdf.save('Ordersbetween.pdf');
    });
        
  }

}
