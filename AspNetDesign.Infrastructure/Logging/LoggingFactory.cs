using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Infrastructure.Logging
{
    public class LoggingFactory 
    {
        public static ILogger _logger;

        public static void InitializeLogFactory(ILogger logger)
        {
            _logger = logger;
        }

        public static ILogger GetLogger()
        {
            return _logger;
        }
    }
}
