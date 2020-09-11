import { RestaurantStatus } from "../RestaurantStatus/restaurantstatus.model";

export interface CreateRestaurant{
    restaurantId:number;
    restaurantUrl:string;
    restaurantDescription:string;
    restaurantCoordinates:string;
    restaurantDateCreated:Date;
    restaurantAddressLine1:string;
    restaurantAddressLine2:string;
    restaurantAddressLine3:string;
    restaurantCity:string;
    restaurantPostalCode:string;
    restaurantProvince:string;
    restaurantCountry:string;
    restaurantStatus?: RestaurantStatus;
}