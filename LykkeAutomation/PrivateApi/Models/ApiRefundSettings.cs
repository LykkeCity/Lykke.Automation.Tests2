// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ApiRefundSettings
    {
        /// <summary>
        /// Initializes a new instance of the ApiRefundSettings class.
        /// </summary>
        public ApiRefundSettings()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApiRefundSettings class.
        /// </summary>
        public ApiRefundSettings(string address = default(string))
        {
            Address = address;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Address")]
        public string Address { get; set; }

    }
}
