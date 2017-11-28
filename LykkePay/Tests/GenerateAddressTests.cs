using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace LykkePay.Tests
{
    public class GenerateAddressTests
    {
        public class GetGenerateAddress : BaseTest
        {
            [Test]
            [Category("LykkePay")]
            public void GetGenerateAddressTest()
            {
                var r = lykkePayApi.generateAddress.GetGenerateAddress("BTC");
            }
        }
    }
}
