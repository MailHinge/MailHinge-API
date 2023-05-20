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
            var _graphServiceClient = _outlookService.GetGraphServiceClient();
            var result = await _graphServiceClient.Me.GetAsync();

            /*var result = await _graphServiceClient.Me.Messages.GetAsync((requestConfiguration) =>
            {
                requestConfiguration.QueryParameters.Select = new string[] { "sender", "subject" };
            }); */

            return "success";
        }
    }
}