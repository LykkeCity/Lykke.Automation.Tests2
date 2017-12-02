using LykkePay.Resources.AssetPairRates;
using LykkePay.Resources.GenerateAddress;
using LykkePay.Resources.GetBalance;
using LykkePay.Resources.Order;
using LykkePay.Resources.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsCore.ServiceSettings;

namespace LykkePay.Api
{
    public class LykkePayApi
    {
        public ServiceSettingsApi settings => new ServiceSettingsApi();
        public AssetPairRates assetPairRates => new AssetPairRates();
        public Purchase purchase => new Purchase();
        public GenerateAddress generateAddress => new GenerateAddress();
        public GetBalance getBalance => new GetBalance();
        public Order order => new Order();
    }
}
