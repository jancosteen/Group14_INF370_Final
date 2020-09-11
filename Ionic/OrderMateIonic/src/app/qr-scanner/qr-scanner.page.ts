import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ToastController, LoadingController, Platform, NavController } from '@ionic/angular';
import jsQR, { QRCode } from 'jsqr';
import { AuthenticationService } from '../services/authentication.service';
import { RepositoryService } from '../shared/services/repository.service';
import { Restaurant } from '../_interfaces/restaurant.model';
import { QrCode } from '../_interfaces/qrCode.model';
import { qrCodeSeating } from '../_interfaces/ForCreation/qrCodeSeatingForCreation.model';
import { ErrorHandlerService } from '../shared/services/error-handler.service';



@Component({
  selector: 'app-qr-scanner',
  templateUrl: './qr-scanner.page.html',
  styleUrls: ['./qr-scanner.page.scss'],
})
export class QrScannerPage {

  @ViewChild('video', { static: false }) video: ElementRef;
  @ViewChild('canvas', { static: false }) canvas: ElementRef;
  @ViewChild('fileinput', { static: false }) fileinput: ElementRef;

  canvasElement: any;
  videoElement: any;
  canvasContext: any;
  scanActive = false;
  scanResult: string = null;
  loading: HTMLIonLoadingElement = null;
  qrCodeId:number;
  seatingId:number;
  seatingIdString:string;
  qrCodeIdString:string;
  restaurant: Restaurant[];
  restaurantIdString:string;
  qrCode: QrCode;
  slashIndex1:number;
  slashIndex2:number;
  countResult:number;
  resId;
  qrCodeSeating: qrCodeSeating;
  scanResutlString: string;
  public errorMessage: string = '';

  constructor(
    private toastCtrl: ToastController,
    private loadingCtrl: LoadingController,
    private plt: Platform,
    private authService: AuthenticationService,
    private repository:RepositoryService,
    private nav: NavController,
    private errorHandler: ErrorHandlerService
    //private storage:Storage
  ) { 
    const isInStandaloneMode = () =>
      'standalone' in window.navigator && window.navigator['standalone'];
    if (this.plt.is('ios') && isInStandaloneMode()) {
      console.log('I am a an iOS PWA!');
      // E.g. hide the scan functionality!
  }
}

  ngAfterViewInit() {
    this.canvasElement = this.canvas.nativeElement;
    this.canvasContext = this.canvasElement.getContext('2d');
    this.videoElement = this.video.nativeElement;
  }

  // Helper functions
  async showQrToast() {
    const toast = await this.toastCtrl.create({
      message: `Open ${this.scanResult}?`,
      position: 'top',
      buttons: [
        {
          text: 'Ok',
          handler: () => {
            //window.open(this.scanResult, '_system', 'location=yes');//
              this.scanResutlString = this.scanResult;
              this.slashIndex1 = this.scanResutlString.indexOf("/");
              this.slashIndex2 = this.scanResutlString.lastIndexOf("/")
              this.countResult = this.scanResutlString.length;
              this.qrCodeIdString = this.scanResutlString.slice(1,this.slashIndex2);
              this.seatingIdString = this.scanResutlString.slice(this.slashIndex2+1,this.countResult);
              this.qrCodeId = +this.qrCodeIdString;
              this.seatingId = +this.seatingIdString;   
              localStorage.setItem('qrCodeId',this.qrCodeIdString);
              localStorage.setItem('seatingId', this.seatingIdString);          
              console.log(this.qrCodeIdString,this.seatingIdString);               
            }
        }
      ]
    });
    this.authService.checkedInState.next(true);
    toast.present();
  }

  onClick(string1,string2){
    const apiUrl = `api/qrCodeSeating/${string1}/${string2}`;
    this.repository.create(apiUrl,'')
          .subscribe(res => {                
            this.qrCodeSeating = res as qrCodeSeating;
            this.qrCodeId = this.qrCodeSeating.qrCodeIdFk;                           
            });
    this.getRestaurantDetails(string1);
    
  }

  getRestaurantDetails(id){
      let apiUrl: string = `api/qrCode/${id}/detail`
      this.repository.getData(apiUrl)
        .subscribe(res=>{          
          this.qrCode = res as QrCode;  
          this.restaurant = this.qrCode.restaurant;          
          console.log(this.qrCode.restaurantIdFk); 
          this.navigateToRestaurant(this.qrCode.restaurantIdFk);
        },
        (error) => {
          this.errorHandler.handleError(error);
          this.errorMessage = this.errorHandler.errorMessage;
        });        
  }

