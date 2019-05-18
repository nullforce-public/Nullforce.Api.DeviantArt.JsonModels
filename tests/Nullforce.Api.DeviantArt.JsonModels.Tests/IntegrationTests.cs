using System;
using Flurl;
using Flurl.Http;
using Xunit;

namespace Nullforce.Api.DeviantArt.JsonModels.Tests
{
    [Trait("Category", "IntegrationTests")]
    public class IntegrationTests
    {
        [Fact]
        public async void Placebo_WithDefaults_ReturnsResult()
        {
            var clientId = Environment.GetEnvironmentVariable("DEVIANTART_CLIENTID");
            var clientSecret = Environment.GetEnvironmentVariable("DEVIANTART_CLIENTSECRET");

            if (string.IsNullOrEmpty(clientId))
            {
                Console.WriteLine("DEVIANTART_CLIENTID environment variable not found");
            }

            if (string.IsNullOrEmpty(clientSecret))
            {
                Console.WriteLine("DEVIANTART_CLIENTSECRET environment variable not found");
            }

            var authUri = "https://www.deviantart.com/oauth2/token";
            authUri = authUri.SetQueryParams(new {
                grant_type = "client_credentials",
                client_id = clientId,
                client_secret = clientSecret
            });

            var authResult = await authUri.GetJsonAsync<AuthJson>();

            var uri = "https://www.deviantart.com/api/v1/oauth2/placebo";

            var result = await uri.WithOAuthBearerToken(authResult.AccessToken).GetJsonAsync<PlaceboJson>();
        }
    }
}
