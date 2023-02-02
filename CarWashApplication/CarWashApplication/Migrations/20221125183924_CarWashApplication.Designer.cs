﻿// <auto-generated />
using System;
using CarWashApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarWashApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221125183924_CarWashApplication")]
    partial class CarWashApplication
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarWashApp.Entities.GeneralUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "87fb7a58-b2f7-4f34-a2bd-fc47e9791a89",
                            Email = "aleksandarjovanovic@example.com",
                            EmailConfirmed = false,
                            FirstName = "Aleksandar",
                            LastName = "Jovanovic",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALEKSANDARJOVANOVIC@EXAMPLE.COM",
                            NormalizedUserName = "ALEKSANDARJOVANOVIC@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFOfVEunFZA9oO+lfUUhZMEgPx4cRGPY9zYaMnVhKDgVZatEd9N6YvkgiHT5iHWFlg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "00fcad23-9182-4412-b3f7-40132d61c2ae",
                            TwoFactorEnabled = false,
                            UserName = "aleksandarjovanovic@example.com"
                        },
                        new
                        {
                            Id = "e843d605-789e-4d0b-b9c6-9a2409a04857",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5ff049d9-83cd-4f57-a805-257b29051649",
                            Email = "mihailosimic@example.com",
                            EmailConfirmed = false,
                            FirstName = "Mihailo",
                            LastName = "Simic",
                            LockoutEnabled = false,
                            NormalizedEmail = "MIHAILOSIMIC@EXAMPLE.COM",
                            NormalizedUserName = "MIHAILOSIMIC@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJ4SQF2NriIU7ZyrVTKHkETskrGundgQ6JJ789jRZaqD/63DqLn5bq6uZn5wNZMq6A==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9dc7f025-7682-491b-8c94-250287dd13cd",
                            TwoFactorEnabled = false,
                            UserName = "mihailosimic@example.com"
                        },
                        new
                        {
                            Id = "17529DFE-458B-43E1-8F99-473F6F671812",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7ba93c52-2a8f-4512-8013-273de27f53ac",
                            Email = "lukabulatovic@example.com",
                            EmailConfirmed = false,
                            FirstName = "Luka",
                            LastName = "Bulatovic",
                            LockoutEnabled = false,
                            NormalizedEmail = "LUKABULATOVIC@EXAMPLE.COM",
                            NormalizedUserName = "LUKABULATOVIC@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBZ0c0FSycs+4KdmceOCAzwAR9n3uzhxka544T8F25+bs9mmmYt2HD9EZt71nncMNA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "bf859b58-8fbb-4a5f-9c4f-cee3987691f2",
                            TwoFactorEnabled = false,
                            UserName = "lukabulatovic@example.com"
                        },
                        new
                        {
                            Id = "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3e2c0df7-af47-45e6-a34d-0df7b5ea7f5b",
                            Email = "nikolapanic@example.com",
                            EmailConfirmed = false,
                            FirstName = "Nikola",
                            LastName = "Panic",
                            LockoutEnabled = false,
                            NormalizedEmail = "NIKOLAPANIC@EXAMPLE.COM",
                            NormalizedUserName = "NIKOLAPANIC@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEGbOFpPARZ+VK60nOb4zJpz1PTB2/78VxA8ixC1ueYgT9WvFtsd9xRlm1OXuLxBGeQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f09a8012-ae28-4b6c-ad2f-c6b2a0b08f25",
                            TwoFactorEnabled = false,
                            UserName = "nikolapanic@example.com"
                        },
                        new
                        {
                            Id = "66342aee-8dc1-4b13-b912-f84fe202ef9d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d15f18a3-cc8b-4f70-8095-2a40e2733c49",
                            Email = "milosmijatovic@example.com",
                            EmailConfirmed = false,
                            FirstName = "Milos",
                            LastName = "Mijatovic",
                            LockoutEnabled = false,
                            NormalizedEmail = "MILOSMIJATOVIC@EXAMPLE.COM",
                            NormalizedUserName = "MILOSMIJATOVIC@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKfMnm/tvvL2B7+4DXg3MNlC1wQbLpUurrFKpR6q4wz+cXOa8fRKel5ioOq+juHNHA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "995f288b-f4b6-41ad-ab1d-6cd8edd68e6b",
                            TwoFactorEnabled = false,
                            UserName = "milosmijatovic@example.com"
                        },
                        new
                        {
                            Id = "11dfd9c9-5d08-4196-9397-654a3b6fef3a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cfabf635-41fc-4075-b842-ed88a8e51d73",
                            Email = "lukapavlovic@example.com",
                            EmailConfirmed = false,
                            FirstName = "Luka",
                            LastName = "Pavlovic",
                            LockoutEnabled = false,
                            NormalizedEmail = "LUKAPAVLOVIC@EXAMPLE.COM",
                            NormalizedUserName = "LUKAPAVLOVIC@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPURVkBnph5raNKeeCYsAsNptev8TZWvXI0lyA/qcZZcUoo5NW6BVOLPES4Bcc0T2Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "617de1f9-befc-450c-bd5a-71ea8c9681e8",
                            TwoFactorEnabled = false,
                            UserName = "lukapavlovic@example.com"
                        },
                        new
                        {
                            Id = "4895dcbe-94df-45f7-87f5-c519b8380878",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dfcc82a4-6126-44c6-a2fc-7f15af8d2015",
                            Email = "stefanijamarkovic@example.com",
                            EmailConfirmed = false,
                            FirstName = "Stefanija",
                            LastName = "Markovic",
                            LockoutEnabled = false,
                            NormalizedEmail = "STEFANIJAMARKOVIC@EXAMPLE.COM",
                            NormalizedUserName = "STEFANIJAMARKOVIC@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEKp1r+4JbbP5n7/94Gl9HNG7J8hdNSuMJatv72TX45wcnOWaC/l3EJ2PnTQTmR4KoQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e7a0098f-8891-4135-970d-2d257b11b482",
                            TwoFactorEnabled = false,
                            UserName = "stefanijamarkovic@example.com"
                        },
                        new
                        {
                            Id = "86eb1953-9686-4779-9d8f-7b236878435b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "27ff1d5a-174b-47e3-89a0-edd1c9268037",
                            Email = "vanjaarsic@example.com",
                            EmailConfirmed = false,
                            FirstName = "Vanja",
                            LastName = "Arsic",
                            LockoutEnabled = false,
                            NormalizedEmail = "VANJAARSIC@EXAMPLE.COM",
                            NormalizedUserName = "VANJAARSIC@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEI+NB1+WfhRoRtldYrf5Gs4A1ACPtTgLt3dND5M4wNFA/QeIbxD6lwWfI1nmAhzyDw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3fded660-ac4e-4050-9f23-4c907e8c23e8",
                            TwoFactorEnabled = false,
                            UserName = "vanjaarsic@example.com"
                        },
                        new
                        {
                            Id = "8492a90d-2a60-4d51-913f-35f7522c40a1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8450dbae-b757-4c3b-939a-27ec9675a2c9",
                            Email = "aleksandarkrstic@example.com",
                            EmailConfirmed = false,
                            FirstName = "Aleksandar",
                            LastName = "Krstic",
                            LockoutEnabled = false,
                            NormalizedEmail = "ALEKSANDARKRSTIC@EXAMPLE.COM",
                            NormalizedUserName = "ALEKSANDARKRSTIC@EXAMPLE.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELljN2LFbn3E+vzsTjBxgtFFZHUT0ZnNRWmG8fmpV4LeOJ4VzukoC/DPimBmnrbseQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d61125f2-bb9f-4fdd-8079-954b150a3bcc",
                            TwoFactorEnabled = false,
                            UserName = "aleksandarkrstic@example.com"
                        });
                });

            modelBuilder.Entity("CarWashApp.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<string>("ConsumerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ReservationDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("ReservationId");

                    b.HasIndex("ConsumerId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("ShopId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            ConsumerId = "11dfd9c9-5d08-4196-9397-654a3b6fef3a",
                            ReservationDateTime = new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2610),
                            ServiceId = 1,
                            ShopId = 1,
                            Status = true
                        },
                        new
                        {
                            ReservationId = 2,
                            ConsumerId = "17529DFE-458B-43E1-8F99-473F6F671812",
                            ReservationDateTime = new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2660),
                            ServiceId = 2,
                            ShopId = 1,
                            Status = true
                        },
                        new
                        {
                            ReservationId = 3,
                            ConsumerId = "4895dcbe-94df-45f7-87f5-c519b8380878",
                            ReservationDateTime = new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2662),
                            ServiceId = 3,
                            ShopId = 1,
                            Status = true
                        },
                        new
                        {
                            ReservationId = 4,
                            ConsumerId = "66342aee-8dc1-4b13-b912-f84fe202ef9d",
                            ReservationDateTime = new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2664),
                            ServiceId = 1,
                            ShopId = 2,
                            Status = true
                        },
                        new
                        {
                            ReservationId = 5,
                            ConsumerId = "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c",
                            ReservationDateTime = new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2665),
                            ServiceId = 2,
                            ShopId = 2,
                            Status = true
                        },
                        new
                        {
                            ReservationId = 6,
                            ConsumerId = "86eb1953-9686-4779-9d8f-7b236878435b",
                            ReservationDateTime = new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2667),
                            ServiceId = 3,
                            ShopId = 2,
                            Status = true
                        },
                        new
                        {
                            ReservationId = 7,
                            ConsumerId = "e843d605-789e-4d0b-b9c6-9a2409a04857",
                            ReservationDateTime = new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2668),
                            ServiceId = 1,
                            ShopId = 3,
                            Status = true
                        },
                        new
                        {
                            ReservationId = 8,
                            ConsumerId = "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9",
                            ReservationDateTime = new DateTime(2022, 11, 25, 19, 39, 24, 687, DateTimeKind.Local).AddTicks(2670),
                            ServiceId = 2,
                            ShopId = 3,
                            Status = true
                        });
                });

            modelBuilder.Entity("CarWashApp.Entities.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceId"), 1L, 1);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceId");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            ServiceId = 1,
                            Duration = 1,
                            Price = 12f,
                            ServiceType = "Regular"
                        },
                        new
                        {
                            ServiceId = 2,
                            Duration = 1,
                            Price = 16f,
                            ServiceType = "Extended"
                        },
                        new
                        {
                            ServiceId = 3,
                            Duration = 1,
                            Price = 26f,
                            ServiceType = "Premium"
                        });
                });

            modelBuilder.Entity("CarWashApp.Entities.Shop", b =>
                {
                    b.Property<int>("ShopId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShopId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClosingTime")
                        .HasColumnType("int");

                    b.Property<int>("OpeningTime")
                        .HasColumnType("int");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShopId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Shops");

                    b.HasData(
                        new
                        {
                            ShopId = 1,
                            Address = "Tomazeova 36",
                            ClosingTime = 18,
                            OpeningTime = 8,
                            OwnerId = "8492a90d-2a60-4d51-913f-35f7522c40a1",
                            ShopName = "Shop1"
                        },
                        new
                        {
                            ShopId = 2,
                            Address = "Maksima Gorkog 9",
                            ClosingTime = 18,
                            OpeningTime = 8,
                            OwnerId = "8492a90d-2a60-4d51-913f-35f7522c40a1",
                            ShopName = "Shop2"
                        },
                        new
                        {
                            ShopId = 3,
                            Address = "Gospodara Vucica 18",
                            ClosingTime = 18,
                            OpeningTime = 8,
                            OwnerId = "8492a90d-2a60-4d51-913f-35f7522c40a1",
                            ShopName = "Shop3"
                        });
                });

            modelBuilder.Entity("CarWashApp.Entities.ShopsServices", b =>
                {
                    b.Property<int>("ShopId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("ShopId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("ShopsServices");

                    b.HasData(
                        new
                        {
                            ShopId = 1,
                            ServiceId = 1
                        },
                        new
                        {
                            ShopId = 1,
                            ServiceId = 2
                        },
                        new
                        {
                            ShopId = 1,
                            ServiceId = 3
                        },
                        new
                        {
                            ShopId = 2,
                            ServiceId = 1
                        },
                        new
                        {
                            ShopId = 2,
                            ServiceId = 2
                        },
                        new
                        {
                            ShopId = 2,
                            ServiceId = 3
                        },
                        new
                        {
                            ShopId = 3,
                            ServiceId = 1
                        },
                        new
                        {
                            ShopId = 3,
                            ServiceId = 2
                        },
                        new
                        {
                            ShopId = 3,
                            ServiceId = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Owner",
                            UserId = "8492a90d-2a60-4d51-913f-35f7522c40a1"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Consumer",
                            UserId = "11dfd9c9-5d08-4196-9397-654a3b6fef3a"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Consumer",
                            UserId = "17529DFE-458B-43E1-8F99-473F6F671812"
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Consumer",
                            UserId = "4895dcbe-94df-45f7-87f5-c519b8380878"
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Consumer",
                            UserId = "66342aee-8dc1-4b13-b912-f84fe202ef9d"
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Consumer",
                            UserId = "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c"
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Consumer",
                            UserId = "86eb1953-9686-4779-9d8f-7b236878435b"
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Consumer",
                            UserId = "e843d605-789e-4d0b-b9c6-9a2409a04857"
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Consumer",
                            UserId = "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarWashApp.Entities.Reservation", b =>
                {
                    b.HasOne("CarWashApp.Entities.GeneralUser", "Consumer")
                        .WithMany("Reservations")
                        .HasForeignKey("ConsumerId");

                    b.HasOne("CarWashApp.Entities.Service", "Service")
                        .WithMany("Reservations")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarWashApp.Entities.Shop", "Shop")
                        .WithMany("Reservations")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Consumer");

                    b.Navigation("Service");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("CarWashApp.Entities.Shop", b =>
                {
                    b.HasOne("CarWashApp.Entities.GeneralUser", "Owner")
                        .WithMany("Shops")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("CarWashApp.Entities.ShopsServices", b =>
                {
                    b.HasOne("CarWashApp.Entities.Service", "Service")
                        .WithMany("ShopServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarWashApp.Entities.Shop", "Shop")
                        .WithMany("ShopServices")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CarWashApp.Entities.GeneralUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CarWashApp.Entities.GeneralUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarWashApp.Entities.GeneralUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CarWashApp.Entities.GeneralUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarWashApp.Entities.GeneralUser", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Shops");
                });

            modelBuilder.Entity("CarWashApp.Entities.Service", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("ShopServices");
                });

            modelBuilder.Entity("CarWashApp.Entities.Shop", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("ShopServices");
                });
#pragma warning restore 612, 618
        }
    }
}
