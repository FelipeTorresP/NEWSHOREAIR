namespace RecruitingExternalSource
{
    public class HttpClient : IHttpClient
    {
        static readonly HttpClient client = new();
                 
        public static HttpClient Instance
        {
            get
            {
                return client;
            }
        }

        public async Task<string> GetAsync(string url)
        {
            var client = new System.Net.Http.HttpClient();
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }

    }
}