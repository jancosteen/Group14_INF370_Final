using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMate_Server
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Supplier, SupplierDto>();
            CreateMap<Supplier, SupplierDetailsDto>();

            CreateMap<SupplierOrder, SupplierOrderDto>();
            CreateMap<SupplierOrder, SupplierOrderDetailsDto>();

            CreateMap<SupplierOrderLine, SupplierOrderLineDto>();
            CreateMap<SupplierOrderLine, SupplierOrderLineDetailsDto>();

            //Create Supplier
            CreateMap<SupplierForCreationDto, Supplier>();
            CreateMap<SupplierOrderForCreationDto, SupplierOrder>();
            CreateMap<SupplierOrderLineForCreationDto, SupplierOrderLine>();
            CreateMap<ProductCategoryForCreationDto, ProductCategory>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductTypeForCreationDto, ProductType>();
            CreateMap<ProductReorderFreqForCreationDto, ProductReorderFreq>();
            CreateMap<ProductWrittenOffForCreationDto, ProductWrittenOff>();
            CreateMap<WrittenOffStockForCreationDto, WrittenOffStock>();
            CreateMap<WriteOffReasonForCreationDto, WriteOffReason>();

            //Update Supplier
            CreateMap<SupplierForUpdateDto, Supplier>();
            CreateMap<SupplierOrderLineForUpdateDto, SupplierOrderLine>();
            CreateMap<SupplierOrderForUpdateDto, SupplierOrder>();

            CreateMap<ProductForUpdateDto, Product>();
            CreateMap<ProductTypeForUpdateDto, ProductType>();
            CreateMap<ProductCategoryForUpdateDto, ProductCategory>();
            CreateMap<ProductReorderFreqForUpdateDto, ProductReorderFreq>();

            CreateMap<ProductWrittenOffForUpdateDto, ProductWrittenOff>();
            CreateMap<WrittenOffStockForUpdateDto, WrittenOffStock>();
            CreateMap<WriteOffReasonForUpdateDto, WriteOffReason>();

            //View productTypes
            CreateMap<ProductType, ProductTypeDto>();
            CreateMap<ProductType, ProductTypeDetailsDto>();
            CreateMap<Product, ProductDto>();

            //view productCat
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategory, ProductCategoryDetailsDto>();
            //view productReorderFreq
            CreateMap<ProductReorderFreq, ProductReorderFreqDto>();
            CreateMap<ProductReorderFreq, ProductReorderFreqDetailsDto>();
            //productDetailsDto
            CreateMap<Product, ProductDetailsDto>();

            //Write Offs
            CreateMap<ProductWrittenOff, ProductWrittenOffDto>();
            CreateMap<ProductWrittenOff, ProductWrittenOffDetailsDto>();

            CreateMap<WriteOffReason, WriteOffReasonDto>();
            CreateMap<WriteOffReason, WriteOffReasonDetailsDto>();

            CreateMap<WrittenOffStock, WrittenOffStockDto>();
            CreateMap<WrittenOffStock, WrittenOffStockDetailsDto>();

            //StockTake
            CreateMap<ProductStockTake, ProductStockTakeDto>();
            CreateMap<ProductStockTake, ProductStockTakeDetailsDto>();
            CreateMap<StockTake, StockTakeDto>();
            CreateMap<StockTake, StockTakeDetailsDto>();

            //Create
            CreateMap<ProductStockTakeForCreationDto, ProductStockTake>();
            CreateMap<StockTakeForCreationDto, StockTake>();

            //Update
            CreateMap<ProductStockTakeForUpdateDto, ProductStockTake>();
            CreateMap<StockTakeForUpdateDto, StockTake>();

            //View
            CreateMap<Employee, EmployeeDetailsDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeShift, EmployeeShiftDetailsDto>();
            CreateMap<EmployeeShift, EmployeeShiftDto>();
            CreateMap<Shift, ShiftDetailsDto>();
            CreateMap<Shift, ShiftDto>();
            CreateMap<ShiftStatus, ShiftStatusDetailsDto>();
            CreateMap<ShiftStatus, ShiftStatusDto>();
            CreateMap<AttendanceSheet, AttendanceSheetDetailsDto>();
            CreateMap<AttendanceSheet, AttendanceSheetDto>();

            CreateMap<Allergy, AllergyDto>();
            CreateMap<Allergy, AllergyDetailsDto>();
            CreateMap<MenuItemAllergy, MenuItem_AllergyDto>();
            CreateMap<MenuItemAllergy, MenuItem_AllergyDetailsDto>();
            CreateMap<MenuItemCategory, MenuItemCategoryDto>();
            CreateMap<MenuItemCategory, MenuItemCategoryDetailsDto>();
            CreateMap<MenuItemSpecial, MenuItem_SpecialDto>();
            CreateMap<MenuItemSpecial, MenuItem_SpecialDetailsDto>();

            CreateMap<MenuItemPrice, MenuItem_PriceDto>();
            CreateMap<MenuItemPrice, MenuItem_PriceDetailsDto>();

            CreateMap<ItemTypeMenuMenuItem, MenuItem_ItemTypeDetailsDto>();
            CreateMap<ItemTypeMenuMenuItem, MenuItem_ItemTypeDto>();
            CreateMap<MenuItem, MenuItemDto>();
            CreateMap<MenuItem, MenuItemDetailsDto>();

            CreateMap<MenuItemPrice, MenuItem_PriceDto>();
            CreateMap<MenuItemPrice, MenuItem_PriceDetailsDto>();

            CreateMap<Menu, MenuDto>();
            CreateMap<Menu, MenuDetailsDto>();
            CreateMap<ReservationStatus, ReservationStatusDto>();
            CreateMap<ReservationStatus, ReservationStatusDetailsDto>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<Reservation, ReservationDetailsDto>();
            CreateMap<SpecialPrice, SpecialPriceDto>();
            CreateMap<SpecialPrice, SpecialPriceDetailsDto>();
            CreateMap<Special, SpecialDto>();
            CreateMap<Special, SpecialDetailsDto>();
           // CreateMap<UserRole, UserRoleDetailsDto>();
          //  CreateMap<UserRole, UserRoleDto>();
            CreateMap<User, UserDto>();
            CreateMap<User, UserDetailsDto>();

            //Create
            CreateMap<EmployeeForCreationDto, Employee>();
            CreateMap<EmployeeShiftForCreationDto, EmployeeShift>();
            CreateMap<ShiftForCreationDto, Shift>();
            CreateMap<ShiftStatusForCreationDto, ShiftStatus>();
            CreateMap<AttendanceSheetForCreationDto, AttendanceSheet>();

            CreateMap<AllergyForCreationDto, Allergy>();
            CreateMap<MenuItem_AllergyForCreationDto, MenuItemAllergy>();
            CreateMap<MenuItemCategoryForCreationDto, MenuItemCategory>();
            CreateMap<MenuItem_ItemTypeForCreationDto, ItemTypeMenuMenuItem>();
            CreateMap<MenuItem_PriceForCreationDto, MenuItemPrice>();
            CreateMap<MenuItem_SpecialForCreationDto, MenuItemSpecial>();
            CreateMap<MenuItemTypeForCreationDto, MenuItemType>();
            CreateMap<MenuItemForCreationDto, MenuItem>();
            CreateMap<MenuForCreationDto, Menu>();
            CreateMap<ReservationStatusForCreationDto, ReservationStatus>();
            CreateMap<ReservationForCreationDto, Reservation>();
            CreateMap<SpecialForCreationDto, Special>();
            CreateMap<SpecialPriceForCreationDto, SpecialPrice>();
            CreateMap<UserForCreationDto, User>();
        //    CreateMap<UserRoleForCreationDto, UserRole>();

            //Update
            CreateMap<EmployeeForUpdateDto, Employee>();
            CreateMap<EmployeeShiftForUpdateDto, EmployeeShift>();
            CreateMap<ShiftForUpdateDto, Shift>();
            CreateMap<ShiftStatusForUpdateDto, ShiftStatus>();
            CreateMap<AttendanceSheetForUpdateDto, AttendanceSheet>();

            CreateMap<AllergyForUpdateDto, Allergy>();
            CreateMap<MenuItem_AllergyForUpdateDto, MenuItemAllergy>();
            CreateMap<MenuItemCategoryForUpdateDto, MenuItemCategory>();
            CreateMap<MenuItem_ItemTypeForUpdateDto, ItemTypeMenuMenuItem>();
            CreateMap<MenuItem_PriceForUpdateDto, MenuItemPrice>();
            CreateMap<MenuItem_SpecialForUpdateDto, MenuItemSpecial>();
            CreateMap<MenuItemTypeForUpdateDto, MenuItemType>();
            CreateMap<MenuItemForUpdateDto, MenuItem>();
            CreateMap<MenuForUpdateDto, Menu>();
            CreateMap<ReservationStatusForUpdateDto, ReservationStatus>();
            CreateMap<ReservationForUpdateDto, Reservation>();
            CreateMap<SpecialForUpdateDto, Special>();
            CreateMap<SpecialPriceForUpdateDto, SpecialPrice>();
            CreateMap<UserForUpdateDto, User>();
        //    CreateMap<UserRoleForUpdateDto, UserRole>();

            CreateMap<AdvertisementDate, Advertisement_DateDto>();
            CreateMap<AdvertisementDate, Advertisement_DateDetailsDto>();
            CreateMap<Advertisement_DateForUpdateDto, AdvertisementDate>();
            CreateMap<Advertisement_DateForCreationDto, AdvertisementDate>();

            CreateMap<AdvertisementPrice, Advertisement_PriceDto>();
            CreateMap<AdvertisementPrice, Advertisement_PriceDetailsDto>();
            CreateMap<Advertisement_PriceForUpdateDto, AdvertisementPrice>();
            CreateMap<Advertisement_PriceForCreationDto, AdvertisementPrice>();

            CreateMap<Advertisement, AdvertisementDto>();
            CreateMap<Advertisement, AdvertisementDetailsDto>();
            CreateMap<AdvertisementForUpdateDto, Advertisement>();
            CreateMap<AdvertisementForCreationDto, Advertisement>();

            CreateMap<LayoutType, Layout_TypeDto>();
            CreateMap<LayoutType, Layout_TypeDetailsDto>();
            CreateMap<Layout_TypeForUpdateDto, LayoutType>();
            CreateMap<Layout_TypeForCreationDto, LayoutType>();

            CreateMap<RestaurantAdvertisement, Restaurant_AdvertisementDto>();
            CreateMap<RestaurantAdvertisement, Restaurant_AdvertisementDetailsDto>();
            CreateMap<Restaurant_AdvertisementForUpdateDto, RestaurantAdvertisement>();
            CreateMap<Restaurant_AdvertisementForCreationDto, RestaurantAdvertisement>();

            CreateMap<ResaurantFacilityRef, Restaurant_Facility_RefDto>();
            CreateMap<ResaurantFacilityRef, Restaurant_Facility_RefDetailsDto>();
            CreateMap<Restaurant_Facility_RefForUpdateDto, ResaurantFacilityRef>();
            CreateMap<Restaurant_Facility_RefForCreationDto, ResaurantFacilityRef>();

            CreateMap<RestaurantImage, Restaurant_ImageDto>();
            CreateMap<RestaurantImage, Restaurant_ImageDetailsDto>();
            CreateMap<Restaurant_ImageForUpdateDto, RestaurantImage>();
            CreateMap<Restaurant_ImageForCreationDto, RestaurantImage>();

            CreateMap<RestaurantStatus, Restaurant_StatusDto>();
            CreateMap<RestaurantStatus, Restaurant_StatusDetailsDto>();
            CreateMap<Restaurant_StatusForUpdateDto, RestaurantStatus>();
            CreateMap<Restaurant_StatusForCreationDto, RestaurantStatus>();

            CreateMap<RestaurantType, Restaurant_TypeDto>();
            CreateMap<RestaurantType, Restaurant_TypeDetailsDto>();
            CreateMap<Restaurant_TypeForUpdateDto, RestaurantType>();
            CreateMap<Restaurant_TypeForCreationDto, RestaurantType>();

            CreateMap<RestaurantTypeReference, Restaurant_Type_RefDto>();
            CreateMap<RestaurantTypeReference, Restaurant_Type_RefDetailsDto>();
            CreateMap<Restaurant_Type_RefForUpdateDto, RestaurantTypeReference>();
            CreateMap<Restaurant_Type_RefForCreationDto, RestaurantTypeReference>();

            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<Restaurant, RestaurantDetailsDto>();
            CreateMap<RestaurantForUpdateDto, Restaurant>();
            CreateMap<RestaurantForCreationDto, Restaurant>();

            CreateMap<SeatingLayout, Seating_LayoutDto>();
            CreateMap<SeatingLayout, Seating_LayoutDetailsDto>();
            CreateMap<Seating_LayoutForUpdateDto, SeatingLayout>();
            CreateMap<Seating_LayoutForCreationDto, SeatingLayout>();

            CreateMap<SocialMedia, SocialMediaDto>();
            CreateMap<SocialMedia, SocialMediaDetailsDto>();
            CreateMap<SocialMediaForUpdateDto, SocialMedia>();
            CreateMap<SocialMediaForCreationDto, SocialMedia>();

            CreateMap<SocialMediaType, SocialMedia_TypeDto>();
            CreateMap<SocialMediaType, SocialMedia_TypeDetailsDto>();
            CreateMap<SocialMedia_TypeForUpdateDto, SocialMediaType>();
            CreateMap<SocialMedia_TypeForCreationDto, SocialMediaType>();

            CreateMap<StarRating, Star_RatingDto>();
            CreateMap<StarRating, Star_RatingDetailsDto>();
            CreateMap<Star_RatingForUpdateDto, StarRating>();
            CreateMap<Star_RatingForCreationDto, StarRating>();

            CreateMap<UserComment, User_CommentDto>();
            CreateMap<UserComment, User_CommentDetailsDto>();
            CreateMap<User_CommentForUpdateDto, UserComment>();
            CreateMap<User_CommentForCreationDto, UserComment>();

            CreateMap<Seating, SeatingDto>();
            CreateMap<Seating, SeatingDetailsDto>();
            CreateMap<SeatingForUpdateDto, Seating>();
            CreateMap<SeatingForCreationDto, Seating>();

            CreateMap<RestaurantFacility, Restaurant_FacilityDto>();
            CreateMap<RestaurantFacility, Restaurant_FacilityDetailsDto>();
            CreateMap<Restaurant_FacilityForUpdateDto, RestaurantFacility>();
            CreateMap<Restaurant_FacilityForCreationDto, RestaurantFacility>();

            CreateMap<QrCode, QrCodeDto>();
            CreateMap<QrCode, QrCodeDetailsDto>();
            CreateMap<QrCodeForUpdateDto, QrCode>();
            CreateMap<QrCodeForCreationDto, QrCode>();

            CreateMap<QrCodeSeating, QrCode_SeatingDto>();
            CreateMap<QrCodeSeating, QrCode_SeatingDetailsDto>();
            CreateMap<QrCode_SeatingForUpdateDto, QrCodeSeating>();
            CreateMap<QrCode_SeatingForCreationDto, QrCodeSeating>();

            CreateMap<Order, OrderDto>();
            CreateMap<Order, OrderDetailsDto>();
            CreateMap<OrderForUpdateDto, Order>();
            CreateMap<OrderForCreationDto, Order>();

            CreateMap<OrderStatus, Order_StatusDto>();
            CreateMap<OrderStatus, Order_StatusDetailsDto>();
            CreateMap<Order_StatusForUpdateDto, OrderStatus>();
            CreateMap<Order_StatusForCreationDto, OrderStatus>();

            CreateMap<OrderLine, Order_LineDto>();
            CreateMap<OrderLine, Order_LineDetailsDto>();
            CreateMap<Order_LineForUpdateDto, OrderLine>();
            CreateMap<Order_LineForCreationDto, OrderLine>();




        }
    }
}
