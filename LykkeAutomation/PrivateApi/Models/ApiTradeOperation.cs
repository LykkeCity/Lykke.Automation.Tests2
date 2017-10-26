// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ApiTradeOperation
    {
        /// <summary>
        /// Initializes a new instance of the ApiTradeOperation class.
        /// </summary>
        public ApiTradeOperation()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApiTradeOperation class.
        /// </summary>
        /// <param name="state">Possible values include: 'InProcessOnchain',
        /// 'SettledOnchain', 'InProcessOffchain', 'SettledOffchain',
        /// 'SettledNoChain'</param>
        public ApiTradeOperation(string id = default(string), string dateTime = default(string), string asset = default(string), double? volume = default(double?), string iconId = default(string), string blockChainHash = default(string), string addressFrom = default(string), string addressTo = default(string), bool? isSettled = default(bool?), string state = default(string), ApiMarketOrder marketOrder = default(ApiMarketOrder), string orderId = default(string), bool? isLimitTrade = default(bool?))
        {
            Id = id;
            DateTime = dateTime;
            Asset = asset;
            Volume = volume;
            IconId = iconId;
            BlockChainHash = blockChainHash;
            AddressFrom = addressFrom;
            AddressTo = addressTo;
            IsSettled = isSettled;
            State = state;
            MarketOrder = marketOrder;
            OrderId = orderId;
            IsLimitTrade = isLimitTrade;
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
        [JsonProperty(PropertyName = "DateTime")]
        public string DateTime { get; set; }

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
        [JsonProperty(PropertyName = "IconId")]
        public string IconId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "BlockChainHash")]
        public string BlockChainHash { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AddressFrom")]
        public string AddressFrom { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AddressTo")]
        public string AddressTo { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsSettled")]
        public bool? IsSettled { get; set; }

        /// <summary>
        /// Gets or sets possible values include: 'InProcessOnchain',
        /// 'SettledOnchain', 'InProcessOffchain', 'SettledOffchain',
        /// 'SettledNoChain'
        /// </summary>
        [JsonProperty(PropertyName = "State")]
        public string State { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MarketOrder")]
        public ApiMarketOrder MarketOrder { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "OrderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsLimitTrade")]
        public bool? IsLimitTrade { get; set; }

    }
}
