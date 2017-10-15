﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LykkeAutomation.TestsData;
using Newtonsoft.Json;

namespace LykkeAutomation.ApiModels
{
    public class PersonalDataModel
    {
        [JsonProperty("Result")]
        public PersonalData PersonalData { get; set; }
        public Error Error { get; set; }
    }

    public class PersonalData
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }


        public PersonalData()
        {
            SetName();
            Email = PersonalTestData.GenerateEmail();
        }

        public void SetName()
        {
            var person = PersonalTestData.FirstLastName();

            this.FirstName = person.Key;
            this.LastName = person.Value;
            this.FullName = $"{FirstName} {LastName}";
        }
    }

    public class Error
    {
        public string Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }  
}