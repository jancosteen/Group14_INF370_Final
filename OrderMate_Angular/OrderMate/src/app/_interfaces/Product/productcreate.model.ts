import {ProductCategory} from './ProductCategory/productCategory.model';
import {ProductType} from './ProductType/productType.model';
import { ReorderFreq} from './ReorderFreq/ReorderFreq.model';

export interface CreateProduct{
    productName:string;
    productDescription:string;
    productReorderLevel:string;
    productOnHand:string;
    
    productTypeIdFk:string;
    productCategoryIdFk:string;
    productReorderFreqIdFk:string;

    productTypes?: ProductType[];
    productCategories?: ProductCategory[];
    ReorderFreq?: ReorderFreq[];
}