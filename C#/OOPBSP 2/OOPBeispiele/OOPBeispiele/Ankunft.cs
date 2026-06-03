using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBeispiele
{
    public class Ankunft
    {
        //member: private
        //Der Benutzer hat keinen direkten Zugriff darauf
        //Datenkapselung
        private string _Herkunft;
        private string _Flugnummer;//fangen mit zwei Buchbstaben
        private int _Terminal;//Terminal >= 0

        //Standardkonstruktor
        /*public Ankunft()
        {
            _Terminal = 0;
            _Flugnummer = "";
        } erzeugt sonst falsche Objekte */

        //benutzerdefinierte Konstruktoren
        public Ankunft(string herkunft, string flugnummer, int terminal)
        {
            _Herkunft = herkunft;
            SetFlugnummerException(flugnummer);
            _Terminal = terminal;
        }

        //Copy-Konstruktor
        public Ankunft(Ankunft copyFrom)
        {
            _Herkunft = copyFrom._Herkunft;
            _Flugnummer = copyFrom._Flugnummer;
            _Terminal = copyFrom._Terminal;
        }

        //Get-Methoden
        public string GetFlugnummer()
        {
            return _Flugnummer;
        }

        //Set-Methoden
        public int SetFlugnummerRetCode(string flugnummer)
        {
            if (Char.IsLetter(flugnummer[0]) && Char.IsLetter(flugnummer[1]))
            {
                _Flugnummer = flugnummer;
                return 1;
            }
            return -1;
        }
        public void SetFlugnummerException(string flugnummer)
        {
            if (Char.IsLetter(flugnummer[0]) && Char.IsLetter(flugnummer[1]))
            {
                _Flugnummer = flugnummer;
            } else 
                throw new Exception("Falsche Flugnummer");
        }
    }
}
