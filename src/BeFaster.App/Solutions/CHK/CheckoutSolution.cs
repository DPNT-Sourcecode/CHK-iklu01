using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int GetProduct(string skus)
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

            //if (letterCounter > 2)
            //{
            //    if (letterCounter % 8 == 0
            //        || letterCounter % 8 == 1)
            //    {
            //        priceToPay -= 70;
            //    }

            //    else if (letterCounter % 5 == 0
            //        || letterCounter % 5 == 1
            //        || letterCounter % 5 == 2)
            //    {
            //        priceToPay -= 50 * (letterCounter / 5);
            //    }

            //    else if (letterCounter % 3 == 0
            //        || letterCounter % 3 == 1)
            //    {
            //        priceToPay -= 20;
            //    }
            //}

            //if (letterCounter > 1 && skus.Contains('B'))
            //{
            //    priceToPay -= 30 * (letterCounter / 2);

            //    if (letterCounter % 2 == 1)
            //    {
            //        priceToPay -= 15 * (letterCounter / 2);
            //    }
            //}

            //else if (letterCounter > 1)
            //{
            //    if (letterCounter % 2 == 0 
            //        || letterCounter % 2 == 1)
            //    {
            //        priceToPay -= 15 * (letterCounter / 2);
            //    }
            //}

            //if (letterCounter > 2 && skus.Contains('F'))
            //{
            //    if (letterCounter % 3 == 0 
            //        || letterCounter % 3 == 1 
            //        || letterCounter % 3 == 2)
            //    {
            //        priceToPay -= 10 * (letterCounter / 3);
            //    }
            //}

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
