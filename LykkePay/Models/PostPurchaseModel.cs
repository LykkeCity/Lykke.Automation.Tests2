using System;
using System.Collections.Generic;
using System.Text;

namespace LykkePay.Models
{
    public class PostPurchaseModel
    {
        public string destinationAddress { get; set; }
        public string assetPair { get; set; }
        public string baseAsset { get; set; }
        public string amount { get; set; }
        public string successUrl { get; set; }
        public string errorUrl { get; set; }
        public string progressUrl { get; set; }
        public string orderId { get; set; }
        public PostMarkup markup { get; set; }


        public PostPurchaseModel(PostMarkup markup, string assetPair)
        {
            this.markup = markup;
            destinationAddress = "mnosddsjcchkwjfnnjcdodsc=";
            this.assetPair = assetPair;
            baseAsset = "USD";
            amount = "10";
            successUrl = "http://yandex.ru";
            errorUrl = "http://yandex.ru";
            progressUrl = "http://yandex.ru";
            orderId = "";
        }
    }

    public class PostMarkup
    {
        public float percent { get; set; }
        public int pips { get; set; }
        public float fixedFee { get; set; }

        public PostMarkup(float percent, int pips, float fixedFee)
        {
            this.percent = percent;
            this.pips = pips;
            this.fixedFee = fixedFee;
        }

        public PostMarkup(MarkupModel markupModel, float fixedFee)
        {
            this.percent = markupModel.markup.percent;
            this.pips = markupModel.markup.pips;
            this.fixedFee = fixedFee;
        }

    }

    public class PostMerchantModel
    {
        public string LykkeMerchantId { get; set; }
        public string LykkeMerchantSign { get; set; }
        public string LykkeMerchantSessionID { get; set; }

        public PostMerchantModel(string merchantId, string merchantSign, string MerchantSessionID)
        {
            LykkeMerchantId = merchantId;
            LykkeMerchantSign = merchantSign;
            LykkeMerchantSessionID = MerchantSessionID;
        }
    }
}
