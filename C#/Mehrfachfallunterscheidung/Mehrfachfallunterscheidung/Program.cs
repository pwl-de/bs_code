using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mehrfachfallunterscheidung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restart:
            //Welche Variante?
            bool smartPrice = false;
            Console.Write("Wollen Sie den Smartpreis Rechner nutzen? y/n. ");
            if (Console.ReadLine() == "y")
            {
                smartPrice = true;
            }
            Console.Clear();

            // Variante für dumm dumm:
            // -------------------------------------------------
            if (smartPrice == false) {

                string wunschWagenKategorie;
                double Kilometer;

                Console.Write("Gewünschte Mietwagenkategorie:");
                wunschWagenKategorie = Console.ReadLine();

                Console.Write("Zu fahrende Kilometer: ");
                Kilometer = Convert.ToDouble(Console.ReadLine());

                double Preis = 0;

                if (wunschWagenKategorie == "A" || wunschWagenKategorie == "a")
                {
                    Console.WriteLine("Mietwagenkategorie A");
                    if (Kilometer < 300)
                    {
                        Preis = Kilometer * 0.42 + 90;
                    }
                    else if (Kilometer >= 300)
                    {
                        Preis = Kilometer * 0.24 + 114;
                    }
                }
                if (wunschWagenKategorie == "B" || wunschWagenKategorie == "b")
                {
                    Console.WriteLine("Mietwagenkategorie B");
                    if (Kilometer <= 100)
                    {
                        Preis = 99;
                    }
                    else if (Kilometer > 100)
                    {
                        Preis = Kilometer * 0.17 + 99;
                    }
                }
                if (wunschWagenKategorie == "C" || wunschWagenKategorie == "c")
                {
                    Console.WriteLine("Mietwagenkategorie C");
                    Preis = 149;
                }



                Console.WriteLine("Preis: " + Preis);
            } else
            {



                //Smart Choice Rechner:
                //---------------------------------------
                string idealCat;
                double minPreis = 0;
                double Kilometer = 0;
                Console.Write("Kilometer: ");
                Kilometer = Convert.ToDouble(Console.ReadLine());

                double varianteA = 0;
                double varianteB = 0;
                double varianteC = 0;

                // Variante A Preisberechnung:
                if (Kilometer < 300) {
                    varianteA = Kilometer * 0.42 + 90;
                }
                else if (Kilometer >= 300)
                {
                    varianteA = Kilometer * 0.24 + 114;
                }
                // Variante B
                if (Kilometer <= 100)
                {
                    varianteB = 99;
                } else
                {
                    varianteB = Kilometer * 0.17 + 99; 
                }
                // Varianate C
                varianteC = 149;


                //Auswertung:
                if (varianteC < varianteB && varianteC < varianteA)
                {
                    idealCat = "C";
                    minPreis = varianteC;                    
                } else if (varianteB < varianteA)
                {
                    idealCat = "B";
                    minPreis = varianteB;
                } else
                {
                    idealCat = "A";
                    minPreis = varianteA;
                }
                    // Result
                    Console.WriteLine("Mit der Mietwagenkategorie " + idealCat + " sind sie mit " + minPreis + "€l am günstisten.");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("To continue press return. ");
            Console.ReadLine();
            Console.Clear();
            goto Restart;
        }
    }
}
