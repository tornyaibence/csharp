using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat05_hazi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem az intervallum kezdőértékét!");
            int kezdoertek = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kérem az intervallum végértékét!");
            int vegertek = Convert.ToInt32(Console.ReadLine());
            int osszeg = 0;
            int segedszam = 2;

            for (int i = kezdoertek; i <= vegertek; i++)
            {
                if (i%2 == 0)
                {
                    osszeg = osszeg + i;
                }
                else if (i%2 != 0)
                {
                    osszeg = osszeg - i;
                }
                segedszam++;

            }

            Console.WriteLine($"Összeg:{osszeg}");

            Console.ReadLine();
        }
    }
}
