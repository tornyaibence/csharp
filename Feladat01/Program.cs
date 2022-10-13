using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérek egy egész számot!");
            int sz = Convert.ToInt32(Console.ReadLine());

            if (sz % 2 == 0 && sz % 3 == 0)
            {
                Console.WriteLine("ZIZI");
            }
            else if (sz % 2 == 0)
            {
                Console.WriteLine("BIZ");
            }
            else if (sz % 3 == 0)
            {
                Console.WriteLine("BAZ");
            }
            else
            {
                Console.WriteLine("Kettővel és hárommal sem osztható!");
            }

            Console.ReadLine();
        }
    }
