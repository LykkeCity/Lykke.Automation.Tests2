﻿using System;
using System.Collections.Generic;
using System.Text;
using LykkeAutomationPrivate.Models.ClientAccount.Models;
using TestsCore.RestRequests.Interfaces;

namespace LykkeAutomationPrivate.Resources.ClientAccountResource
{
    public class AccountExist : ClientAccount
    {
        public IResponse GetAccountExist(string email)
        {
            return Request.Get("/api/AccountExist").AddQueryParameter("email", email).Build().Execute();
        }
    }
}