  navigateToRestaurant(resId){
    const detailsUrl: string =`/restaurant/${resId}`;
    this.nav.navigateRoot(detailsUrl);
  }
 
  reset() {
    this.scanResult = null;
  }
 
  stopScan() {
    this.scanActive = false;
  }

  async startScan() {
    // Not working on iOS standalone mode!
    const stream = await navigator.mediaDevices.getUserMedia({
      video: { facingMode: 'environment' }
    });
   
    this.videoElement.srcObject = stream;
    // Required for Safari
    this.videoElement.setAttribute('playsinline', true);
   
    this.loading = await this.loadingCtrl.create({});
    await this.loading.present();
   
    this.videoElement.play();
    requestAnimationFrame(this.scan.bind(this));
  }
   
  async scan() {
    if (this.videoElement.readyState === this.videoElement.HAVE_ENOUGH_DATA) {
      if (this.loading) {
        await this.loading.dismiss();
        this.loading = null;
        this.scanActive = true;
      }
   
      this.canvasElement.height = this.videoElement.videoHeight;
      this.canvasElement.width = this.videoElement.videoWidth;
   
      this.canvasContext.drawImage(
        this.videoElement,
        0,
        0,
        this.canvasElement.width,
        this.canvasElement.height
      );
      const imageData = this.canvasContext.getImageData(
        0,
        0,
        this.canvasElement.width,
        this.canvasElement.height
      );
      const code = jsQR(imageData.data, imageData.width, imageData.height, {
        inversionAttempts: 'dontInvert'
      });
   
      if (code) {
        this.scanActive = false;
        this.scanResult = code.data;
        //this.showQrToast();
        this.scanResutlString = this.scanResult;
              this.slashIndex1 = this.scanResutlString.indexOf("/");
              this.slashIndex2 = this.scanResutlString.lastIndexOf("/")
              this.countResult = this.scanResutlString.length;
              this.qrCodeIdString = this.scanResutlString.slice(1,this.slashIndex2);
              this.seatingIdString = this.scanResutlString.slice(this.slashIndex2+1,this.countResult);
              this.qrCodeId = +this.qrCodeIdString;
              this.seatingId = +this.seatingIdString;   
              localStorage.setItem('qrCodeId',this.qrCodeIdString);
              localStorage.setItem('seatingId', this.seatingIdString);          
              console.log(this.qrCodeIdString,this.seatingIdString); 
              this.authService.checkedInState.next(true);
        
      } else {
        if (this.scanActive) {
          requestAnimationFrame(this.scan.bind(this));
        }
      }
    } else {
      requestAnimationFrame(this.scan.bind(this));
    }
    
  }

captureImage() {
  this.fileinput.nativeElement.click();
}
 
handleFile(files: FileList) {
  const file = files.item(0);
 
  var img = new Image();
  img.onload = () => {
    this.canvasContext.drawImage(img, 0, 0, this.canvasElement.width, this.canvasElement.height);
    const imageData = this.canvasContext.getImageData(
      0,
      0,
      this.canvasElement.width,
      this.canvasElement.height
    );
    const code = jsQR(imageData.data, imageData.width, imageData.height, {
      inversionAttempts: 'dontInvert'
    });
 
    if (code) {
      this.scanResult = code.data;
      //this.showQrToast();
      this.scanResutlString = this.scanResult;
              this.slashIndex1 = this.scanResutlString.indexOf("/");
              this.slashIndex2 = this.scanResutlString.lastIndexOf("/")
              this.countResult = this.scanResutlString.length;
              this.qrCodeIdString = this.scanResutlString.slice(1,this.slashIndex2);
              this.seatingIdString = this.scanResutlString.slice(this.slashIndex2+1,this.countResult);
              this.qrCodeId = +this.qrCodeIdString;
              this.seatingId = +this.seatingIdString;   
              localStorage.setItem('qrCodeId',this.qrCodeIdString);
              localStorage.setItem('seatingId', this.seatingIdString);          
              console.log(this.qrCodeIdString,this.seatingIdString); 
              this.authService.checkedInState.next(true);
    }
  };
  img.src = URL.createObjectURL(file);
  
  }

  logout() {
    this.authService.logout();
  }
}
