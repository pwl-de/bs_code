using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace OOPBeispiele
{
    public class Verbindung
    {
        public string Destination;
        public string Location;
        public double Duration;

        //Konstruktoren
        //------------------------------
        //default
        public Verbindung()
        {
        }
        //benutzerdefinierte Konstruktoren:
        public Verbindung(string inputDestination, string inputLocation, double inputDuration)
        {
            Destination = inputDestination;
            Location = inputLocation;
            Duration = inputDuration;
        }

    }
}
