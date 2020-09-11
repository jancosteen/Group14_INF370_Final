import {Product} from '../../Product/product.model'
import{SupplierOrder} from '../SupplierOrder/supplierorder.model'

export interface CreateSupplierOrderLine {

    supplierOrder:SupplierOrder;
    deliveryLeadTime: Date;
    productStandardPrice: string;
    discountAgreement:string;
    orderedQty:string;
    product:Product;

}