// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class PubkeyAddressValidationRespModel
    {
        /// <summary>
        /// Initializes a new instance of the PubkeyAddressValidationRespModel
        /// class.
        /// </summary>
        public PubkeyAddressValidationRespModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PubkeyAddressValidationRespModel
        /// class.
        /// </summary>
        public PubkeyAddressValidationRespModel(bool? valid = default(bool?))
        {
            Valid = valid;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Valid")]
        public bool? Valid { get; set; }

    }
}
