using System;
using MailHinge_API.Interfaces;
using Google.Apis.Gmail.v1;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;

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

            return _gmailService;

        }
    }
}

