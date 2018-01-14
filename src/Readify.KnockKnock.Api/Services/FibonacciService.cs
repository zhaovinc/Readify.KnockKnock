using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Readify.KnockKnock.Api.Services
{
    public class FibonacciService : IFibonacciService
    {
        public long GetNth(long n)
        {
            if (n <= 0)
            {
                throw new ApplicationException("Invalid Value");
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            long x = 1, y = 1;
            for (long i = 3; i <= n; i++)
            {
                // will throw OverFlowException if it's too big
                y = checked(x + y);
                x = y - x;
            }

            return y;
        }
    }
}
