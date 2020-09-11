using Contacts.Interfaces;
using Contacts.IReports;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts
{
    public interface IRepositoryWrapper
    {
        //supplier
        ISupplierRepository Supplier { get; }
        ISupplierOrderRepository SupplierOrder { get; }
        ISupplierOrderLineRepository SupplierOrderLine { get; }

        //Product
        IProduct_TypeRepository Product_Type { get; }
        IProduct_Reorder_FreqRepository Product_Reorder_Freq { get; }
        IProduct_CategoryRepository Product_Category { get; }
        IProductRepository Product { get; }
        IProduct_Stock_TakeRepository Product_Stock_Take { get; }
        IProduct_Written_OffRepository Product_Written_Off { get; }
        IWrite_Off_ReasonRepository Write_Off_Reason { get; }
        IWritten_Off_StockRepository Written_Off_Stock { get; }
        IStock_Take_Repository Stock_Take { get; }
        IEmployeeRepository Employee { get;  }
        IEmployee_ShiftRepository Employee_Shift { get; }
        IShiftRepository Shift { get; }
        IShift_StatusRepository Shift_Status { get; }
        IAttendanceSheetRepository Attendance_Sheet { get; }

        IAllergyRepository Allergy { get; }
        IMenuItem_AllergyRepository MenuItem_Allergy { get; }
        IMenuItem_CategoryRepository MenuItem_Category { get; }
        IMenuItem_ItemTypeRepository MenuItem_ItemType { get; }
        IMenuItem_PriceRepository MenuItem_Price { get; }
        IMenuItem_SpecialRepository MenuItem_Special { get; }
        IMenuItem_TypeRepository MenuItem_Type { get; }
        IMenuItemRepository MenuItem { get; }
        IMenuRepository Menu { get; }
        IReservation_StatusRepository Reservation_Status { get; }
        ISpecialRepository Special { get; }
        ISpecial_PriceRepository Special_Price { get; }
        IUser_RoleRepository User_Role { get; }
        IUserRepository User { get; }
        IAdvertisementRepository Advertisement { get; }
        IAdvertisement_DateRepository Advertisement_Date { get; }
        IAdvertisement_PriceRepository Advertisement_Price { get; }
        ILayout_TypeRepository Layout_Type { get; }
        IRestaurant_TypeRepository Restaurant_Type { get; }
        IRestaurant_AdvertisementRepository Restaurant_Advertisement { get; }
        IRestaurant_Facility_RefRepository Restaurant_Facility_Ref { get; }
        IRestaurant_ImageRepository Restaurant_Image { get; }
        IRestaurant_StatusRepository Restaurant_Status { get; }
        IRestaurant_Type_ReferenceRepository Restaurant_Type_Ref { get; }
        IRestaurantRepository Restaurant { get; }
        ISeating_LayoutRepository Seating_Layout { get; }
        ISocialMediaRepository SocialMedia { get; }
        ISocialMedia_TypeRepository SocialMedia_Type { get; }
        IStar_RatingRepository Star_Rating { get; }
        IUser_CommentRepository User_Comment { get; }

        IOrder_LineRepository Order_Line { get; }
        ISeatingRepository Seating { get; }
        IQrCode_SeatingRepository QrCode_Seating { get; }
        IQrCodeRepository QrCode { get; }
        IOrder_StatusRepository Order_Status { get; }
        IOrderRepository Order { get; }
        IRestaurant_FacilityRepository Restaurant_Facility { get; }

        IReservationRepository Reservation { get; }

        ISalesByMenuITemRepository SalesByMenuITem_Repository { get; }



        void Save();
    }
}
