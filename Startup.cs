using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Google.Apis.Auth.AspNetCore3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;

namespace MailHinge_API
{
    public class Startup
	{
        private const string clientID = "1010069659275-2n1ovsplhcumjagac61vjer0lo35o1r7.apps.googleusercontent.com";
        private const string clientSecret = "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";
        private const string redirectURI = "http://localhost:7144/authorize";

        public Startup()
		{

        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configure your services here
            // This configures Google.Apis.Auth.AspNetCore3 for use in this app.
            services
                .AddAuthentication(o =>
                {
                    // This forces challenge results to be handled by Google OpenID Handler, so there's no
                    // need to add an AccountController that emits challenges for Login.
                    o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                    // This forces forbid results to be handled by Google OpenID Handler, which checks if
                    // extra scopes are required and does automatic incremental auth.
                    o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                    // Default scheme that will handle everything else.
                    // Once a user is authenticated, the OAuth2 token info is stored in cookies.
                    o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie()
                .AddGoogleOpenIdConnect(options =>
                {
                    options.ClientId = clientID;
                    options.ClientSecret = clientSecret;
                });
                
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

