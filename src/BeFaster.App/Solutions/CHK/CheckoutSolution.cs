using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static Dictionary<char, int> Prices => new Dictionary<char, int>
        {
            {'A', 50 },
            {'B', 30 },
            {'C', 20 },
            {'D', 15 },
            {'E', 40 }
        };

        public static int GetProduct(string skus)
        {
            var priceToPay = 0;
            var arr = skus.ToCharArray(0, skus.Length);

            var countA = skus.Count(x => x == 'A');
            var countB = skus.Count(x => x == 'B');
            var countE = skus.Count(x => x == 'E');

            var increaseProductNumber = new Dictionary<char, int>
            {
                {'A', 0 },
                {'B', 0 },
                {'C', 0 },
                {'D', 0 },
                {'E', 0 }
            };

            foreach (var c in arr)
            {
                increaseProductNumber[c]++;
                priceToPay += Prices[c];
            }

            if (countA > 2)
            {
                if (countA % 8 == 0
                    || countA % 8 == 1)
                {
                    priceToPay -= 70;
                }

                else if (countA % 5 == 0
                    || countA % 5 == 1
                    || countA % 5 == 2)
                {
                    priceToPay -= 50 * (countA / 5);
                }

                else if (countA % 3 == 0
                    || countA % 3 == 1)
                {
                    priceToPay -= 20;
                }
            }

            if (countE > 1 && skus.Contains('B'))
            {
                priceToPay -= 30 * (countE / 2);

                switch (countB % 2)
                {
                    case 0:
                    case 1:
                        priceToPay -= 15 * (countB / 2);
                        break;
                }
            }

            else if (countB > 1)
            {
                switch (countB % 2)
                {
                    case 0:
                    case 1:
                        priceToPay -= 15 * (countB / 2);
                        break;
                }
            }

            return priceToPay;
        }

        public static int Checkout(string skus)
        {
            if (string.IsNullOrEmpty(skus))
            {
                return 0;
            }

            if (!Regex.IsMatch(skus, @"^[A-Z]+$"))
            {
                return -1;
            }

            return GetProduct(skus);
        }
    }
}
