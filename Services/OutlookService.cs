using Azure.Identity;
using Google.Apis.Auth.OAuth2;
using MailHinge_API.Interfaces;
using Microsoft.Graph;

namespace MailHinge_API.Services
{
    public class OutlookService : IOutlookService
    {
        public OutlookService()
        {
        }

        public GraphServiceClient GetGraphServiceClient()
        {
            #region explanation for scopes
            // The client credentials flow requires that you request the
            // /.default scope, and preconfigure your permissions on the
            // app registration in Azure. An administrator must grant consent
            // to those permissions beforehand.
            #endregion
            var scopes = new[] { "User.Read.All" };

            //client, client secret and tenant IDs from app registration
            string clientID = "4b496d0e-e0ad-4c65-a8ee-3f603b78635d";
            string tenantID = "f8cdef31-a31e-4b4a-93e4-5f571e91255a";
            string clientSecret = "k2x8Q~3KjmBP-CC~46nwh1zM9Mr25_PK508~6b7G";

            // For authorization code flow, the user signs into the Microsoft
            // identity platform, and the browser is redirected back to your app
            // with an authorization code in the query parameters
            var authorizationCode = "AUTH_CODE_FROM_REDIRECT";

            //using azure.identity
            TokenCredentialOptions options = new TokenCredentialOptions
            {
                AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
            };

            var authCodeCredential = new AuthorizationCodeCredential(
            tenantID, clientID, clientSecret, authorizationCode, options);

            var graphClient = new GraphServiceClient(authCodeCredential, scopes);

            return graphClient;
        }
    }
}

