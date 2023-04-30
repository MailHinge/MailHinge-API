using System;
using Azure.Identity;
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
        string[] scopes = new[] { "https://graph.microsoft.com/.default" };

        //client, client secret and tenant IDs from app registration
        string clientID = "4b496d0e-e0ad-4c65-a8ee-3f603b78635d";
        string tenantID = "f8cdef31-a31e-4b4a-93e4-5f571e91255a";
        string clientSecretVal = "k2x8Q~3KjmBP-CC~46nwh1zM9Mr25_PK508~6b7G";

        //using azure.identity
        TokenCredentialOptions options = new TokenCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
        };

        ClientSecretCredential clientSecretCredential = new ClientSecretCredential(
        tenantID, clientID, clientSecretVal, options);

        GraphServiceClient _graphService = new GraphServiceClient(clientSecretCredential, scopes);

            return _graphService;
        }
    }
}

