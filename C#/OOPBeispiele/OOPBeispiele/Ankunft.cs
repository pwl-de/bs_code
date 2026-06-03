using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBeispiele
{
    public class Ankunft
    {
        //Member
        //Datenkapselung Datahiding, kein direkter Zugriff
        private string Herkunft;
        private string Flugnummer; // fangen mit zwei Buchstaben an
        private int Terminal; // Terminal >=0

        // -----------------------------------------------------------------------------
        //Standardkonstruktor 
        public Ankunft()
        {
            Terminal = 0;
        }
        //benutzerdefinierte Konstruktoren
        public Ankunft(string herkunft, string flugnummer, int terminal)
        {
            Herkunft = herkunft;
            Flugnummer = flugnummer;
            Terminal = terminal;
        }
        //Kopierkonstruktor
        public Ankunft(Ankunft copyFrom)
        {
            Herkunft = copyFrom.Herkunft;
            Flugnummer = copyFrom.Flugnummer;
            Terminal = copyFrom.Terminal;
        }


        //Setter & Getter-

        public string GetFlugnummer() {
            return Flugnummer;
        }
    }
}
