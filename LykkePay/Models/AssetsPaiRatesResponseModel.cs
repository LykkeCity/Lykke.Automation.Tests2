using System;
using System.Collections.Generic;
using System.Text;

namespace LykkePay.Models
{
    public class AssetsPaiRatesResponseModel
    {
            public string assetPair { get; set; }
            public float bid { get; set; }
            public float ask { get; set; }
            public int accuracy { get; set; }
    }
}
