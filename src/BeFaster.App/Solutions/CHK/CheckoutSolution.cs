using System.Linq;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int GetProductPrice(string skus)
        {
            Product.AddProductNumer();
            Product.AddProductPrice();
            var priceToPay = 0;

            var skusToCharacter = skus.ToCharArray(0, skus.Length);

            foreach (var charachter in skusToCharacter)
            {
                Product.ProductNumber[charachter]++;
                priceToPay += Product.ProductPrice[charachter];
            }

            if (skus.Length > 1)
            {
                if (skus.Distinct().Any())
                {
                    Discount.GetOneKindProductsDiscount(priceToPay, skus);
                }
                Discount.GetMultipleKindProductsDiscount(priceToPay, skus);
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

            return GetProductPrice(skus);
        }
    }
}
