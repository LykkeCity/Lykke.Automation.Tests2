// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class WalletDto
    {
        /// <summary>
        /// Initializes a new instance of the WalletDto class.
        /// </summary>
        public WalletDto()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WalletDto class.
        /// </summary>
        public WalletDto(string id = default(string), string name = default(string), string type = default(string), string description = default(string))
        {
            Id = id;
            Name = name;
            Type = type;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

    }
}