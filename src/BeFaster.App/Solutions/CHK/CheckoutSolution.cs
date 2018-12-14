using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        //public static Dictionary<char, DiscountedProduct> DiscountedProducts => new Dictionary<char, DiscountedProduct>
        //{
        //    {
        //        'A', new DiscountedProduct
        //            {ProductQuantity = 3, Discount = 20}
        //    },
        //    {
        //        'B', new DiscountedProduct
        //            {ProductQuantity = 2, Discount = 15}
        //    },
        //    {
        //        'E', new DiscountedProduct
        //            {ProductQuantity = 2, Discount = 30}
        //    }
        //};

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

            var countProducts = new Dictionary<char, int>
            {
                {'A', 0 },
                {'B', 0 },
                {'C', 0 },
                {'D', 0 },
                {'E', 0 }
            };

            var discountedProducts = new Dictionary<char, DiscountedProduct>
            {
                {
                    'A', new DiscountedProduct
                        {ProductQuantity = 3, Discount = 20}
                },
                {
                    'B', new DiscountedProduct
                        {ProductQuantity = 2, Discount = 15}
                },
                {
                    'E', new DiscountedProduct
                        {ProductQuantity = 2, Discount = 30}
                }
            };

            foreach (var c in arr)
            {
                countProducts[c]++;
                priceToPay += Prices[c];

                if (discountedProducts.ContainsKey(c))
                {
                    if (countProducts[c] < 5 && countProducts[c] % discountedProducts[c].ProductQuantity == 0)
                    {
                        priceToPay -= discountedProducts[c].Discount;
                    }

                    if (countProducts[c] == 5 && countProducts[c] % discountedProducts[c].ProductQuantity == 0)
                    {
                        priceToPay -= 50;
                    }

                    if (countProducts[c] == 5 && countProducts[c] % discountedProducts[c].ProductQuantity == 2)
                    {
                        priceToPay -= 30;
                    }

                    if (countProducts[c] == 8 && countProducts[c] % discountedProducts[c].ProductQuantity == 2)
                    {
                        priceToPay -= 20;
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
