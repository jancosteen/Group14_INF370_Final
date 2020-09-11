import {ReservationStatus} from '../../../_interfaces/Reservationmanage/ReservationStatus/reservationstatus.model'
import {User} from '../../../_interfaces/UserManage/User/user.model'

export interface CreateReservation {
    reservationDateCreated: string;
    reservationDateReserved: string;
    reservationPartyQty: number;
    reservationStatusIdFk:number;
    reservationStatusName:string; 
    reservationNumberOfBills:number; 
    userIdFk:string;
    userName?:string;

}