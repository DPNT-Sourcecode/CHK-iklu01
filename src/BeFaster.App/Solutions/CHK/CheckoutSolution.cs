using System;
using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static Dictionary<string, DiscountedProduct> DiscountedProducts() => new Dictionary<string, DiscountedProduct>
            {
                {
                    "A", new DiscountedProduct
                        {ProductQuantity = 3, Discount = 20}
                },
                {
                    "B", new DiscountedProduct
                        {ProductQuantity = 3, Discount = 20}
                },

            };
        public static int Checkout(string skus)
        {
            throw new NotImplementedException();
        }
    }
}

