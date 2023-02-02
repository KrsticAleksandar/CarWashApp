using AutoMapper;
using CarWashApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashApp.Tests.UnitTests
{
    [TestClass]
    public class AutomapperTest : BaseTests
    {
        [TestMethod]
        public void AutomappeConfigurationIsValid()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile<AutoMapperProfiles>();
            });

            configuration.AssertConfigurationIsValid();
        }
    }
    
}
