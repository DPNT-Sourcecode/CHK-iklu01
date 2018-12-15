using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        //public static Dictionary<char, DiscountedProduct> DiscountedProducts => new Dictionary<char, DiscountedProduct>
        //{
        //    {
        //        'A', new DiscountedProduct
        //            {ProductQuantity = 3, Discount = 20}
        //    },
        //    {
        //        'B', new DiscountedProduct
        //            {ProductQuantity = 2, Discount = 15}
        //    },
        //    {
        //        'E', new DiscountedProduct
        //            {ProductQuantity = 2, Discount = 30}
        //    }
        //};

        public static Dictionary<char, int> Prices => new Dictionary<char, int>
        {
            {'A', 50 },
            {'B', 30 },
            {'C', 20 },
            {'D', 15 },
            {'E', 40 }
        };

        public static Dictionary<char, int> CountProducts(this string skus)
        {
            return skus.GroupBy(c => c)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        public static int GetProduct(string skus)
        {
            var counts = skus.CountProducts();
            var priceToPay = 0;
            var arr = skus.ToCharArray(0, skus.Length);

            var countProducts = new Dictionary<char, int>
            {
                {'A', 0 },
                {'B', 0 },
                {'C', 0 },
                {'D', 0 },
                {'E', 0 }
            };

            foreach (var c in arr)
            {
                countProducts[c]++;
                priceToPay += Prices[c];
            }

            foreach (var count in counts)
            {
                if (count.Key == 'A')
                {
                    if (count.Value % 3 == 0
                        || count.Value % 3 == 1)
                    {
                        priceToPay -= 20;
                    }

                    if (count.Value % 5 == 0
                        || count.Value % 5 == 1)
                    {
                        priceToPay -= 50;
                    }
                }

                if (count.Key == 'B')
                {
                    if (count.Value % 2 == 0)
                    {
                        priceToPay -= 15;
                    }
                }

                if (count.Key == 'E')
                {
                    if (count.Value % 2 == 0)
                    {
                        priceToPay -= 30;
                    }
                }
            }

            //return priceToPay;

            //foreach (var c in arr)
            //{
            //    countProducts[c]++;
            //    priceToPay += Prices[c];



            //    if (countProducts[c] % 3 == 0)
            //    {
            //        priceToPay -= 20;
            //    }

            //    if (countProducts[c] % 5 == 0)
            //    {
            //        priceToPay -= 50;
            //    }

            //    if (discountedProducts.ContainsKey(c))
            //    {
            //        if (counts[c] > 4
            //            && countProducts[c] % 5 == 0
            //            || counts[c] > 8
            //            && countProducts[c] % 5 == 0
            //            || counts[c] > 8
            //            && countProducts[c] % 5 == 1)
            //        {
            //            priceToPay -= 50;
            //        }

            //        if (counts[c] <= 4
            //            && countProducts[c] % 3 == 0
            //            || counts[c] == 8
            //            && countProducts[c] % 8 == 0)
            //        {
            //            priceToPay -= discountedProducts[c].Discount;
            //        }

            //        if (counts[c] >= 5 && counts[c] <= 7
            //            && countProducts[c] % 5 == 0
            //            )
            //        {
            //            priceToPay -= 50;
            //        }

            //        if (counts[c] <= 4
            //            && countProducts[c] % 3 == 0
            //            )
            //        {
            //            priceToPay -= discountedProducts[c].Discount;
            //        }

            //        if (counts[c] >= 8 && counts[c] < 10
            //            && countProducts[c] % 5 == 0
            //            || counts[c] >= 8 && counts[c] < 10
            //            && countProducts[c] % 3 == 0
            //        )
            //        {
            //            priceToPay -= 70;
            //        }

            //        if (counts[c] >= 8 && counts[c] <= 10
            //            && countProducts[c] % 5 == 0
            //            || counts[c] >= 8 && counts[c] <= 10
            //            && countProducts[c] % 3 == 0
            //        )
            //        {
            //            priceToPay -= 70;
            //        }
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
