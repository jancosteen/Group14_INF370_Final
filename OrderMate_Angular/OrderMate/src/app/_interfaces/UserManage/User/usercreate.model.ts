import {Employee} from '../../EmployeeManage/Employee/employee.model'
import {UserRoles} from '../UserRoles/userroles.model'

export interface CreateUser {
    userName:string;
    email:string; 
    password:string;
    confirmPassword:string;
    user_Name:string;
    user_Surname:string;
    user_Contact_Number:number;
    userRoleName?:string;
    userRoleIdFk?:string; 
    employeeIdFk?:Employee;
   
}