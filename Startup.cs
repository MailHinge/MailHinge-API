using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Graph.Models.ExternalConnectors;
using Microsoft.Graph;

namespace MailHinge_API
{
    public class Startup
	{
        private const string clientID = "1010069659275-2n1ovsplhcumjagac61vjer0lo35o1r7.apps.googleusercontent.com";
        private const string clientSecret = "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";
        private const string redirectURI = "http://localhost:7144/authorize";

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
		{
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
          .AddMicrosoftIdentityWebApp(_configuration.GetSection("AzureAd"));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure your middleware pipeline here
            app.UseHttpsRedirection();
           
                
            app.UseAuthentication();
            app.UseAuthorization();

        }
    }
}

