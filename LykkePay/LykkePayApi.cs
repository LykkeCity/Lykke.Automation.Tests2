using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsCore.ServiceSettings;

namespace LykkePay.Api
{
    public class LykkePayApi
    {
        public ServiceSettingsApi settings => new ServiceSettingsApi();
    }
}
