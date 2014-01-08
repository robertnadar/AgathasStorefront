using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Infrastructure.Configuration
{
    public interface IApplicationSettings
    {
        string LoggerName { get; }
        string NoOfResultsPerPage { get; }
        string JanrainApiKey { get; }
        string PayPalBusinessEmail { get; }
        string PayPalPaymentPostToUrl { get; }
    }
}
