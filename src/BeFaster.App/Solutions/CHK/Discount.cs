using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class Discount
    {
        public static int GetDiscountRate(string skus)
        {
            var products = skus.ToCharArray(0, skus.Length);
            var priceToPay = 0;

            if (skus.Length == 1)
            {
                foreach (var product in products)
                {
                    Product.ProductNumber[product]++;
                    priceToPay += Product.ProductPrice[product];
                }
                return priceToPay;
            }
            return GetDiscount(products, priceToPay, skus);
        }

        public static int GetDiscount(char[] products, int priceToPay, string skus)
        {
            var counts = skus.GroupBy(c => c).ToDictionary(group => group.Key, group => group.Count());
            int counterB = 0, counterE = 0, counterN = 0, counterQ = 0, counterR = 0;

            foreach (var product in products)
            {
                Product.ProductNumber[product]++;
                priceToPay += Product.ProductPrice[product];

                switch (product)
                {
                    case 'B': counterB++; break;
                    case 'E': counterE++; break;
                    case 'N': counterN++; break;
                    case 'Q': counterQ++; break;
                    case 'R': counterR++; break;
                }
            }

            if (skus.Length >= 3
                && Regex.IsMatch(skus, @"^[STXYZ]+$"))
            {
                var min = Product.ProductPrice.Select(item => Convert.ToDecimal(item.Value)).Min();

                if (skus.Length % 3 == 0)
                {
                    priceToPay = 45 * (skus.Length / 3);
                }
                else if (skus.Length % 3 <= 2)
                {
                    priceToPay = 45 * (skus.Length / 3) + Product.ProductPrice[products[(int) min]];
                }
            }

            if (skus.Contains('E')
                && skus.Contains('B')
                && counterE >= 2)
            {
                priceToPay -= 30 * (counterE / 2);
            }

            if (skus.Contains('N')
                && skus.Contains('M')
                && counterN >= 3)
            {
                priceToPay -= 15 * (counterN / 3);
            }

            if (skus.Contains('R')
                && skus.Contains('Q')
                && counterR >= 3)
            {
                priceToPay -= 30 * (counterR / 3);
            }

            foreach (var count in counts)
            {
                //if (count.Key == 'S'
                //    || count.Key == 'T'
                //    || count.Key == 'Y')
                //{
                //    if (count.Value < 3)
                //    {
                //        priceToPay -= 20;
                //    }

                //    if (count.Value >= 3)
                //    {
                //        priceToPay = 45 * (skus.Length / 3);
                //    }
                //}

                //else if (count.Key == 'X')
                //{
                //    priceToPay += 17;
                //}

                //else if (count.Key == 'Z')
                //{
                //    priceToPay += 21;
                //}

                if (counterB % 2 <= 1
                    && counterB > counterE)
                {
                    if (count.Key == 'B')
                    {
                        priceToPay -= 15 * (count.Value / 2);
                    }
                }

                if (count.Key == 'V')
                {
                    if (count.Value > 2)
                    {
                        if (count.Value % 5 == 0)
                        {
                            priceToPay -= 30 * (count.Value / 5);
                        }

                        else if (count.Value % 3 <= 2)
                        {
                            priceToPay -= 20 * (count.Value / 3);
                        }
                    }

                    else if (count.Value % 2 == 0)
                    {
                        priceToPay -= 10;
                    }
                }

                if (count.Value % 2 <= 1)
                {
                    if (count.Key == 'K')
                    {
                        priceToPay -= 20 * (count.Value / 2);
                    }
                }

                if (count.Value > 2)
                {
                    if (count.Value % 3 <= 2)
                    {
                        if (count.Key == 'F')
                        {
                            priceToPay -= 10 * (count.Value / 3);
                        }

                        if (count.Key == 'Q'
                            && counterQ > counterR)
                        {
                            priceToPay -= 10 * (count.Value / 3);
                        }
                    }

                    if (count.Key == 'A')
                    {
                        if (count.Value % 8 <= 1)
                        {
                            priceToPay -= 70;
                        }

                        else if (count.Value % 5 <= 2)
                        {
                            priceToPay -= 50 * (count.Value / 5);
                        }

                        else if (count.Value % 3 <= 1)
                        {
                            priceToPay -= 20;
                        }
                    }
                }

                if (count.Value > 3)
                {
                    //if (count.Key == 'U')
                    //{
                    //    if (count.Value % 4 <= 3)
                    //    {
                    //        priceToPay -= 40 * (count.Value / 4);
                    //    }
                    //}
                }

                if (count.Value > 4)
                {
                    if (count.Key == 'H')
                    {
                        if (count.Value >= 10
                            && count.Value % 10 <= 4)
                        {
                            priceToPay -= 10 * (count.Value / 5);
                        }

                        else if (count.Value >= 15)
                        {
                            priceToPay -= 25;
                        }

                        else if (count.Value >= 5
                                 && count.Value < 10)
                        {
                            priceToPay -= 5;
                        }
                    }

                    if (count.Key == 'P')
                    {
                        if (count.Value % 5 <= 4)
                        {
                            priceToPay -= 50 * (count.Value / 5);
                        }
                    }
                }
            }
            return priceToPay;
        }
    }
}
