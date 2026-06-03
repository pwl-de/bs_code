using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bußgeldrechner
{
    internal class Program
    {


        //Reset Funktion zum neustart des Programms
        static void totalReset() {
            Reset:
            Console.WriteLine(" \n \n \n \n");
            Console.Write("Wollen Sie eine neue Berechnung durchführen? j/n ");
            string userInput = Console.ReadLine();
            if (userInput.Equals("n") || userInput.Equals("N"))
            {
                //Programm beenden
                return; 
            }
            else if (userInput.Equals("j") || userInput.Equals("J"))
            {
                Console.Clear();
                Rechner();
            }
            else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte erneut versuchen");
                goto Reset;
            }
        }


        // Main Funktion ruft Bußgeldrechner auf
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Rechner();
        }

        // Bußgeldrechner......................................................................................
        static void Rechner() { 
            Console.WriteLine("Bußgeldrechner - programmiert von Max Weis und Paul Langsdorf. \n");

            double actualSpeed = 0;
            double allowedSpeed = 0;
            bool inTown = false;
            string userInput;
            int checkInt;

            //ActualSpeed Userinput
            ActualSpeedInput:
            Console.Write("Bitte gefahrene Geschwindigkeit eintragen: ");

            userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out checkInt)) 
            {
                Console.WriteLine("Ungültige Eingabe. Bitte erneut versuchen");
                goto ActualSpeedInput;
            } else if (checkInt <= 0) 
            { 
                Console.WriteLine("Ungültige Eingabe. Bitte erneut versuchen");
                goto ActualSpeedInput;
            }
            actualSpeed = Convert.ToDouble(checkInt);

            //AllowedSpeed Userinput
            allowedSpeedInput:
            Console.Write("Bitte erlaubte Geschwindigkeit eintragen: ");

            userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out checkInt))
            {
                Console.WriteLine("Ungültige Eingabe. Bitte erneut versuchen");
                goto allowedSpeedInput;
       
            } else if (checkInt <= 0 || actualSpeed <= Convert.ToDouble(checkInt)) //checkInt = allowedSpeed
            {
                Console.WriteLine("Ungültige Eingabe. Bitte erneut versuchen");
                goto allowedSpeedInput;
            } 
            allowedSpeed = Convert.ToDouble(checkInt);

            //Toleranz abfrage
            Toleranz:
            Console.Write("Wurde die Toleranz bereits abgezogen? j/n ");
            userInput = Console.ReadLine();
            if (userInput.Equals("n") || userInput.Equals("N"))
            {
                if (actualSpeed <= 100) {
                    actualSpeed -= 3; // Toleranz wird nachträglich abgezogen
                } else
                {
                    actualSpeed -= ((actualSpeed / 100) * 3);  // Toleranz wird nachträglich abgezogen 
                }
                
                // Immernoch zu schnell nach Toleranzabzug?
                if ((actualSpeed - allowedSpeed) <= 0)
                {
                    Console.WriteLine("Nach Toleranzabzug sind sie nicht zu schnell gefahren.");
                    totalReset();
                } else 
                {
                    Console.WriteLine("Nach Toleranzabzug sind Sie " + actualSpeed + "Km/h gefahren."); 
                }
            }   
            else if (userInput.Equals("j") || userInput.Equals("J"))
            {
                // pass
            } else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte erneut versuchen");
                goto Toleranz;
            }

            //Abfrage Innerorts
            inTown:
            Console.Write("Waren sie Inneorts? j/n ");
            userInput = Console.ReadLine();
            if (userInput.Equals("j") || userInput.Equals("J"))
            {
                inTown = true;
            }
            else if (userInput.Equals("n") || userInput.Equals("N"))
            {
                //pass default = false
            }else
            {
                Console.WriteLine("Ungültige Eingabe. Bitte erneut versuchen");
                goto inTown;
            }

            // BERECHNUNG des Bußgeldes:
            double difference = actualSpeed - allowedSpeed;
            if (inTown)
            {
                // Innerorts
                if (difference <= 10)
                {
                    Console.WriteLine("Das Bußgeld beträgt 30 \u20ac.");

                } else if (difference > 10 && 15 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 50 \u20ac.");
                }
                else if (difference > 15 && 20 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 70 \u20ac.");
                }
                else if (difference > 20 && 25 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 115 \u20ac, und ein Punkt.");
                }
                else if (difference > 25 && 30 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 180 \u20ac, und ein Punkt.");
                }
                else if (difference > 30 && 40 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 260 \u20ac, und zwei Punkte, sowie ein Monat Fahrverbot.");
                }
                else if (difference > 40 && 50 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 400 \u20ac, und zwei Punkte, sowie ein Monat Fahrverbot.");
                }
                else if (difference > 50 && 60 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 560 \u20ac, und zwei Punkte, sowie zwei Monate Fahrverbot.");
                }
                else if (difference > 60 && 70 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 700 \u20ac, und zwei Punkte, sowie drei Monate Fahrverbot.");
                }
                else if (difference > 70)
                {
                    Console.WriteLine("Das Bußgeld beträgt 800 \u20ac, und zwei Punkte, sowie drei Monate Fahrverbot.");
                }
            } else
            {
                //Außerorts
                if (difference <= 10)
                {
                    Console.WriteLine("Das Bußgeld beträgt 20 \u20ac.");
                }
                else if (difference > 10 && 15 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 40 \u20ac.");
                }
                else if (difference > 15 && 20 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 60 \u20ac.");
                }
                else if (difference > 20 && 25 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 100 \u20ac, und ein Punkt.");
                }
                else if (difference > 25 && 30 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 150 \u20ac, und ein Punkt.");
                }
                else if (difference > 30 && 40 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 200 \u20ac, und ein Punkt.");
                }
                else if (difference > 40 && 50 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 320 \u20ac, und zwei Punkte, sowie ein Monat Fahrverbot.");
                }
                else if (difference > 50 && 60 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 480 \u20ac, und zwei Punkte, sowie ein Monat Fahrverbot.");
                }
                else if (difference > 60 && 70 >= difference)
                {
                    Console.WriteLine("Das Bußgeld beträgt 600 \u20ac, und zwei Punkte, sowie zwei Monate Fahrverbot.");
                }
                else if (difference > 70)
                {
                    Console.WriteLine("Das Bußgeld beträgt 700 \u20ac, und zwei Punkte, sowie drei Monate Fahrverbot.");
                }
            }
            totalReset();
        }
    }
}
