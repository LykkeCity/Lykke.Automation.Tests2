﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LykkePay.Models
{
    public class PostAssetsPairRatesModel
    {
        public string assetPair { get; set; }
        public double ask { get; set; }
        public double bid { get; set; }
        public int accuracy { get; set; }
        [JsonProperty("Lykke-Merchant-Session-Id")]
        public string LykkeMerchantSessionId { get; set; }
    }
}
