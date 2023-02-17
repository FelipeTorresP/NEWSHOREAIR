using Business.Utils;

namespace Utils.Tests
{
    [TestClass()]
    public class MapperTests
    {
        [DataRow(@"..\..\..\Resources\responseSimpleTest.json",2, "JFK" )]
        [DataRow(@"..\..\..\Resources\responseMultiReturnTest.json",20, "MDE")]
        [DataRow(@"..\..\..\Resources\responseMultiTest.json",10, "MDE")]
        [DataTestMethod()]
        public void MapResponseToObjectWhenResponseContaintsFlightsTest(string path, int expectedCountResult,string arrivalExpeted)
        {
            //arrange
            var response = BuilderResponse.BuildResponseCorrectly(path);

            //act
            List<Business.Models.FlightRecruiting> result = Mapper.MapResponseToObject(response);

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedCountResult, result.Count);
            Assert.AreEqual(arrivalExpeted, result[0].ArrivalStation);
        }
    }
}