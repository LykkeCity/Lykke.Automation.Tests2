using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukkeAutomation.TestsCore
{
    class BaseTest
    {

        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("SetUp");
        }



        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("TearDown");
        }

    }
}
