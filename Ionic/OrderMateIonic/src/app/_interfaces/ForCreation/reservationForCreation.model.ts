export interface reservationForCreation{
    reservationDateCreated: string,
        reservationDateReserved: string,
        reservationPartyQty: string,
        userIdFk: string,
        reservationStatusIdFk?: number,
        reservationNumberOfBills: string,
}