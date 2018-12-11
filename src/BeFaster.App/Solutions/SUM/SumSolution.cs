using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.SUM
{
    public static class SumSolution
    {
        public static int Sum(int x, int y)
        {
            //- param[0] = a positive integer between 0-100
            // -param[1] = a positive integer between 0 - 100
            //- @return = an Integer representing the sum of the two numbers

            if (Enumerable.Range(0, 101).Contains(x)
                && Enumerable.Range(0, 101).Contains(y))
            {
                return x + y;
            }
            
            return -1;
        }
    }
}
