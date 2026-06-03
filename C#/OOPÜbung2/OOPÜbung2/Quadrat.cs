using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OOPÜbung2
{
    internal class Quadrat
    {
        private double _seitenLaenge;
        public void setSeitenLaenge(double input)
        {
            if (input < 0)
                _seitenLaenge = input;
            else
                throw new Exception("Seitenlänge kann nicht negativ sein");
        }
        public double getSeitenLaenge() { return _seitenLaenge; }

        public Quadrat() { }

        public Quadrat(double input)
        {
            setSeitenLaenge(input);
        }

        public double Umfang()
        {
            return _seitenLaenge * 4 - 4;
        }

    }
}
