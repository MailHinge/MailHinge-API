using System;
using Microsoft.AspNetCore.Mvc;
using MailHinge_API.Interfaces;
using Google.Apis.Gmail.v1;

using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;

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
        [GoogleScopedAuthorize(GmailService.ScopeConstants.GmailReadonly)]

        public async Task<string> GetEmail([FromServices] IGoogleAuthProvider auth)
		{
            GoogleCredential cred = await auth.GetCredentialAsync();
            var service = new GmailService(new BaseClientService.Initializer
            {
                HttpClientInitializer = cred
            });


            return "success";
		}



    }
}

