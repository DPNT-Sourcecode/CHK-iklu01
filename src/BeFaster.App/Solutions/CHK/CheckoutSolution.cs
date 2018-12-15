using System.Collections.Generic;
using System.Linq;
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
        public static Dictionary<char, int> CountProducts(this string skus)
        {
            return skus.GroupBy(c => c)
                .OrderBy(c => c.Key)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        public static int GetProduct(string skus)
        {
            var counts = skus.CountProducts();
            var priceToPay = 0;
            var arr = skus.ToCharArray(0, skus.Length);

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

            var countProducts = new Dictionary<char, int>
            {
                {'A', 0 },
                {'B', 0 },
                {'C', 0 },
                {'D', 0 },
                {'E', 0 }
            };

            foreach (var c in arr)
            {
                countProducts[c]++;
                priceToPay += Prices[c];

                if (discountedProducts.ContainsKey(c))
                {
                    if (counts[c] > 4 
                        && countProducts[c] % 5 == 0
                        || counts[c] > 9 
                        && countProducts[c] % 5 == 0)
                    {
                        priceToPay -= 50;
                    }

                    if (counts[c] <= 4 
                        && countProducts[c] % 3 == 0
                        || counts[c] == 8 
                        && countProducts[c] % 8 == 0)
                    {
                        priceToPay -= discountedProducts[c].Discount;
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
