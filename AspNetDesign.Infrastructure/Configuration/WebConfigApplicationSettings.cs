using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Infrastructure.Configuration
{
    public class WebConfigApplicationSettings : IApplicationSettings
    {
        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }
        public string NoOfResultsPerPage
        {
            get { return ConfigurationManager.AppSettings["NoOfResultsPerPage"]; }
        }

        public string JanrainApiKey
        {
            get
            {
                return ConfigurationManager.AppSettings["JanrainApiKey"];
            }
        }

        public string PayPalBusinessEmail
        {
            get { return ConfigurationManager.AppSettings["PayPalBusinessEmail"]; }
        }

        public string PayPalPaymentPostToUrl
        {
            get { return ConfigurationManager.AppSettings["PayPalPaymentPostToUrl"]; }
        }

    }
}
