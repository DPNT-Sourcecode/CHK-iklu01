using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class Discount
    {
        public static Dictionary<char, int> CountProducts(this string skus)
        {
            return skus.GroupBy(c => c).ToDictionary(group => group.Key, group => group.Count());
        }

        public static int GetOneKindProductsDiscount(int priceToPay, string skus)
        {
            var counts = skus.CountProducts();

            foreach (var count in counts)
            {
                if (count.Key == 'A' && count.Value > 2)
                {
                    if (count.Value % 8 <= 1)
                    {
                        priceToPay -= 70;
                    }

                    else if (count.Value % 5 <= 2)
                    {
                        priceToPay -= 50 * (count.Value / 5);
                    }

                    else if (count.Value % 3 <= 1)
                    {
                        priceToPay -= 20;
                    }
                }
                else if (count.Key == 'F' && count.Value > 2)
                {
                    if (count.Value % 3 <= 2)
                    {
                        priceToPay -= 10 * (count.Value / 3);
                    }
                }
                else if (count.Key == 'H' && count.Value > 4)
                {
                    if (count.Value >= 10)
                    {
                        if (count.Value % 5 == 0)
                        {
                            priceToPay -= 10 * (count.Value / 5);
                        }
                    }

                    else if (count.Value % 5 <= 4)
                    {
                        priceToPay -= 5;
                    }
                }
                else if (count.Key == 'K' && count.Value > 1)
                {
                    if (count.Value % 2 <= 1)
                    {
                        priceToPay -= 10 * (count.Value / 2);
                    }
                }
                else if (count.Key == 'P' && count.Value > 4)
                {
                    if (count.Value % 5 <= 4)
                    {
                        priceToPay -= 50 * (count.Value / 5);
                    }
                }
                else if (count.Key == 'Q' && count.Value > 2)
                {
                    if (count.Value % 3 <= 2)
                    {
                        priceToPay -= 10;
                    }
                }
                else if (count.Key == 'V' && count.Value > 1)
                {
                    if (count.Value % 3 <= 2)
                    {
                        priceToPay -= 20;
                    }
                    else if (count.Value % 2 <= 1)
                    {
                        priceToPay -= 10;
                    }
                }
                else if (count.Key == 'U' && count.Value > 3)
                {
                    if (count.Value % 4 <= 3)
                    {
                        priceToPay -= 40 * (count.Value / 4);
                    }
                }
                else if (count.Key == 'B' && count.Value > 1)
                {
                    if (count.Value % 2 <= 1)
                    {
                        priceToPay -= 15 * (count.Value / 2);
                    }
                }
            }

            return priceToPay;
        }

        public static int GetMultipleKindProductsDiscount(int priceToPay, string skus)
        {
            return priceToPay;
        }
    }
}
