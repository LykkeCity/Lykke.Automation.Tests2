using System;
using System.Collections.Generic;
using System.Text;

namespace LykkePay.Models
{
    public class MerchantModel
    {
        public string LykkeMerchantId { get; set; }
        public string LykkeMerchantSign { get; set; }

        public MerchantModel(string merchantId, string merchantSign)
        {
            LykkeMerchantId = merchantId;
            LykkeMerchantSign = merchantSign;
        }
    }
}
