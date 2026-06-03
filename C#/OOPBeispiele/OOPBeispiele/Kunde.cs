using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBeispiele
{
    internal class Kunde
    {
        private int _amount;
        private char _discountgroup;



        //Def. Konstruktor
        public Kunde()
        {}

        //Konstruktor
        public Kunde(int amount)
        {
            try {
                AddOrder(amount);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        // GetMethoden
        public int GetAmount()
        {
            return _amount;
        }
        public char GetDiscountgroup()
        {
            return _discountgroup;
        }

        //Set Method
        private void UpdateDiscountGroup(int amount)
        {
            if (amount >= 20000)
                _discountgroup = 'C';
            else if (10000 <= amount && 19999 >= amount)
                _discountgroup = 'B';
            else if (0 <= amount && 9999 > amount)
                _discountgroup = 'A';
        }
        /*public void SetAmount(int amount)
        {
            if (amount >= 0) {
                _amount = amount;
                UpdateDiscountGroup(_amount);
            }
            else if (amount < 0)
                throw new Exception("Bestellmenge darf nicht weniger als 0 sein.");
        }*/

        //AddOrder Methode
        public void AddOrder(int amount)
        {
            if (amount >= 0)
            {
                _amount += amount;
                UpdateDiscountGroup(_amount);
            }
            else if (amount < 0)
                throw new Exception("Bestellmenge darf nicht weniger als 0 sein.");
        }
    }
}
