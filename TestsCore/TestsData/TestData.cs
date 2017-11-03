using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsCore.TestsData
{
    public class TestData
    {
        private static Dictionary<string, string> Names()
        {
            Dictionary<string, string> Names = new Dictionary<string, string>();
            Names.Add("Han", "Solo");
            Names.Add("Lyke", "Skywalker");
            Names.Add("Anakin", "Skywalker");
            Names.Add("Coleman ", "Trebor");
            return Names;
        }

        public static KeyValuePair<string, string> FirstLastName()
        {
            Random r = new Random();
            return Names().ElementAt(r.Next(4));
        }

        public static string FullName()
        {
            Random r = new Random();
            int random = r.Next(4);
            return $"{Names().ElementAt(random).Key} {Names().ElementAt(random).Value}";
        }

        public static string GenerateString(int length) => Guid.NewGuid().ToString("n").Substring(0, length);

        public static string GenerateEmail() => $"lykke_autotest_{GenerateString(10)}@lykke.com";
    }
}
