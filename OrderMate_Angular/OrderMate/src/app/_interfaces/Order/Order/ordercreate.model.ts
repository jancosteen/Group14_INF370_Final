import {QrCodeSeating} from '../QRCodeSeating/qrcodeseating.model'
export interface CreateOrder {
    orderDateCreated: Date; 
    orderDateCompleted: Date;
    qrCodeSeating: number;
}

