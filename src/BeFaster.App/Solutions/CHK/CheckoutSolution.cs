using System;
using System.Collections.Generic;

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

        public static int Checkout(string skus)
        {
            throw new NotImplementedException();
        }
    }
}



