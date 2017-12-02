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
        public double percent { get; set; }
        public int pips { get; set; }
        public double fixedFee { get; set; }

        public PostMarkup(double percent, int pips, double fixedFee)
        {
            this.percent = percent;
            this.pips = pips;
            this.fixedFee = fixedFee;
        }

        public PostMarkup(MarkupModel markupModel, double fixedFee)
        {
            this.percent = markupModel.markup.percent;
            this.pips = markupModel.markup.pips;
            this.fixedFee = fixedFee;
        }
    }
}
