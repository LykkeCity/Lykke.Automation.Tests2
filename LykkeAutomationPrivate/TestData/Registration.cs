using System;
using System.Collections.Generic;
using System.Text;
using LykkeAutomationPrivate.Models.Registration.Models;
using TestsCore;
using TestsCore.TestsData;

namespace LykkeAutomationPrivate.TestData2
{
    public class Registration
    {
        public AccountRegistrationModel GetTestAccountRegistrationModel()
        {
            return new AccountRegistrationModel()
            {
                Email = TestData.GenerateEmail(),
                FullName = TestData.FullName(),
                ContactPhone = TestData.GeneratePhone(),
                Password = "1234567",
                Hint = TestData.GenerateString(5)
                //ClientInfo = 
                //UserAgent = 
                //PartnerId = 
                //Ip = 
                //Changer = 
                //IosVersion = 
                //Referer = 
            };
        }
    }
}
