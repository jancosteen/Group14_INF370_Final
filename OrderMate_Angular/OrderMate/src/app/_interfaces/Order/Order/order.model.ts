import { OrderStatus } from './../OrderStatus/orderstatus.model';
import {QrCodeSeating} from '../QRCodeSeating/qrcodeseating.model'
export interface Order {
    orderId: number;
    orderDateCreated: Date; 
    orderDateCompleted: Date;
    qrCodeSeating: number;
    orderStatus?: string;
}

