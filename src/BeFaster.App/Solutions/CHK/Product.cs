using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public class Product
    {
        public static Dictionary<char,int> ProductNumber { get; set; }
        public static Dictionary<char,int> ProductPrice { get; set; }

        public static void AddProductNumer()
        {
            for (var product = 'A'; product <= 'Z'; product++)
            {
                ProductNumber[product] = 0;
            }
        }

        public static void AddProductPrice()
        {
            for (var product = 'A'; product <= 'Z'; product++)
            {
                switch (product)
                {
                    case 'F':
                    case 'H':
                    case 'O':
                    case 'Y':
                        ProductPrice[product] = 10;
                        break;
                    case 'D':
                    case 'M':
                        ProductPrice[product] = 15;
                        break;
                    case 'C':
                    case 'G':
                    case 'T':
                    case 'W':
                        ProductPrice[product] = 20;
                        break;
                    case 'B':
                    case 'Q':
                    case 'S':
                        ProductPrice[product] = 30;
                        break;
                    case 'I':
                        ProductPrice[product] = 35;
                        break;
                    case 'E':
                    case 'N':
                    case 'U':
                        ProductPrice[product] = 40;
                        break;
                    case 'A':
                    case 'P':
                    case 'R':
                    case 'V':
                    case 'Z':
                        ProductPrice[product] = 50;
                        break;
                    case 'J':
                        ProductPrice[product] = 60;
                        break;
                    case 'K':
                        ProductPrice[product] = 80;
                        break;
                    case 'L':
                    case 'X':
                        ProductPrice[product] = 90;
                        break;
                }
            }
        }
    }
}
