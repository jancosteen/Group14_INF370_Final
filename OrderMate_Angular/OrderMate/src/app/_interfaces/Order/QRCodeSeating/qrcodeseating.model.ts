import {Order} from '../../../_interfaces/Order/Order/order.model'
import {QrCode} from '../../../_interfaces/Order/QRCode/qrcode.model'
import {Seating} from '../../../_interfaces/Order/Seating/seating.model'

export interface QrCodeSeating {
    qrCodeSeatingId: number;
    numberOfPeople: number;
    qrCode:QrCode;
    Seating: Seating;
    Order: Order;
}  