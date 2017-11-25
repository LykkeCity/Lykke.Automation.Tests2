// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace LykkeAutomationPrivate.Models.ClientAccount.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class IsUsaUserModel
    {
        /// <summary>
        /// Initializes a new instance of the IsUsaUserModel class.
        /// </summary>
        public IsUsaUserModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IsUsaUserModel class.
        /// </summary>
        public IsUsaUserModel(bool isUSA, string clientId = default(string))
        {
            IsUSA = isUSA;
            ClientId = clientId;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsUSA")]
        public bool IsUSA { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ClientId")]
        public string ClientId { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}