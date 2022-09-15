using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pizzeria.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id_Address = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressesStreet = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    AdressesCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AddressesZipCode = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    AddressesCountry = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id_Address);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id_Category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id_Category);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompanies",
                columns: table => new
                {
                    Id_DeliveryCompany = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CompanyAddress = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CompanyZip = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: true),
                    CompanyCity = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanies", x => x.Id_DeliveryCompany);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPriceRules",
                columns: table => new
                {
                    Id_DeliveryPriceRules = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RulesMaxDistance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    RulesPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPriceRules", x => x.Id_DeliveryPriceRules);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id_Ingredient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id_Ingredient);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id_Status = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id_Status);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "UsersAddresses",
                columns: table => new
                {
                    Id_AppUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id_Address = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAddresses", x => new { x.Id_AppUser, x.Id_Address });
                    table.ForeignKey(
                        name: "FK_UsersAddresses_Addresses",
                        column: x => x.Id_Address,
                        principalTable: "Addresses",
                        principalColumn: "Id_Address");
                    table.ForeignKey(
                        name: "FK_UsersAddresses_AppUsers",
                        column: x => x.Id_AppUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id_Product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ProductDescription = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ProductPrice = table.Column<decimal>(type: "money", nullable: false),
                    ProductImageName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Id_Category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id_Product);
                    table.ForeignKey(
                        name: "FK_Products_Categories",
                        column: x => x.Id_Category,
                        principalTable: "Categories",
                        principalColumn: "Id_Category");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPrice",
                columns: table => new
                {
                    Id_DeliveryPrice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDistance = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DeliveryPrice = table.Column<decimal>(type: "money", nullable: false),
                    Id_DeliveryPriceRules = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPrice", x => x.Id_DeliveryPrice);
                    table.ForeignKey(
                        name: "FK_DeliveryPrice_DeliveryPriceRules",
                        column: x => x.Id_DeliveryPriceRules,
                        principalTable: "DeliveryPriceRules",
                        principalColumn: "Id_DeliveryPriceRules");
                });

            migrationBuilder.CreateTable(
                name: "CarItems",
                columns: table => new
                {
                    Id_CarItem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    CartId = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Id_Product = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarItems", x => x.Id_CarItem);
                    table.ForeignKey(
                        name: "FK_CarItems_Products",
                        column: x => x.Id_Product,
                        principalTable: "Products",
                        principalColumn: "Id_Product");
                });

            migrationBuilder.CreateTable(
                name: "ProductsIngredients",
                columns: table => new
                {
                    Id_Product = table.Column<int>(type: "int", nullable: false),
                    Id_Ingredient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsIngredients", x => new { x.Id_Product, x.Id_Ingredient });
                    table.ForeignKey(
                        name: "FK_ProductsIngredients_Ingredients",
                        column: x => x.Id_Ingredient,
                        principalTable: "Ingredients",
                        principalColumn: "Id_Ingredient");
                    table.ForeignKey(
                        name: "FK_ProductsIngredients_Products",
                        column: x => x.Id_Product,
                        principalTable: "Products",
                        principalColumn: "Id_Product");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id_Order = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "money", nullable: true),
                    Id_DeliveryPrice = table.Column<int>(type: "int", nullable: true),
                    Id_Status = table.Column<int>(type: "int", nullable: false),
                    Id_DeliveryCompany = table.Column<int>(type: "int", nullable: true),
                    Id_Address = table.Column<int>(type: "int", nullable: false),
                    Id_AppUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id_Order);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses",
                        column: x => x.Id_Address,
                        principalTable: "Addresses",
                        principalColumn: "Id_Address");
                    table.ForeignKey(
                        name: "FK_Orders_AppUsers",
                        column: x => x.Id_AppUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryCompanies",
                        column: x => x.Id_DeliveryCompany,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id_DeliveryCompany");
                    table.ForeignKey(
                        name: "FK_Orders_DeliveryPrice",
                        column: x => x.Id_DeliveryPrice,
                        principalTable: "DeliveryPrice",
                        principalColumn: "Id_DeliveryPrice");
                    table.ForeignKey(
                        name: "FK_Orders_Status",
                        column: x => x.Id_Status,
                        principalTable: "Status",
                        principalColumn: "Id_Status");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id_Product = table.Column<int>(type: "int", nullable: false),
                    Id_Order = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => new { x.Id_Product, x.Id_Order });
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders",
                        column: x => x.Id_Order,
                        principalTable: "Orders",
                        principalColumn: "Id_Order");
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products",
                        column: x => x.Id_Product,
                        principalTable: "Products",
                        principalColumn: "Id_Product");
                });

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
                name: "IX_CarItems_Id_Product",
                table: "CarItems",
                column: "Id_Product");

            migrationBuilder.CreateIndex(
                name: "AK_Categories",
                table: "Categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPrice_Id_DeliveryPriceRules",
                table: "DeliveryPrice",
                column: "Id_DeliveryPriceRules");

            migrationBuilder.CreateIndex(
                name: "AK_Ingredients",
                table: "Ingredients",
                column: "IngredientName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_Id_Order",
                table: "OrderDetails",
                column: "Id_Order");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_Address",
                table: "Orders",
                column: "Id_Address");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_AppUser",
                table: "Orders",
                column: "Id_AppUser");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_DeliveryCompany",
                table: "Orders",
                column: "Id_DeliveryCompany");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_DeliveryPrice",
                table: "Orders",
                column: "Id_DeliveryPrice");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Id_Status",
                table: "Orders",
                column: "Id_Status");

            migrationBuilder.CreateIndex(
                name: "AK_Products",
                table: "Products",
                column: "ProductName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Id_Category",
                table: "Products",
                column: "Id_Category");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsIngredients_Id_Ingredient",
                table: "ProductsIngredients",
                column: "Id_Ingredient");

            migrationBuilder.CreateIndex(
                name: "AK_Status",
                table: "Status",
                column: "StatusName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersAddresses_Id_Address",
                table: "UsersAddresses",
                column: "Id_Address");
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
                name: "CarItems");


            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductsIngredients");

            migrationBuilder.DropTable(
                name: "UsersAddresses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DeliveryCompanies");

            migrationBuilder.DropTable(
                name: "DeliveryPrice");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DeliveryPriceRules");
        }
    }
}
