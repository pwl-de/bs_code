using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Übungsaufgaben_zu_Schleifen_Teil_2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Aufgabe 1: Segel ausgeben.

            Console.Write("Größe? ");
            int sailSize = Convert.ToInt32(Console.ReadLine());


            //Normal
            for (int i = 0; i < sailSize; i++)
                {

                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write("X");
                    }
                    Console.WriteLine();
                }



            Console.WriteLine("\n \n \n");
            //flipped
            for (int i = 0; i < sailSize; i++)
            {

                for (int j = i; j < sailSize; j++)
                {
                    Console.Write("X");
                }
                Console.WriteLine();
            }



            // Aufgabe 2: Quadrat
            // ---------------------------------------------------------------------------------
            Console.Write('\n');
            Console.Write("Größe? ");
            int squareSize = Convert.ToInt32(Console.ReadLine());
            

            //Erste Zeile
            for (int i = 0; i < squareSize; i++)
            {
                Console.Write("X");
            }
            Console.WriteLine();
            //Ränder
            for (int j = 2; j < squareSize; j++)
            {
                Console.Write("X");
                for (int k = 2; k < squareSize; k++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine("X");
            }

            //Letzte Zeile
            for (int i = 0; i < squareSize; i++)
            {
                Console.Write("X");
            }
            Console.WriteLine();


            Console.WriteLine("\n \n \n");
            // Variante 2
            for (int i = 0; i < squareSize; i++)
            {

                //Erste Zeile
                if (i == 0)
                {
                    for (int j = 0; j < squareSize; j++)
                    {
                        Console.Write("X");
                    }
                    Console.WriteLine();
                }

                if (i != 0 && i != squareSize - 1)
                {
                    Console.Write("X");
                    for (int k = 2; k < squareSize; k++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("X");
                }

                //Letzte Zeile
                if (i == squareSize - 1)
                {
                    for (int j = 0; j < squareSize; j++)
                    {
                        Console.Write("X");
                    }
                }
            }

        }
    }
}
