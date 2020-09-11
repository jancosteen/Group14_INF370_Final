import {ShiftStatus} from '../ShiftStatus/shiftstatus.model';


export interface Shift {
    shiftId: number;
    shiftStartDateTime: Date;
    shiftEndDateTime: Date;
    shiftCapacity: number;
    shiftName: string;
    shiftStatus?: ShiftStatus;
}