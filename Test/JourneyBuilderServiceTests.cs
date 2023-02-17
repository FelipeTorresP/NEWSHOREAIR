using Microsoft.VisualStudio.TestTools.UnitTesting;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Utils;
using RecruitingExternalSource;
using Moq;
using System.IO;

namespace Business.Tests
{
    [TestClass()]
    public class JourneyBuilderServiceTests
    {
        private readonly Mock<IAppVariables> appVariables;
        private readonly Mock<IHttpClient> httpClient;
        private JourneyBuilderService journeyBuilderService;
        public JourneyBuilderServiceTests()
        {
            appVariables = new Mock<IAppVariables>();
            httpClient = new Mock<IHttpClient>();
            
            journeyBuilderService = new JourneyBuilderService(appVariables.Object, httpClient.Object);
        }
        [DataRow(@"..\..\..\Resources\responseMultiReturnTest.json")]
        [DataRow(@"..\..\..\Resources\responseSimpleTest.json")]
        [DataTestMethod()]
        public void GetJourneyTest(string path)
        {
            //arrange
            var response = BuilderResponse.BuildResponseCorrectly(path);

            httpClient.Setup(x => x.GetAsync(It.IsAny<string>())).Returns(Task.FromResult(response));
            //act
            var actual = journeyBuilderService.GetJourney("BOG", "MZL", 0);
            //assert
            Assert.IsNotNull(actual);
        }

    }
}