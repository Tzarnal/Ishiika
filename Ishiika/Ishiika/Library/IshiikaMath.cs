using System;
using System.Collections.Generic;

namespace Ishiika.Library
{
    public static class IshiikaMath
    {
        public static IEnumerable<long> Primes(int UpperLimit)
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

            const int offset = 3;

            //Helpers
            static int ToNumber(int index) => (2 * index) + offset;
            static int ToIndex(int number) => (number - offset) / 2;

            //Create a an array
            var bits = new bool[ToIndex(UpperLimit) + 1];

            var upperSqrtIndex = ToIndex((int)Math.Sqrt(UpperLimit));
            for (var i = 0; i <= upperSqrtIndex; i++)
            {
                // If this bit has already been turned off, then its associated number is composite.
                if (bits[i]) continue;
                var number = ToNumber(i);

                // The instant we have a known prime, immediately yield its value.
                yield return number;

                // Any multiples of number are composite and their respective bits should be turned off.
                for (var j = ToIndex(number * number); (j > i) && (j < bits.Length); j += number)
                {
                    bits[j] = true;
                }
            }

            // Output remaining primes once bit array is fully resolved:
            for (var i = upperSqrtIndex + 1; i < bits.Length; i++)
            {
                if (!bits[i])
                {
                    yield return ToNumber(i);
                }
            }
        }
    }
}