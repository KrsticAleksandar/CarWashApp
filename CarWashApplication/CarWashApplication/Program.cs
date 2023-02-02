
using CarWashApp.Entities;
using CarWashApp.Models;
using CarWashApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.Text;

//namespace CarWashApplication
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);
//            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'CarWashApplicationContextConnection' not found.");
//            // Add services to the container.

//            builder.Services.AddControllers().AddNewtonsoftJson();
//            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
//            builder.Services.AddIdentity<GeneralUser, IdentityRole>()
//                .AddEntityFrameworkStores<ApplicationDbContext>()
//                .AddDefaultTokenProviders();

//            builder.Services.AddDefaultIdentity<IdentityUser>()
//            .AddEntityFrameworkStores<ApplicationDbContext>();

//            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//                .AddJwtBearer(options =>
//                    options.TokenValidationParameters = new TokenValidationParameters
//                    {
//                        ValidateIssuer = false,
//                        ValidateAudience = false,
//                        ValidateLifetime = true,
//                        ValidateIssuerSigningKey = true,
//                        IssuerSigningKey = new SymmetricSecurityKey(
//                        Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"])),
//                        ClockSkew = TimeSpan.Zero
//                    }
//                );

//            builder.Services.AddAuthorization(options =>
//            {
//                options.AddPolicy("UserPolicy", policy => policy.RequireAssertion(opt => opt.User.IsInRole("Consumer") || opt.User.IsInRole("Owner")));
//            });

//            builder.Services.AddAutoMapper(typeof(Program));
//            builder.Services.AddTransient<IHostedService, BackgroundTask>();

//            builder.Services.AddControllersWithViews();
//            builder.Services.AddHttpContextAccessor();
//            builder.Services.AddSession();
//            builder.Services.AddRazorPages();
//            builder.Services.AddServerSideBlazor();

//            var app = builder.Build();

//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                //app.UseSwagger();
//                //app.UseSwaggerUI();
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }

//            app.UseHttpsRedirection();

//            app.UseStaticFiles();

//            app.UseSession();

//            app.UseAuthentication();

//            app.UseAuthorization();

//            //app.MapDefaultControllerRoute();

//            app.MapControllerRoute(
//                name: "default",
//                pattern: "{controller=Home}/{action=Index}/{id?}");

//            app.MapRazorPages();

//            app.MapBlazorHub();

//            //DbInitializer.SeedData(app);

//            //app.Run();
//        }
//    }
//}

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
