namespace RecruitingExternalSource.Tests
{
    [TestClass()]
    public class HttpClientTests
    {
        [TestMethod()]
        public void GetAsyncTest()
        {
            var client = new HttpClient();
            var result = client.GetAsync("https://recruiting-api.newshore.es/api/flights/2").Result;
            Assert.IsNotNull(result);            
        }
    }
}