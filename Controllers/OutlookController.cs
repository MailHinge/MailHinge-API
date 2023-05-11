using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Azure.Identity;
using MailHinge_API.Interfaces;
using System.Linq;


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
            var graphClient = _outlookService.GetGraphServiceClient();

            string userEmail = "hafiirahman@outlook.com";

            // Call the Graph API to find the user by email address
            //var user = await result.Me
            //.GetAsync()

            var users = await graphClient.Users[userEmail].MailFolders["inbox"]
                .Messages.GetAsync(requestConfiguration =>
                {
                    requestConfiguration.QueryParameters.Select = new string[] { "sender", "subject" };
                });

            return "success";
        }


        
	}
}

