﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static Dictionary<string, DiscountedProduct> DiscountedProducts => new Dictionary<string, DiscountedProduct>
            {
                {
                    "A", new DiscountedProduct
                        {ProductQuantity = 3, Discount = 20}
                },
                {
                    "B", new DiscountedProduct
                        {ProductQuantity = 2, Discount = 15}
                }
            };

        public static Dictionary<string, int> CountProducts => new Dictionary<string, int>
        {
            {"A", 0 },
            {"B", 0 },
            {"C", 0 },
            {"D", 0 }
        };

        public static Dictionary<string, int> Prices => new Dictionary<string, int>
        {
            {"A", 50 },
            {"B", 30 },
            {"C", 20 },
            {"D", 15 }
        };

        public static bool IsProductDiscounted(string skus)
        {
            return DiscountedProducts.ContainsKey(skus);
        }

        public static bool IsProductAmountEnoughToGetDiscount(string skus)
        {
            return CountProducts[skus] == DiscountedProducts[skus].ProductQuantity;
        }

        public static int GetProduct(string skus)
        {
            var priceToPay = 0;
            if (skus == "AxA")
            {
                CountProducts[skus]++;
                priceToPay += Prices[skus];
                if (IsProductDiscounted(skus)
                    && IsProductAmountEnoughToGetDiscount(skus))
                {
                    priceToPay -= DiscountedProducts[skus].Discount;
                }
            }
            return priceToPay;
        }
        public static int Checkout(string skus)
        {
            if (!Regex.IsMatch(skus, @"^[A-Z]+$"))
            {
                return -1;
            }
            return GetProduct(skus);
        }
    }
}
