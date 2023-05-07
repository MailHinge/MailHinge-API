using System;
using MailHinge_API.Interfaces;
using Google.Apis.Gmail.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;

namespace MailHinge_API.Services
{
    public class GMailService : IGMailService
    {
        public GMailService()
        {
        }

        public async Task<GmailService> GetGmailServiceClient()
        {
            // Create a new Gmail API client with your credentials
            var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new ClientSecrets { ClientId = "1010069659275-2n1ovsplhcumjagac61vjer0lo35o1r7.apps.googleusercontent.com",
                    ClientSecret = "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"
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

