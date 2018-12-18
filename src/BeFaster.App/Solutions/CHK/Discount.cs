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

        public static int GetDiscountRate(string skus)
        {
            var skusToCharacter = skus.ToCharArray(0, skus.Length);
            var priceToPay = 0;

            if (skus.Length == 1)
            {
                foreach (var charachter in skusToCharacter)
                {
                    Product.ProductNumber[charachter]++;
                    priceToPay += Product.ProductPrice[charachter];
                }
            }

            if (skus.Length > 1 && !skus.Distinct().Any())
            {
                return GetMultipleKindProductsDiscount(priceToPay, skus);

            }

            if (skus.Length > 1 && skus.Distinct().Any())
            {
                return GetOneKindProductsDiscount(priceToPay, skus);
            }

            return priceToPay;
        }

        public static int GetOneKindProductsDiscount(int priceToPay, string skus)
        {
            var counts = skus.CountProducts();
            var skusToCharacter = skus.ToCharArray(0, skus.Length);

            foreach (var charachter in skusToCharacter)
            {
                Product.ProductNumber[charachter]++;
                priceToPay += Product.ProductPrice[charachter];
            }

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
                else if (count.Key == 'B' && count.Value > 1)
                {
                    if (count.Value % 2 <= 1)
                    {
                        priceToPay -= 15 * (count.Value / 2);
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
                else if (count.Key == 'U' && count.Value > 3)
                {
                    if (count.Value % 4 <= 3)
                    {
                        priceToPay -= 40 * (count.Value / 4);
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
            }

            return priceToPay;
        }

        public static int GetMultipleKindProductsDiscount(int priceToPay, string skus)
        {
            var counts = skus.CountProducts();
            var skusToCharacter = skus.ToCharArray(0, skus.Length);

            foreach (var charachter in skusToCharacter)
            {
                Product.ProductNumber[charachter]++;
                priceToPay += Product.ProductPrice[charachter];
            }

            foreach (var count in counts)
            {
                if (count.Key == 'E'
                    && count.Value > 1
                    && skus.Contains('B'))
                {
                    priceToPay -= 30 * (count.Value / 2);
                }
            }
            return priceToPay;
        }
    }
}
