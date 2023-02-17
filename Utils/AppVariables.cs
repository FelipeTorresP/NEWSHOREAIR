using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Utils
{
    public class AppVariables : IAppVariables
    {
        const string GetFlightsUrl = "ApiNewShoreRoutes:GetFlightsUrl";
        IConfiguration configuration;
        public AppVariables(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GetAppSettingsVariable()
        {

            return configuration.GetSection(key: GetFlightsUrl).Value?? String.Empty;
        }
    }
    
}