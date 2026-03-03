using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EKART.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductNameLength : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__19093A2B7A36B935", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDemographics",
                columns: table => new
                {
                    CustomerTypeID = table.Column<int>(type: "int", nullable: false),
                    CustomerDesc = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__958B614C8346C7E1", x => x.CustomerTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ContactName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ContactTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Fax = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__A4AE64B8AFB8F44A", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TitleOfCourtesy = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: true),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    HomePhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Notes = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ReportTo = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PhotoPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__7AD04FF107141345", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Region__ACD8444353E0013B", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Shippers",
                columns: table => new
                {
                    ShipperID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Shippers__1F8AFFB9AA343892", x => x.ShipperID);
                    table.UniqueConstraint("AK_Shippers_CompanyName", x => x.CompanyName);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ContactName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ContactTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Region = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    PostalCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Fax = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    HpmePage = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Supplier__4BE66694BC35E7DC", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCustomerDemo",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    CustomerTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Customer__7DF6D2ACC57B7DAA", x => new { x.CustomerID, x.CustomerTypeID });
                    table.ForeignKey(
                        name: "FK__CustomerC__Custo__5FB337D6",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__CustomerC__Custo__60A75C0F",
                        column: x => x.CustomerTypeID,
                        principalTable: "CustomerDemographics",
                        principalColumn: "CustomerTypeID");
                });

            migrationBuilder.CreateTable(
                name: "Territories",
                columns: table => new
                {
                    TerritoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerritoryDescription = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RegionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Territor__2BECD2E4C90271D7", x => x.TerritoryID);
                    table.ForeignKey(
                        name: "FK__Territori__Regio__534D60F1",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RequiredDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ShippedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ShipVia = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Freight = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ShipName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ShipAddress = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    ShipCity = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ShipRegion = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    ShipPostalCode = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ShipCountry = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C3905BAFDE39C490", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK__Orders__Employee__4D94879B",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__Orders__ShipCoun__4CA06362",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID");
                    table.ForeignKey(
                        name: "FK__Orders__ShipName__4E88ABD4",
                        column: x => x.ShipName,
                        principalTable: "Shippers",
                        principalColumn: "CompanyName");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    QuantityPerUnit = table.Column<int>(type: "int", nullable: true),
                    UnitPrice = table.Column<int>(type: "int", nullable: true),
                    UnitInStock = table.Column<int>(type: "int", nullable: true),
                    UnitsOnOrder = table.Column<int>(type: "int", nullable: true),
                    ReorderLevel = table.Column<int>(type: "int", nullable: true),
                    Discontinued = table.Column<bool>(type: "bit", nullable: true, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__B40CC6ED86095F4E", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK__Products__Catego__3C69FB99",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID");
                    table.ForeignKey(
                        name: "FK__Products__Suppli__3B75D760",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTerritories",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    TerritoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__286E82DF97605DE9", x => new { x.EmployeeID, x.TerritoryID });
                    table.ForeignKey(
                        name: "FK__EmployeeT__Emplo__5629CD9C",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK__EmployeeT__Terri__571DF1D5",
                        column: x => x.TerritoryID,
                        principalTable: "Territories",
                        principalColumn: "TerritoryID");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(4,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderDet__08D097C110B0FF81", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "FK__OrderDeta__Order__59FA5E80",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID");
                    table.ForeignKey(
                        name: "FK__OrderDeta__Produ__5AEE82B9",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCustomerDemo_CustomerTypeID",
                table: "CustomerCustomerDemo",
                column: "CustomerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTerritories_TerritoryID",
                table: "EmployeeTerritories",
                column: "TerritoryID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID",
                table: "OrderDetails",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShipName",
                table: "Orders",
                column: "ShipName");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierID",
                table: "Products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "UQ__Shippers__9BCE05DCF1B983B3",
                table: "Shippers",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Territories_RegionID",
                table: "Territories",
                column: "RegionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerCustomerDemo");

            migrationBuilder.DropTable(
                name: "EmployeeTerritories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "CustomerDemographics");

            migrationBuilder.DropTable(
                name: "Territories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Shippers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
