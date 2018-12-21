using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public class Product
    {
        public static Dictionary<char, int> ProductNumber = new Dictionary<char, int>();
        public static Dictionary<char, int> ProductPrice = new Dictionary<char, int>();

        public static void InitializeProductList()
        {
            for (var product = 'A'; product <= 'Z'; product++)
            {
                ProductNumber[product] = 0;
                ProductPrice[product] = 1;
            }
        }
    }
}
