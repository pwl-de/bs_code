using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPÜbung2
{
    internal class Rechteck
    {
        private double _breite = 1;
        private double _hoehe = 1;


        public void setBreite(double breite)
        {
            if (breite < 0) { _breite = breite; }
            else
                throw new Exception("Breite kann nicht negativ sein");
        }
        public void setHoehe(double hoehe)
        {
            if (hoehe < 0) { _hoehe = hoehe; }
            else
                throw new Exception("Breite kann nicht negativ sein");
        }

        public double getBreite() { return _breite; }
        public double getHoehe() { return _hoehe; }

        public Rechteck() { }
        public double flaeche()
        {
            return _hoehe * _breite;
        }
    }
}
