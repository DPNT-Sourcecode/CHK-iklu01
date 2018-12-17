using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static Dictionary<char, int> CountProducts(this string skus) => skus.GroupBy(c => c)
            .ToDictionary(group => group.Key, group => group.Count());

        private static int _priceToPay;

        public static int GetProductPrice(string skus)
        {
            Product.AddProductNumer();
            Product.AddProductPrice();

            var skusToCharacter = skus.ToCharArray(0, skus.Length);

            foreach (var charachter in skusToCharacter)
            {
                Product.ProductNumber[charachter]++;
                _priceToPay += Product.ProductPrice[charachter];
            }

            return GetOneKindProductsDiscount(skus);
        }


        public static int GetOneKindProductsDiscount(string skus)
        {
            var counts = skus.CountProducts();

            foreach (var count in counts)
            {
                if (count.Key == 'A' && count.Value > 2)
                {
                    if (count.Value % 8 <= 1)
                    {
                        _priceToPay -= 70;
                    }

                    else if (count.Value % 5 <= 2)
                    {
                        _priceToPay -= 50 * (count.Value / 5);
                    }

                    else if (count.Value % 3 <= 1)
                    {
                        _priceToPay -= 20;
                    }
                }

                if (count.Key == 'F' && count.Value > 2)
                {
                    if (count.Value % 3 <= 2)
                    {
                        _priceToPay -= 10 * (count.Value / 3);
                    }
                }

                if (count.Key == 'H' && count.Value > 4)
                {
                    if (count.Value >= 10)
                    {
                        if (count.Value % 5 == 0)
                        {
                            _priceToPay -= 10 * (count.Value / 5);
                        }
                    }

                    else if (count.Value % 5 <= 4)
                    {
                        _priceToPay -= 5;
                    }
                }

                if (count.Key == 'K' && count.Value > 1)
                {
                    if (count.Value % 2 <= 1)
                    {
                        _priceToPay -= 10 * (count.Value / 2);
                    }
                }

                if (count.Key == 'P' && count.Value > 4)
                {
                    if (count.Value % 5 <= 4)
                    {
                        _priceToPay -= 50 * (count.Value / 5);
                    }
                }

                if (count.Key == 'Q' && count.Value > 2)
                {
                    if (count.Value % 3 <= 2)
                    {
                        _priceToPay -= 10;
                    }
                }

                if (count.Key == 'V' && count.Value > 1)
                {
                    if (count.Value % 3 <= 2)
                    {
                        _priceToPay -= 20;
                    }
                    else if (count.Value % 2 <= 1)
                    {
                        _priceToPay -= 10;
                    }
                }

                if (count.Key == 'U' && count.Value > 3)
                {
                    if (count.Value % 4 <= 3)
                    {
                        _priceToPay -= 40 * (count.Value / 4);
                    }
                }

                if (count.Key == 'B' && count.Value > 1)
                {
                    if (count.Value % 2 <= 1)
                    {
                        _priceToPay -= 15 * (count.Value / 2);
                    }
                }
            }

            return _priceToPay;
        }

        public static int GetMultipleKindProductsDiscount(string skus)
        {
            return _priceToPay;
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

            return GetProductPrice(skus);
        }
    }
}
