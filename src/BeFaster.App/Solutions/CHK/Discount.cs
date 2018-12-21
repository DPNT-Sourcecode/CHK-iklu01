using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class Discount
    {
        public static Dictionary<char, int> CountProducts(this string skus)
        {
            return skus.GroupBy(c => c).ToDictionary(group => group.Key, group => group.Count());
        }

        public static int GetDiscountRate(string skus)
        {
            var skusToCharacter = skus.ToCharArray(0, skus.Length);
            var priceToPay = 0;

            if (skus.Length == 1)
            {
                foreach (var charachter in skusToCharacter)
                {
                    Product.ProductNumber[charachter]++;
                    priceToPay += Product.ProductPrice[charachter];
                }
            }

            if (skus.Length > 1)
            {
                if (skus.Distinct().Count() != 1)
                {
                    return GetMultipleKindProductsDiscount(priceToPay, skus);
                }

                if (skus.Distinct().Count() == 1)
                {
                    return GetOneKindProductsDiscount(priceToPay, skus);
                }
            }

            return priceToPay;
        }

        public static int GetOneKindProductsDiscount(int priceToPay, string skus)
        {
            var counts = skus.CountProducts();
            var skusToCharacter = skus.ToCharArray(0, skus.Length);

            foreach (var charachter in skusToCharacter)
            {
                Product.ProductNumber[charachter]++;
                priceToPay += Product.ProductPrice[charachter];
            }

            foreach (var count in counts)
            {
                if (count.Value % 2 <= 1)
                {
                    switch (count.Key)
                    {
                        case 'B':
                            priceToPay -= 15 * (count.Value / 2);
                            break;
                        case 'K':
                            priceToPay -= 10 * (count.Value / 2);
                            break;
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

                if (count.Value > 2)
                {
                    if (count.Value % 3 <= 2)
                    {
                        switch (count.Key)
                        {
                            case 'F':
                                priceToPay -= 10 * (count.Value / 3);
                                break;
                            case 'Q':
                                priceToPay -= 10 * (count.Value / 3);
                                break;
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
                    if (count.Key == 'U')
                    {
                        if (count.Value % 4 <= 3)
                        {
                            priceToPay -= 40 * (count.Value / 4);
                        }
                    }
                }

                if (count.Value > 4)
                {
                    switch (count.Key)
                    {
                        case 'H':
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

                            break;
                        case 'P':
                            if (count.Value % 5 <= 4)
                            {
                                priceToPay -= 50 * (count.Value / 5);
                            }

                            break;
                    }
                }
            }

            return priceToPay;
        }

        public static int GetMultipleKindProductsDiscount(int priceToPay, string skus)
        {
            var counts = skus.CountProducts();
            var skusToCharacter = skus.ToCharArray(0, skus.Length);

            foreach (var charachter in skusToCharacter)
            {
                Product.ProductNumber[charachter]++;
                priceToPay += Product.ProductPrice[charachter];
            }

            foreach (var count in counts)
            {
                switch (count.Key)
                {
                    case 'E' when count.Value > 1 && skus.Contains('B'):
                        {
                            priceToPay -= 30 * (count.Value / 2);
                            break;
                        }
                    case 'N' when count.Value > 2 && skus.Contains('M'):
                        priceToPay -= 15 * (count.Value / 3);
                        break;
                    case 'R' when count.Value > 2 && skus.Contains('Q'):
                        priceToPay -= 30 * (count.Value / 3);
                        break;
                }
            }
            return priceToPay;
        }
    }
}
