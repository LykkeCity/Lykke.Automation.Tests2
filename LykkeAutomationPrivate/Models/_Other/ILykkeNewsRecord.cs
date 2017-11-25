// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ILykkeNewsRecord
    {
        /// <summary>
        /// Initializes a new instance of the ILykkeNewsRecord class.
        /// </summary>
        public ILykkeNewsRecord()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ILykkeNewsRecord class.
        /// </summary>
        public ILykkeNewsRecord(string author = default(string), string title = default(string), System.DateTime? dateTime = default(System.DateTime?), string imgUrl = default(string), string url = default(string), string text = default(string))
        {
            Author = author;
            Title = title;
            DateTime = dateTime;
            ImgUrl = imgUrl;
            Url = url;
            Text = text;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Author")]
        public string Author { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Title")]
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "DateTime")]
        public System.DateTime? DateTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ImgUrl")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Url")]
        public string Url { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }

    }
}