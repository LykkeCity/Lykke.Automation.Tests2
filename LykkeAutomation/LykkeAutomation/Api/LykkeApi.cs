using LykkeAutomation.Api.AuthResource;
using LykkeAutomation.Api.PersonalDataResource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LykkeAutomation.Api.RegistrationResource;
using LykkeAutomation.Api.ApiModels.AccountExistModels;
using LykkeAutomation.Api.ApiResources.AccountExist;

namespace LykkeAutomation.Api
{
    class LykkeApi
    {
        public PersonalData PersonalData => new PersonalData();
        public Registration Registration => new Registration();
        public Auth Auth => new Auth();
        public AccountExist AccountExist => new AccountExist();
    }
}
