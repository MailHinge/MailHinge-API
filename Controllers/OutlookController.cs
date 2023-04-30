﻿using System;
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
        public string GetEmail()
        {
            return "Wojtek";
        }


        
	}
}

