using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace MailHinge_API
{
	public class Startup
	{
        private static string clientID = "1010069659275-2n1ovsplhcumjagac61vjer0lo35o1r7.apps.googleusercontent.com";
        private static string clientSecret = "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";
        private static string redirectURI = "http://localhost:7144/authorize";

        public Startup()
		{

        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure your services here
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure your middleware pipeline here
        }
    }
}

