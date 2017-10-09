using LukkeAutomation.TestsCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukkeAutomation.Tests.Resourse1
{
    class SampleTests1Container
    {

        public class ResourseGetPositive : BaseTest
        {
            [Test]
            [Category("Resource1")]
            public void ResourseGetPositiveTest()
            {
                Console.WriteLine($"Test positive");
                Assert.That(true, Is.True, "True!");
            }
        }


        public class ResourseGetNegative : BaseTest
        {
            [Test]
            [Category("Resource1")]
            public void ResourseGetNegativeTest()
            {
                Console.WriteLine($"Test negative");
                Assert.That(true, Is.False, "False!");
            }
        }

    }
}
