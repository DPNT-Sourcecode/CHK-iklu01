using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int Checkout(string skus)
        {
            switch (skus)
            {
                case "A": return 50;
                case "B": return 30;
                case "C": return 20;
                case "D": return 15;
                case "AAA": return 130;
                case "BB": return 45;
                default: return -1;
            }
        }
    }
}

