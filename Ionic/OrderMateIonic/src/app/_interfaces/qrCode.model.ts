import { Restaurant } from './restaurant.model';

export interface QrCode{
    qrCodeId:number;
    restaurantIdFk?:number;

    restaurant:Restaurant[];
}