using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBeispiele
{
    public class Benzinpreis
    {
        public double price;
        public string name;
        public double distance;

        //Konstruktoren
        //------------------------------
        //default
        public Benzinpreis() {}
        //Benutzerdefiniert
        public Benzinpreis(double inputPrice, string inputName, double inputDistance)
        {
            price = inputPrice;
            name = inputName;
            distance = inputDistance;
        }




    }
}
