export interface OrdersBetween {
    dateFrom: Date,
    dateTo: Date
}


export interface ReturnfromOrdersBetween {
    orderId: number;
    orderDateCreated: Date; 
}