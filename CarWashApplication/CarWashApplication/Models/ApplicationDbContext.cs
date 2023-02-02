using CarWashApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarWashApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<GeneralUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<GeneralUser> GeneralUsers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopsServices> ShopsServices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeneralUser>()
                .HasMany(x => x.Shops)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.OwnerId);
            modelBuilder.Entity<GeneralUser>()
                .HasMany(x => x.Reservations)
                .WithOne(x => x.Consumer)
                .HasForeignKey(x => x.ConsumerId);

            modelBuilder.Entity<Shop>()
                .HasOne(x => x.Owner)
                .WithMany(x => x.Shops)
                .HasForeignKey(x => x.OwnerId);
            modelBuilder.Entity<Shop>()
                .HasMany(x => x.Reservations)
                .WithOne(x => x.Shop)
                .HasForeignKey(x => x.ShopId);

            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.Shop)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.ShopId);
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.Service)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.ServiceId);
            modelBuilder.Entity<Reservation>()
                .HasOne(x => x.Consumer)
                .WithMany(x => x.Reservations)
                .HasForeignKey(x => x.ConsumerId);

            modelBuilder.Entity<Service>()
                .HasMany(x => x.Reservations)
                .WithOne(x => x.Service)
                .HasForeignKey(x => x.ServiceId);

            modelBuilder.Entity<ShopsServices>()
                .HasKey(x => new { x.ShopId, x.ServiceId });

            SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<GeneralUser>();

            var generalUsers = new List<GeneralUser>() {
                new GeneralUser()
                {
                    Id = "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c",
                    FirstName = "Aleksandar",
                    LastName = "Jovanovic",
                    UserName = "aleksandarjovanovic@example.com",
                    NormalizedUserName = "ALEKSANDARJOVANOVIC@EXAMPLE.COM",
                    Email = "aleksandarjovanovic@example.com",
                    NormalizedEmail = "ALEKSANDARJOVANOVIC@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Password123!")
                },
                new GeneralUser()
                {
                    Id = "e843d605-789e-4d0b-b9c6-9a2409a04857",
                    FirstName = "Mihailo",
                    LastName = "Simic",
                    UserName = "mihailosimic@example.com",
                    NormalizedUserName = "MIHAILOSIMIC@EXAMPLE.COM",
                    Email = "mihailosimic@example.com",
                    NormalizedEmail = "MIHAILOSIMIC@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Password123!")
                },
                new GeneralUser()
                {
                    Id = "17529DFE-458B-43E1-8F99-473F6F671812",
                    FirstName = "Luka",
                    LastName = "Bulatovic",
                    UserName = "lukabulatovic@example.com",
                    NormalizedUserName = "LUKABULATOVIC@EXAMPLE.COM",
                    Email = "lukabulatovic@example.com",
                    NormalizedEmail = "LUKABULATOVIC@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Password123!")
                },
                new GeneralUser()
                {
                    Id = "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9",
                    FirstName = "Nikola",
                    LastName = "Panic",
                    UserName = "nikolapanic@example.com",
                    NormalizedUserName = "NIKOLAPANIC@EXAMPLE.COM",
                    Email = "nikolapanic@example.com",
                    NormalizedEmail = "NIKOLAPANIC@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Password123!")
                },
                new GeneralUser()
                {
                    Id = "66342aee-8dc1-4b13-b912-f84fe202ef9d",
                    FirstName = "Milos",
                    LastName = "Mijatovic",
                    UserName = "milosmijatovic@example.com",
                    NormalizedUserName = "MILOSMIJATOVIC@EXAMPLE.COM",
                    Email = "milosmijatovic@example.com",
                    NormalizedEmail = "MILOSMIJATOVIC@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Password123!")
                },
                new GeneralUser()
                {
                    Id = "11dfd9c9-5d08-4196-9397-654a3b6fef3a",
                    FirstName = "Luka",
                    LastName = "Pavlovic",
                    UserName = "lukapavlovic@example.com",
                    NormalizedUserName = "LUKAPAVLOVIC@EXAMPLE.COM",
                    Email = "lukapavlovic@example.com",
                    NormalizedEmail = "LUKAPAVLOVIC@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Password123!")
                },
                new GeneralUser()
                {
                    Id = "4895dcbe-94df-45f7-87f5-c519b8380878",
                    FirstName = "Stefanija",
                    LastName = "Markovic",
                    UserName = "stefanijamarkovic@example.com",
                    NormalizedUserName = "STEFANIJAMARKOVIC@EXAMPLE.COM",
                    Email = "stefanijamarkovic@example.com",
                    NormalizedEmail = "STEFANIJAMARKOVIC@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Password123!")
                },
                new GeneralUser()
                {
                    Id = "86eb1953-9686-4779-9d8f-7b236878435b",
                    FirstName = "Vanja",
                    LastName = "Arsic",
                    UserName = "vanjaarsic@example.com",
                    NormalizedUserName = "VANJAARSIC@EXAMPLE.COM",
                    Email = "vanjaarsic@example.com",
                    NormalizedEmail = "VANJAARSIC@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Password123!")
                },
                new GeneralUser()
                {
                    Id = "8492a90d-2a60-4d51-913f-35f7522c40a1",
                    FirstName = "Aleksandar",
                    LastName = "Krstic",
                    UserName = "aleksandarkrstic@example.com",
                    NormalizedUserName = "ALEKSANDARKRSTIC@EXAMPLE.COM",
                    Email = "aleksandarkrstic@example.com",
                    NormalizedEmail = "ALEKSANDARKRSTIC@EXAMPLE.COM",
                    PasswordHash = hasher.HashPassword(null, "Password123!")
                }
            };

            var shops = new List<Shop>() {
                new Shop()
                {
                    ShopId = 1,
                    OwnerId = "8492a90d-2a60-4d51-913f-35f7522c40a1",
                    ShopName = "Shop1",
                    OpeningTime = 8,
                    ClosingTime = 18,
                    Address = "Tomazeova 36",
                },
                new Shop()
                {
                    ShopId = 2,
                    OwnerId = "8492a90d-2a60-4d51-913f-35f7522c40a1",
                    ShopName = "Shop2",
                    OpeningTime = 8,
                    ClosingTime = 18,
                    Address = "Maksima Gorkog 9",
                },
                new Shop()
                {
                    ShopId = 3,
                    OwnerId = "8492a90d-2a60-4d51-913f-35f7522c40a1",
                    ShopName = "Shop3",
                    OpeningTime = 8,
                    ClosingTime = 18,
                    Address = "Gospodara Vucica 18",
                }
            };

            var services = new List<Service>() {
                new Service()
                {
                    ServiceId = 1,
                    ServiceType = "Regular",
                    Price = 12,
                    Duration = 1
                },
                new Service()
                {
                    ServiceId = 2,
                    ServiceType = "Extended",
                    Price = 16,
                    Duration = 1
                },
                new Service()
                {
                    ServiceId = 3,
                    ServiceType = "Premium",
                    Price = 26,
                    Duration = 1
                }
                };

            var reservations = new List<Reservation>() {
                new Reservation()
                {
                    ReservationId = 1,
                    ReservationDateTime = DateTime.Now,
                    ConsumerId = "11dfd9c9-5d08-4196-9397-654a3b6fef3a",
                    ShopId = 1,
                    ServiceId = 1
                },
                new Reservation()
                {
                    ReservationId = 2,
                    ReservationDateTime = DateTime.Now,
                    ConsumerId = "17529DFE-458B-43E1-8F99-473F6F671812",
                    ShopId = 1,
                    ServiceId = 2
                },
                new Reservation()
                {
                    ReservationId = 3,
                    ReservationDateTime = DateTime.Now,
                    ConsumerId = "4895dcbe-94df-45f7-87f5-c519b8380878",
                    ShopId = 1,
                    ServiceId = 3
                },
                new Reservation()
                {
                    ReservationId = 4,
                    ReservationDateTime = DateTime.Now,
                    ConsumerId = "66342aee-8dc1-4b13-b912-f84fe202ef9d",
                    ShopId = 2,
                    ServiceId = 1
                },
                new Reservation()
                {
                    ReservationId = 5,
                    ReservationDateTime = DateTime.Now,
                    ConsumerId = "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c",
                    ShopId = 2,
                    ServiceId = 2
                },
                new Reservation()
                {
                    ReservationId = 6,
                    ReservationDateTime = DateTime.Now,
                    ConsumerId = "86eb1953-9686-4779-9d8f-7b236878435b",
                    ShopId = 2,
                    ServiceId = 3
                },
                new Reservation()
                {
                    ReservationId = 7,
                    ReservationDateTime = DateTime.Now,
                    ConsumerId = "e843d605-789e-4d0b-b9c6-9a2409a04857",
                    ShopId = 3,
                    ServiceId = 1
                },
                new Reservation()
                {
                    ReservationId = 8,
                    ReservationDateTime = DateTime.Now,
                    ConsumerId = "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9",
                    ShopId = 3,
                    ServiceId = 2
                }
            };

            var shopsServices = new List<ShopsServices>() {
                new ShopsServices()
                {
                    ShopId = 1,
                    ServiceId = 1
                },
                 new ShopsServices()
                {
                    ShopId = 1,
                    ServiceId = 2
                },
                  new ShopsServices()
                {
                    ShopId = 1,
                    ServiceId = 3
                },
                  new ShopsServices()
                {
                    ShopId = 2,
                    ServiceId = 1
                },
                  new ShopsServices()
                {
                    ShopId = 2,
                    ServiceId = 2
                },
                  new ShopsServices()
                {
                    ShopId = 2,
                    ServiceId = 3
                },
                  new ShopsServices()
                {
                    ShopId = 3,
                    ServiceId = 1
                },
                  new ShopsServices()
                {
                    ShopId = 3,
                    ServiceId = 2
                },
                  new ShopsServices()
                {
                    ShopId = 3,
                    ServiceId = 3
                }
            };

            var claims = new List<IdentityUserClaim<string>>() {
                new IdentityUserClaim<string>(){
                    Id = 1,
                    UserId = "8492a90d-2a60-4d51-913f-35f7522c40a1",
                    ClaimType =  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = "Owner"
                },
                 new IdentityUserClaim<string>(){
                    Id = 2,
                    UserId = "11dfd9c9-5d08-4196-9397-654a3b6fef3a",
                    ClaimType =  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = "Consumer"
                },
                  new IdentityUserClaim<string>(){
                    Id = 3,
                    UserId = "17529DFE-458B-43E1-8F99-473F6F671812",
                    ClaimType =  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = "Consumer"
                },
                   new IdentityUserClaim<string>(){
                    Id = 4,
                    UserId = "4895dcbe-94df-45f7-87f5-c519b8380878",
                    ClaimType =  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = "Consumer"
                },
                    new IdentityUserClaim<string>(){
                    Id = 5,
                    UserId = "66342aee-8dc1-4b13-b912-f84fe202ef9d",
                    ClaimType =  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = "Consumer"
                },
                     new IdentityUserClaim<string>(){
                    Id = 6,
                    UserId = "7bfbaf9a-ca2e-462b-8ef7-32d102cf1d5c",
                    ClaimType =  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = "Consumer"
                },
                      new IdentityUserClaim<string>(){
                    Id = 7,
                    UserId = "86eb1953-9686-4779-9d8f-7b236878435b",
                    ClaimType =  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = "Consumer"
                },
                       new IdentityUserClaim<string>(){
                    Id = 8,
                    UserId = "e843d605-789e-4d0b-b9c6-9a2409a04857",
                    ClaimType =  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = "Consumer"
                },
                        new IdentityUserClaim<string>(){
                    Id = 9,
                    UserId = "fdc70c25-e01f-4ecb-8a97-2af2857c4cb9",
                    ClaimType =  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                    ClaimValue = "Consumer"
                },

            };

            modelBuilder.Entity<GeneralUser>().HasData(generalUsers);
            modelBuilder.Entity<Shop>().HasData(shops);
            modelBuilder.Entity<Service>().HasData(services);
            modelBuilder.Entity<Reservation>().HasData(reservations);
            modelBuilder.Entity<ShopsServices>().HasData(shopsServices);
            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(claims);
        }
    }
}



