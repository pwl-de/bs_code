using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChuckALuck
{


    public class UserParams
    {
        //Klassenmember
        public int Amount;
        public string Symbol;

        //Default Konstruktor
        // leere Paramlist
        public UserParams()
        {
            Amount = 0;
            Symbol = "";
        }

        //benutzerdefinierter Konstruktur
        // 1. keien Rückgabetyp
        // 2. Name = Class Name
        // 3. 
        public UserParams(string Symbol, int Amount)
        {
            this.Symbol = Symbol;
            this.Amount = Amount;
        }
        
    }
}
