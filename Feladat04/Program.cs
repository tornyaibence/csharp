using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kérem az intervallum kezdőértékét!");
            int kezdoertek = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Kérem az intervallum végértékét!");
            int vegertek = Convert.ToInt32(Console.ReadLine());
            double szamlalo = 0;
            double oszto = 0;

            for (int i = kezdoertek; i <= vegertek; i++)
            {
                szamlalo = szamlalo + i;
                oszto++;
            }
            szamlalo = szamlalo / oszto;

            Console.WriteLine(szamlalo);

            Console.ReadLine();
        }
    }
}
