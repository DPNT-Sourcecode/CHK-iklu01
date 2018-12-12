using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static Dictionary<char, DiscountedProduct> DiscountedProducts => new Dictionary<char, DiscountedProduct>
            {
                {
                    'A', new DiscountedProduct
                        {ProductQuantity = 3, Discount = 20}
                },
                {
                    'B', new DiscountedProduct
                        {ProductQuantity = 2, Discount = 15}
                }
            };

        public static Dictionary<char, int> CountProducts => new Dictionary<char, int>
        {
            {'A', 0 },
            {'B', 0 },
            {'C', 0 },
            {'D', 0 }
        };

        public static Dictionary<char, int> Prices => new Dictionary<char, int>
        {
            {'A', 50 },
            {'B', 30 },
            {'C', 20 },
            {'D', 15 }
        };

        public static bool IsProductDiscounted(string skus)
        {
            var arr = skus.ToCharArray(0, skus.Length);
            foreach (var c in arr)
            {
                return DiscountedProducts.ContainsKey(skus[c]);
            }

            return false;
        }

        public static bool IsProductAmountEnoughToGetDiscount(string skus)
        {
            var arr = skus.ToCharArray(0, skus.Length);
            foreach (var c in arr)
            {
                return DiscountedProducts.ContainsKey(skus[c]);
            }

            return false;
            
        }

        public static int GetProduct(string skus)
        {
            var priceToPay = 0;
            var arr = skus.ToCharArray(0, skus.Length);
            foreach (var c in arr)
            {
                CountProducts[c]++;
                priceToPay += Prices[c];
                if (IsProductDiscounted(skus)
                    && IsProductAmountEnoughToGetDiscount(skus))
                {
                    priceToPay -= DiscountedProducts[c].Discount;
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
