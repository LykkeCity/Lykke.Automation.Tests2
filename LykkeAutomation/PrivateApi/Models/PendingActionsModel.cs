// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class PendingActionsModel
    {
        /// <summary>
        /// Initializes a new instance of the PendingActionsModel class.
        /// </summary>
        public PendingActionsModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PendingActionsModel class.
        /// </summary>
        public PendingActionsModel(bool? unsignedTxs = default(bool?), bool? offchainRequests = default(bool?), bool? needReinit = default(bool?), bool? dialogPending = default(bool?))
        {
            UnsignedTxs = unsignedTxs;
            OffchainRequests = offchainRequests;
            NeedReinit = needReinit;
            DialogPending = dialogPending;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UnsignedTxs")]
        public bool? UnsignedTxs { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "OffchainRequests")]
        public bool? OffchainRequests { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "NeedReinit")]
        public bool? NeedReinit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DialogPending")]
        public bool? DialogPending { get; set; }

    }
}
