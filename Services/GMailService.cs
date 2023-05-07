using System;
using MailHinge_API.Interfaces;
using Google.Apis.Gmail.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;

namespace MailHinge_API.Services
{
    public class GMailService : IGMailService
    {
        private static string clientID = "1010069659275-2n1ovsplhcumjagac61vjer0lo35o1r7.apps.googleusercontent.com";
        private static string clientSecret = "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";
        private static string redirectURI = "http://localhost:7144/authorize";

        public GMailService()
        {
        }

        public async Task<GmailService> GetGmailServiceClient()
        {
            // Create a new Gmail API client with your credentials
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets { ClientId = clientID,
                    ClientSecret = clientSecret
                },
                new[] { GmailService.Scope.GmailReadonly },
                "user",
                CancellationToken.None);

            GmailService _gmailService = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "MailHinge"
            });

            return _gmailService;

        }
    }
}

