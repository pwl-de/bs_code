using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schleifen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int itemCount = 0;
            double sum = 0;


            Console.Write("Produktanzahl: ");
            itemCount = Convert.ToInt32(Console.ReadLine());
            //bisher nicht -X gefiltert etc...


            //while-schleife
            //------------------------------------
            //kopfgesteuerte Schleife
            /*int i = 1;
            while (i <= itemCount)
            {
                Console.Write("Betrag:");
                sum += Convert.ToDouble(Console.ReadLine());
                i++;
            }
            Console.WriteLine("Summe: " + sum);
            */


            //do-while-schleife
            //fußgesteuerte Schleife -> wird mind. 1x betreten.
            /*
            sum = 0;
            int k = 1;
            do
            {
                Console.Write("Betrag:");
                sum += Convert.ToDouble(Console.ReadLine());
                k++;
            } while (k <= itemCount);
            Console.WriteLine("Summe: " + sum);
            */

            //for-schleife
            //kopfgesteuert
            for (int j = 0; j <= itemCount; j++)
            {
                Console.Write("Betrag:");
                sum += Convert.ToDouble(Console.ReadLine());
            }
            Console.WriteLine("Summe: " + sum);
        }
    }
}
