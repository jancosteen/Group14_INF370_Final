import {SupplierOrder} from './SupplierOrder/supplierorder.model';

export interface Supplier{
    supplierId: string;
    supplierName: string;
    supplierDescription: string;
    supplierEmail: string;
    supplierContactNumber: string;
    supplierAddressLine1: string;
    supplierAddressLine2: string;
    supplierAddressLine3: string;
    supplierCity: string;
    supplierPostalCode: string;
    supplierCountry: string;

    supplierorders?: SupplierOrder[];
}