using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class OrderMateDbDel08Context : IdentityDbContext<User>
    {
        public OrderMateDbDel08Context()
        {
        }

        public OrderMateDbDel08Context(DbContextOptions<OrderMateDbDel08Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Advertisement> Advertisement { get; set; }
        public virtual DbSet<AdvertisementDate> AdvertisementDate { get; set; }
        public virtual DbSet<AdvertisementPrice> AdvertisementPrice { get; set; }
        public virtual DbSet<Allergy> Allergy { get; set; }
        public virtual DbSet<AttendanceSheet> AttendanceSheet { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeShift> EmployeeShift { get; set; }
        public virtual DbSet<ItemTypeMenuMenuItem> ItemTypeMenuMenuItem { get; set; }
        public virtual DbSet<LayoutType> LayoutType { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<MenuItemAllergy> MenuItemAllergy { get; set; }
        public virtual DbSet<MenuItemCategory> MenuItemCategory { get; set; }
        public virtual DbSet<MenuItemPrice> MenuItemPrice { get; set; }
        public virtual DbSet<MenuItemSpecial> MenuItemSpecial { get; set; }
        public virtual DbSet<MenuItemType> MenuItemType { get; set; }
        public virtual DbSet<MenuRestaurant> MenuRestaurant { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderLine> OrderLine { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductReorderFreq> ProductReorderFreq { get; set; }
        public virtual DbSet<ProductStockTake> ProductStockTake { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<ProductWrittenOff> ProductWrittenOff { get; set; }
        public virtual DbSet<QrCode> QrCode { get; set; }
        public virtual DbSet<QrCodeSeating> QrCodeSeating { get; set; }
        public virtual DbSet<ResaurantFacilityRef> ResaurantFacilityRef { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<ReservationRestaurant> ReservationRestaurant { get; set; }
        public virtual DbSet<ReservationStatus> ReservationStatus { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<RestaurantAdvertisement> RestaurantAdvertisement { get; set; }
        public virtual DbSet<RestaurantFacility> RestaurantFacility { get; set; }
        public virtual DbSet<RestaurantImage> RestaurantImage { get; set; }
        public virtual DbSet<RestaurantRestaurantImage> RestaurantRestaurantImage { get; set; }
        public virtual DbSet<RestaurantStatus> RestaurantStatus { get; set; }
        public virtual DbSet<RestaurantType> RestaurantType { get; set; }
        public virtual DbSet<RestaurantTypeReference> RestaurantTypeReference { get; set; }
        public virtual DbSet<Seating> Seating { get; set; }
        public virtual DbSet<SeatingLayout> SeatingLayout { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<ShiftStatus> ShiftStatus { get; set; }
        public virtual DbSet<SocialMedia> SocialMedia { get; set; }
        public virtual DbSet<SocialMediaType> SocialMediaType { get; set; }
        public virtual DbSet<Special> Special { get; set; }
        public virtual DbSet<SpecialPrice> SpecialPrice { get; set; }
        public virtual DbSet<StarRating> StarRating { get; set; }
        public virtual DbSet<StockTake> StockTake { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<SupplierOrder> SupplierOrder { get; set; }
        public virtual DbSet<SupplierOrderLine> SupplierOrderLine { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserComment> UserComment { get; set; }
        public virtual DbSet<UserImage> UserImage { get; set; }

        public virtual DbSet<UserUserImage> UserUserImage { get; set; }
        public virtual DbSet<UserUserRole> UserUserRole { get; set; }
        public virtual DbSet<WriteOffReason> WriteOffReason { get; set; }
        public virtual DbSet<WrittenOffStock> WrittenOffStock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               // optionsBuilder.UseSqlServer("Server=.;Database=OrderMateDbDel08;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

  

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.HasKey(e => e.AdvertisementId)
                    .HasName("PK_Table_1_Advertisement_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.AdvertisementId)
                    .HasName("UX_Table_1_Advertisement_Id")
                    .IsUnique();

                entity.Property(e => e.AdvertisementId).HasColumnName("Advertisement_Id");

                entity.Property(e => e.AdvertisementDateIdFk).HasColumnName("Advertisement_Date_Id_FK");

                entity.Property(e => e.AdvertisementDescription)
                    .IsRequired()
                    .HasColumnName("Advertisement_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AdvertisementFile)
                    .HasColumnName("Advertisement_File")
                    .HasColumnType("image");

                entity.Property(e => e.AdvertisementName)
                    .IsRequired()
                    .HasColumnName("Advertisement_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdvertisementPriceIdFk).HasColumnName("Advertisement_Price_Id_FK");

                entity.HasOne(d => d.AdvertisementDateIdFkNavigation)
                    .WithMany(p => p.Advertisement)
                    .HasForeignKey(d => d.AdvertisementDateIdFk)
                    .HasConstraintName("Advertisement_Advertisement_Date_FK");

                entity.HasOne(d => d.AdvertisementPriceIdFkNavigation)
                    .WithMany(p => p.Advertisement)
                    .HasForeignKey(d => d.AdvertisementPriceIdFk)
                    .HasConstraintName("Advertisement_Advertisement_Price_FK");
            });

            modelBuilder.Entity<AdvertisementDate>(entity =>
            {
                entity.HasKey(e => e.AdvertisementDateId)
                    .HasName("PK_Table_1_Advertisement_Date_Id")
                    .IsClustered(false);

                entity.ToTable("Advertisement_Date");

                entity.HasIndex(e => e.AdvertisementDateId)
                    .HasName("UX_Table_1_Advertisement_Date_Id")
                    .IsUnique();

                entity.Property(e => e.AdvertisementDateId).HasColumnName("Advertisement_Date_Id");

                entity.Property(e => e.AdvertisementDateActiveTo)
                    .HasColumnName("Advertisement_Date_Active_To")
                    .HasColumnType("date");

                entity.Property(e => e.AdvertisementDateAcvtiveFrom)
                    .HasColumnName("Advertisement_Date_Acvtive_From")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<AdvertisementPrice>(entity =>
            {
                entity.HasKey(e => e.AdvertisementPriceId)
                    .HasName("PK_Table_1_Advertisement_Price_Id")
                    .IsClustered(false);

                entity.ToTable("Advertisement_Price");

                entity.HasIndex(e => e.AdvertisementPriceId)
                    .HasName("UX_Table_1_Advertisement_Price_Id")
                    .IsUnique();

                entity.Property(e => e.AdvertisementPriceId).HasColumnName("Advertisement_Price_Id");

                entity.Property(e => e.AdvertisementPriceDateUpdated)
                    .HasColumnName("Advertisement_Price_Date_Updated")
                    .HasColumnType("date");

                entity.Property(e => e.AdvertismentPrice).HasColumnName("Advertisment_Price");
            });

            modelBuilder.Entity<Allergy>(entity =>
            {
                entity.HasKey(e => e.AllergyId)
                    .HasName("PK_Table_1_Allergy_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.AllergyId)
                    .HasName("UX_Table_1_Allergy_Id")
                    .IsUnique();

                entity.Property(e => e.AllergyId).HasColumnName("Allergy_Id");

                entity.Property(e => e.Allergy1)
                    .IsRequired()
                    .HasColumnName("Allergy")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AttendanceSheet>(entity =>
            {
                entity.HasKey(e => e.AttendanceSheetId)
                    .HasName("PK_Table_1_Attendance_Sheet_Id")
                    .IsClustered(false);

                entity.ToTable("Attendance_Sheet");

                entity.HasIndex(e => e.AttendanceSheetId)
                    .HasName("UX_Table_1_Attendance_Sheet_Id")
                    .IsUnique();

                entity.Property(e => e.AttendanceSheetId).HasColumnName("Attendance_Sheet_Id");

                entity.Property(e => e.ClockInDateTime)
                    .HasColumnName("Clock_In_Date_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ClockOutDateTime)
                    .HasColumnName("Clock_Out_Date_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmployeeIdFk).HasColumnName("Employee_Id_FK");

                entity.HasOne(d => d.EmployeeIdFkNavigation)
                    .WithMany(p => p.AttendanceSheet)
                    .HasForeignKey(d => d.EmployeeIdFk)
                    .HasConstraintName("Attendance_Sheet_Employee_FK");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK_Table_1_Employee_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.EmployeeId)
                    .HasName("UX_Table_1_Employee_Id")
                    .IsUnique();

                entity.HasIndex(e => e.EmployeeIdNumber)
                    .HasName("UX_Table_1_Employee_Id_Number")
                    .IsUnique();

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_Id");

                entity.Property(e => e.EmployeeIdNumber)
                    .IsRequired()
                    .HasColumnName("Employee_Id_Number")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .HasConstraintName("Employee_Restaurant_FK");
            });

            modelBuilder.Entity<EmployeeShift>(entity =>
            {
                entity.HasKey(e => e.EmployeeShiftId)
                    .HasName("PK_Employee_Shift_Employee_Shift_Id")
                    .IsClustered(false);

                entity.ToTable("Employee_Shift");

                entity.HasIndex(e => e.EmployeeShiftId);

                entity.Property(e => e.EmployeeShiftId).HasColumnName("Employee_Shift_Id");

                entity.Property(e => e.EmployeeIdFk).HasColumnName("Employee_Id_FK");

                entity.Property(e => e.ShiftIdFk).HasColumnName("Shift_Id_FK");

                entity.HasOne(d => d.EmployeeIdFkNavigation)
                    .WithMany(p => p.EmployeeShift)
                    .HasForeignKey(d => d.EmployeeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Employee_FK");

                entity.HasOne(d => d.ShiftIdFkNavigation)
                    .WithMany(p => p.EmployeeShift)
                    .HasForeignKey(d => d.ShiftIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Shift_FK");
            });

            modelBuilder.Entity<ItemTypeMenuMenuItem>(entity =>
            {
                entity.HasKey(e => e.ItemTypeMenuItemId)
                    .HasName("PK_Item_Type_Menu_Menu_Item_Item_Type_menu_Item_Id")
                    .IsClustered(false);

                entity.ToTable("Item_Type_Menu_Menu_Item");

                entity.HasIndex(e => e.ItemTypeMenuItemId);

                entity.Property(e => e.ItemTypeMenuItemId).HasColumnName("Item_Type_menu_Item_Id");

                entity.Property(e => e.MenuItemIdFk).HasColumnName("Menu_Item_Id_FK");

                entity.Property(e => e.MenuItemTypeIdFk).HasColumnName("Menu_Item_Type_Id_FK");

                entity.HasOne(d => d.MenuItemIdFkNavigation)
                    .WithMany(p => p.ItemTypeMenuMenuItem)
                    .HasForeignKey(d => d.MenuItemIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Menu_Item_FK_1");

                entity.HasOne(d => d.MenuItemTypeIdFkNavigation)
                    .WithMany(p => p.ItemTypeMenuMenuItem)
                    .HasForeignKey(d => d.MenuItemTypeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Menu_Item_Type_FK");
            });

            modelBuilder.Entity<LayoutType>(entity =>
            {
                entity.HasKey(e => e.LayoutTypeId)
                    .HasName("PK_Layout_Type_Layout_Type_Id")
                    .IsClustered(false);

                entity.ToTable("Layout_Type");

                entity.HasIndex(e => e.LayoutTypeId)
                    .HasName("AK_Table_1_Layout_Type_Id")
                    .IsUnique();

                entity.Property(e => e.LayoutTypeId).HasColumnName("Layout_Type_Id");

                entity.Property(e => e.LayoutType1)
                    .IsRequired()
                    .HasColumnName("Layout_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenuId)
                    .HasName("PK_Table_1_Menu_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.MenuId)
                    .HasName("UX_Table_1_Menu_Id")
                    .IsUnique();

                entity.Property(e => e.MenuId).HasColumnName("Menu_Id");

                entity.Property(e => e.MenuDateCreated)
                    .HasColumnName("Menu_Date_Created")
                    .HasColumnType("date");

                entity.Property(e => e.MenuDescription)
                    .IsRequired()
                    .HasColumnName("Menu_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasColumnName("Menu_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuTimeActiveFrom).HasColumnName("Menu_Time_Active_From");

                entity.Property(e => e.MenuTimeActiveTo).HasColumnName("Menu_Time_Active_To");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.MenuItemId)
                    .HasName("PK_Table_1_Menu_Item_Id")
                    .IsClustered(false);

                entity.ToTable("Menu_Item");

                entity.HasIndex(e => e.MenuItemId)
                    .HasName("UX_Table_1_Menu_Item_Id")
                    .IsUnique();

                entity.Property(e => e.MenuItemId).HasColumnName("Menu_Item_Id");

                entity.Property(e => e.MenuItemCategoryIdFk).HasColumnName("Menu_Item_Category_Id_FK");

                entity.Property(e => e.MenuItemDescription)
                    .IsRequired()
                    .HasColumnName("Menu_Item_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MenuItemName)
                    .IsRequired()
                    .HasColumnName("Menu_Item_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MenuItemPriceIdFk).HasColumnName("Menu_Item_Price_Id_FK");

                entity.HasOne(d => d.MenuItemCategoryIdFkNavigation)
                    .WithMany(p => p.MenuItem)
                    .HasForeignKey(d => d.MenuItemCategoryIdFk)
                    .HasConstraintName("Menu_Item_Menu_Item_Category_FK");

                entity.HasOne(d => d.MenuItemPriceIdFkNavigation)
                    .WithMany(p => p.MenuItem)
                    .HasForeignKey(d => d.MenuItemPriceIdFk)
                    .HasConstraintName("Menu_Item_Menu_Item_Price_FK");
            });

            modelBuilder.Entity<MenuItemAllergy>(entity =>
            {
                entity.HasKey(e => e.MenuItemAllergyId)
                    .HasName("PK_Menu_Item_Allergy_Menu_Item_Allergy_Id")
                    .IsClustered(false);

                entity.ToTable("Menu_Item_Allergy");

                entity.HasIndex(e => e.MenuItemAllergyId);

                entity.Property(e => e.MenuItemAllergyId).HasColumnName("Menu_Item_Allergy_Id");

                entity.Property(e => e.AllergyIdFk).HasColumnName("Allergy_Id_FK");

                entity.Property(e => e.MenuItemIdFk).HasColumnName("Menu_Item_Id_FK");

                entity.HasOne(d => d.AllergyIdFkNavigation)
                    .WithMany(p => p.MenuItemAllergy)
                    .HasForeignKey(d => d.AllergyIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Allergy_FK");

                entity.HasOne(d => d.MenuItemIdFkNavigation)
                    .WithMany(p => p.MenuItemAllergy)
                    .HasForeignKey(d => d.MenuItemIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Menu_Item_FK");
            });

            modelBuilder.Entity<MenuItemCategory>(entity =>
            {
                entity.HasKey(e => e.MenuItemCategoryId)
                    .HasName("PK_Table_1_Menu_Item_Category_Id")
                    .IsClustered(false);

                entity.ToTable("Menu_Item_Category");

                entity.HasIndex(e => e.MenuItemCategoryId)
                    .HasName("UX_Table_1_Menu_Item_Category_Id")
                    .IsUnique();

                entity.Property(e => e.MenuItemCategoryId).HasColumnName("Menu_Item_Category_Id");

                entity.Property(e => e.MenuItemCategory1)
                    .IsRequired()
                    .HasColumnName("Menu_Item_Category")
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<MenuItemPrice>(entity =>
            {
                entity.HasKey(e => e.MenuItemPriceId)
                    .HasName("PK_Table_1_Menu_Item_Price_Id")
                    .IsClustered(false);

                entity.ToTable("Menu_Item_Price");

                entity.HasIndex(e => e.MenuItemPriceId)
                    .HasName("UX_Table_1_Menu_Item_Price_Id")
                    .IsUnique();

                entity.Property(e => e.MenuItemPriceId).HasColumnName("Menu_Item_Price_Id");

                entity.Property(e => e.MenuItemDateUpdated)
                    .HasColumnName("Menu_Item_Date_Updated")
                    .HasColumnType("date");

                entity.Property(e => e.MenuItemPrice1).HasColumnName("Menu_Item_Price");
            });

            modelBuilder.Entity<MenuItemSpecial>(entity =>
            {
                entity.HasKey(e => e.MenuItemSpecialId)
                    .HasName("PK_Menu_Item_Special_Menu_Item_Special_Id")
                    .IsClustered(false);

                entity.ToTable("Menu_Item_Special");

                entity.HasIndex(e => e.MenuItemSpecialId);

                entity.Property(e => e.MenuItemSpecialId).HasColumnName("Menu_Item_Special_Id");

                entity.Property(e => e.MenuItemIdFk).HasColumnName("Menu_Item_Id_FK");

                entity.Property(e => e.SpecialIdFk).HasColumnName("Special_Id_FK");

                entity.HasOne(d => d.MenuItemIdFkNavigation)
                    .WithMany(p => p.MenuItemSpecial)
                    .HasForeignKey(d => d.MenuItemIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Menu_Item_FK_2");

                entity.HasOne(d => d.SpecialIdFkNavigation)
                    .WithMany(p => p.MenuItemSpecial)
                    .HasForeignKey(d => d.SpecialIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Special_FK");
            });

            modelBuilder.Entity<MenuItemType>(entity =>
            {
                entity.HasKey(e => e.MenuItemTypeId)
                    .HasName("PK_Table_1_Menu_Item_Type_Id")
                    .IsClustered(false);

                entity.ToTable("Menu_Item_Type");

                entity.HasIndex(e => e.MenuItemTypeId)
                    .HasName("UX_Table_1_Menu_Item_Type_Id")
                    .IsUnique();

                entity.Property(e => e.MenuItemTypeId).HasColumnName("Menu_Item_Type_Id");

                entity.Property(e => e.MenuItemType1)
                    .IsRequired()
                    .HasColumnName("Menu_Item_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MenuRestaurant>(entity =>
            {
                entity.HasKey(e => e.MenuRestaurantId)
                    .IsClustered(false);

                entity.ToTable("Menu_Restaurant");

                entity.Property(e => e.MenuRestaurantId).HasColumnName("Menu_Restaurant_Id");

                entity.Property(e => e.MenuIdFk).HasColumnName("Menu_Id_FK");

                entity.Property(e => e.MenuItemIdFk).HasColumnName("Menu_Item_Id_FK");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.HasOne(d => d.MenuIdFkNavigation)
                    .WithMany(p => p.MenuRestaurant)
                    .HasForeignKey(d => d.MenuIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Menu_Restaurant_Menu_FK");

                entity.HasOne(d => d.MenuItemIdFkNavigation)
                    .WithMany(p => p.MenuRestaurant)
                    .HasForeignKey(d => d.MenuItemIdFk)
                    .HasConstraintName("Menu_Restaurant_Menu_Item_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.MenuRestaurant)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Menu_Restaurant_Restaurant_FK");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_Order_Order_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.OrderId)
                    .HasName("UX_Order_Order_Id")
                    .IsUnique();

                entity.Property(e => e.OrderId).HasColumnName("Order_Id");

                entity.Property(e => e.OrderDateCompleted)
                    .HasColumnName("Order_Date_Completed")
                    .HasColumnType("date");

                entity.Property(e => e.OrderDateCreated)
                    .HasColumnName("Order_Date_Created")
                    .HasColumnType("date");

                entity.Property(e => e.OrderStatusIdFk).HasColumnName("Order_Status_Id_FK");

                entity.Property(e => e.QrCodeSeatingIdFk).HasColumnName("QrCode_Seating_Id_FK");

                entity.HasOne(d => d.OrderStatusIdFkNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.OrderStatusIdFk)
                    .HasConstraintName("Order_Order_Status_FK");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasKey(e => e.OrderLineId)
                    .HasName("PK_Table_1_Order_Line_id")
                    .IsClustered(false);

                entity.ToTable("Order_Line");

                entity.HasIndex(e => e.OrderLineId)
                    .HasName("UX_Table_1_Order_Line_id")
                    .IsUnique();

                entity.Property(e => e.OrderLineId).HasColumnName("Order_Line_id");

                entity.Property(e => e.ItemComments)
                    .IsRequired()
                    .HasColumnName("Item_Comments")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ItemQty).HasColumnName("Item_Qty");

                entity.Property(e => e.MenuItemIdFk).HasColumnName("Menu_Item_Id_FK");

                entity.Property(e => e.OrderIdFk).HasColumnName("Order_Id_FK");

                entity.Property(e => e.SpecialIdFk).HasColumnName("Special_Id_FK");

                entity.Property(e => e.UserIdFk).HasColumnName("User_Id_FK");

                entity.HasOne(d => d.MenuItemIdFkNavigation)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.MenuItemIdFk)
                    .HasConstraintName("Order_Line_Menu_Item_FK");

                entity.HasOne(d => d.OrderIdFkNavigation)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.OrderIdFk)
                    .HasConstraintName("Order_Line_Order_FK");

                entity.HasOne(d => d.SpecialIdFkNavigation)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.SpecialIdFk)
                    .HasConstraintName("Order_Line_Special_FK");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.OrderLine)
                    .HasForeignKey(d => d.UserIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Line_User_FK");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.OrderStatusId)
                    .HasName("PK_Table_1_Order_Status_Id")
                    .IsClustered(false);

                entity.ToTable("Order_Status");

                entity.HasIndex(e => e.OrderStatusId)
                    .HasName("UX_Table_1_Order_Status_Id")
                    .IsUnique();

                entity.Property(e => e.OrderStatusId).HasColumnName("Order_Status_Id");

                entity.Property(e => e.OrderStatus1)
                    .IsRequired()
                    .HasColumnName("Order_Status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_Table_1_Product_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.ProductId)
                    .HasName("UX_Table_1_Product_Id")
                    .IsUnique();

                entity.HasIndex(e => e.ProductName)
                    .HasName("UX_Table_1_Product_Name")
                    .IsUnique();

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.ProductCategoryIdFk).HasColumnName("Product_Category_Id_FK");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("Product_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("Product_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProductOnHand).HasColumnName("Product_On_Hand");

                entity.Property(e => e.ProductReorderFreqIdFk).HasColumnName("Product_Reorder_Freq_Id_FK");

                entity.Property(e => e.ProductReorderLevel).HasColumnName("Product_Reorder_Level");

                entity.Property(e => e.ProductTypeIdFk).HasColumnName("Product_Type_Id_FK");

                entity.HasOne(d => d.ProductCategoryIdFkNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCategoryIdFk)
                    .HasConstraintName("Product_Product_Category_FK");

                entity.HasOne(d => d.ProductReorderFreqIdFkNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductReorderFreqIdFk)
                    .HasConstraintName("Product_Product_Reorder_Freq_FK");

                entity.HasOne(d => d.ProductTypeIdFkNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductTypeIdFk)
                    .HasConstraintName("Product_Product_Type_FK");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCategoryId)
                    .HasName("PK_Table_1_Product_Category_Id")
                    .IsClustered(false);

                entity.ToTable("Product_Category");

                entity.HasIndex(e => e.ProductCategory1)
                    .HasName("UX_Table_1_Product_Category")
                    .IsUnique();

                entity.HasIndex(e => e.ProductCategoryId)
                    .HasName("UX_Table_1_Product_Category_Id")
                    .IsUnique();

                entity.Property(e => e.ProductCategoryId).HasColumnName("Product_Category_Id");

                entity.Property(e => e.ProductCategory1)
                    .IsRequired()
                    .HasColumnName("Product_Category")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductReorderFreq>(entity =>
            {
                entity.HasKey(e => e.ProductReorderFreqId)
                    .HasName("PK_Product_Reorder_Freq_Product_Reorder_Freq_Id")
                    .IsClustered(false);

                entity.ToTable("Product_Reorder_Freq");

                entity.HasIndex(e => e.ProductReorderFreq1)
                    .HasName("UX_Table_1_Product_Reorder_Freq")
                    .IsUnique();

                entity.HasIndex(e => e.ProductReorderFreqId)
                    .HasName("UX_Product_Reorder_Freq_Product_Reorder_Freq_Id")
                    .IsUnique();

                entity.Property(e => e.ProductReorderFreqId).HasColumnName("Product_Reorder_Freq_Id");

                entity.Property(e => e.ProductReorderFreq1)
                    .IsRequired()
                    .HasColumnName("Product_Reorder_Freq")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductStockTake>(entity =>
            {
                entity.HasKey(e => e.ProductStockTakeId)
                    .HasName("PK_Product_Stock_Take_Product_Stock_Take_Id")
                    .IsClustered(false);

                entity.ToTable("Product_Stock_Take");

                entity.HasIndex(e => e.ProductStockTakeId);

                entity.Property(e => e.ProductStockTakeId).HasColumnName("Product_Stock_Take_Id");

                entity.Property(e => e.EmployeeIdFk).HasColumnName("Employee_Id_FK");

                entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");

                entity.Property(e => e.ProductStockTakeQty).HasColumnName("Product_Stock_Take_Qty");

                entity.Property(e => e.StockTakeIdFk).HasColumnName("Stock_Take_Id_FK");

                entity.HasOne(d => d.EmployeeIdFkNavigation)
                    .WithMany(p => p.ProductStockTake)
                    .HasForeignKey(d => d.EmployeeIdFk)
                    .HasConstraintName("Table_1_Employee_FK_1");

                entity.HasOne(d => d.ProductIdFkNavigation)
                    .WithMany(p => p.ProductStockTake)
                    .HasForeignKey(d => d.ProductIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Product_FK");

                entity.HasOne(d => d.StockTakeIdFkNavigation)
                    .WithMany(p => p.ProductStockTake)
                    .HasForeignKey(d => d.StockTakeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Product_Stock_Take_Stock_Take_FK");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasKey(e => e.ProductTypeId)
                    .HasName("PK_Table_1_Product_Type_Id")
                    .IsClustered(false);

                entity.ToTable("Product_Type");

                entity.HasIndex(e => e.ProductType1)
                    .HasName("UX_Table_1_Product_Type")
                    .IsUnique();

                entity.HasIndex(e => e.ProductTypeId)
                    .HasName("UX_Table_1_Product_Type_Id")
                    .IsUnique();

                entity.Property(e => e.ProductTypeId).HasColumnName("Product_Type_Id");

                entity.Property(e => e.ProductType1)
                    .IsRequired()
                    .HasColumnName("Product_Type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductWrittenOff>(entity =>
            {
                entity.HasKey(e => new { e.WrittenOffStockIdFk, e.ProductIdFk })
                    .HasName("PK_Product_Written_Off_Written_Off_Stock_Id_FK_Product_Id_FK")
                    .IsClustered(false);

                entity.ToTable("Product_Written_Off");

                entity.Property(e => e.WrittenOffStockIdFk).HasColumnName("Written_Off_Stock_Id_FK");

                entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");

                entity.Property(e => e.EmployeeIdFk).HasColumnName("Employee_Id_FK");

                entity.Property(e => e.WrittenOffQty).HasColumnName("Written_Off_Qty");

                entity.HasOne(d => d.EmployeeIdFkNavigation)
                    .WithMany(p => p.ProductWrittenOff)
                    .HasForeignKey(d => d.EmployeeIdFk)
                    .HasConstraintName("Product_Written_Off_Employee_FK");

                entity.HasOne(d => d.ProductIdFkNavigation)
                    .WithMany(p => p.ProductWrittenOff)
                    .HasForeignKey(d => d.ProductIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Product_FK_1");

                entity.HasOne(d => d.WrittenOffStockIdFkNavigation)
                    .WithMany(p => p.ProductWrittenOff)
                    .HasForeignKey(d => d.WrittenOffStockIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Written_Off_Stock_FK");
            });

            modelBuilder.Entity<QrCode>(entity =>
            {
                entity.HasKey(e => e.QrCodeId)
                    .IsClustered(false);

                entity.HasIndex(e => e.QrCodeId)
                    .HasName("AK_QrCode_QrCode_Id")
                    .IsUnique();

                entity.Property(e => e.QrCodeId).HasColumnName("QrCode_Id");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.QrCode)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .HasConstraintName("QrCode_Restaurant_FK");
            });

            modelBuilder.Entity<QrCodeSeating>(entity =>
            {
                entity.HasKey(e => e.QrCodeSeatingId)
                    .HasName("PK_QrCode_Seating_QrCode_Seating_Id")
                    .IsClustered(false);

                entity.ToTable("QrCode_Seating");

                entity.HasIndex(e => e.QrCodeSeatingId)
                    .HasName("UX_QrCode_Seating_QrCode_Seating_Id")
                    .IsUnique();

                entity.Property(e => e.QrCodeSeatingId).HasColumnName("QrCode_Seating_Id");

                entity.Property(e => e.NrOfPeople).HasColumnName("Nr_Of_People");

                entity.Property(e => e.OrderIdFk).HasColumnName("Order_Id_FK");

                entity.Property(e => e.QrCodeIdFk).HasColumnName("QrCode_Id_FK");

                entity.Property(e => e.SeatingIdFk).HasColumnName("SeatingId_FK");

                entity.HasOne(d => d.OrderIdFkNavigation)
                    .WithMany(p => p.QrCodeSeating)
                    .HasForeignKey(d => d.OrderIdFk)
                    .HasConstraintName("QrCode_Seating_Order_FK");

                entity.HasOne(d => d.QrCodeIdFkNavigation)
                    .WithMany(p => p.QrCodeSeating)
                    .HasForeignKey(d => d.QrCodeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("QrCode_Seating_QrCode_FK");

                entity.HasOne(d => d.SeatingIdFkNavigation)
                    .WithMany(p => p.QrCodeSeating)
                    .HasForeignKey(d => d.SeatingIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("QrCode_Seating_Seating_FK");
            });

            modelBuilder.Entity<ResaurantFacilityRef>(entity =>
            {
                entity.HasKey(e => e.RestaurantFacilityRefId)
                    .HasName("PK_Resaurant_Facility_Ref_Restaurant_Facility_Ref_Id")
                    .IsClustered(false);

                entity.ToTable("Resaurant_Facility_Ref");

                entity.HasIndex(e => e.RestaurantFacilityRefId);

                entity.Property(e => e.RestaurantFacilityRefId).HasColumnName("Restaurant_Facility_Ref_Id");

                entity.Property(e => e.RestaurantFacilityIdFk).HasColumnName("Restaurant_Facility_Id_FK");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.HasOne(d => d.RestaurantFacilityIdFkNavigation)
                    .WithMany(p => p.ResaurantFacilityRef)
                    .HasForeignKey(d => d.RestaurantFacilityIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Res_Fac_Restaurant_Facility_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.ResaurantFacilityRef)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Restaurant_FK_1");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.ReservationId)
                    .HasName("PK_Reservation_Reservation_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.ReservationId)
                    .HasName("UX_Reservation_Reservation_Id")
                    .IsUnique();

                entity.Property(e => e.ReservationId).HasColumnName("Reservation_Id");

                entity.Property(e => e.ReservationDateCreated)
                    .HasColumnName("Reservation_date_Created")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReservationDateReserved)
                    .HasColumnName("Reservation_Date_Reserved")
                    .HasColumnType("datetime");

                entity.Property(e => e.ReservationNumberOfBills).HasColumnName("Reservation_NumberOfBills");

                entity.Property(e => e.ReservationPartyQty).HasColumnName("Reservation_Party_Qty");

                entity.Property(e => e.ReservationStatusIdFk).HasColumnName("Reservation_Status_Id_FK");

                entity.Property(e => e.UserIdFk).HasColumnName("User_Id_FK");

                entity.HasOne(d => d.ReservationStatusIdFkNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.ReservationStatusIdFk)
                    .HasConstraintName("Reservation_Reservation_Status_FK");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.UserIdFk)
                    .HasConstraintName("Reservation_User_FK");
            });

            modelBuilder.Entity<ReservationRestaurant>(entity =>
            {
                entity.HasKey(e => e.ReservationRestaurantId)
                    .HasName("PK_Reservation_Restaurant_Reservation_Restaurant_Id")
                    .IsClustered(false);

                entity.ToTable("Reservation_Restaurant");

                entity.HasIndex(e => e.ReservationRestaurantId);

                entity.Property(e => e.ReservationRestaurantId).HasColumnName("Reservation_Restaurant_Id");

                entity.Property(e => e.ReservationIdFk).HasColumnName("Reservation_Id_FK");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.HasOne(d => d.ReservationIdFkNavigation)
                    .WithMany(p => p.ReservationRestaurant)
                    .HasForeignKey(d => d.ReservationIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservation_Restaurant_Reservation_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.ReservationRestaurant)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservation_Restaurant_Restaurant_FK");
            });

            modelBuilder.Entity<ReservationStatus>(entity =>
            {
                entity.HasKey(e => e.ReservationStatusId)
                    .HasName("PK_Table_1_Reservation_Status_Id")
                    .IsClustered(false);

                entity.ToTable("Reservation_Status");

                entity.HasIndex(e => e.ReservationStatusId)
                    .HasName("UX_Table_1_Reservation_Status_Id")
                    .IsUnique();

                entity.Property(e => e.ReservationStatusId).HasColumnName("Reservation_Status_Id");

                entity.Property(e => e.ReservationStatus1)
                    .IsRequired()
                    .HasColumnName("Reservation_Status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.RestaurantId)
                    .HasName("PK_Table_1_Restaurant_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.RestaurantId)
                    .HasName("UX_Table_1_Restaurant_Id")
                    .IsUnique();

                entity.Property(e => e.RestaurantId).HasColumnName("Restaurant_Id");

                entity.Property(e => e.QrCodeIdFk).HasColumnName("QrCode_Id_FK");

                entity.Property(e => e.ResaturantAddressLine2)
                    .IsRequired()
                    .HasColumnName("Resaturant_Address_Line_2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantAddressLine1)
                    .IsRequired()
                    .HasColumnName("Restaurant_Address_Line_1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantCity)
                    .IsRequired()
                    .HasColumnName("Restaurant_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantCountry)
                    .IsRequired()
                    .HasColumnName("Restaurant_Country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantDateCreated)
                    .HasColumnName("Restaurant_Date_Created")
                    .HasColumnType("date");

                entity.Property(e => e.RestaurantDescription)
                    .IsRequired()
                    .HasColumnName("Restaurant_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantName)
                    .IsRequired()
                    .HasColumnName("Restaurant_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantPostalCode)
                    .IsRequired()
                    .HasColumnName("Restaurant_Postal_Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantProvince)
                    .IsRequired()
                    .HasColumnName("Restaurant_Province")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantStatusIdFk).HasColumnName("Restaurant_Status_ID_FK");

                entity.Property(e => e.RestaurantUrl)
                    .HasColumnName("Restaurant_Url")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SocialMediaIdFk).HasColumnName("Social_Media_Id_FK");

                entity.Property(e => e.SocialMediaTypeIdFkFk).HasColumnName("Social_Media_Type_Id_FK_FK");

                entity.HasOne(d => d.RestaurantStatusIdFkNavigation)
                    .WithMany(p => p.Restaurant)
                    .HasForeignKey(d => d.RestaurantStatusIdFk)
                    .HasConstraintName("Restaurant_Restaurant_Status_FK");

                entity.HasOne(d => d.SocialMedia)
                    .WithMany(p => p.Restaurant)
                    .HasForeignKey(d => new { d.SocialMediaIdFk, d.SocialMediaTypeIdFkFk })
                    .HasConstraintName("Restaurant_Social_Media_FK");
            });

            modelBuilder.Entity<RestaurantAdvertisement>(entity =>
            {
                entity.HasKey(e => e.RestaurantAdvertisesementId)
                    .HasName("PK_Restaurant_Advertisement_Restaurant_Advertisesement_Id")
                    .IsClustered(false);

                entity.ToTable("Restaurant_Advertisement");

                entity.HasIndex(e => e.RestaurantAdvertisesementId);

                entity.Property(e => e.RestaurantAdvertisesementId).HasColumnName("Restaurant_Advertisesement_Id");

                entity.Property(e => e.AdvertisementIdFk).HasColumnName("Advertisement_Id_FK");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.HasOne(d => d.AdvertisementIdFkNavigation)
                    .WithMany(p => p.RestaurantAdvertisement)
                    .HasForeignKey(d => d.AdvertisementIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Advertisement_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.RestaurantAdvertisement)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Restaurant_FK");
            });

            modelBuilder.Entity<RestaurantFacility>(entity =>
            {
                entity.HasKey(e => e.RestaurantFacilityId)
                    .HasName("PK_Table_1_Restaurant_Facility_Id")
                    .IsClustered(false);

                entity.ToTable("Restaurant_Facility");

                entity.HasIndex(e => e.RestaurantFacilityId)
                    .HasName("UX_Table_1_Restaurant_Facility_Id")
                    .IsUnique();

                entity.Property(e => e.RestaurantFacilityId).HasColumnName("Restaurant_Facility_Id");

                entity.Property(e => e.RestaurantFacility1)
                    .IsRequired()
                    .HasColumnName("Restaurant_Facility")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RestaurantImage>(entity =>
            {
                entity.HasKey(e => e.RestaurantImageId)
                    .HasName("PK_Table_1_Restaurant_Image_Id")
                    .IsClustered(false);

                entity.ToTable("Restaurant_Image");

                entity.HasIndex(e => e.RestaurantImageId)
                    .HasName("UX_Table_1_Restaurant_Image_Id")
                    .IsUnique();

                entity.Property(e => e.RestaurantImageId).HasColumnName("Restaurant_Image_Id");

                entity.Property(e => e.ImageDescription)
                    .IsRequired()
                    .HasColumnName("Image_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImageFile)
                    .HasColumnName("Image_File")
                    .HasColumnType("image");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.RestaurantImage)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .HasConstraintName("Restaurant_Image_Restaurant_FK");
            });

            modelBuilder.Entity<RestaurantRestaurantImage>(entity =>
            {
                entity.HasKey(e => e.RestaurantRestaurantImageId)
                    .HasName("PK_Restaurant_Restaurant_Image_Restaurant_Restaurant_Image_Id")
                    .IsClustered(false);

                entity.ToTable("Restaurant_Restaurant_Image");

                entity.HasIndex(e => e.RestaurantRestaurantImageId);

                entity.Property(e => e.RestaurantRestaurantImageId).HasColumnName("Restaurant_Restaurant_Image_Id");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.Property(e => e.RestaurantImageIdFk).HasColumnName("Restaurant_Image_Id_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.RestaurantRestaurantImage)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Restaurant_Restaurant_Image_Restaurant_FK");

                entity.HasOne(d => d.RestaurantImageIdFkNavigation)
                    .WithMany(p => p.RestaurantRestaurantImage)
                    .HasForeignKey(d => d.RestaurantImageIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Restaurant_Restaurant_Image_Restaurant_Image_FK");
            });

            modelBuilder.Entity<RestaurantStatus>(entity =>
            {
                entity.HasKey(e => e.RestaurantStatusId)
                    .HasName("PK_Table_1_Restaurant_Status_ID")
                    .IsClustered(false);

                entity.ToTable("Restaurant_Status");

                entity.HasIndex(e => e.RestaurantStatusId)
                    .HasName("UX_Table_1_Restaurant_Status_ID")
                    .IsUnique();

                entity.Property(e => e.RestaurantStatusId).HasColumnName("Restaurant_Status_ID");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.Property(e => e.RestaurantStatus1)
                    .IsRequired()
                    .HasColumnName("Restaurant_Status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RestaurantType>(entity =>
            {
                entity.HasKey(e => e.RestaurantTypeId)
                    .HasName("PK_Table_1_Restaurant_Type_Id")
                    .IsClustered(false);

                entity.ToTable("Restaurant_Type");

                entity.HasIndex(e => e.RestaurantTypeId)
                    .HasName("AK_Table_1_Restaurant_Facility_Id")
                    .IsUnique();

                entity.Property(e => e.RestaurantTypeId).HasColumnName("Restaurant_Type_Id");

                entity.Property(e => e.RestaurantType1)
                    .IsRequired()
                    .HasColumnName("Restaurant_Type")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<RestaurantTypeReference>(entity =>
            {
                entity.HasKey(e => e.RestaurantTypeRefId)
                    .HasName("PK_Restaurant_Type_Reference_Restaurant_Type_Ref_Id")
                    .IsClustered(false);

                entity.ToTable("Restaurant_Type_Reference");

                entity.HasIndex(e => e.RestaurantTypeRefId);

                entity.Property(e => e.RestaurantTypeRefId).HasColumnName("Restaurant_Type_Ref_Id");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.Property(e => e.RestaurantTypeIdFk).HasColumnName("Restaurant_Type_Id_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.RestaurantTypeReference)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Restaurant_FK_2");

                entity.HasOne(d => d.RestaurantTypeIdFkNavigation)
                    .WithMany(p => p.RestaurantTypeReference)
                    .HasForeignKey(d => d.RestaurantTypeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Restaurant_Type_FK");
            });

            modelBuilder.Entity<Seating>(entity =>
            {
                entity.HasKey(e => e.SeatingId)
                    .HasName("PK_Seating_SeatingId")
                    .IsClustered(false);

                entity.HasIndex(e => e.SeatingId)
                    .HasName("AK_Seating_SeatingId")
                    .IsUnique();

                entity.Property(e => e.ReservationIdFk).HasColumnName("Reservation_Id_FK");

                entity.Property(e => e.SeatingDate).HasColumnType("date");

                entity.HasOne(d => d.ReservationIdFkNavigation)
                    .WithMany(p => p.Seating)
                    .HasForeignKey(d => d.ReservationIdFk)
                    .HasConstraintName("Seating_Reservation_FK");
            });

            modelBuilder.Entity<SeatingLayout>(entity =>
            {
                entity.HasKey(e => new { e.SeatingLayoutId, e.RestaurantIdFk, e.LayoutTypeIdFk })
                    .HasName("Seating_Layout_PK")
                    .IsClustered(false);

                entity.ToTable("Seating_Layout");

                entity.HasIndex(e => e.SeatingLayoutId)
                    .HasName("UX_Table_1_Seating_Layout_Id")
                    .IsUnique();

                entity.Property(e => e.SeatingLayoutId)
                    .HasColumnName("Seating_Layout_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.Property(e => e.LayoutTypeIdFk).HasColumnName("Layout_Type_Id_FK");

                entity.Property(e => e.SeatingLayoutQty)
                    .IsRequired()
                    .HasColumnName("Seating_Layout_Qty")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.LayoutTypeIdFkNavigation)
                    .WithMany(p => p.SeatingLayout)
                    .HasForeignKey(d => d.LayoutTypeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Seating_Layout_Layout_Type_FK");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.SeatingLayout)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Seating_Layout_Restaurant_FK");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.HasKey(e => e.ShiftId)
                    .HasName("PK_Table_1_Shift_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.ShiftId)
                    .HasName("UX_Table_1_Shift_Id")
                    .IsUnique();

                entity.HasIndex(e => e.ShiftName)
                    .HasName("UX_Table_1_Shift_Name")
                    .IsUnique();

                entity.Property(e => e.ShiftId).HasColumnName("Shift_Id");

                entity.Property(e => e.ShiftCapacity).HasColumnName("Shift_Capacity");

                entity.Property(e => e.ShiftEndDateTime)
                    .HasColumnName("Shift_End_Date_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasColumnName("Shift_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShiftStartDateTime)
                    .HasColumnName("Shift_Start_Date_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.ShiftStatusIdFk).HasColumnName("Shift_Status_Id_FK");

                entity.HasOne(d => d.ShiftStatusIdFkNavigation)
                    .WithMany(p => p.Shift)
                    .HasForeignKey(d => d.ShiftStatusIdFk)
                    .HasConstraintName("Shift_Shift_Status_FK");
            });

            modelBuilder.Entity<ShiftStatus>(entity =>
            {
                entity.HasKey(e => e.ShiftStatusId)
                    .HasName("PK_Table_1_Shift_Status_Id")
                    .IsClustered(false);

                entity.ToTable("Shift_Status");

                entity.HasIndex(e => e.ShiftStatus1)
                    .HasName("UX_Table_1_Shift_Status")
                    .IsUnique();

                entity.HasIndex(e => e.ShiftStatusId)
                    .HasName("UX_Table_1_Shift_Status_Id")
                    .IsUnique();

                entity.Property(e => e.ShiftStatusId).HasColumnName("Shift_Status_Id");

                entity.Property(e => e.ShiftStatus1)
                    .IsRequired()
                    .HasColumnName("Shift_Status")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.HasKey(e => new { e.SocialMediaId, e.SocialMediaTypeIdFk })
                    .HasName("Social_Media_PK")
                    .IsClustered(false);

                entity.ToTable("Social_Media");

                entity.HasIndex(e => e.SocialMediaId)
                    .HasName("UX_Table_1_Social_Media_Id")
                    .IsUnique();

                entity.Property(e => e.SocialMediaId)
                    .HasColumnName("Social_Media_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SocialMediaTypeIdFk).HasColumnName("Social_Media_Type_Id_FK");

                entity.Property(e => e.SocialMediaAddress)
                    .IsRequired()
                    .HasColumnName("Social_Media_Address")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.SocialMediaTypeIdFkNavigation)
                    .WithMany(p => p.SocialMedia)
                    .HasForeignKey(d => d.SocialMediaTypeIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Social_Media_Social_Media_Type_FK");
            });

            modelBuilder.Entity<SocialMediaType>(entity =>
            {
                entity.HasKey(e => e.SocialMediaTypeId)
                    .HasName("PK_Table_1_Social_Media_Type_Id")
                    .IsClustered(false);

                entity.ToTable("Social_Media_Type");

                entity.HasIndex(e => e.SocialMediaTypeId)
                    .HasName("UX_Table_1_Social_Media_Type_Id")
                    .IsUnique();

                entity.Property(e => e.SocialMediaTypeId).HasColumnName("Social_Media_Type_Id");

                entity.Property(e => e.SocialMediaType1)
                    .IsRequired()
                    .HasColumnName("Social_Media_Type")
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Special>(entity =>
            {
                entity.HasKey(e => e.SpecialId)
                    .HasName("PK_Table_1_Special_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.SpecialId)
                    .HasName("UX_Table_1_Special_Id")
                    .IsUnique();

                entity.Property(e => e.SpecialId).HasColumnName("Special_Id");

                entity.Property(e => e.SpecialDescription)
                    .IsRequired()
                    .HasColumnName("Special_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialEndDate)
                    .HasColumnName("Special_End_Date")
                    .HasColumnType("date");

                entity.Property(e => e.SpecialName)
                    .IsRequired()
                    .HasColumnName("Special_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SpecialStartDate)
                    .HasColumnName("Special_Start_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<SpecialPrice>(entity =>
            {
                entity.HasKey(e => e.SpecialPriceId)
                    .HasName("PK_Table_1_Special_Price_Id")
                    .IsClustered(false);

                entity.ToTable("Special_Price");

                entity.HasIndex(e => e.SpecialPriceId)
                    .HasName("UX_Table_1_Special_Price_Id")
                    .IsUnique();

                entity.Property(e => e.SpecialPriceId).HasColumnName("Special_Price_Id");

                entity.Property(e => e.SpecialIdFk).HasColumnName("Special_Id_FK");

                entity.Property(e => e.SpecialPrice1).HasColumnName("Special_Price");

                entity.Property(e => e.SpecialPriceDateUpdated)
                    .HasColumnName("Special_Price_Date_Updated")
                    .HasColumnType("date");

                entity.HasOne(d => d.SpecialIdFkNavigation)
                    .WithMany(p => p.SpecialPrice)
                    .HasForeignKey(d => d.SpecialIdFk)
                    .HasConstraintName("Special_Price_Special_FK");
            });

            modelBuilder.Entity<StarRating>(entity =>
            {
                entity.HasKey(e => e.StarRatingId)
                    .HasName("PK_Table_1_Star_Rating_Id")
                    .IsClustered(false);

                entity.ToTable("Star_Rating");

                entity.HasIndex(e => e.StarRatingId)
                    .HasName("UX_Table_1_Star_Rating_Id")
                    .IsUnique();

                entity.HasIndex(e => e.StarRatingValue)
                    .HasName("UX_Table_1_Star_Rating_Value")
                    .IsUnique();

                entity.Property(e => e.StarRatingId).HasColumnName("Star_Rating_Id");

                entity.Property(e => e.StarRatingValue).HasColumnName("Star_Rating_Value");

                entity.Property(e => e.UserCommentIdFk).HasColumnName("User_Comment_Id_FK");

                entity.HasOne(d => d.UserCommentIdFkNavigation)
                    .WithMany(p => p.StarRating)
                    .HasForeignKey(d => d.UserCommentIdFk)
                    .HasConstraintName("Star_Rating_User_Comment_FK");
            });

            modelBuilder.Entity<StockTake>(entity =>
            {
                entity.HasKey(e => e.StockTakeId)
                    .HasName("PK_Table_1_Stock_Take_Id")
                    .IsClustered(false);

                entity.ToTable("Stock_Take");

                entity.HasIndex(e => e.StockTakeId)
                    .HasName("UX_Table_1_Stock_Take_Id")
                    .IsUnique();

                entity.Property(e => e.StockTakeId).HasColumnName("Stock_Take_Id");

                entity.Property(e => e.StockTakeDate)
                    .HasColumnName("Stock_take_date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK_Table_1_Supplier_Id")
                    .IsClustered(false);

                entity.HasIndex(e => e.SupplierId)
                    .HasName("UX_Table_1_Supplier_Id")
                    .IsUnique();

                entity.HasIndex(e => e.SupplierName)
                    .HasName("UX_Table_1_Supplier_Name")
                    .IsUnique();

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_Id");

                entity.Property(e => e.SupplierAddressLine1)
                    .IsRequired()
                    .HasColumnName("Supplier_Address_Line_1")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierAddressLine2)
                    .HasColumnName("Supplier_Address_Line_2")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierAddressLine3)
                    .HasColumnName("Supplier_Address_Line_3")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierCity)
                    .IsRequired()
                    .HasColumnName("Supplier_City")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierContactNumber)
                    .IsRequired()
                    .HasColumnName("Supplier_Contact_Number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierCountry)
                    .IsRequired()
                    .HasColumnName("Supplier_Country")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierDescription)
                    .HasColumnName("Supplier_Description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierEmail)
                    .IsRequired()
                    .HasColumnName("Supplier_Email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasColumnName("Supplier_Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SupplierPostalCode)
                    .HasColumnName("Supplier_Postal_Code")
                    .HasMaxLength(5)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SupplierOrder>(entity =>
            {
                entity.HasKey(e => e.SupplierOrderId)
                    .HasName("PK_Table_1_Supplier_Order_Id")
                    .IsClustered(false);

                entity.ToTable("Supplier_Order");

                entity.HasIndex(e => e.SupplierOrderId)
                    .HasName("UX_Table_1_Supplier_Order_Id")
                    .IsUnique();

                entity.Property(e => e.SupplierOrderId).HasColumnName("Supplier_Order_Id");

                entity.Property(e => e.SupplierIdFk).HasColumnName("Supplier_Id_FK");

                entity.Property(e => e.SupplierOrderDate)
                    .HasColumnName("Supplier_Order_Date")
                    .HasColumnType("date");

                entity.HasOne(d => d.SupplierIdFkNavigation)
                    .WithMany(p => p.SupplierOrder)
                    .HasForeignKey(d => d.SupplierIdFk)
                    .HasConstraintName("Supplier_Order_Supplier_FK");
            });

            modelBuilder.Entity<SupplierOrderLine>(entity =>
            {
                entity.HasKey(e => e.SupplierOrderLineId)
                    .HasName("PK_Supplier_Order_Line_Supplier_Order_Line_Id")
                    .IsClustered(false);

                entity.ToTable("Supplier_Order_Line");

                entity.HasIndex(e => e.SupplierOrderLineId);

                entity.Property(e => e.SupplierOrderLineId).HasColumnName("Supplier_Order_Line_Id");

                entity.Property(e => e.DeliveryLeadTime).HasColumnName("Delivery_Lead_Time");

                entity.Property(e => e.DiscountAgreement).HasColumnName("Discount_Agreement");

                entity.Property(e => e.OrderedQty).HasColumnName("Ordered_Qty");

                entity.Property(e => e.ProductIdFk).HasColumnName("Product_Id_FK");

                entity.Property(e => e.ProductStandardPrice).HasColumnName("Product_Standard_Price");

                entity.Property(e => e.SupplierOrderIdFk).HasColumnName("Supplier_Order_Id_FK");

                entity.HasOne(d => d.ProductIdFkNavigation)
                    .WithMany(p => p.SupplierOrderLine)
                    .HasForeignKey(d => d.ProductIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Product_FK_2");

                entity.HasOne(d => d.SupplierOrderIdFkNavigation)
                    .WithMany(p => p.SupplierOrderLine)
                    .HasForeignKey(d => d.SupplierOrderIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_1_Supplier_Order_FK");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("User_PK")
                    .IsClustered(false);

                entity.HasIndex(e => e.Email)
                    .HasName("UX_Table_1_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("UX_Table_1_Id")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UX_Table_1_Username")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("Id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeIdFk).HasColumnName("Employee_Id_FK");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasColumnName("Contact_Number")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("Surname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.EmployeeIdFkNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.EmployeeIdFk)
                    .HasConstraintName("User_Employee_FK");
            });

            modelBuilder.Entity<UserComment>(entity =>
            {
                entity.HasKey(e => e.UserCommentId)
                    .HasName("PK_Table_1_User_Comment_Id")
                    .IsClustered(false);

                entity.ToTable("User_Comment");

                entity.HasIndex(e => e.UserCommentId)
                    .HasName("UX_Table_1_User_Comment_Id")
                    .IsUnique();

                entity.Property(e => e.UserCommentId).HasColumnName("User_Comment_Id");

                entity.Property(e => e.RestaurantIdFk).HasColumnName("Restaurant_Id_FK");

                entity.Property(e => e.UserComment1)
                    .IsRequired()
                    .HasColumnName("User_Comment")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserCommentDateCreated)
                    .HasColumnName("User_Comment_Date_Created")
                    .HasColumnType("date");

                entity.HasOne(d => d.RestaurantIdFkNavigation)
                    .WithMany(p => p.UserComment)
                    .HasForeignKey(d => d.RestaurantIdFk)
                    .HasConstraintName("User_Comment_Restaurant_FK");
            });

            modelBuilder.Entity<UserImage>(entity =>
            {
                entity.HasKey(e => e.UserImageId)
                    .HasName("UserImage_PK")
                    .IsClustered(false);

                entity.Property(e => e.UserImageId).HasColumnName("UserImage_Id");

                entity.Property(e => e.ImageFile)
                    .IsRequired()
                    .HasColumnName("Image_File")
                    .HasColumnType("image");
            });



            modelBuilder.Entity<UserUserImage>(entity =>
            {
                entity.HasKey(e => e.UserUserImage1)
                    .HasName("PK_User_UserImage_User_UserImage")
                    .IsClustered(false);

                entity.ToTable("User_UserImage");

                entity.HasIndex(e => e.UserUserImage1);

                entity.Property(e => e.UserUserImage1).HasColumnName("User_UserImage");

                entity.Property(e => e.UserIdFk).HasColumnName("User_Id_FK");

                entity.Property(e => e.UserImageIdFk).HasColumnName("UserImage_Id_FK");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.UserUserImage)
                    .HasForeignKey(d => d.UserIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_UserImage_User_FK");

                entity.HasOne(d => d.UserImageIdFkNavigation)
                    .WithMany(p => p.UserUserImage)
                    .HasForeignKey(d => d.UserImageIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_UserImage_UserImage_FK");
            });

            modelBuilder.Entity<UserUserRole>(entity =>
            {
                entity.HasKey(e => e.UserUserRoleId)
                    .HasName("PK_User_UserRole_User_UserRole_Id")
                    .IsClustered(false);

                entity.ToTable("User_UserRole");

                entity.HasIndex(e => e.UserUserRoleId);

                entity.Property(e => e.UserUserRoleId).HasColumnName("User_UserRole_Id");

                entity.Property(e => e.UserIdFk).HasColumnName("User_Id_FK");

                entity.Property(e => e.UserRoleIdFk).HasColumnName("User_Role_Id_FK");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.UserUserRole)
                    .HasForeignKey(d => d.UserIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_UserRole_User_FK");
                /*
                entity.HasOne(d => d.UserRoleIdFkNavigation)
                    .WithMany(p => p.UserUserRole)
                    .HasForeignKey(d => d.UserRoleIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("User_UserRole_User_Role_FK");

                */
            });

            modelBuilder.Entity<WriteOffReason>(entity =>
            {
                entity.HasKey(e => new { e.WriteOffReasonId, e.WrittenOffStockIdFkFk, e.ProductIdFkFk })
                    .HasName("Write_Off_Reason_PK")
                    .IsClustered(false);

                entity.ToTable("Write_Off_Reason");

                entity.HasIndex(e => e.WriteOffReason1)
                    .HasName("UX_Table_1_Write_Off_Reason")
                    .IsUnique();

                entity.HasIndex(e => e.WriteOffReasonId)
                    .HasName("UX_Table_1_Write_Off_Reason_Id")
                    .IsUnique();

                entity.Property(e => e.WriteOffReasonId)
                    .HasColumnName("Write_Off_Reason_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.WrittenOffStockIdFkFk).HasColumnName("Written_Off_Stock_Id_FK_FK");

                entity.Property(e => e.ProductIdFkFk).HasColumnName("Product_Id_FK_FK");

                entity.Property(e => e.WriteOffReason1)
                    .IsRequired()
                    .HasColumnName("Write_Off_Reason")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProductWrittenOff)
                    .WithMany(p => p.WriteOffReason)
                    .HasForeignKey(d => new { d.WrittenOffStockIdFkFk, d.ProductIdFkFk })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Write_Off_Reason_Product_Written_Off_FK");
            });

            modelBuilder.Entity<WrittenOffStock>(entity =>
            {
                entity.HasKey(e => e.WrittenOfStockId)
                    .HasName("PK_Table_1_Written_Of_Stock_Id")
                    .IsClustered(false);

                entity.ToTable("Written_Off_Stock");

                entity.HasIndex(e => e.WrittenOfStockId)
                    .HasName("UX_Table_1_Written_Of_Stock_Id")
                    .IsUnique();

                entity.Property(e => e.WrittenOfStockId).HasColumnName("Written_Of_Stock_Id");

                entity.Property(e => e.WrittenOfStockDate)
                    .HasColumnName("Written_Of_Stock_Date")
                    .HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
