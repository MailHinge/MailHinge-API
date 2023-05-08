using System;
using MailHinge_API.Interfaces;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Gmail.v1;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MailHinge_API.Services
{
    public class GMailService : IGMailService
    {
        private static string clientID = "1010069659275-2n1ovsplhcumjagac61vjer0lo35o1r7.apps.googleusercontent.com";
        private static string clientSecret = "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";
        private static string redirectURI = "http://localhost:7144/authorize";

        public GMailService()
        {
        }

        public void GetGmailServiceClient(IServiceCollection gmailservice)
        {
            // This configures Google.Apis.Auth.AspNetCore3 for use in this app.
            gmailservice
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
            
            app.UseHttpsRedirection();
            

            app.UseAuthentication();
            app.UseAuthorization();

            
}



    }
}

