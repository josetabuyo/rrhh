using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace General.Csv
{
    class Base36
    {
        public static string DecimalToArbitrarySystem(long decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789abcdefghijklmnopqrstuvwxyz";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " +
                    Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }


        /// <summary>
        /// Converts the given number from the numeral system with the specified
        /// radix (in the range [2, 36]) to decimal numeral system.
        /// </summary>
        /// <param name="number">The arbitrary numeral system number to convert.</param>
        /// <param name="radix">The radix of the numeral system the given number
        /// is in (in the range [2, 36]).</param>
        /// <returns></returns>
        public static long ArbitraryToDecimalSystem(string number, int radix)
        {
            const string Digits = "0123456789abcdefghijklmnopqrstuvwxyz";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " +
                    Digits.Length.ToString());

            if (String.IsNullOrEmpty(number))
                return 0;

            // Make sure the arbitrary numeral system number is in upper case
            number = number.ToUpperInvariant();

            long result = 0;
            long multiplier = 1;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                char c = number[i];
                if (i == 0 && c == '-')
                {
                    // This is the negative sign symbol
                    result = -result;
                    break;
                }

                int digit = Digits.IndexOf(c);
                if (digit == -1)
                    throw new ArgumentException(
                        "Invalid character in the arbitrary numeral system number",
                        "number");

                result += digit * multiplier;
                multiplier *= radix;
            }

            return result;
        }


        const int kByteBitCount = 8; // number of bits in a byte
        const string kBase36Digits = "0123456789abcdefghijklmnopqrstuvwxyz";
        // constants that we use in ToBase36CharArray
        static readonly double kBase36CharsLengthDivisor = Math.Log(kBase36Digits.Length, 2);
        static readonly BigInteger kBigInt36 = new BigInteger(36);

        public static string ToBase36String(byte[] bytes, bool bigEndian = false)
        {
            // Estimate the result's length so we don't waste time realloc'ing
            int result_length = (int)
                Math.Ceiling(bytes.Length * kByteBitCount / kBase36CharsLengthDivisor);
            // We use a List so we don't have to CopyTo a StringBuilder's characters
            // to a char[], only to then Array.Reverse it later
            var result = new System.Collections.Generic.List<char>(result_length);

            var dividend = new BigInteger(bytes);
            // IsZero's computation is less complex than evaluating "dividend > 0"
            // which invokes BigInteger.CompareTo(BigInteger)
            while (!dividend.IsZero)
            {
                BigInteger remainder;
                dividend = BigInteger.DivRem(dividend, kBigInt36, out remainder);
                int digit_index = Math.Abs((int)remainder);
                result.Add(kBase36Digits[digit_index]);
            }

            // orientate the characters in big-endian ordering
            if (!bigEndian)
                result.Reverse();
            // ToArray will also trim the excess chars used in length prediction
            return new string(result.ToArray());
        }


    }
}
