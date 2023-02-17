using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Business.Utils;

namespace Utils.Tests
{
    [TestClass()]
    public class AppVariablesTests
    {
        private IConfigurationRoot _configuration;
        private AppVariables appVariables;
        public AppVariablesTests()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            appVariables = new AppVariables(_configuration);
        }

        [TestMethod()]
        public void GetAppSettingsVariableTest()
        {
            //arrange
            string expected = "https://recruiting-api.newshore.es/api/flights/2";
            //act
            string actual = appVariables.GetAppSettingsVariable();
            //assert
            Assert.AreEqual(expected, actual);

        }
    }
}