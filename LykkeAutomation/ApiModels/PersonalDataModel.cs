using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LykkeAutomation.ApiModels
{
    class PersonalDataModel
    {
        public Result Result { get; set; }
        public Error Error { get; set; }
    }

    public class Result
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
    }

    public class Error
    {
        public string Code { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }
    }
}
