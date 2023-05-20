using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Azure.Identity;
using MailHinge_API.Interfaces;

namespace MailHinge_API.Controllers
{
    [ApiController]
    [Route("outlook/")]
    public class OutlookController : ControllerBase
    {
        private readonly IOutlookService _outlookService;

        public OutlookController(IOutlookService outlookService)
        {
            _outlookService = outlookService;

        }

        [HttpGet("getEmail")]
        public async Task<string> GetEmail()
        {
            //var graphServiceClient = _outlookService.GetGraphServiceClient();

            var scopes = new[] { "https://graph.microsoft.com/.default" };
            var tenantId = "f8cdef31-a31e-4b4a-93e4-5f571e91255a";
            var clientId = "4b496d0e-e0ad-4c65-a8ee-3f603b78635d";
            var clientSecret = "k2x8Q~3KjmBP-CC~46nwh1zM9Mr25_PK508~6b7G";
            var clientSecretCredential = new ClientSecretCredential(
                            tenantId, clientId, clientSecret);
            var graphClient = new GraphServiceClient(clientSecretCredential, scopes);

            var result = await graphClient.Me.Messages.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "sender", "subject" };
            });

            return "success";
        }
    }
}