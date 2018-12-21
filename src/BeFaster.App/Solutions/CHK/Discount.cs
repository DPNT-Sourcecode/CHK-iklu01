﻿using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class Discount
    {
        //public static Dictionary<char, int> ProductNumber = new Dictionary<char, int>();
        //public static Dictionary<char, int> ProductPrice = new Dictionary<char, int>();

        public static Dictionary<char, int> CountProducts(this string skus)
        {
            return skus.GroupBy(c => c).ToDictionary(group => group.Key, group => group.Count());
        }

        public static int GetDiscountRate(string skus)
        {
            var skusToCharacter = skus.ToCharArray(0, skus.Length);
            var priceToPay = 0;

            //if (skus.Length == 1)
            //{
            foreach (var product in skusToCharacter)
            {
                Product.ProductNumber[product]++;

                if (product == 'F' || product == 'H' || product == 'O' || product == 'Y')
                {
                    priceToPay += 10 * Product.ProductPrice[product];
                }
                else if (product == 'D' || product == 'M')
                {
                    priceToPay += 15 * Product.ProductPrice[product];
                }
                else if (product == 'C' || product == 'G' || product == 'T' || product == 'W')
                {
                    priceToPay += 20 * Product.ProductPrice[product];
                }
                else if (product == 'B' || product == 'Q' || product == 'S')
                {
                    priceToPay += 30 * Product.ProductPrice[product];
                }
                else if (product == 'I')
                {
                    priceToPay += 35 * Product.ProductPrice[product];
                }
                else if (product == 'E' || product == 'N' || product == 'U')
                {
                    priceToPay += 40 * Product.ProductPrice[product];
                }
                else if (product == 'A' || product == 'P' || product == 'R' || product == 'V' || product == 'Z')
                {
                    priceToPay += 50 * Product.ProductPrice[product];
                }
                else if (product == 'J')
                {
                    priceToPay += 60 * Product.ProductPrice[product];
                }
                else if (product == 'K')
                {
                    priceToPay += 80 * Product.ProductPrice[product];
                }
                else if (product == 'L' || product == 'X')
                {
                    priceToPay += 90 * Product.ProductPrice[product];
                }
            }

            //if (skus.Length > 1)
            //{
            //    if (skus.Distinct().Count() != 1)
            //    {
            //        return GetMultipleKindProductsDiscount(priceToPay, skus);
            //    }

            //    if (skus.Distinct().Count() == 1)
            //    {
            //        return GetOneKindProductsDiscount(priceToPay, skus);
            //    }
            //}

            return priceToPay;
        }

        //    public static int GetOneKindProductsDiscount(int priceToPay, string skus)
        //    {
        //        var counts = skus.CountProducts();
        //        var skusToCharacter = skus.ToCharArray(0, skus.Length);

        //        foreach (var charachter in skusToCharacter)
        //        {
        //            Product.ProductNumber[charachter]++;
        //            priceToPay += Product.ProductPrice[charachter];
        //        }

        //        foreach (var count in counts)
        //        {
        //            if (count.Value % 2 <= 1)
        //            {
        //                if (count.Key == 'B')
        //                {
        //                    priceToPay -= 15 * (count.Value / 2);
        //                }
        //                else if (count.Key == 'K')
        //                {
        //                    priceToPay -= 10 * (count.Value / 2);
        //                }
        //            }

        //            if (count.Key == 'V')
        //            {
        //                if (count.Value > 2)
        //                {
        //                    if (count.Value % 5 == 0)
        //                    {
        //                        priceToPay -= 30 * (count.Value / 5);
        //                    }

        //                    else if (count.Value % 3 <= 2)
        //                    {
        //                        priceToPay -= 20 * (count.Value / 3);
        //                    }
        //                }

        //                else if (count.Value % 2 == 0)
        //                {
        //                    priceToPay -= 10;
        //                }
        //            }

        //            if (count.Value > 2)
        //            {
        //                if (count.Value % 3 <= 2)
        //                {
        //                    if (count.Key == 'F')
        //                    {
        //                        priceToPay -= 10 * (count.Value / 3);
        //                    }
        //                    else if (count.Key == 'Q')
        //                    {
        //                        priceToPay -= 10 * (count.Value / 3);
        //                    }
        //                }

        //                if (count.Key == 'A')
        //                {
        //                    if (count.Value % 8 <= 1)
        //                    {
        //                        priceToPay -= 70;
        //                    }

        //                    else if (count.Value % 5 <= 2)
        //                    {
        //                        priceToPay -= 50 * (count.Value / 5);
        //                    }

        //                    else if (count.Value % 3 <= 1)
        //                    {
        //                        priceToPay -= 20;
        //                    }
        //                }
        //            }

        //            if (count.Value > 3)
        //            {
        //                if (count.Key == 'U')
        //                {
        //                    if (count.Value % 4 <= 3)
        //                    {
        //                        priceToPay -= 40 * (count.Value / 4);
        //                    }
        //                }
        //            }

        //            if (count.Value > 4)
        //            {
        //                switch (count.Key)
        //                {
        //                    case 'H':
        //                        if (count.Value >= 10
        //                            && count.Value % 10 <= 4)
        //                        {
        //                            priceToPay -= 10 * (count.Value / 5);
        //                        }

        //                        else if (count.Value >= 15)
        //                        {
        //                            priceToPay -= 25;
        //                        }

        //                        else if (count.Value >= 5
        //                                 && count.Value < 10)
        //                        {
        //                            priceToPay -= 5;
        //                        }

        //                        break;
        //                    case 'P':
        //                        if (count.Value % 5 <= 4)
        //                        {
        //                            priceToPay -= 50 * (count.Value / 5);
        //                        }

        //                        break;
        //                }
        //            }
        //        }

        //        return priceToPay;
        //    }

        //    public static int GetMultipleKindProductsDiscount(int priceToPay, string skus)
        //    {
        //        var counts = skus.CountProducts();
        //        var skusToCharacter = skus.ToCharArray(0, skus.Length);

        //        foreach (var charachter in skusToCharacter)
        //        {
        //            Product.ProductNumber[charachter]++;
        //            priceToPay += Product.ProductPrice[charachter];
        //        }

        //        foreach (var count in counts)
        //        {
        //            if (count.Key == 'E' 
        //                && count.Value > 1)
        //            {
        //                priceToPay -= 30 * (count.Value / 2);
        //            }
        //            else if (count.Key == 'N' && (count.Value > 2 && skus.Contains('M')))
        //            {
        //                priceToPay -= 15 * (count.Value / 3);
        //            }
        //            else if (count.Key == 'R' && (count.Value > 2 && skus.Contains('Q')))
        //            {
        //                priceToPay -= 30 * (count.Value / 3);
        //            }
        //        }
        //        return priceToPay;
        //    }
    }
}
