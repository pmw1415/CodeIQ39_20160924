using System;

namespace CodeIQ39_20160924
{
    class Program
    {
        /*
         * 桁数を算出
         */
        static int getDigit(double value)
        {
            int digit = 0;
            while (!(value < 1.0))
            {
                digit++;
                value /= 10.0;
            }
            return digit;
        }

        /*
         * 数値の各桁の値を逆順にした値に変換
         */
        static double flip(double value)
        {
            double flipValue = 0, tmp;
            int digit = getDigit(Math.Truncate(value));
            for (int i = 0; i < digit; i++)
            {
                tmp = (value / Math.Pow(10, i)) % 10;
                flipValue = Math.Truncate(flipValue) * 10 + Math.Truncate(tmp);
            }
            return Math.Truncate(flipValue);
        }

        /*
         * 数値が回文数かチェック
         */
        static bool isAnagramNumber(double value)
        {
            Console.WriteLine("  値チェック: " + Math.Truncate(value) + " | " + Math.Truncate(flip(value)));
            return Math.Truncate(value) == Math.Truncate(flip(value));
        }

        static void Main(string[] args)
        {
            /*
             * 自然数Nに対して、Nを逆に並べた数を足し続けると回文数になることがある。
             * これを25回繰り返しても回文数にならない最小のNを見つける。
             */
            double number = 0, value = 0;
            bool result;

            Console.WriteLine("start");
            while (Math.Truncate(++number) < 10000.0)
            {
                value = number;
                Console.WriteLine("自然数: " + value);
                result = false;
                for (int i = 0; i < 25; i++)
                {
                    if (isAnagramNumber(value))
                    {
                        // 回文数を検出
                        Console.WriteLine("    回文数: " + value);
                        result = true;
                        break;
                    }

                    // 逆に並べた値を足す
                    value += Math.Truncate(flip(value));
                }

                if (!result)
                {
                    Console.WriteLine("回文数にならない数値ゲット: " + number);
                    break;
                }
            }
            Console.WriteLine("end");
            Console.Read();
        }
    }
}
