using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.OperationalInsights;
using Microsoft.Rest.Azure.Authentication;
using System.Text.Json;

namespace KubernetesService.Controllers
{
    [Route("api/LogAnalytics")]
    [ApiController]
    public class LogAnalyticsConnectorController : ControllerBase
    {

        [HttpPost("LogAnalyticsConnector")]
        public string LogAnalyticsConnector(string query)
        {
            //query = "Heartbeat | where TimeGenerated > ago(7d)";// GetInv(name)
            var workspaceId = "";//"<your workspace ID>"; // Config
            var clientId = "";//"<your client ID>"; 
            var clientSecret = "";//"<your client secret>"; // Key Vault Exports in Environment
            var json = "";
            // Reading from Environment Add-IN Init Port --- to env  
            // OS OS.GetEvv

            var domain = "microsoft.onmicrosoft.com";//"<your AAD domain>";
            var authEndpoint = "https://login.microsoftonline.com";
            var tokenAudience = "https://api.loganalytics.io/";

            var adSettings = new ActiveDirectoryServiceSettings
            {
                AuthenticationEndpoint = new Uri(authEndpoint),
                TokenAudience = new Uri(tokenAudience),
                ValidateAuthority = true
            };

                var creds = ApplicationTokenProvider.LoginSilentAsync(domain, clientId, clientSecret, adSettings).GetAwaiter().GetResult();
                
                var client = new OperationalInsightsDataClient(creds);
                client.WorkspaceId = workspaceId;
            if (query != null)
            {
                var results = client.Query(query);
                json = JsonSerializer.Serialize(results);
            }
            else
            {
                json = "Possibly innecurate Query.";
            }


            return json;
        }


     }
}