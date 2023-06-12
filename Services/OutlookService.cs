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
            var credentials = new DeviceCodeCredential(new DeviceCodeCredentialOptions
            {
                ClientId = "4b496d0e-e0ad-4c65-a8ee-3f603b78635d",
                TenantId = "f8cdef31-a31e-4b4a-93e4-5f571e91255a",

            });

            var graphClient = new GraphServiceClient(credentials, new List<string> { "User.Read" });

            return graphClient;
        }
    }
}

