using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWalkthrough
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string SignInPageUrl = ConfigurationManager.AppSettings["login_url"];
        public static readonly string EmailAddress = ConfigurationManager.AppSettings["email_address"];
        public static readonly string Password = ConfigurationManager.AppSettings["password"];
    }
}
