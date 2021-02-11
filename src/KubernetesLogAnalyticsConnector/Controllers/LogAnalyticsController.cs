using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.OperationalInsights;
using Microsoft.Extensions.Logging;
using Microsoft.Rest.Azure.Authentication;
using System.Text.Json;

namespace KubernetesLogAnalyticsConnector.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogAnalyticsController : ControllerBase
    {
        private readonly ILogger<LogAnalyticsController> _logger;

        public LogAnalyticsController(ILogger<LogAnalyticsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetLogAnalyticsQueryResults(string query, string WorkspaceId,
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
