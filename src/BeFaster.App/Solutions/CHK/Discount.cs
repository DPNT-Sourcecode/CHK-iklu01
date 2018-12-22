namespace BeFaster.App.Solutions.CHK
{
    public static class Discount
    {
        public static int GetBasePrice(string skus)
        {
            Product.InitializeProductList();
            var productCounter = skus.ToCharArray(0, skus.Length);
            var priceToPay = 0;

            foreach (var product in productCounter)
            {
                Product.ProductNumber[product]++;

                switch (product)
                {
                    case 'F':
                    case 'H':
                    case 'O':
                    case 'Y':
                        priceToPay += 10 * Product.ProductPrice[product];
                        break;
                    case 'D':
                    case 'M':
                        priceToPay += 15 * Product.ProductPrice[product];
                        break;
                    case 'C':
                    case 'G':
                    case 'T':
                    case 'W':
                        priceToPay += 20 * Product.ProductPrice[product];
                        break;
                    case 'B':
                    case 'Q':
                    case 'S':
                        priceToPay += 30 * Product.ProductPrice[product];
                        break;
                    case 'I':
                        priceToPay += 35 * Product.ProductPrice[product];
                        break;
                    case 'E':
                    case 'N':
                    case 'U':
                        priceToPay += 40 * Product.ProductPrice[product];
                        break;
                    case 'A':
                    case 'P':
                    case 'R':
                    case 'V':
                    case 'Z':
                        priceToPay += 50 * Product.ProductPrice[product];
                        break;
                    case 'J':
                        priceToPay += 60 * Product.ProductPrice[product];
                        break;
                    case 'K':
                        priceToPay += 80 * Product.ProductPrice[product];
                        break;
                    case 'L':
                    case 'X':
                        priceToPay += 90 * Product.ProductPrice[product];
                        break;
                }
            }

            return GetDiscount(productCounter, skus, priceToPay);
        }

        public static int GetDiscount(char[] productCounter, string skus, int priceToPay)
        {
            int counterA = 0, counterB = 0, counterE = 0, counterF = 0, counterH = 0, counterK = 0, counterM = 0,
                counterN = 0, counterP = 0, counterQ = 0, counterR = 0, counterU = 0, counterV = 0;

            foreach (var product in productCounter)
            {
                switch (product)
                {
                    case 'A':
                        counterA++;
                        break;
                    case 'B':
                        counterB++;
                        break;
                    case 'E':
                        counterE++;
                        break;
                    case 'F':
                        counterF++;
                        break;
                    case 'H':
                        counterH++;
                        break;
                    case 'K':
                        counterK++;
                        break;
                    case 'M':
                        counterM++;
                        break;
                    case 'N':
                        counterN++;
                        break;
                    case 'P':
                        counterP++;
                        break;
                    case 'Q':
                        counterQ++;
                        break;
                    case 'R':
                        counterU++;
                        break;
                    case 'U':
                        counterU++;
                        break;
                    case 'V':
                        counterV++;
                        break;
                }
            }
            //foreach (var product in skus.GroupBy(c => c))
            //{
            //    if (product.Key == 'A' && product.Count() % 3 <= 1)
            //    {
            //        priceToPay -= 20;
            //    }

            //    if (product.Key == 'B' && product.Count() % 2 == 0)
            //    {
            //        priceToPay -= 15;
            //    }

            //    if (product.Key == 'F' && product.Count() % 2 == 0
            //        || product.Key == 'K' && product.Count() % 2 == 0
            //        || product.Key == 'V' && product.Count() % 2 == 0)
            //    {
            //        priceToPay -= 10;
            //    }

            //    if (product.Key == 'P' && product.Count() % 5 == 0)
            //    {
            //        priceToPay -= 15;
            //    }

            //    if (product.Key == 'Q' && product.Count() % 3 == 0)
            //    {
            //        priceToPay -= 10;
            //    }

            //    if (product.Key == 'U' && product.Count() % 4 == 0)
            //    {
            //        priceToPay -= 40;
            //    }
            //}

            return priceToPay;
        }
    }
}
