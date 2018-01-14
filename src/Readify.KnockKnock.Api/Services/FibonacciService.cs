using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Readify.KnockKnock.Api.Services
{
    public class FibonacciService
    {
        public long GetNth(long n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return GetNth(n - 1) + GetNth(n - 2);
        }
    }
}
