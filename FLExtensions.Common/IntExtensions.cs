namespace FLExtensions.Common
{
    public static class IntExtensions
    {
        public static int QuickPow(this int number, int power)
        {
            if (power == 0)
            {
                return 1;
            }

            if ((power & 1) == 1)
            {
                return number.QuickPow(power - 1) * number;
            }

            var squareRoot = number.QuickPow(power >> 1);

            return squareRoot * squareRoot;
        }

        public static int QuickParse(this string number)
        {
            int result = 0;
            int first = number[0] == '-' ? 1 : 0;

            for (int i = number.Length - 1, multiplier = 1; i >= first; i--, multiplier *= 10)
            {
                result += (number[i] - 48) * multiplier;
            }

            return number[0] == '-' ? -result : result;
        }
    }
}