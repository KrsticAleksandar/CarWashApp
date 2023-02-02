using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWashApp.Migrations
{
    public partial class CarWashApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
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
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningTime = table.Column<int>(type: "int", nullable: false),
                    ClosingTime = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                    table.ForeignKey(
                        name: "FK_Shops_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ConsumerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reservations_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShopsServices",
                columns: table => new
                {
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopsServices", x => new { x.ShopId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ShopsServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopsServices_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "11dfd9c9-5d08-4196-9397-654a3b6fef3a", 0, "fb539327-548c-4e1c-9472-add14b255a17", "lukapavlovic@example.com", false, "Luka", "Pavlovic", false, null, "LUKAPAVLOVIC@EXAMPLE.COM", "LUKAPAVLOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJWUTL5MjM8Ztrg8FnGxpnswY6g8JeXaXoN9E2LpxQ8iuVPVjxanAidDoretPLznQg==", null, false, "95613d8f-5d10-4e8f-a4be-6aa11ae29660", false, "lukapavlovic@example.com" },
                    { "17529DFE-458B-43E1-8F99-473F6F671812", 0, "36db3789-bdb8-4967-92c8-adc27e0a24df", "lukabulatovic@example.com", false, "Luka", "Bulatovic", false, null, "LUKABULATOVIC@EXAMPLE.COM", "LUKABULATOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEBnsQPU0S10djid4FYIhO+vez5QqI/ZEXxI9ClG9jKJ3lC+aGYly1fAsg7QIJiZg1Q==", null, false, "d47a57b5-a422-4dd5-aac0-13077a31a3f7", false, "lukabulatovic@example.com" },
                    { "4895dcbe-94df-45f7-87f5-c519b8380878", 0, "8421d23a-bc0b-495c-9946-df47dd69e60e", "stefanijamarkovic@example.com", false, "Stefanija", "Markovic", false, null, "STEFANIJAMARKOVIC@EXAMPLE.COM", "STEFANIJAMARKOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKo4rOt9ZPCXm1IuhxRhpwsS8kKDkVgbifO6WzUHPsIt2fHZRcGnBiYaBkQt3bY54A==", null, false, "e2c17e6c-3115-49ec-adb9-c0f74b83c50a", false, "stefanijamarkovic@example.com" },
                    { "66342aee-8dc1-4b13-b912-f84fe202ef9d", 0, "4c198ca0-7253-4bce-b9c6-f83ea66cfa8b", "milosmijatovic@example.com", false, "Milos", "Mijatovic", false, null, "MILOSMIJATOVIC@EXAMPLE.COM", "MILOSMIJATOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAECPmntJGdgGBp88iwfOqBuE+CJYqvuxlrXqA3BCxe7mtj/Wc4f486+W6XzNiRqX02Q==", null, false, "695bf8ce-e6b1-45a0-a2bc-92b247c81c0f", false, "milosmijatovic@example.com" },
                    { "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c", 0, "d418d728-55ef-4e08-8fb3-41529cce4e73", "aleksandarjovanovic@example.com", false, "Aleksandar", "Jovanovic", false, null, "ALEKSANDARJOVANOVIC@EXAMPLE.COM", "ALEKSANDARJOVANOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEGpht70GsFePxF2x5g8bCly1RjeC2OV5bG2ORxOLlmyAY3a8FtYGU0R8knavsqqKuQ==", null, false, "1187fc3a-06f4-4447-8a6d-80957cbf934a", false, "aleksandarjovanovic@example.com" },
                    { "8492a90d-2a60-4d51-913f-35f7522c40a1", 0, "5bfa0ed3-6afa-45ef-b973-e55445d5ba4b", "aleksandarkrstic@example.com", false, "Aleksandar", "Krstic", false, null, "ALEKSANDARKRSTIC@EXAMPLE.COM", "ALEKSANDARKRSTIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEL9zLHHJscTY4BW9Dj90AJgcBZz9GAQ49X04Zdiu2zPFEdhAX2lPr697zStaNU/nMQ==", null, false, "41bb5d1b-d84c-498c-a3bf-de5f5edb6e79", false, "aleksandarkrstic@example.com" },
                    { "86eb1953-9686-4779-9d8f-7b236878435b", 0, "91a506c0-b049-4a9e-83c4-20946920e138", "vanjaarsic@example.com", false, "Vanja", "Arsic", false, null, "VANJAARSIC@EXAMPLE.COM", "VANJAARSIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEMk72B/nb1oIsH8qycayi4mq5A3ZZQCRg0ukwb2r6ugtU6WPI2VsIjYaZfiT8p8vPA==", null, false, "93872861-9d82-4341-9f22-c3787dd2458d", false, "vanjaarsic@example.com" },
                    { "e843d605-789e-4d0b-b9c6-9a2409a04857", 0, "1562aea2-aac7-4568-9892-7ee7d75012f4", "mihailosimic@example.com", false, "Mihailo", "Simic", false, null, "MIHAILOSIMIC@EXAMPLE.COM", "MIHAILOSIMIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKPT4fLtLBzMpOfVPD8x2WAry00N2nuSAGO3I9TcaFyLIOUoAcgRSYY/Tx/Ageyu+A==", null, false, "f1f2c76c-a88a-419a-8b12-e6c36adfacb6", false, "mihailosimic@example.com" },
                    { "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9", 0, "23c10082-c5e6-48c0-9954-9c78a4bde43a", "nikolapanic@example.com", false, "Nikola", "Panic", false, null, "NIKOLAPANIC@EXAMPLE.COM", "NIKOLAPANIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJ3pMCTrUAp2T04uAYttfa8OYfFzq00uTacSGwpifefiRrLJh8jcswQyy/gIYU/QdQ==", null, false, "8cc2311b-2aaf-44ba-ba0d-0c2b3e4eaabc", false, "nikolapanic@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Duration", "Price", "ServiceType" },
                values: new object[,]
                {
                    { 1, 1, 12f, "Regular" },
                    { 2, 1, 16f, "Extended" },
                    { 3, 1, 26f, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Owner", "8492a90d-2a60-4d51-913f-35f7522c40a1" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Consumer", "11dfd9c9-5d08-4196-9397-654a3b6fef3a" },
                    { 3, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Consumer", "17529DFE-458B-43E1-8F99-473F6F671812" },
                    { 4, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Consumer", "4895dcbe-94df-45f7-87f5-c519b8380878" },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Consumer", "66342aee-8dc1-4b13-b912-f84fe202ef9d" },
                    { 6, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Consumer", "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c" },
                    { 7, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Consumer", "86eb1953-9686-4779-9d8f-7b236878435b" },
                    { 8, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Consumer", "e843d605-789e-4d0b-b9c6-9a2409a04857" },
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Consumer", "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "ShopId", "Address", "ClosingTime", "OpeningTime", "OwnerId", "ShopName" },
                values: new object[,]
                {
                    { 1, "Tomazeova 36", 18, 8, "8492a90d-2a60-4d51-913f-35f7522c40a1", "Shop1" },
                    { 2, "Maksima Gorkog 9", 18, 8, "8492a90d-2a60-4d51-913f-35f7522c40a1", "Shop2" },
                    { 3, "Gospodara Vucica 18", 18, 8, "8492a90d-2a60-4d51-913f-35f7522c40a1", "Shop3" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "ConsumerId", "ReservationDateTime", "ServiceId", "ShopId", "Status" },
                values: new object[,]
                {
                    { 1, "11dfd9c9-5d08-4196-9397-654a3b6fef3a", new DateTime(2022, 10, 12, 14, 27, 23, 907, DateTimeKind.Local).AddTicks(8301), 1, 1, true },
                    { 2, "17529DFE-458B-43E1-8F99-473F6F671812", new DateTime(2022, 10, 12, 14, 27, 23, 907, DateTimeKind.Local).AddTicks(8339), 2, 1, true },
                    { 3, "4895dcbe-94df-45f7-87f5-c519b8380878", new DateTime(2022, 10, 12, 14, 27, 23, 907, DateTimeKind.Local).AddTicks(8341), 3, 1, true },
                    { 4, "66342aee-8dc1-4b13-b912-f84fe202ef9d", new DateTime(2022, 10, 12, 14, 27, 23, 907, DateTimeKind.Local).AddTicks(8343), 1, 2, true },
                    { 5, "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c", new DateTime(2022, 10, 12, 14, 27, 23, 907, DateTimeKind.Local).AddTicks(8344), 2, 2, true },
                    { 6, "86eb1953-9686-4779-9d8f-7b236878435b", new DateTime(2022, 10, 12, 14, 27, 23, 907, DateTimeKind.Local).AddTicks(8347), 3, 2, true },
                    { 7, "e843d605-789e-4d0b-b9c6-9a2409a04857", new DateTime(2022, 10, 12, 14, 27, 23, 907, DateTimeKind.Local).AddTicks(8348), 1, 3, true },
                    { 8, "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9", new DateTime(2022, 10, 12, 14, 27, 23, 907, DateTimeKind.Local).AddTicks(8350), 2, 3, true }
                });

            migrationBuilder.InsertData(
                table: "ShopsServices",
                columns: new[] { "ServiceId", "ShopId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 }
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
                name: "IX_Reservations_ConsumerId",
                table: "Reservations",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ShopId",
                table: "Reservations",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_OwnerId",
                table: "Shops",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopsServices_ServiceId",
                table: "ShopsServices",
                column: "ServiceId");
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
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "ShopsServices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
