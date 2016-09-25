using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeIQ39_20160924
{
    class Program
    {
        static int getdigit(double src)
        {
            int val = 0;
            while (!(src < 1.0))
            {
                val++;
                src /= 10.0;
            }
            return val;
        }

        static double flip(double src)
        {
            double val = 0, tmp;
            int digit = getdigit(Math.Truncate(src));
            for (int i = 0; i < digit; i++)
            {
                tmp = (src / Math.Pow(10, i)) % 10;
                val = Math.Truncate(val) * 10 + Math.Truncate(tmp);
            }
            return Math.Truncate(val);
        }

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
            double number = 1, value = 0;
            bool result;

            Console.WriteLine("start");
            while (Math.Truncate(number) < 10000.0)
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

                    value += Math.Truncate(flip(value));
                }

                if (!result)
                {
                    Console.WriteLine("回文数にならない数値ゲット: " + number);
                    break;
                }
                number += 1.0;
            }
            Console.WriteLine("end");
            Console.Read();
        }
    }
}
