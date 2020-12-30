using System;
using System.Collections;
using System.Collections.Generic;

namespace Ishiika.Library
{
    public static class IshiikaMath
    {
        //Naive, does not use a sieve but still pretty fast
        public static IEnumerable<int> GeneratePrimes(int UpperLimit)
        {
            //No primes before 2.
            if (UpperLimit < 2)
            {
                yield break;
            }

            //First prime
            yield return 2;

            if (UpperLimit == 2)
            {
                yield break;
            }

            for (int i = 3; i < UpperLimit; i += 2)
            {
                if (IsPrime(i))
                {
                    yield return i;
                }
            }
        }

        public static bool IsPrime(int Number)
        {
            if (Number < 2)
                return false;

            if (Number == 2)
                return true;

            if (Number % 2 == 0)
                return false;

            var upperLimit = Math.Sqrt(Number) + 1;

            for (int i = 3; i < upperLimit; i += 2)
            {
                if (Number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}