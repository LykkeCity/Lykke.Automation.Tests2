// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class DateRangeModel
    {
        /// <summary>
        /// Initializes a new instance of the DateRangeModel class.
        /// </summary>
        public DateRangeModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the DateRangeModel class.
        /// </summary>
        public DateRangeModel(System.DateTime? dateFrom = default(System.DateTime?), System.DateTime? dateTo = default(System.DateTime?))
        {
            DateFrom = dateFrom;
            DateTo = dateTo;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DateFrom")]
        public System.DateTime? DateFrom { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DateTo")]
        public System.DateTime? DateTo { get; set; }

    }
}