// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ApiLimitTradeEvent
    {
        /// <summary>
        /// Initializes a new instance of the ApiLimitTradeEvent class.
        /// </summary>
        public ApiLimitTradeEvent()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApiLimitTradeEvent class.
        /// </summary>
        public ApiLimitTradeEvent(string id = default(string), string orderId = default(string), System.DateTime? dateTime = default(System.DateTime?), string asset = default(string), string assetPair = default(string), double? volume = default(double?), double? price = default(double?), string status = default(string), string type = default(string), double? totalCost = default(double?))
        {
            Id = id;
            OrderId = orderId;
            DateTime = dateTime;
            Asset = asset;
            AssetPair = assetPair;
            Volume = volume;
            Price = price;
            Status = status;
            Type = type;
            TotalCost = totalCost;
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
        [JsonProperty(PropertyName = "OrderId")]
        public string OrderId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DateTime")]
        public System.DateTime? DateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Asset")]
        public string Asset { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AssetPair")]
        public string AssetPair { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Volume")]
        public double? Volume { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Price")]
        public double? Price { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "TotalCost")]
        public double? TotalCost { get; set; }

    }
}
