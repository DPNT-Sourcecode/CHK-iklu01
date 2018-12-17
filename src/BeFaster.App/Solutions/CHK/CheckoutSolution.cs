using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static Dictionary<char, int> CountProducts(this string skus) => skus.GroupBy(c => c)
            .ToDictionary(group => group.Key, group => group.Count());

        public static int CountLetters(string skus, char countableLetter)
        {
            var letters = skus.Count(x => x == countableLetter);
            return letters;
        }

        public static int GetProduct(string skus)
        {
            Product.AddProductNumer();
            Product.AddProductPrice();

            var priceToPay = 0;
            var counts = skus.CountProducts();
            var skusToCharacter = skus.ToCharArray(0, skus.Length);
            var productCounter = 0;

            foreach (var charachter in skusToCharacter)
            {
                Product.ProductNumber[charachter]++;
                priceToPay += Product.ProductPrice[charachter];
            }

            foreach (var count in counts)
            {
                productCounter = skus.Count(x => x == count.Key);
            }

            if (skus.Contains('A') && productCounter > 2)
            {
                if (productCounter % 8 <= 1)
                {
                    priceToPay -= 70;
                }

                else if (productCounter % 5 <= 2)
                {
                    priceToPay -= 50 * (productCounter / 5);
                }

                else if (productCounter % 3 <= 1)
                {
                    priceToPay -= 20;
                }
            }

            if (skus.Contains('E') && productCounter > 1)
            {
                priceToPay -= 30 * (productCounter / 2);

                if (skus.Contains('B') && productCounter % 2 == 1)
                {
                    priceToPay -= 15 * (productCounter / 2);
                }
            }

            if (skus.Contains('F') && productCounter > 2)
            {
                if (productCounter % 3 <= 2)
                {
                    priceToPay -= 10 * (productCounter / 3);
                }
            }

            if (skus.Contains('H') && productCounter > 4)
            {
                if (productCounter >= 10)
                {
                    if (productCounter % 5 == 0)
                    {
                        priceToPay -= 10 * (productCounter / 5);
                    }
                }

                else if (productCounter % 5 <= 4)
                {
                    priceToPay -= 5;
                }
            }

            if (skus.Contains('K') && productCounter > 1)
            {
                if (productCounter % 2 <= 1)
                {
                    priceToPay -= 10 * (productCounter / 2);
                }
            }

            if (skus.Contains('P') && productCounter > 4)
            {
                if (productCounter % 5 <= 4)
                {
                    priceToPay -= 50 * (productCounter / 5);
                }
            }

            if (skus.Contains('Q') && productCounter > 2)
            {
                if (productCounter % 3 <= 2)
                {
                    priceToPay -= 10;
                }
            }

            if (skus.Contains('V') && productCounter > 1)
            {
                if (productCounter % 3 <= 2)
                {
                    priceToPay -= 20;
                }
                else if (productCounter % 2 <= 1)
                {
                    priceToPay -= 10;
                }
            }

            if (skus.Contains('U') && productCounter > 3)
            {
                if (productCounter % 4 <= 3)
                {
                    priceToPay -= 40 * (productCounter / 4);
                }
            }

            else if (skus.Contains('B') && productCounter > 1)
            {
                if (productCounter % 2 <= 1)
                {
                    priceToPay -= 15 * (productCounter / 2);
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

