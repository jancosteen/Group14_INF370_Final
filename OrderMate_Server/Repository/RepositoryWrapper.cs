using Contacts;
using Contacts.Interfaces;
using Contacts.IReports;
using Entities.Models;
using Repository.ReportingRepoClasses;
using Repository.RepoUserClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private OrderMateDbFinalContext _repoContext;

        //supplier
        private ISupplierRepository _supplier;
        private ISupplierOrderRepository _supplierOrder;
        private ISupplierOrderLineRepository _supplierOrderLine;

        //product
        private IProductRepository _product;
        private IProduct_CategoryRepository _prodCategeory;
        private IProduct_Reorder_FreqRepository _prodReorderFreq;
        private IProduct_TypeRepository _prodType;
        private IProduct_Stock_TakeRepository _prodStockTake;
        private IProduct_Written_OffRepository _prodWrittenOff;
        private IWritten_Off_StockRepository _writtenOffStock;
        private IWrite_Off_ReasonRepository _writeOffReason;

        private IStock_Take_Repository _stockTake;

        private IEmployeeRepository _employee;
        private IEmployee_ShiftRepository _employeeShift;
        private IShiftRepository _shift;
        private IShift_StatusRepository _shiftStatus;

        private IAttendanceSheetRepository _attendanceSheet;

        private IAllergyRepository _allergy;
        private IMenuItem_AllergyRepository _menuItemAllergy;
        private IMenuItem_CategoryRepository _menuItemCategory;
        private IMenuItem_ItemTypeRepository _menuItemItemType;
        private IMenuItem_PriceRepository _menuItemPrice;
        private IMenuItem_SpecialRepository _menuItemSpecial;
        private IMenuItem_TypeRepository _menuItemType;
        private IMenuItemRepository _menuItem;
        private IMenuRepository _menu;
        private IReservation_StatusRepository _reservationStatus;
        private ISpecial_PriceRepository _specialPrice;
        private ISpecialRepository _special;
        private IUserRepository _user;
        private IUser_RoleRepository _UserRole;

        private IAdvertisement_DateRepository _advertisementDate;
        private IAdvertisement_PriceRepository _advPrice;
        private IAdvertisementRepository _adv;

        private ILayout_TypeRepository _layoutType;
        private ISeating_LayoutRepository _seatingLayout;

        private IRestaurant_Type_ReferenceRepository _resTypeRef;
        private IRestaurant_AdvertisementRepository _resAdv;
        private IRestaurant_Facility_RefRepository _resFacRef;
        private IRestaurant_ImageRepository _resImage;
        private IRestaurant_StatusRepository _resStatus;
        private IRestaurant_TypeRepository _resType;
        private IRestaurantRepository _restaurant;

        private ISocialMediaRepository _socialMedia;
        private ISocialMedia_TypeRepository _socialMediaType;

        private IStar_RatingRepository _starRating;
        private IUser_CommentRepository _userComment;

        private ISeatingRepository _seating;
        private IQrCodeRepository _qrCode;
        private IQrCode_SeatingRepository _qrCodeSeating;
        private IOrderRepository _order;
        private IOrder_StatusRepository _orderStatus;
        private IOrder_LineRepository _orderLine;
        private IRestaurant_FacilityRepository _restFac;

        private IReservationRepository _reservation;

        private ISalesByMenuITemRepository _salesByMenuItemRepo;

        public IRestaurant_AdvertisementRepository Restaurant_Advertisement
        {
            get
            {
                if (_resAdv == null)
                {
                    _resAdv = new Restaurant_AdvertisementRepository(_repoContext);
                }
                return _resAdv;
            }
        }


        public IRestaurant_Type_ReferenceRepository Restaurant_Type_Ref
        {
            get
            {
                if (_resTypeRef == null)
                {
                    _resTypeRef = new Restaurant_Type_ReferenceRepository(_repoContext);
                }
                return _resTypeRef;
            }
        }

        public ILayout_TypeRepository Layout_Type
        {
            get
            {
                if (_layoutType == null)
                {
                    _layoutType = new Layout_TypeRepository(_repoContext);
                }
                return _layoutType;
            }
        }

        public IAdvertisementRepository Advertisement
        {
            get
            {
                if (_adv == null)
                {
                    _adv = new AdvertisementRepository(_repoContext);
                }
                return _adv;
            }
        }

        public IAdvertisement_PriceRepository Advertisement_Price
        {
            get
            {
                if (_advPrice == null)
                {
                    _advPrice = new Advertisement_PriceRepository(_repoContext);
                }
                return _advPrice;
            }
        }

        public IAdvertisement_DateRepository Advertisement_Date
        {
            get
            {
                if (_advertisementDate == null)
                {
                    _advertisementDate = new Advertisement_DateRepository(_repoContext);
                }
                return _advertisementDate;
            }
        }
        

        public IUser_RoleRepository User_Role
        {
            get
            {
                if (_UserRole == null)
                {
                    _UserRole = new User_RoleRepository(_repoContext);
                }
                return _UserRole;
            }
        }
        

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        public ISpecialRepository Special
        {
            get
            {
                if (_special == null)
                {
                    _special = new SpecialRepository(_repoContext);
                }
                return _special;
            }
        }

        public ISpecial_PriceRepository Special_Price
        {
            get
            {
                if (_specialPrice == null)
                {
                    _specialPrice = new Special_PriceRepository(_repoContext);
                }
                return _specialPrice;
            }
        }

        public IReservation_StatusRepository Reservation_Status
        {
            get
            {
                if (_reservationStatus == null)
                {
                    _reservationStatus = new Reservation_StatusRepository(_repoContext);
                }
                return _reservationStatus;
            }
        }

        public IMenuRepository Menu
        {
            get
            {
                if (_menu == null)
                {
                    _menu = new MenuRepository(_repoContext);
                }
                return _menu;
            }
        }

        public IMenuItemRepository MenuItem
        {
            get
            {
                if (_menuItem == null)
                {
                    _menuItem = new MenuItemRepository(_repoContext);
                }
                return _menuItem;
            }
        }

        public IMenuItem_TypeRepository MenuItem_Type
        {
            get
            {
                if (_menuItemType == null)
                {
                    _menuItemType = new MenuItem_TypeRepository(_repoContext);
                }
                return _menuItemType;
            }
        }

        public IMenuItem_SpecialRepository MenuItem_Special
        {
            get
            {
                if (_menuItemSpecial == null)
                {
                    _menuItemSpecial = new MenuItem_SpecialRepository(_repoContext);
                }
                return _menuItemSpecial;
            }
        }

        public IMenuItem_PriceRepository MenuItem_Price
        {
            get
            {
                if (_menuItemPrice == null)
                {
                    _menuItemPrice = new MenuItem_PriceRepository(_repoContext);
                }
                return _menuItemPrice;
            }
        }

        public IMenuItem_ItemTypeRepository MenuItem_ItemType
        {
            get
            {
                if (_menuItemItemType == null)
                {
                    _menuItemItemType = new MenuITem_ItemTypeRepository(_repoContext);
                }
                return _menuItemItemType;
            }
        }

        public IMenuItem_CategoryRepository MenuItem_Category
        {
            get
            {
                if (_menuItemCategory == null)
                {
                    _menuItemCategory = new MenuItem_CategoryRepository(_repoContext);
                }
                return _menuItemCategory;
            }
        }

        public IMenuItem_AllergyRepository MenuItem_Allergy
        {
            get
            {
                if (_menuItemAllergy == null)
                {
                    _menuItemAllergy = new MenuItem_AllergyRepository(_repoContext);
                }
                return _menuItemAllergy;
            }
        }

        public IAllergyRepository Allergy
        {
            get
            {
                if (_allergy == null)
                {
                    _allergy = new AllergyRepository(_repoContext);
                }
                return _allergy;
            }
        }

        public IAttendanceSheetRepository Attendance_Sheet
        {
            get
            {
                if (_attendanceSheet == null)
                {
                    _attendanceSheet = new AttendanceSheetRepository(_repoContext);
                }
                return _attendanceSheet;
            }
        }

        public IShift_StatusRepository Shift_Status
        {
            get
            {
                if (_shiftStatus == null)
                {
                    _shiftStatus = new Shift_StatusRepository(_repoContext);
                }
                return _shiftStatus;
            }
        }

        public IShiftRepository Shift
        {
            get
            {
                if (_shift == null)
                {
                    _shift = new ShiftRepository(_repoContext);
                }
                return _shift;
            }
        }

        public IEmployee_ShiftRepository Employee_Shift
        {
            get
            {
                if (_employeeShift == null)
                {
                    _employeeShift = new Employee_ShiftRepository(_repoContext);
                }
                return _employeeShift;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_repoContext);
                }
                return _employee;
            }
        }

        public IWrite_Off_ReasonRepository Write_Off_Reason
        {
            get
            {
                if (_writeOffReason == null)
                {
                    _writeOffReason = new Write_Off_ReasonRepository(_repoContext);
                }
                return _writeOffReason;
            }
        }

        public IWritten_Off_StockRepository Written_Off_Stock
        {
            get
            {
                if (_writtenOffStock == null)
                {
                    _writtenOffStock = new Written_Off_StockRepository(_repoContext);
                }
                return _writtenOffStock;
            }
        }

        public IProduct_Written_OffRepository Product_Written_Off
        {
            get
            {
                if (_prodWrittenOff == null)
                {
                    _prodWrittenOff = new Product_Written_OffRepository(_repoContext);
                }
                return _prodWrittenOff;
            }
        }

        public IProduct_Stock_TakeRepository Product_Stock_Take
        {
            get
            {
                if (_prodStockTake == null)
                {
                    _prodStockTake = new Product_Stock_TakeRepository(_repoContext);
                }
                return _prodStockTake;
            }
        }

        public ISupplierRepository Supplier
        {
            get
            {
                if (_supplier == null)
                {
                    _supplier = new SupplierRepository(_repoContext);
                }
                return _supplier;
            }
        }

        public ISupplierOrderRepository SupplierOrder
        {
            get
            {
                if (_supplierOrder == null)
                {
                    _supplierOrder = new SupplierOrderRepository(_repoContext);
                }
                return _supplierOrder;
            }
        }

        public ISupplierOrderLineRepository SupplierOrderLine
        {
            get
            {
                if (_supplierOrderLine == null)
                {
                    _supplierOrderLine = new SupplierOrderLineRepository(_repoContext);
                }
                return _supplierOrderLine;
            }
        }

        public IProduct_TypeRepository Product_Type
        {
            get
            {
                if (_prodType == null)
                {
                    _prodType = new Product_TypeRepository(_repoContext);
                }
                return _prodType;
            }
        }

        public IProduct_Reorder_FreqRepository Product_Reorder_Freq
        {
            get
            {
                if (_prodReorderFreq == null)
                {
                    _prodReorderFreq = new Product_Reorder_Freq(_repoContext);
                }
                return _prodReorderFreq;
            }
        }

        public IProduct_CategoryRepository Product_Category
        {
            get
            {
                if(_prodCategeory == null)
                {
                    _prodCategeory = new Product_CategoryRepository(_repoContext);
                }
                return _prodCategeory;
            }
        }

        public IProductRepository Product
        {
            get
            {
                if(_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }
                return _product;
            }
        }

        public IStock_Take_Repository Stock_Take
        {
            get
            {
                if (_stockTake == null)
                {
                    _stockTake = new Stock_TakeRepository(_repoContext);
                }
                return _stockTake;
            }
        }

        public IRestaurant_TypeRepository Restaurant_Type
        {
            get
            {
                if (_resType == null)
                {
                    _resType = new Restaurant_TypeRepository(_repoContext);
                }
                return _resType;
            }
        }

        public IRestaurant_Facility_RefRepository Restaurant_Facility_Ref
        {
            get
            {
                if (_resFacRef == null)
                {
                    _resFacRef = new Restaurant_FacilityRefRepository(_repoContext);
                }
                return _resFacRef;
            }
        }

        public IRestaurant_ImageRepository Restaurant_Image
        {
            get
            {
                if (_resImage == null)
                {
                    _resImage = new Restaurant_ImageRepository(_repoContext);
                }
                return _resImage;
            }
        }

        public IRestaurant_StatusRepository Restaurant_Status
        {
            get
            {
                if (_resStatus == null)
                {
                    _resStatus = new Restaurant_StatusRepository(_repoContext);
                }
                return _resStatus;
            }
        }

        public IRestaurantRepository Restaurant
        {
            get
            {
                if (_restaurant == null)
                {
                    _restaurant = new RestaurantRepository(_repoContext);
                }
                return _restaurant;
            }
        }

        public ISeating_LayoutRepository Seating_Layout
        {
            get
            {
                if (_seatingLayout == null)
                {
                    _seatingLayout = new Seating_LayoutRepository(_repoContext);
                }
                return _seatingLayout;
            }
        }

        public ISocialMediaRepository SocialMedia
        {
            get
            {
                if (_socialMedia == null)
                {
                    _socialMedia = new SocialMediaRepository(_repoContext);
                }
                return _socialMedia;
            }
        }

        public ISocialMedia_TypeRepository SocialMedia_Type
        {
            get
            {
                if (_socialMediaType == null)
                {
                    _socialMediaType = new SocialMedia_TypeRepository(_repoContext);
                }
                return _socialMediaType;
            }
        }

        public IStar_RatingRepository Star_Rating
        {
            get
            {
                if (_starRating == null)
                {
                    _starRating = new Star_RatingRepository(_repoContext);
                }
                return _starRating;
            }
        }

        public IUser_CommentRepository User_Comment
        {
            get
            {
                if (_userComment == null)
                {
                    _userComment = new User_CommentRepository(_repoContext);
                }
                return _userComment;
            }
        }

        public IOrder_LineRepository Order_Line
        {
            get
            {
                if (_orderLine == null)
                {
                    _orderLine = new Order_LineRepository(_repoContext);
                }
                return _orderLine;
            }
        }

        public ISeatingRepository Seating
        {
            get
            {
                if (_seating == null)
                {
                    _seating = new SeatingRepository(_repoContext);
                }
                return _seating;
            }
        }

        public IQrCode_SeatingRepository QrCode_Seating
        {
            get
            {
                if (_qrCodeSeating == null)
                {
                    _qrCodeSeating = new QrCode_SeatingRepository(_repoContext);
                }
                return _qrCodeSeating;
            }
        }

        public IQrCodeRepository QrCode
        {
            get
            {
                if (_qrCode == null)
                {
                    _qrCode = new QrCodeRepository(_repoContext);
                }
                return _qrCode;
            }
        }

        public IOrder_StatusRepository Order_Status
        {
            get
            {
                if (_orderStatus == null)
                {
                    _orderStatus = new Order_StatusRepository(_repoContext);
                }
                return _orderStatus;
            }
        }

        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                {
                    _order = new OrderRepository(_repoContext);
                }
                return _order;
            }
        }

        public IRestaurant_FacilityRepository Restaurant_Facility
        {
            get
            {
                if (_restFac == null)
                {
                    _restFac = new Restaurant_FacilityRepository(_repoContext);
                }
                return _restFac;
            }
        }

        public IReservationRepository Reservation
        {
            get
            {
                if (_reservation == null)
                {
                    _reservation = new ReservationRepository(_repoContext);
                }
                return _reservation;
            }
        }

        public ISalesByMenuITemRepository SalesByMenuITem_Repository
        {
            get
            {
                if (_salesByMenuItemRepo == null)
                {
                    _salesByMenuItemRepo = new SalesByMenuItemReportReposotory(_repoContext);
                }
                return _salesByMenuItemRepo;
            }
        }




        //Add IRepositories above this comment
        public RepositoryWrapper(OrderMateDbFinalContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
