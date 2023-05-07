using System;
using Microsoft.AspNetCore.Mvc;
using MailHinge_API.Interfaces;
using Google.Apis.Gmail.v1;

namespace MailHinge_API.Controllers
{
    [ApiController]
    [Route("gmail/")]

    public class GmailController : ControllerBase
	{
		private readonly IGMailService _IGMailService;

		public GmailController(IGMailService gmailService)
		{
			_IGMailService = gmailService;
		}

        [HttpGet("getEmail")]
		public async Task<string> GetEmail()
		{
			var serviceResult = await _IGMailService.GetGmailServiceClient();


			

			return "success";
		}



    }
}

