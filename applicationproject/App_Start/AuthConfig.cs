using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.WebPages.OAuth;
using applicationproject.Models;

namespace applicationproject
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            OAuthWebSecurity.RegisterMicrosoftClient(
                clientId: "00000000401775F1",
                clientSecret: "hNUIzvdNzQw6ai8cFd1Tbd8cjdrTkrxw");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "fRcRb32ecT0zisqLsEiQtpTXL",
                consumerSecret: "EgNjk9b4Phv9DvWsEqCCix9dMiuwgccybUfoz0rfLonGlEoB47");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: "1059256540760467",
                appSecret: "d500d37e53269f250844a919731f8196");

            //OAuthWebSecurity.RegisterClient(new GooglePlusClient("975823701661-7jambdei7i4jl6opnp3c03p7gg86njme.apps.googleusercontent.com", "KaQhXXVy1-DA4j_U-yDrUFUd"), "Google+", null);

            //OAuthWebSecurity.RegisterGoogleClient("975823701661-7jambdei7i4jl6opnp3c03p7gg86njme.apps.googleusercontent.com", "KaQhXXVy1-DA4j_U-yDrUFUd");
        }
    }
}
