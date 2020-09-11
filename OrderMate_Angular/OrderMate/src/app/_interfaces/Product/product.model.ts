export interface Product{
    productId:string;
    productName:string;
    productDescription:string;
    productReorderLevel:string;
    productOnHand:string;
    
    productTypeIdFk:string;
    productCategoryIdFk:string;
    productReorderFreqIdFk:string;
}