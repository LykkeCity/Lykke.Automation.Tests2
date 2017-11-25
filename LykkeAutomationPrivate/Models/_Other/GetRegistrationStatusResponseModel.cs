// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class GetRegistrationStatusResponseModel
    {
        /// <summary>
        /// Initializes a new instance of the
        /// GetRegistrationStatusResponseModel class.
        /// </summary>
        public GetRegistrationStatusResponseModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the
        /// GetRegistrationStatusResponseModel class.
        /// </summary>
        /// <param name="kycStatus">Possible values include: 'NeedToFillData',
        /// 'Pending', 'Ok', 'RestrictedArea'</param>
        public GetRegistrationStatusResponseModel(string kycStatus = default(string), bool? pinIsEntered = default(bool?), ApiPersonalDataModel personalData = default(ApiPersonalDataModel))
        {
            KycStatus = kycStatus;
            PinIsEntered = pinIsEntered;
            PersonalData = personalData;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets possible values include: 'NeedToFillData', 'Pending',
        /// 'Ok', 'RestrictedArea'
        /// </summary>
        [JsonProperty(PropertyName = "KycStatus")]
        public string KycStatus { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PinIsEntered")]
        public bool? PinIsEntered { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PersonalData")]
        public ApiPersonalDataModel PersonalData { get; set; }

    }
}