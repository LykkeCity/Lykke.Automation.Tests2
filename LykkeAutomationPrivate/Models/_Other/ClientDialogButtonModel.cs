// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ClientDialogButtonModel
    {
        /// <summary>
        /// Initializes a new instance of the ClientDialogButtonModel class.
        /// </summary>
        public ClientDialogButtonModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ClientDialogButtonModel class.
        /// </summary>
        public ClientDialogButtonModel(System.Guid? id = default(System.Guid?), bool? pinRequired = default(bool?), string text = default(string))
        {
            Id = id;
            PinRequired = pinRequired;
            Text = text;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public System.Guid? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PinRequired")]
        public bool? PinRequired { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }

    }
}
