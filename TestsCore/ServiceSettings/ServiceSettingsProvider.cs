using LykkeAutomation.TestsCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsCore.ServiceSettings
{
    public class ServiceSettingsProvider : Api
    {
        public ServiceSettingsProvider() : base("https://settings-test.lykkex.net/")
        {
        }

        public void ServiceSettings<T>(string resource,ref T type)
        {
            var response = client.GetAsync(resource);
            if (response.IsSuccessStatusCode)
                type = JsonConvert.DeserializeObject<T>(response.ContentJson);      
        }
    }
}
