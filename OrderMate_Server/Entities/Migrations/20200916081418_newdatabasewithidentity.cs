using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class newdatabasewithidentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advertisement_Date",
                columns: table => new
                {
                    Advertisement_Date_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Advertisement_Date_Acvtive_From = table.Column<DateTime>(type: "date", nullable: false),
                    Advertisement_Date_Active_To = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Advertisement_Date_Id", x => x.Advertisement_Date_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement_Price",
                columns: table => new
                {
                    Advertisement_Price_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Advertisment_Price = table.Column<double>(nullable: false),
                    Advertisement_Price_Date_Updated = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Advertisement_Price_Id", x => x.Advertisement_Price_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    Allergy_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Allergy = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Allergy_Id", x => x.Allergy_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Layout_Type",
                columns: table => new
                {
                    Layout_Type_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Layout_Type = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layout_Type_Layout_Type_Id", x => x.Layout_Type_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Menu_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Menu_Description = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Menu_Date_Created = table.Column<DateTime>(type: "date", nullable: false),
                    Menu_Time_Active_From = table.Column<TimeSpan>(nullable: true),
                    Menu_Time_Active_To = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Menu_Id", x => x.Menu_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Item_Category",
                columns: table => new
                {
                    Menu_Item_Category_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Item_Category = table.Column<string>(fixedLength: true, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Menu_Item_Category_Id", x => x.Menu_Item_Category_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Item_Price",
                columns: table => new
                {
                    Menu_Item_Price_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Item_Price = table.Column<double>(nullable: false),
                    Menu_Item_Date_Updated = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Menu_Item_Price_Id", x => x.Menu_Item_Price_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Item_Type",
                columns: table => new
                {
                    Menu_Item_Type_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Item_Type = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Menu_Item_Type_Id", x => x.Menu_Item_Type_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Order_Status",
                columns: table => new
                {
                    Order_Status_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Status = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Order_Status_Id", x => x.Order_Status_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Product_Category",
                columns: table => new
                {
                    Product_Category_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Category = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Product_Category_Id", x => x.Product_Category_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Product_Reorder_Freq",
                columns: table => new
                {
                    Product_Reorder_Freq_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Reorder_Freq = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Reorder_Freq_Product_Reorder_Freq_Id", x => x.Product_Reorder_Freq_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Product_Type",
                columns: table => new
                {
                    Product_Type_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Type = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Product_Type_Id", x => x.Product_Type_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Reservation_Status",
                columns: table => new
                {
                    Reservation_Status_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_Status = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Reservation_Status_Id", x => x.Reservation_Status_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant_Facility",
                columns: table => new
                {
                    Restaurant_Facility_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Facility = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Restaurant_Facility_Id", x => x.Restaurant_Facility_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant_Status",
                columns: table => new
                {
                    Restaurant_Status_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Status = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Restaurant_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Restaurant_Status_ID", x => x.Restaurant_Status_ID)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant_Type",
                columns: table => new
                {
                    Restaurant_Type_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Type = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Restaurant_Type_Id", x => x.Restaurant_Type_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Shift_Status",
                columns: table => new
                {
                    Shift_Status_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift_Status = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Shift_Status_Id", x => x.Shift_Status_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Social_Media_Type",
                columns: table => new
                {
                    Social_Media_Type_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Social_Media_Type = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Social_Media_Type_Id", x => x.Social_Media_Type_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Special",
                columns: table => new
                {
                    Special_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Special_Start_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Special_End_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Special_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Special_Description = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Special_Id", x => x.Special_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Stock_Take",
                columns: table => new
                {
                    Stock_Take_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock_take_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Stock_Take_Id", x => x.Stock_Take_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Supplier_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Supplier_Description = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Supplier_Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Supplier_Contact_Number = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Supplier_Address_Line_1 = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Supplier_Address_Line_2 = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Supplier_Address_Line_3 = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Supplier_City = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Supplier_Postal_Code = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    Supplier_Country = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Supplier_Id", x => x.Supplier_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "UserImage",
                columns: table => new
                {
                    UserImage_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_File = table.Column<byte[]>(type: "image", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("UserImage_PK", x => x.UserImage_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Written_Off_Stock",
                columns: table => new
                {
                    Written_Of_Stock_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Written_Of_Stock_Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Written_Of_Stock_Id", x => x.Written_Of_Stock_Id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    Advertisement_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Advertisement_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Advertisement_Description = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Advertisement_File = table.Column<byte[]>(type: "image", nullable: true),
                    Advertisement_Date_Id_FK = table.Column<int>(nullable: true),
                    Advertisement_Price_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Advertisement_Id", x => x.Advertisement_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Advertisement_Advertisement_Date_FK",
                        column: x => x.Advertisement_Date_Id_FK,
                        principalTable: "Advertisement_Date",
                        principalColumn: "Advertisement_Date_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Advertisement_Advertisement_Price_FK",
                        column: x => x.Advertisement_Price_Id_FK,
                        principalTable: "Advertisement_Price",
                        principalColumn: "Advertisement_Price_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Item",
                columns: table => new
                {
                    Menu_Item_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Item_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Menu_Item_Description = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Menu_Item_Category_Id_FK = table.Column<int>(nullable: true),
                    Menu_Item_Price_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Menu_Item_Id", x => x.Menu_Item_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Menu_Item_Menu_Item_Category_FK",
                        column: x => x.Menu_Item_Category_Id_FK,
                        principalTable: "Menu_Item_Category",
                        principalColumn: "Menu_Item_Category_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Menu_Item_Menu_Item_Price_FK",
                        column: x => x.Menu_Item_Price_Id_FK,
                        principalTable: "Menu_Item_Price",
                        principalColumn: "Menu_Item_Price_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Order_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order_Date_Created = table.Column<DateTime>(type: "date", nullable: false),
                    Order_Date_Completed = table.Column<DateTime>(type: "date", nullable: true),
                    QrCode_Seating_Id_FK = table.Column<int>(nullable: true),
                    Order_Status_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Order_Id", x => x.Order_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Order_Order_Status_FK",
                        column: x => x.Order_Status_Id_FK,
                        principalTable: "Order_Status",
                        principalColumn: "Order_Status_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Product_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Product_Description = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Product_Reorder_Level = table.Column<int>(nullable: false),
                    Product_On_Hand = table.Column<int>(nullable: false),
                    Product_Type_Id_FK = table.Column<int>(nullable: true),
                    Product_Category_Id_FK = table.Column<int>(nullable: true),
                    Product_Reorder_Freq_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Product_Id", x => x.Product_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Product_Product_Category_FK",
                        column: x => x.Product_Category_Id_FK,
                        principalTable: "Product_Category",
                        principalColumn: "Product_Category_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Product_Product_Reorder_Freq_FK",
                        column: x => x.Product_Reorder_Freq_Id_FK,
                        principalTable: "Product_Reorder_Freq",
                        principalColumn: "Product_Reorder_Freq_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Product_Product_Type_FK",
                        column: x => x.Product_Type_Id_FK,
                        principalTable: "Product_Type",
                        principalColumn: "Product_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Shift_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift_Start_Date_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Shift_End_Date_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Shift_Capacity = table.Column<int>(nullable: false),
                    Shift_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Shift_Status_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Shift_Id", x => x.Shift_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Shift_Shift_Status_FK",
                        column: x => x.Shift_Status_Id_FK,
                        principalTable: "Shift_Status",
                        principalColumn: "Shift_Status_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Social_Media",
                columns: table => new
                {
                    Social_Media_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Social_Media_Type_Id_FK = table.Column<int>(nullable: false),
                    Social_Media_Address = table.Column<string>(unicode: false, maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Social_Media_PK", x => new { x.Social_Media_Id, x.Social_Media_Type_Id_FK })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Social_Media_Social_Media_Type_FK",
                        column: x => x.Social_Media_Type_Id_FK,
                        principalTable: "Social_Media_Type",
                        principalColumn: "Social_Media_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Special_Price",
                columns: table => new
                {
                    Special_Price_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Special_Price = table.Column<double>(nullable: false),
                    Special_Price_Date_Updated = table.Column<DateTime>(type: "date", nullable: false),
                    Special_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Special_Price_Id", x => x.Special_Price_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Special_Price_Special_FK",
                        column: x => x.Special_Id_FK,
                        principalTable: "Special",
                        principalColumn: "Special_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplier_Order",
                columns: table => new
                {
                    Supplier_Order_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier_Order_Date = table.Column<DateTime>(type: "date", nullable: false),
                    Supplier_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Supplier_Order_Id", x => x.Supplier_Order_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Supplier_Order_Supplier_FK",
                        column: x => x.Supplier_Id_FK,
                        principalTable: "Supplier",
                        principalColumn: "Supplier_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item_Type_Menu_Menu_Item",
                columns: table => new
                {
                    Item_Type_menu_Item_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Item_Id_FK = table.Column<int>(nullable: false),
                    Menu_Item_Type_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Type_Menu_Menu_Item_Item_Type_menu_Item_Id", x => x.Item_Type_menu_Item_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Table_1_Menu_Item_FK_1",
                        column: x => x.Menu_Item_Id_FK,
                        principalTable: "Menu_Item",
                        principalColumn: "Menu_Item_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Menu_Item_Type_FK",
                        column: x => x.Menu_Item_Type_Id_FK,
                        principalTable: "Menu_Item_Type",
                        principalColumn: "Menu_Item_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Item_Allergy",
                columns: table => new
                {
                    Menu_Item_Allergy_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Item_Id_FK = table.Column<int>(nullable: false),
                    Allergy_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Item_Allergy_Menu_Item_Allergy_Id", x => x.Menu_Item_Allergy_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Table_1_Allergy_FK",
                        column: x => x.Allergy_Id_FK,
                        principalTable: "Allergy",
                        principalColumn: "Allergy_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Menu_Item_FK",
                        column: x => x.Menu_Item_Id_FK,
                        principalTable: "Menu_Item",
                        principalColumn: "Menu_Item_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Item_Special",
                columns: table => new
                {
                    Menu_Item_Special_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Special_Id_FK = table.Column<int>(nullable: false),
                    Menu_Item_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Item_Special_Menu_Item_Special_Id", x => x.Menu_Item_Special_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Table_1_Menu_Item_FK_2",
                        column: x => x.Menu_Item_Id_FK,
                        principalTable: "Menu_Item",
                        principalColumn: "Menu_Item_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Special_FK",
                        column: x => x.Special_Id_FK,
                        principalTable: "Special",
                        principalColumn: "Special_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Restaurant_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Restaurant_Url = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    Restaurant_Description = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Restaurant_Date_Created = table.Column<DateTime>(type: "date", nullable: true),
                    Restaurant_Address_Line_1 = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Resaturant_Address_Line_2 = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Restaurant_City = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Restaurant_Postal_Code = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Restaurant_Province = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Restaurant_Country = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Restaurant_Status_ID_FK = table.Column<int>(nullable: true),
                    QrCode_Id_FK = table.Column<int>(nullable: true),
                    Social_Media_Id_FK = table.Column<int>(nullable: true),
                    Social_Media_Type_Id_FK_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Restaurant_Id", x => x.Restaurant_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Restaurant_Restaurant_Status_FK",
                        column: x => x.Restaurant_Status_ID_FK,
                        principalTable: "Restaurant_Status",
                        principalColumn: "Restaurant_Status_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Restaurant_Social_Media_FK",
                        columns: x => new { x.Social_Media_Id_FK, x.Social_Media_Type_Id_FK_FK },
                        principalTable: "Social_Media",
                        principalColumns: new[] { "Social_Media_Id", "Social_Media_Type_Id_FK" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Supplier_Order_Line",
                columns: table => new
                {
                    Supplier_Order_Line_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_Id_FK = table.Column<int>(nullable: false),
                    Supplier_Order_Id_FK = table.Column<int>(nullable: false),
                    Delivery_Lead_Time = table.Column<int>(nullable: false),
                    Product_Standard_Price = table.Column<double>(nullable: false),
                    Discount_Agreement = table.Column<double>(nullable: false),
                    Ordered_Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier_Order_Line_Supplier_Order_Line_Id", x => x.Supplier_Order_Line_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Table_1_Product_FK_2",
                        column: x => x.Product_Id_FK,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Supplier_Order_FK",
                        column: x => x.Supplier_Order_Id_FK,
                        principalTable: "Supplier_Order",
                        principalColumn: "Supplier_Order_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Employee_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Id_Number = table.Column<string>(unicode: false, maxLength: 13, nullable: false),
                    Restaurant_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Employee_Id", x => x.Employee_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Employee_Restaurant_FK",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Restaurant",
                columns: table => new
                {
                    Menu_Restaurant_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_Id_FK = table.Column<int>(nullable: false),
                    Restaurant_Id_FK = table.Column<int>(nullable: false),
                    Menu_Item_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Restaurant", x => x.Menu_Restaurant_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Menu_Restaurant_Menu_FK",
                        column: x => x.Menu_Id_FK,
                        principalTable: "Menu",
                        principalColumn: "Menu_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Menu_Restaurant_Menu_Item_FK",
                        column: x => x.Menu_Item_Id_FK,
                        principalTable: "Menu_Item",
                        principalColumn: "Menu_Item_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Menu_Restaurant_Restaurant_FK",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QrCode",
                columns: table => new
                {
                    QrCode_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCode", x => x.QrCode_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "QrCode_Restaurant_FK",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resaurant_Facility_Ref",
                columns: table => new
                {
                    Restaurant_Facility_Ref_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Facility_Id_FK = table.Column<int>(nullable: false),
                    Restaurant_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resaurant_Facility_Ref_Restaurant_Facility_Ref_Id", x => x.Restaurant_Facility_Ref_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Res_Fac_Restaurant_Facility_FK",
                        column: x => x.Restaurant_Facility_Id_FK,
                        principalTable: "Restaurant_Facility",
                        principalColumn: "Restaurant_Facility_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Restaurant_FK_1",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant_Advertisement",
                columns: table => new
                {
                    Restaurant_Advertisesement_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Id_FK = table.Column<int>(nullable: false),
                    Advertisement_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant_Advertisement_Restaurant_Advertisesement_Id", x => x.Restaurant_Advertisesement_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Table_1_Advertisement_FK",
                        column: x => x.Advertisement_Id_FK,
                        principalTable: "Advertisement",
                        principalColumn: "Advertisement_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Restaurant_FK",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant_Image",
                columns: table => new
                {
                    Restaurant_Image_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image_Description = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Image_File = table.Column<byte[]>(type: "image", nullable: true),
                    Restaurant_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Restaurant_Image_Id", x => x.Restaurant_Image_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Restaurant_Image_Restaurant_FK",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant_Type_Reference",
                columns: table => new
                {
                    Restaurant_Type_Ref_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Type_Id_FK = table.Column<int>(nullable: false),
                    Restaurant_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant_Type_Reference_Restaurant_Type_Ref_Id", x => x.Restaurant_Type_Ref_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Table_1_Restaurant_FK_2",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Restaurant_Type_FK",
                        column: x => x.Restaurant_Type_Id_FK,
                        principalTable: "Restaurant_Type",
                        principalColumn: "Restaurant_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seating_Layout",
                columns: table => new
                {
                    Seating_Layout_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Id_FK = table.Column<int>(nullable: false),
                    Layout_Type_Id_FK = table.Column<int>(nullable: false),
                    Seating_Layout_Qty = table.Column<string>(fixedLength: true, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Seating_Layout_PK", x => new { x.Seating_Layout_Id, x.Restaurant_Id_FK, x.Layout_Type_Id_FK })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Seating_Layout_Layout_Type_FK",
                        column: x => x.Layout_Type_Id_FK,
                        principalTable: "Layout_Type",
                        principalColumn: "Layout_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Seating_Layout_Restaurant_FK",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Comment",
                columns: table => new
                {
                    User_Comment_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Comment = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    User_Comment_Date_Created = table.Column<DateTime>(type: "date", nullable: false),
                    Restaurant_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_User_Comment_Id", x => x.User_Comment_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "User_Comment_Restaurant_FK",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Surname = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Contact_Number = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    Employee_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_PK", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "User_Employee_FK",
                        column: x => x.Employee_Id_FK,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attendance_Sheet",
                columns: table => new
                {
                    Attendance_Sheet_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clock_In_Date_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Clock_Out_Date_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    Employee_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Attendance_Sheet_Id", x => x.Attendance_Sheet_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Attendance_Sheet_Employee_FK",
                        column: x => x.Employee_Id_FK,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Shift",
                columns: table => new
                {
                    Employee_Shift_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Shift_Id_FK = table.Column<int>(nullable: false),
                    Employee_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Shift_Employee_Shift_Id", x => x.Employee_Shift_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Table_1_Employee_FK",
                        column: x => x.Employee_Id_FK,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Shift_FK",
                        column: x => x.Shift_Id_FK,
                        principalTable: "Shift",
                        principalColumn: "Shift_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Stock_Take",
                columns: table => new
                {
                    Product_Stock_Take_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Id_FK = table.Column<int>(nullable: true),
                    Product_Id_FK = table.Column<int>(nullable: false),
                    Product_Stock_Take_Qty = table.Column<int>(nullable: false),
                    Stock_Take_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Stock_Take_Product_Stock_Take_Id", x => x.Product_Stock_Take_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Table_1_Employee_FK_1",
                        column: x => x.Employee_Id_FK,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Product_FK",
                        column: x => x.Product_Id_FK,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Product_Stock_Take_Stock_Take_FK",
                        column: x => x.Stock_Take_Id_FK,
                        principalTable: "Stock_Take",
                        principalColumn: "Stock_Take_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product_Written_Off",
                columns: table => new
                {
                    Written_Off_Stock_Id_FK = table.Column<int>(nullable: false),
                    Product_Id_FK = table.Column<int>(nullable: false),
                    Written_Off_Qty = table.Column<int>(nullable: false),
                    Employee_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Written_Off_Written_Off_Stock_Id_FK_Product_Id_FK", x => new { x.Written_Off_Stock_Id_FK, x.Product_Id_FK })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Product_Written_Off_Employee_FK",
                        column: x => x.Employee_Id_FK,
                        principalTable: "Employee",
                        principalColumn: "Employee_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Product_FK_1",
                        column: x => x.Product_Id_FK,
                        principalTable: "Product",
                        principalColumn: "Product_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Table_1_Written_Off_Stock_FK",
                        column: x => x.Written_Off_Stock_Id_FK,
                        principalTable: "Written_Off_Stock",
                        principalColumn: "Written_Of_Stock_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant_Restaurant_Image",
                columns: table => new
                {
                    Restaurant_Restaurant_Image_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant_Id_FK = table.Column<int>(nullable: false),
                    Restaurant_Image_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant_Restaurant_Image_Restaurant_Restaurant_Image_Id", x => x.Restaurant_Restaurant_Image_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Restaurant_Restaurant_Image_Restaurant_FK",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Restaurant_Restaurant_Image_Restaurant_Image_FK",
                        column: x => x.Restaurant_Image_Id_FK,
                        principalTable: "Restaurant_Image",
                        principalColumn: "Restaurant_Image_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Star_Rating",
                columns: table => new
                {
                    Star_Rating_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Star_Rating_Value = table.Column<int>(nullable: false),
                    User_Comment_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Star_Rating_Id", x => x.Star_Rating_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Star_Rating_User_Comment_FK",
                        column: x => x.User_Comment_Id_FK,
                        principalTable: "User_Comment",
                        principalColumn: "User_Comment_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order_Line",
                columns: table => new
                {
                    Order_Line_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Qty = table.Column<int>(nullable: false),
                    Item_Comments = table.Column<string>(unicode: false, maxLength: 200, nullable: false),
                    Special_Id_FK = table.Column<int>(nullable: true),
                    Menu_Item_Id_FK = table.Column<int>(nullable: true),
                    Order_Id_FK = table.Column<int>(nullable: true),
                    User_Id_FK = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table_1_Order_Line_id", x => x.Order_Line_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Order_Line_Menu_Item_FK",
                        column: x => x.Menu_Item_Id_FK,
                        principalTable: "Menu_Item",
                        principalColumn: "Menu_Item_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Order_Line_Order_FK",
                        column: x => x.Order_Id_FK,
                        principalTable: "Order",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Order_Line_Special_FK",
                        column: x => x.Special_Id_FK,
                        principalTable: "Special",
                        principalColumn: "Special_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Order_Line_User_FK",
                        column: x => x.User_Id_FK,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Reservation_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_date_Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    Reservation_Date_Reserved = table.Column<DateTime>(type: "datetime", nullable: false),
                    Reservation_Party_Qty = table.Column<int>(nullable: false),
                    User_Id_FK = table.Column<string>(nullable: true),
                    Reservation_Status_Id_FK = table.Column<int>(nullable: true),
                    Reservation_NumberOfBills = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation_Reservation_Id", x => x.Reservation_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Reservation_Reservation_Status_FK",
                        column: x => x.Reservation_Status_Id_FK,
                        principalTable: "Reservation_Status",
                        principalColumn: "Reservation_Status_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Reservation_User_FK",
                        column: x => x.User_Id_FK,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_UserImage",
                columns: table => new
                {
                    User_UserImage = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id_FK = table.Column<string>(nullable: true),
                    UserImage_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_UserImage_User_UserImage", x => x.User_UserImage)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "User_UserImage_User_FK",
                        column: x => x.User_Id_FK,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "User_UserImage_UserImage_FK",
                        column: x => x.UserImage_Id_FK,
                        principalTable: "UserImage",
                        principalColumn: "UserImage_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_UserRole",
                columns: table => new
                {
                    User_UserRole_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id_FK = table.Column<string>(nullable: true),
                    User_Role_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_UserRole_User_UserRole_Id", x => x.User_UserRole_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "User_UserRole_User_FK",
                        column: x => x.User_Id_FK,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Write_Off_Reason",
                columns: table => new
                {
                    Write_Off_Reason_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Written_Off_Stock_Id_FK_FK = table.Column<int>(nullable: false),
                    Product_Id_FK_FK = table.Column<int>(nullable: false),
                    Write_Off_Reason = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Write_Off_Reason_PK", x => new { x.Write_Off_Reason_Id, x.Written_Off_Stock_Id_FK_FK, x.Product_Id_FK_FK })
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Write_Off_Reason_Product_Written_Off_FK",
                        columns: x => new { x.Written_Off_Stock_Id_FK_FK, x.Product_Id_FK_FK },
                        principalTable: "Product_Written_Off",
                        principalColumns: new[] { "Written_Off_Stock_Id_FK", "Product_Id_FK" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation_Restaurant",
                columns: table => new
                {
                    Reservation_Restaurant_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reservation_Id_FK = table.Column<int>(nullable: false),
                    Restaurant_Id_FK = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation_Restaurant_Reservation_Restaurant_Id", x => x.Reservation_Restaurant_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Reservation_Restaurant_Reservation_FK",
                        column: x => x.Reservation_Id_FK,
                        principalTable: "Reservation",
                        principalColumn: "Reservation_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Reservation_Restaurant_Restaurant_FK",
                        column: x => x.Restaurant_Id_FK,
                        principalTable: "Restaurant",
                        principalColumn: "Restaurant_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seating",
                columns: table => new
                {
                    SeatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatingDate = table.Column<DateTime>(type: "date", nullable: false),
                    SeatingTime = table.Column<TimeSpan>(nullable: false),
                    Reservation_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seating_SeatingId", x => x.SeatingId)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "Seating_Reservation_FK",
                        column: x => x.Reservation_Id_FK,
                        principalTable: "Reservation",
                        principalColumn: "Reservation_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QrCode_Seating",
                columns: table => new
                {
                    QrCode_Seating_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr_Of_People = table.Column<int>(nullable: false),
                    QrCode_Id_FK = table.Column<int>(nullable: false),
                    SeatingId_FK = table.Column<int>(nullable: false),
                    Order_Id_FK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCode_Seating_QrCode_Seating_Id", x => x.QrCode_Seating_Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "QrCode_Seating_Order_FK",
                        column: x => x.Order_Id_FK,
                        principalTable: "Order",
                        principalColumn: "Order_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "QrCode_Seating_QrCode_FK",
                        column: x => x.QrCode_Id_FK,
                        principalTable: "QrCode",
                        principalColumn: "QrCode_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "QrCode_Seating_Seating_FK",
                        column: x => x.SeatingId_FK,
                        principalTable: "Seating",
                        principalColumn: "SeatingId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_Advertisement_Date_Id_FK",
                table: "Advertisement",
                column: "Advertisement_Date_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Advertisement_Id",
                table: "Advertisement",
                column: "Advertisement_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_Advertisement_Price_Id_FK",
                table: "Advertisement",
                column: "Advertisement_Price_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Advertisement_Date_Id",
                table: "Advertisement_Date",
                column: "Advertisement_Date_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Advertisement_Price_Id",
                table: "Advertisement_Price",
                column: "Advertisement_Price_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Allergy_Id",
                table: "Allergy",
                column: "Allergy_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Employee_Id_FK",
                table: "AspNetUsers",
                column: "Employee_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Id",
                table: "AspNetUsers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Username",
                table: "AspNetUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Attendance_Sheet_Id",
                table: "Attendance_Sheet",
                column: "Attendance_Sheet_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Sheet_Employee_Id_FK",
                table: "Attendance_Sheet",
                column: "Employee_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Employee_Id",
                table: "Employee",
                column: "Employee_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Employee_Id_Number",
                table: "Employee",
                column: "Employee_Id_Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Restaurant_Id_FK",
                table: "Employee",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Shift_Employee_Id_FK",
                table: "Employee_Shift",
                column: "Employee_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Shift_Employee_Shift_Id",
                table: "Employee_Shift",
                column: "Employee_Shift_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Shift_Shift_Id_FK",
                table: "Employee_Shift",
                column: "Shift_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Type_Menu_Menu_Item_Item_Type_menu_Item_Id",
                table: "Item_Type_Menu_Menu_Item",
                column: "Item_Type_menu_Item_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Type_Menu_Menu_Item_Menu_Item_Id_FK",
                table: "Item_Type_Menu_Menu_Item",
                column: "Menu_Item_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Type_Menu_Menu_Item_Menu_Item_Type_Id_FK",
                table: "Item_Type_Menu_Menu_Item",
                column: "Menu_Item_Type_Id_FK");

            migrationBuilder.CreateIndex(
                name: "AK_Table_1_Layout_Type_Id",
                table: "Layout_Type",
                column: "Layout_Type_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Menu_Id",
                table: "Menu",
                column: "Menu_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Menu_Item_Category_Id_FK",
                table: "Menu_Item",
                column: "Menu_Item_Category_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Menu_Item_Id",
                table: "Menu_Item",
                column: "Menu_Item_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Menu_Item_Price_Id_FK",
                table: "Menu_Item",
                column: "Menu_Item_Price_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Allergy_Allergy_Id_FK",
                table: "Menu_Item_Allergy",
                column: "Allergy_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Allergy_Menu_Item_Allergy_Id",
                table: "Menu_Item_Allergy",
                column: "Menu_Item_Allergy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Allergy_Menu_Item_Id_FK",
                table: "Menu_Item_Allergy",
                column: "Menu_Item_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Menu_Item_Category_Id",
                table: "Menu_Item_Category",
                column: "Menu_Item_Category_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Menu_Item_Price_Id",
                table: "Menu_Item_Price",
                column: "Menu_Item_Price_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Special_Menu_Item_Id_FK",
                table: "Menu_Item_Special",
                column: "Menu_Item_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Special_Menu_Item_Special_Id",
                table: "Menu_Item_Special",
                column: "Menu_Item_Special_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Item_Special_Special_Id_FK",
                table: "Menu_Item_Special",
                column: "Special_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Menu_Item_Type_Id",
                table: "Menu_Item_Type",
                column: "Menu_Item_Type_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Restaurant_Menu_Id_FK",
                table: "Menu_Restaurant",
                column: "Menu_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Restaurant_Menu_Item_Id_FK",
                table: "Menu_Restaurant",
                column: "Menu_Item_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Restaurant_Restaurant_Id_FK",
                table: "Menu_Restaurant",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Order_Order_Id",
                table: "Order",
                column: "Order_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Order_Status_Id_FK",
                table: "Order",
                column: "Order_Status_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Line_Menu_Item_Id_FK",
                table: "Order_Line",
                column: "Menu_Item_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Line_Order_Id_FK",
                table: "Order_Line",
                column: "Order_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Order_Line_id",
                table: "Order_Line",
                column: "Order_Line_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_Line_Special_Id_FK",
                table: "Order_Line",
                column: "Special_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Line_User_Id_FK",
                table: "Order_Line",
                column: "User_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Order_Status_Id",
                table: "Order_Status",
                column: "Order_Status_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Product_Category_Id_FK",
                table: "Product",
                column: "Product_Category_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Product_Id",
                table: "Product",
                column: "Product_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Product_Name",
                table: "Product",
                column: "Product_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Product_Reorder_Freq_Id_FK",
                table: "Product",
                column: "Product_Reorder_Freq_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Product_Type_Id_FK",
                table: "Product",
                column: "Product_Type_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Product_Category",
                table: "Product_Category",
                column: "Product_Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Product_Category_Id",
                table: "Product_Category",
                column: "Product_Category_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Product_Reorder_Freq",
                table: "Product_Reorder_Freq",
                column: "Product_Reorder_Freq",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Product_Reorder_Freq_Product_Reorder_Freq_Id",
                table: "Product_Reorder_Freq",
                column: "Product_Reorder_Freq_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Stock_Take_Employee_Id_FK",
                table: "Product_Stock_Take",
                column: "Employee_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Stock_Take_Product_Id_FK",
                table: "Product_Stock_Take",
                column: "Product_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Stock_Take_Product_Stock_Take_Id",
                table: "Product_Stock_Take",
                column: "Product_Stock_Take_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Stock_Take_Stock_Take_Id_FK",
                table: "Product_Stock_Take",
                column: "Stock_Take_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Product_Type",
                table: "Product_Type",
                column: "Product_Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Product_Type_Id",
                table: "Product_Type",
                column: "Product_Type_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Written_Off_Employee_Id_FK",
                table: "Product_Written_Off",
                column: "Employee_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Written_Off_Product_Id_FK",
                table: "Product_Written_Off",
                column: "Product_Id_FK");

            migrationBuilder.CreateIndex(
                name: "AK_QrCode_QrCode_Id",
                table: "QrCode",
                column: "QrCode_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_Restaurant_Id_FK",
                table: "QrCode",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_Seating_Order_Id_FK",
                table: "QrCode_Seating",
                column: "Order_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_Seating_QrCode_Id_FK",
                table: "QrCode_Seating",
                column: "QrCode_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_QrCode_Seating_QrCode_Seating_Id",
                table: "QrCode_Seating",
                column: "QrCode_Seating_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_Seating_SeatingId_FK",
                table: "QrCode_Seating",
                column: "SeatingId_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Resaurant_Facility_Ref_Restaurant_Facility_Id_FK",
                table: "Resaurant_Facility_Ref",
                column: "Restaurant_Facility_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Resaurant_Facility_Ref_Restaurant_Facility_Ref_Id",
                table: "Resaurant_Facility_Ref",
                column: "Restaurant_Facility_Ref_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Resaurant_Facility_Ref_Restaurant_Id_FK",
                table: "Resaurant_Facility_Ref",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Reservation_Reservation_Id",
                table: "Reservation",
                column: "Reservation_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Reservation_Status_Id_FK",
                table: "Reservation",
                column: "Reservation_Status_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_User_Id_FK",
                table: "Reservation",
                column: "User_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Restaurant_Reservation_Id_FK",
                table: "Reservation_Restaurant",
                column: "Reservation_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Restaurant_Reservation_Restaurant_Id",
                table: "Reservation_Restaurant",
                column: "Reservation_Restaurant_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_Restaurant_Restaurant_Id_FK",
                table: "Reservation_Restaurant",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Reservation_Status_Id",
                table: "Reservation_Status",
                column: "Reservation_Status_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Restaurant_Id",
                table: "Restaurant",
                column: "Restaurant_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Restaurant_Status_ID_FK",
                table: "Restaurant",
                column: "Restaurant_Status_ID_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Social_Media_Id_FK_Social_Media_Type_Id_FK_FK",
                table: "Restaurant",
                columns: new[] { "Social_Media_Id_FK", "Social_Media_Type_Id_FK_FK" });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Advertisement_Advertisement_Id_FK",
                table: "Restaurant_Advertisement",
                column: "Advertisement_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Advertisement_Restaurant_Advertisesement_Id",
                table: "Restaurant_Advertisement",
                column: "Restaurant_Advertisesement_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Advertisement_Restaurant_Id_FK",
                table: "Restaurant_Advertisement",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Restaurant_Facility_Id",
                table: "Restaurant_Facility",
                column: "Restaurant_Facility_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Image_Restaurant_Id_FK",
                table: "Restaurant_Image",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Restaurant_Image_Id",
                table: "Restaurant_Image",
                column: "Restaurant_Image_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Restaurant_Image_Restaurant_Id_FK",
                table: "Restaurant_Restaurant_Image",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Restaurant_Image_Restaurant_Image_Id_FK",
                table: "Restaurant_Restaurant_Image",
                column: "Restaurant_Image_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Restaurant_Image_Restaurant_Restaurant_Image_Id",
                table: "Restaurant_Restaurant_Image",
                column: "Restaurant_Restaurant_Image_Id");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Restaurant_Status_ID",
                table: "Restaurant_Status",
                column: "Restaurant_Status_ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "AK_Table_1_Restaurant_Facility_Id",
                table: "Restaurant_Type",
                column: "Restaurant_Type_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Type_Reference_Restaurant_Id_FK",
                table: "Restaurant_Type_Reference",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Type_Reference_Restaurant_Type_Id_FK",
                table: "Restaurant_Type_Reference",
                column: "Restaurant_Type_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_Type_Reference_Restaurant_Type_Ref_Id",
                table: "Restaurant_Type_Reference",
                column: "Restaurant_Type_Ref_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Seating_Reservation_Id_FK",
                table: "Seating",
                column: "Reservation_Id_FK");

            migrationBuilder.CreateIndex(
                name: "AK_Seating_SeatingId",
                table: "Seating",
                column: "SeatingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seating_Layout_Layout_Type_Id_FK",
                table: "Seating_Layout",
                column: "Layout_Type_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Seating_Layout_Restaurant_Id_FK",
                table: "Seating_Layout",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Seating_Layout_Id",
                table: "Seating_Layout",
                column: "Seating_Layout_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Shift_Id",
                table: "Shift",
                column: "Shift_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Shift_Name",
                table: "Shift",
                column: "Shift_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shift_Shift_Status_Id_FK",
                table: "Shift",
                column: "Shift_Status_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Shift_Status",
                table: "Shift_Status",
                column: "Shift_Status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Shift_Status_Id",
                table: "Shift_Status",
                column: "Shift_Status_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Social_Media_Id",
                table: "Social_Media",
                column: "Social_Media_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Social_Media_Social_Media_Type_Id_FK",
                table: "Social_Media",
                column: "Social_Media_Type_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Social_Media_Type_Id",
                table: "Social_Media_Type",
                column: "Social_Media_Type_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Special_Id",
                table: "Special",
                column: "Special_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Special_Price_Special_Id_FK",
                table: "Special_Price",
                column: "Special_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Special_Price_Id",
                table: "Special_Price",
                column: "Special_Price_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Star_Rating_Id",
                table: "Star_Rating",
                column: "Star_Rating_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Star_Rating_Value",
                table: "Star_Rating",
                column: "Star_Rating_Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Star_Rating_User_Comment_Id_FK",
                table: "Star_Rating",
                column: "User_Comment_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Stock_Take_Id",
                table: "Stock_Take",
                column: "Stock_Take_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Supplier_Id",
                table: "Supplier",
                column: "Supplier_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Supplier_Name",
                table: "Supplier",
                column: "Supplier_Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Order_Supplier_Id_FK",
                table: "Supplier_Order",
                column: "Supplier_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Supplier_Order_Id",
                table: "Supplier_Order",
                column: "Supplier_Order_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Order_Line_Product_Id_FK",
                table: "Supplier_Order_Line",
                column: "Product_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Order_Line_Supplier_Order_Id_FK",
                table: "Supplier_Order_Line",
                column: "Supplier_Order_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_Order_Line_Supplier_Order_Line_Id",
                table: "Supplier_Order_Line",
                column: "Supplier_Order_Line_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Comment_Restaurant_Id_FK",
                table: "User_Comment",
                column: "Restaurant_Id_FK");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_User_Comment_Id",
                table: "User_Comment",
                column: "User_Comment_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserImage_User_Id_FK",
                table: "User_UserImage",
                column: "User_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserImage_UserImage_Id_FK",
                table: "User_UserImage",
                column: "UserImage_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserImage_User_UserImage",
                table: "User_UserImage",
                column: "User_UserImage");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRole_User_Id_FK",
                table: "User_UserRole",
                column: "User_Id_FK");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRole_User_UserRole_Id",
                table: "User_UserRole",
                column: "User_UserRole_Id");

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Write_Off_Reason",
                table: "Write_Off_Reason",
                column: "Write_Off_Reason",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Write_Off_Reason_Id",
                table: "Write_Off_Reason",
                column: "Write_Off_Reason_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Write_Off_Reason_Written_Off_Stock_Id_FK_FK_Product_Id_FK_FK",
                table: "Write_Off_Reason",
                columns: new[] { "Written_Off_Stock_Id_FK_FK", "Product_Id_FK_FK" });

            migrationBuilder.CreateIndex(
                name: "UX_Table_1_Written_Of_Stock_Id",
                table: "Written_Off_Stock",
                column: "Written_Of_Stock_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Attendance_Sheet");

            migrationBuilder.DropTable(
                name: "Employee_Shift");

            migrationBuilder.DropTable(
                name: "Item_Type_Menu_Menu_Item");

            migrationBuilder.DropTable(
                name: "Menu_Item_Allergy");

            migrationBuilder.DropTable(
                name: "Menu_Item_Special");

            migrationBuilder.DropTable(
                name: "Menu_Restaurant");

            migrationBuilder.DropTable(
                name: "Order_Line");

            migrationBuilder.DropTable(
                name: "Product_Stock_Take");

            migrationBuilder.DropTable(
                name: "QrCode_Seating");

            migrationBuilder.DropTable(
                name: "Resaurant_Facility_Ref");

            migrationBuilder.DropTable(
                name: "Reservation_Restaurant");

            migrationBuilder.DropTable(
                name: "Restaurant_Advertisement");

            migrationBuilder.DropTable(
                name: "Restaurant_Restaurant_Image");

            migrationBuilder.DropTable(
                name: "Restaurant_Type_Reference");

            migrationBuilder.DropTable(
                name: "Seating_Layout");

            migrationBuilder.DropTable(
                name: "Special_Price");

            migrationBuilder.DropTable(
                name: "Star_Rating");

            migrationBuilder.DropTable(
                name: "Supplier_Order_Line");

            migrationBuilder.DropTable(
                name: "User_UserImage");

            migrationBuilder.DropTable(
                name: "User_UserRole");

            migrationBuilder.DropTable(
                name: "Write_Off_Reason");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Menu_Item_Type");

            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Menu_Item");

            migrationBuilder.DropTable(
                name: "Stock_Take");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "QrCode");

            migrationBuilder.DropTable(
                name: "Seating");

            migrationBuilder.DropTable(
                name: "Restaurant_Facility");

            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "Restaurant_Image");

            migrationBuilder.DropTable(
                name: "Restaurant_Type");

            migrationBuilder.DropTable(
                name: "Layout_Type");

            migrationBuilder.DropTable(
                name: "Special");

            migrationBuilder.DropTable(
                name: "User_Comment");

            migrationBuilder.DropTable(
                name: "Supplier_Order");

            migrationBuilder.DropTable(
                name: "UserImage");

            migrationBuilder.DropTable(
                name: "Product_Written_Off");

            migrationBuilder.DropTable(
                name: "Shift_Status");

            migrationBuilder.DropTable(
                name: "Menu_Item_Category");

            migrationBuilder.DropTable(
                name: "Menu_Item_Price");

            migrationBuilder.DropTable(
                name: "Order_Status");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Advertisement_Date");

            migrationBuilder.DropTable(
                name: "Advertisement_Price");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Written_Off_Stock");

            migrationBuilder.DropTable(
                name: "Reservation_Status");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Product_Category");

            migrationBuilder.DropTable(
                name: "Product_Reorder_Freq");

            migrationBuilder.DropTable(
                name: "Product_Type");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "Restaurant_Status");

            migrationBuilder.DropTable(
                name: "Social_Media");

            migrationBuilder.DropTable(
                name: "Social_Media_Type");
        }
    }
}
