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
    }
}
