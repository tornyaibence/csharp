using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feladat10
{
    public class Aruhaz
    {

        public string Termeknev;
        public string Marka;
        public int Darabszam;

        public Aruhaz(string termeknev, string marka, int darabszam)
        {
            Termeknev = termeknev;
            Marka = marka;
            Darabszam = darabszam;
        }


    }
    public class Ora
    {
        public int Perc { get; set; }
        public double Masodperc { get; set; }

        public Ora(int perc, double masodperc)
        {
            this.Perc = perc;
            this.Masodperc = masodperc;
        }
    }
    public class Szemely
    {
        
    }
}
