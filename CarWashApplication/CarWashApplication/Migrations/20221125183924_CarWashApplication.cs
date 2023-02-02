using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarWashApplication.Migrations
{
    public partial class CarWashApplication : Migration
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    { "11dfd9c9-5d08-4196-9397-654a3b6fef3a", 0, "cfabf635-41fc-4075-b842-ed88a8e51d73", "lukapavlovic@example.com", false, "Luka", "Pavlovic", false, null, "LUKAPAVLOVIC@EXAMPLE.COM", "LUKAPAVLOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEPURVkBnph5raNKeeCYsAsNptev8TZWvXI0lyA/qcZZcUoo5NW6BVOLPES4Bcc0T2Q==", null, false, "617de1f9-befc-450c-bd5a-71ea8c9681e8", false, "lukapavlovic@example.com" },
                    { "17529DFE-458B-43E1-8F99-473F6F671812", 0, "7ba93c52-2a8f-4512-8013-273de27f53ac", "lukabulatovic@example.com", false, "Luka", "Bulatovic", false, null, "LUKABULATOVIC@EXAMPLE.COM", "LUKABULATOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEBZ0c0FSycs+4KdmceOCAzwAR9n3uzhxka544T8F25+bs9mmmYt2HD9EZt71nncMNA==", null, false, "bf859b58-8fbb-4a5f-9c4f-cee3987691f2", false, "lukabulatovic@example.com" },
                    { "4895dcbe-94df-45f7-87f5-c519b8380878", 0, "dfcc82a4-6126-44c6-a2fc-7f15af8d2015", "stefanijamarkovic@example.com", false, "Stefanija", "Markovic", false, null, "STEFANIJAMARKOVIC@EXAMPLE.COM", "STEFANIJAMARKOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKp1r+4JbbP5n7/94Gl9HNG7J8hdNSuMJatv72TX45wcnOWaC/l3EJ2PnTQTmR4KoQ==", null, false, "e7a0098f-8891-4135-970d-2d257b11b482", false, "stefanijamarkovic@example.com" },
                    { "66342aee-8dc1-4b13-b912-f84fe202ef9d", 0, "d15f18a3-cc8b-4f70-8095-2a40e2733c49", "milosmijatovic@example.com", false, "Milos", "Mijatovic", false, null, "MILOSMIJATOVIC@EXAMPLE.COM", "MILOSMIJATOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEKfMnm/tvvL2B7+4DXg3MNlC1wQbLpUurrFKpR6q4wz+cXOa8fRKel5ioOq+juHNHA==", null, false, "995f288b-f4b6-41ad-ab1d-6cd8edd68e6b", false, "milosmijatovic@example.com" },
                    { "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c", 0, "87fb7a58-b2f7-4f34-a2bd-fc47e9791a89", "aleksandarjovanovic@example.com", false, "Aleksandar", "Jovanovic", false, null, "ALEKSANDARJOVANOVIC@EXAMPLE.COM", "ALEKSANDARJOVANOVIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEFOfVEunFZA9oO+lfUUhZMEgPx4cRGPY9zYaMnVhKDgVZatEd9N6YvkgiHT5iHWFlg==", null, false, "00fcad23-9182-4412-b3f7-40132d61c2ae", false, "aleksandarjovanovic@example.com" },
                    { "8492a90d-2a60-4d51-913f-35f7522c40a1", 0, "8450dbae-b757-4c3b-939a-27ec9675a2c9", "aleksandarkrstic@example.com", false, "Aleksandar", "Krstic", false, null, "ALEKSANDARKRSTIC@EXAMPLE.COM", "ALEKSANDARKRSTIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAELljN2LFbn3E+vzsTjBxgtFFZHUT0ZnNRWmG8fmpV4LeOJ4VzukoC/DPimBmnrbseQ==", null, false, "d61125f2-bb9f-4fdd-8079-954b150a3bcc", false, "aleksandarkrstic@example.com" },
                    { "86eb1953-9686-4779-9d8f-7b236878435b", 0, "27ff1d5a-174b-47e3-89a0-edd1c9268037", "vanjaarsic@example.com", false, "Vanja", "Arsic", false, null, "VANJAARSIC@EXAMPLE.COM", "VANJAARSIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEI+NB1+WfhRoRtldYrf5Gs4A1ACPtTgLt3dND5M4wNFA/QeIbxD6lwWfI1nmAhzyDw==", null, false, "3fded660-ac4e-4050-9f23-4c907e8c23e8", false, "vanjaarsic@example.com" },
                    { "e843d605-789e-4d0b-b9c6-9a2409a04857", 0, "5ff049d9-83cd-4f57-a805-257b29051649", "mihailosimic@example.com", false, "Mihailo", "Simic", false, null, "MIHAILOSIMIC@EXAMPLE.COM", "MIHAILOSIMIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEJ4SQF2NriIU7ZyrVTKHkETskrGundgQ6JJ789jRZaqD/63DqLn5bq6uZn5wNZMq6A==", null, false, "9dc7f025-7682-491b-8c94-250287dd13cd", false, "mihailosimic@example.com" },
                    { "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9", 0, "3e2c0df7-af47-45e6-a34d-0df7b5ea7f5b", "nikolapanic@example.com", false, "Nikola", "Panic", false, null, "NIKOLAPANIC@EXAMPLE.COM", "NIKOLAPANIC@EXAMPLE.COM", "AQAAAAEAACcQAAAAEGbOFpPARZ+VK60nOb4zJpz1PTB2/78VxA8ixC1ueYgT9WvFtsd9xRlm1OXuLxBGeQ==", null, false, "f09a8012-ae28-4b6c-ad2f-c6b2a0b08f25", false, "nikolapanic@example.com" }
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
                    { 1, "11dfd9c9-5d08-4196-9397-654a3b6fef3a", new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2610), 1, 1, true },
                    { 2, "17529DFE-458B-43E1-8F99-473F6F671812", new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2660), 2, 1, true },
                    { 3, "4895dcbe-94df-45f7-87f5-c519b8380878", new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2662), 3, 1, true },
                    { 4, "66342aee-8dc1-4b13-b912-f84fe202ef9d", new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2664), 1, 2, true },
                    { 5, "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c", new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2665), 2, 2, true },
                    { 6, "86eb1953-9686-4779-9d8f-7b236878435b", new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2667), 3, 2, true },
                    { 7, "e843d605-789e-4d0b-b9c6-9a2409a04857", new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2668), 1, 3, true },
                    { 8, "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9", new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2670), 2, 3, true }
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
