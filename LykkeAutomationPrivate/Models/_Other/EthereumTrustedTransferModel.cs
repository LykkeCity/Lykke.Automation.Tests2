// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class EthereumTrustedTransferModel
    {
        /// <summary>
        /// Initializes a new instance of the EthereumTrustedTransferModel
        /// class.
        /// </summary>
        public EthereumTrustedTransferModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the EthereumTrustedTransferModel
        /// class.
        /// </summary>
        public EthereumTrustedTransferModel(string asset = default(string), double? volume = default(double?), string walletId = default(string), EthereumTransactionModel transfer = default(EthereumTransactionModel))
        {
            Asset = asset;
            Volume = volume;
            WalletId = walletId;
            Transfer = transfer;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Asset")]
        public string Asset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Volume")]
        public double? Volume { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "WalletId")]
        public string WalletId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Transfer")]
        public EthereumTransactionModel Transfer { get; set; }

    }
}
