using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoZiehung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] playerInput = new int[6];
            int[] outcome = new int[6];


            Console.WriteLine("Lotto 6 aus 49");
            Console.WriteLine("--------------------------");


            //Check User Input and Assign Value to playerInput
            for (int i  = 0; i < 6;i++)
            {
                bool valid = false;
                int tempInt;

                do
                {
                    Console.Write("Tipp " + (i+1) + " : ");
                    valid = int.TryParse(Console.ReadLine(), out tempInt);

                    if (!valid || tempInt < 1 || tempInt > 49)
                    {
                        Console.WriteLine("Eingabe ist ungültig");
                        valid = false;
                    } else if (playerInput.Contains(tempInt))
                    {
                        Console.WriteLine("Auf diese Zahl wurde bereits gesetzt!");
                        valid = false;
                    }
                } while (!valid);
             playerInput[i] = tempInt;   
            }

            Console.Clear();
            Console.WriteLine("Deine Tipps:");
            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine(playerInput[j]);
            }
            Console.WriteLine("---------------------");

            // Ziehung der Lottozahlen in outcome
            int index = 0;
            while (index < 6)
            {
                int randomInt = rnd.Next(1, 50);
                if (!outcome.Contains(randomInt))
                {
                    outcome[index] = randomInt;
                    index++;
                }
            }
            Console.WriteLine("Gezogene Zahlen:");
            for (int j = 0; j < 6; j++)
            {
                Console.WriteLine(outcome[j]);
            }
            Console.WriteLine("---------------------");


            // Check for Correct Tips
            int correctAmount = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int k = 0; k < 6; k++)
                {
                    if (outcome[i].Equals(playerInput[k]))
                        correctAmount++;
                }
            }
            Console.WriteLine("Du hast " + correctAmount + " Richtige!");


        }
    }
}
