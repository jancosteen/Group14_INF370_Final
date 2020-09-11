import { Order } from "../Order/order.model";
import {MenuItem} from '../../../_interfaces/menumange/MenuItem/menuitem.model'
import {Employee} from '../../../_interfaces/EmployeeManage/Employee/employee.model'
import {Special} from '../../../_interfaces/Order/Special/special.model'

export interface CreateOrderLine{
  
    itemQuantity:number; 
    special: Special;
    menuItem: MenuItem;
    Order: Order;
    Employee: Employee;
}


