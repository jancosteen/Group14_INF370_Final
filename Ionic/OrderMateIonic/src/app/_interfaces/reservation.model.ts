export interface Reservation{
    reservationId:number,
    reservationDateCreated: string,
        reservationDateReserved: string,
        reservationPartyQty: string,
        userIdFk: string,
        reservationStatusIdFk?: number,
        reservationNumberOfBills: string,
}