export interface Order{
    orderId:number;
    orderDateCreated:Date;
    orderDateCompleted:Date;
    qrCodeSeatingIdFk?:number;
    orderStatus?:number;
}