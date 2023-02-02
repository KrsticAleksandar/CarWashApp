using AutoMapper;
using CarWashApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarWashApp.Tests
{
    public class BaseTests
    {
        protected ApplicationDbContext BuildContext(string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName).Options;

                var dbContext = new ApplicationDbContext(options);
                return dbContext;
        }

        protected IMapper BuildMap()
        {
            var config = new MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapperProfiles());
            });

            return config.CreateMapper();
        }

        protected ControllerContext BuildControllerContextWithDefaultUser()
        {
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
               {
                new Claim(ClaimTypes.Name, "example@example.com"),
                new Claim(ClaimTypes.Email, "example@example.com"),
               }, "test"));

            return new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
        }
    }
}
