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

        public static int GetOneKindProductsDiscount(string skus)
        {
            var counts = skus.CountProducts();
            var skusToCharacter = skus.ToCharArray(0, skus.Length);

            foreach (var charachter in skusToCharacter)
            {
                Product.ProductNumber[charachter]++;
                CheckoutSolution.priceToPay += Product.ProductPrice[charachter];
            }

            foreach (var count in counts)
            {
                if (count.Key == 'A' && count.Value > 2)
                {
                    if (count.Value % 8 <= 1)
                    {
                        CheckoutSolution.priceToPay -= 70;
                    }

                    else if (count.Value % 5 <= 2)
                    {
                        CheckoutSolution.priceToPay -= 50 * (count.Value / 5);
                    }

                    else if (count.Value % 3 <= 1)
                    {
                        CheckoutSolution.priceToPay -= 20;
                    }
                }
                else if (count.Key == 'F' && count.Value > 2)
                {
                    if (count.Value % 3 <= 2)
                    {
                        CheckoutSolution.priceToPay -= 10 * (count.Value / 3);
                    }
                }
                else if (count.Key == 'H' && count.Value > 4)
                {
                    if (count.Value >= 10)
                    {
                        if (count.Value % 5 == 0)
                        {
                            CheckoutSolution.priceToPay -= 10 * (count.Value / 5);
                        }
                    }

                    else if (count.Value % 5 <= 4)
                    {
                        CheckoutSolution.priceToPay -= 5;
                    }
                }
                else if (count.Key == 'K' && count.Value > 1)
                {
                    if (count.Value % 2 <= 1)
                    {
                        CheckoutSolution.priceToPay -= 10 * (count.Value / 2);
                    }
                }
                else if (count.Key == 'P' && count.Value > 4)
                {
                    if (count.Value % 5 <= 4)
                    {
                        CheckoutSolution.priceToPay -= 50 * (count.Value / 5);
                    }
                }
                else if (count.Key == 'Q' && count.Value > 2)
                {
                    if (count.Value % 3 <= 2)
                    {
                        CheckoutSolution.priceToPay -= 10;
                    }
                }
                else if (count.Key == 'V' && count.Value > 1)
                {
                    if (count.Value % 3 <= 2)
                    {
                        CheckoutSolution.priceToPay -= 20;
                    }
                    else if (count.Value % 2 <= 1)
                    {
                        CheckoutSolution.priceToPay -= 10;
                    }
                }
                else if (count.Key == 'U' && count.Value > 3)
                {
                    if (count.Value % 4 <= 3)
                    {
                        CheckoutSolution.priceToPay -= 40 * (count.Value / 4);
                    }
                }
                else if (count.Key == 'B' && count.Value > 1)
                {
                    if (count.Value % 2 <= 1)
                    {
                        CheckoutSolution.priceToPay -= 15 * (count.Value / 2);
                    }
                }
            }

            return CheckoutSolution.priceToPay;
        }

        public static int GetMultipleKindProductsDiscount(string skus)
        {
            var priceToPay = 0;
            return priceToPay;
        }
    }
}
