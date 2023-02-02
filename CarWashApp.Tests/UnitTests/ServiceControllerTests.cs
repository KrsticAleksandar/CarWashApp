using CarWashApp.Controllers;
using CarWashApp.DTOs.ServiceDTOs;
using CarWashApp.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashApp.Tests.UnitTests
{
    [TestClass]
    public class ServiceControllerTests : BaseTests
    {
        [TestMethod]
        public async Task GetAllServices()
        {
            
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);
            var mapper = BuildMap();

            context.Services.Add(new Service() { ServiceId = 34, ServiceType = "FirstService", Price = 5, Duration = 7 });
            context.Services.Add(new Service() { ServiceId = 28, ServiceType = "SecondService", Price = 56, Duration = 88 });
            context.Services.Add(new Service() { ServiceId = 13, ServiceType = "ThirdService", Price = 18, Duration = 63 });

            context.SaveChanges();

            var context2 = BuildContext(databaseName);

            
            var controller = new ServiceController(context2, mapper);
            var response = await controller.Get();

            
            var services = response.Value;
            Assert.AreEqual(3, services.Count);
        }

        [TestMethod]
        public async Task GetServiceByIdDoesNotExist()
        {
            
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);
            var mapper = BuildMap();
            string message = "Service with this number ID doesn't exist! Please try again!";

            
            var serviceController = new ServiceController(context, mapper);
            var response = await serviceController.Get(4);

            
            var result = response.Result as NotFoundObjectResult;
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual(message, result.Value);
        }

        [TestMethod]
        public async Task GetServiceById()
        {
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);
            var mapper = BuildMap();

            context.Services.Add(new Service() 
            {
                ServiceId = 1,
                ServiceType = "REGULAR",
                Duration = 1,
                Price = 12
            });
            context.Services.Add(new Service()
            {
                ServiceId = 2,
                ServiceType = "EXTENDED",
                Duration = 1,
                Price = 16
            });
            context.Services.Add(new Service()
            {
                ServiceId = 3,
                ServiceType = "PREMIUM",
                Duration = 1,
                Price = 26
            });
            context.SaveChanges();

            var context2 = BuildContext(databaseName);

            var controller = new ServiceController(context2, mapper);

            var id = 1;
            var response = await controller.Get(id);
            var result = response.Value;
            Assert.AreEqual(1, result.ServiceId);
            Assert.AreEqual("REGULAR", result.ServiceType);
            Assert.AreEqual(12, result.Price);
        }

        [TestMethod]
        public async Task PostServiceFromOwner()
        {
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);
            var mapper = BuildMap();

            var context3 = BuildContext(databaseName);

            var controller = new ServiceController(context3, mapper);
            var serviceCreation = new ServiceCreationDTO { ServiceType = "REGULAR", Duration = 1, Price = 12 };


            var response = await controller.Post(serviceCreation);
            var result = response as CreatedAtRouteResult;
            Assert.IsNotNull(result.Value);
        }

        [TestMethod]
        public async Task PutServiceById()
        {
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);
            var mapper = BuildMap();

            context.Services.Add(new Service()
            {
                ServiceId = 1,
                ServiceType = "REGULAR",
                Duration = 1,
                Price = 12
            });
            context.Services.Add(new Service()
            {
                ServiceId = 2,
                ServiceType = "EXTENDED",
                Duration = 1,
                Price = 16
            });
            context.Services.Add(new Service()
            {
                ServiceId = 3,
                ServiceType = "PREMIUM",
                Duration = 1,
                Price = 26
            });
            context.SaveChanges();

            var context2 = BuildContext(databaseName);

            var controller = new ServiceController(context2, mapper);

            string newServiceName = "NEW SERVICE NAME";
            int newServiceDuration = 10;
            float newServicePrice = 120;

            var serviceCreation = new ServiceCreationDTO { ServiceType = newServiceName, Duration = newServiceDuration, Price = newServicePrice };

            var id = 1;
            var response = await controller.Put(id, serviceCreation);
            var result = response.Value;
            Assert.IsNotNull(result);
            Assert.AreEqual(newServiceName, result.ServiceType);
            Assert.AreEqual(newServiceDuration, result.Duration);
            Assert.AreEqual(newServicePrice, result.Price);
        }

        [TestMethod]
        public async Task PutServiceFailedById()
        {
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);
            var mapper = BuildMap();

            context.Services.Add(new Service()
            {
                ServiceId = 1,
                ServiceType = "REGULAR",
                Duration = 1,
                Price = 12
            });
            context.Services.Add(new Service()
            {
                ServiceId = 2,
                ServiceType = "EXTENDED",
                Duration = 1,
                Price = 16
            });
            context.Services.Add(new Service()
            {
                ServiceId = 3,
                ServiceType = "PREMIUM",
                Duration = 1,
                Price = 26
            });
            context.SaveChanges();

            var context2 = BuildContext(databaseName);

            var controller = new ServiceController(context2, mapper);

            string newServiceName = "NEW SERVICE NAME";
            int newServiceDuration = 10;
            float newServicePrice = 120;
            

            var serviceCreation = new ServiceCreationDTO { ServiceType = newServiceName, Duration = newServiceDuration, Price = newServicePrice };

            var id = 99;
            string badRequestMessage = "Service with this number ID doesn't exist! Please try again!";

            var response = await controller.Put(id, serviceCreation);
            var result = response.Result as NotFoundObjectResult;
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual(badRequestMessage, result.Value);
        }

        [TestMethod]
        public async Task DeleteByServiceId()
        {
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);
            var mapper = BuildMap();

            context.Services.Add(new Service()
            {
                ServiceId = 1,
                ServiceType = "REGULAR",
                Duration = 1,
                Price = 12
            });
            context.Services.Add(new Service()
            {
                ServiceId = 2,
                ServiceType = "EXTENDED",
                Duration = 1,
                Price = 16
            });
            context.Services.Add(new Service()
            {
                ServiceId = 3,
                ServiceType = "PREMIUM",
                Duration = 1,
                Price = 26
            });
            context.SaveChanges();

            var context2 = BuildContext(databaseName);

            var controller = new ServiceController(context2, mapper);

            var id = 1;
            var response = await controller.Delete(id);

            var result = response as NoContentResult;
            Assert.AreEqual(204, result.StatusCode);
        }

        [TestMethod]
        public async Task DeleteServiceFailed()
        {
            var databaseName = Guid.NewGuid().ToString();
            var context = BuildContext(databaseName);
            var mapper = BuildMap();

            context.Services.Add(new Service()
            {
                ServiceId = 1,
                ServiceType = "REGULAR",
                Duration = 1,
                Price = 12
            });
            context.Services.Add(new Service()
            {
                ServiceId = 2,
                ServiceType = "EXTENDED",
                Duration = 1,
                Price = 16
            });
            context.Services.Add(new Service()
            {
                ServiceId = 3,
                ServiceType = "PREMIUM",
                Duration = 1,
                Price = 26
            });
            context.SaveChanges();

            var context2 = BuildContext(databaseName);

            var controller = new ServiceController(context2, mapper);
            string message = "Service with this number ID doesn't exist! Please try again!";

            var id = 99;
            var response = await controller.Delete(id);

            var result = response as NotFoundObjectResult;
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual(message, result.Value);
        }
    }
}
