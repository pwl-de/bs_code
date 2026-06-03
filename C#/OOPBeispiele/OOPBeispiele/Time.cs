using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPBeispiele
{
    internal class Time
    {

        // Member
        private int _hours;
        private int _minutes;

        // Konstruktoren
        public Time() {}
        public Time(int hours, int minutes)
        { 

            AddHour(hours);
            AddMinutes(minutes);
            /*
            if (_hours >= 0)
                _hours = hours;
            else
            {
                throw new Exception("Stunden Angabe ist falsch");
            }
            if (_minutes >= 0 && _minutes < 60)
                _minutes = minutes;
            else
            {
                throw new Exception("Minuten Angabe ist falsch");
            }
            */
        }

        //String Konst:
        public Time(string time) {
            if (time.Contains(':'))
            { // Behandlung Möglich HH:MM
                /*
                char sh1 = time[0];
                char sh2 = time[1];
                // :
                char sm1 = time[3];
                char sm2 = time[4];

                int h1 = sh1 - '0';
                int h2 = sh2 - '0';
                int m1 = sm1 - '0';
                int m2 = sm2 - '0';
                
                while (h1 > 0)
                {
                    h1 = h1- 1;
                    h2 = h2 +10;
                }
                while (m1 > 0)
                {
                    m1 = m1 - 1;
                    m2 = m2 + 10;
                }
 
                AddHour(h2);
                AddMinutes(m2);
                */

                string[] temp = time.Split(':');
                AddHour(Convert.ToInt32(temp[0]));
                AddMinutes(Convert.ToInt32(temp[1]));
            }
            else
                throw new Exception("Wert Falsch angegeben. Erwartet war: HH:MM");
        }




        // Get-Methoden
        public int GetHours() { return _hours; }
        public int GetMinutes() { return _minutes; }
        
        public int AsMinute()
        {
            int hoursInMinute = _hours * 60;
            return (hoursInMinute + _minutes);
        }

        public string AsString()
        {
            string tempString;
            string tempHours = Convert.ToString(_hours);
            string tempMinutes = Convert.ToString(_minutes);
            if (tempHours.Length == 1)
                tempHours = "0" + tempHours;
            if (tempMinutes.Length == 1)
                tempMinutes = "0" + tempMinutes;
            tempString = tempHours + ":" + tempMinutes;

            return tempString;
        }


        // Set-Methoden
        public void SetHours(int hours)
        {
            if (hours >= 0)
                _hours = hours;
            else
                throw new Exception("Stunden Angabe ist falsch!");
        }
        public void SetMinutes(int minutes)
        {
            if (minutes >= 0)
                _minutes = minutes;
            else
                throw new Exception("Minuten Angabe ist falsch!");
        }


        public void AddHour(int hour)
        {
            if (hour >= 0)
            {
                _hours += hour;
            }
            else
                throw new Exception("Stunden Angabe ist falsch!");

        }

        public void AddMinutes(int minutes)
        {
            if (minutes >= 0 && minutes < 60)
            {
                _minutes += minutes;
            } else if (minutes >= 60) {
                do
                {
                    minutes = minutes - 60;
                    _hours++;
                }
                while (minutes >= 60);
            } else
            {
                throw new Exception("Minuten Angabe ist falsch!");
            }
        }

    }
}
