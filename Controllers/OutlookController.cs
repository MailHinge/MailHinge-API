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
            var result = _outlookService.GetGraphServiceClient();

            string userEmail = "hafiirahman@outlook.com";

            // Call the Graph API to find the user by email address
            var user = await result.Me
            .GetAsync();

            return "success";
        }


        
	}
}

