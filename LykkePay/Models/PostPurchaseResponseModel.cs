using System;
using System.Collections.Generic;
using System.Text;

namespace LykkePay.Models
{
    public class PostPurchaseResponseModel
    {
        public string transferStatus { get; set; }
        public TransferResponse transferResponse { get; set; }
    }

    public class TransferResponse
    {
        public string currency { get; set; }
        public int timestamp { get; set; }
        public string settlement { get; set; }
        public string transactionId { get; set; }
    }
}
