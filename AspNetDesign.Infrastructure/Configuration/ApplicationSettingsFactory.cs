using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetDesign.Infrastructure.Configuration
{
    public class ApplicationSettingsFactory
    {
        private static IApplicationSettings _applicationSetting;

        public static void InitializeApplicationSettingsFactory(IApplicationSettings applicationSettings)
        {
            _applicationSetting = applicationSettings;
        }

        public static IApplicationSettings GetApplicationSettings()
        {
            return _applicationSetting;
        }
    }
}
