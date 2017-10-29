using LykkeAutomationPrivate.Api.PersonalDataResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsCore.ServiceSettings;

namespace LykkeAutomationPrivate.Api
{
    class LykkeApi
    {
        public ServiceSettingsApi settings => new ServiceSettingsApi();
        public PersonalData PersonalData => new PersonalData();
    }
}
