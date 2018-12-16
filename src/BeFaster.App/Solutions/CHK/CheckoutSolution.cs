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

        public static Dictionary<char, int> CountProducts(this string skus) => skus.GroupBy(c => c)
                .ToDictionary(group => group.Key, group => group.Count());

        public static int GetProduct(string skus)
        {
            var counts = skus.CountProducts();
            var priceToPay = 0;
            var arr = skus.ToCharArray(0, skus.Length);

            var increaseProductNumber = new Dictionary<char, int>
            {
                {'A', 0 },
                {'B', 0 },
                {'C', 0 },
                {'D', 0 },
                {'E', 0 }
            };

            var resultB = 0;
            var resultE = 0;
            var alreadyAdded = false;

            foreach (var c in arr)
            {
                increaseProductNumber[c]++;
                priceToPay += Prices[c];

                if (c == 'B')
                {
                    resultB++;
                }

                if (c == 'E')
                {
                    resultE++;
                }

                if (resultE > 1 && resultB > 0
                    && resultE % resultB == 0)
                {
                    priceToPay -= 30;
                    resultE -= 2;
                    alreadyAdded = true;
                }
            }

            foreach (var count in counts)
            {
                switch (count.Key)
                {
                    case 'A' when count.Value > 2:
                        if (count.Value < 6 && count.Value % 3 == 0
                            || count.Value < 6 && count.Value % 3 == 1)
                        {
                            priceToPay -= 20;
                        }

                        if (count.Value % 5 == 0
                            || count.Value % 5 == 1
                            || count.Value % 5 == 2)
                        {
                            priceToPay -= 50 * (count.Value / 5);
                        }

                        if (count.Value % 8 == 0
                            || count.Value % 8 == 1)
                        {
                            priceToPay -= 70;
                        }

                        break;
                }

                if (!alreadyAdded)
                {
                    if (count.Key == 'B' && count.Value > 1)
                    {
                        if (count.Value % 2 == 0
                            || count.Value % 2 == 1)
                        {
                            priceToPay -= 15 * (count.Value / 2);
                        }
                    }

                    if (count.Key == 'E' && count.Value > 2)
                    {
                        if (count.Value % 2 == 0)
                        {
                            priceToPay -= 30;
                        }
                    }
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
