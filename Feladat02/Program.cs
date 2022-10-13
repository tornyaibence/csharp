using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérek egy számot!");
            int sz = Convert.ToInt32(Console.ReadLine());

            if (sz%2 == 0 && sz != 0)
            {
                Console.WriteLine("A szám páros!");
            }
            else if (sz == 0)
            {
                Console.WriteLine("A nulla se nem páros, se nem páratlan!");
            }
            else
            {
                Console.WriteLine("A szám páratlan!");
            }

            if (sz<0 && sz!=0)
            {
                Console.WriteLine("A szám negatív!");
            }
            else if (sz == 0)
            {
                Console.WriteLine("A szám se nem pozitív, se nem negatív!");
            }
            else
            {
                Console.WriteLine("A szám pozitív");
            }

            if (sz%5 == 0 && sz != 0)
            {
                Console.WriteLine("A szám osztható öttel!");
            }
            else
            {
                Console.WriteLine("A szám nem osztható öttel!");
            }

            Console.ReadLine();
        }
    }
}
