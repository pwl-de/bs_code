using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBeispiele
{
    internal class Quadrat
    {

        // Member
        private double _sideLength;


        //Konstruktoren:

        public Quadrat() {} //Default Konstruktor

        public Quadrat(double sideLength)
        {
            setSideLength(sideLength);
        }


        // Set Methode
        public void setSideLength(double input)
        {
            if (input < 0)
                throw new ArgumentOutOfRangeException("input");
            else
            {
                _sideLength = input;
            }
        }

        // Get Methode:
        public double getSideLength() { return _sideLength; }

        //Umfang Methode

        public double getScope()
        {
            double scope = _sideLength * 4 - 4; 
            return scope;
        }


    }
}
