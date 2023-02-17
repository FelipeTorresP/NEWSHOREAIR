namespace RecruitingExternalSource
{
    public interface IHttpClient
    {
        Task<string> GetAsync(string url);
    }
}