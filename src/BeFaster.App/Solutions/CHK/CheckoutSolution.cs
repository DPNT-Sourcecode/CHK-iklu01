using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        //public static Dictionary<char, int> Prices => new Dictionary<char, int>
        //{
        //    {'A', 50 },
        //    {'B', 30 },
        //    {'C', 20 },
        //    {'D', 15 },
        //    {'E', 40 },
        //    {'F', 10 }
        //};

        public static int GetProduct(string skus)
        {
            var priceToPay = 0;
            var skusToCharacter = skus.ToCharArray(0, skus.Length);
            var increaseProductNumber = new Dictionary<char, int>();
            var prices = new Dictionary<char, int>();

            for (var product = 'A'; product <= 'Z'; product++)
            {
                increaseProductNumber[product] = 0;
            }

            for (var product = 'A'; product <= 'Z'; product++)
            {
                switch (product)
                {
                    case 'F':
                    case 'H':
                    case 'O':
                    case 'Y':
                        prices[product] = 10;
                        break;
                    case 'D':
                    case 'M':
                        prices[product] = 15;
                        break;
                    case 'C':
                    case 'G':
                    case 'T':
                    case 'W':
                        prices[product] = 20;
                        break;
                    case 'B':
                    case 'Q':
                    case 'S':
                        prices[product] = 30;
                        break;
                    case 'I':
                        prices[product] = 35;
                        break;
                    case 'E':
                    case 'N':
                    case 'U':
                        prices[product] = 40;
                        break;
                    case 'A':
                    case 'P':
                    case 'R':
                    case 'V':
                    case 'Z':
                        prices[product] = 50;
                        break;
                    case 'J':
                        prices[product] = 60;
                        break;
                    case 'K':
                        prices[product] = 80;
                        break;
                    case 'L':
                    case 'X':
                        prices[product] = 90;
                        break;
                }
            }

            foreach (var charachter in skusToCharacter)
            {
                increaseProductNumber[charachter]++;
                priceToPay += prices[charachter];
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
