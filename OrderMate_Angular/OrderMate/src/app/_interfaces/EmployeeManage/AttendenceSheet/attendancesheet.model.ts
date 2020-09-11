//import {Employee} from 'src/app/_interfaces/EmployeeManage/Employee/employee.model';

import {Employee}  from '../Employee/employee.model';

export interface AttendanceSheet {
    attendancesheetId: number;
    clockindatetime: Date;
    clockoutdatetime: Date;
    employee?: Employee;
}