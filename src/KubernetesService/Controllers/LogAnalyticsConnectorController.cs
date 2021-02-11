using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        [HttpGet("LogAnalyticsConnector")]
        public ActionResult<string> LogAnalyticsConnector()
        { return "200"; }

        [HttpPost("LogAnalyticsConnector")]
        public ActionResult<string> LogAnalyticsConnector(string query, string WorkspaceId,
                                                               string ClientId,
                                                               string ClientSecret,
                                                              string Domain)
        {
            var workspaceId = WorkspaceId;//"<your workspace ID>";
            var clientId = ClientId;//"<your client ID>";
            var clientSecret = ClientSecret;//"<your client secret>";

            var domain = Domain;//"<your AAD domain>";
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

            var results = client.Query(query);
            var json = JsonSerializer.Serialize(results);
            return json;
        }
    }
}