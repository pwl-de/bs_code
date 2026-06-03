using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace ChuckALuck
{
    class Program
    {
        //static Rückgabetyp Methodenname(Parameterliste)
        static double CalculateWin(int count, double bet)
        {
            double win = 0;

            if (count == 3)
                win = bet * 3;
            else if (count == 2)
                win = bet * 2;
            else if (count == 1)
                win = bet * 1;
            else
                win = -1 * bet;

            return win;
        }

        static void ShowMovingLine(int length, string character)
        {
            for (int i = 1; i <= length; i++)
            {
                Console.Write(character);
                Thread.Sleep(100);
            }
            Console.WriteLine();
        }

        //.exe -Zeichen -Anzahl
        static UserParams CreateUserParams(string[] args)
        {
            if (args.Length != 2)
                return null;

            string args1 = args[0]; // Zeichen
            string args2 = args[1]; // Anzahl

            args1 = args1.TrimStart('-');
            args2 = args2.TrimStart('-');
            
            int args2Num = Convert.ToInt32 (args2);

            UserParams userParams = new UserParams(args1, args2Num);    
            userParams.Symbol = args1;
            userParams.Amount = args2Num;

            return userParams;
        }

        static void Main(string[] args)
        {
            UserParams userParams = CreateUserParams(args);
            if (userParams == null)
            {
                Console.WriteLine("Fehlerhafter Programmaufruf!");
                return;
            } /*else
            {
                Console.WriteLine("Symbol: " + userParams.Symbol);
                Console.WriteLine("Amount: " + userParams.Amount);
            } */


            bool play = false;

            Console.ForegroundColor = ConsoleColor.Black;

            Console.Write("Your money: ");
            double money = Convert.ToDouble(Console.ReadLine());

            Random R = new Random();

            do
            {
                Console.Clear();
                Console.WriteLine($"Your money  = {money}");

                //########### Einsatz ###########

                Console.Write("Your Bet :");
                double bet = Convert.ToDouble(Console.ReadLine());

                Console.Write("On Number :");
                int betNumber = Convert.ToInt32(Console.ReadLine());

                //########### Das eigentliche Würfeln ###########

                int Dice1 = R.Next(1, 7);
                int Dice2 = R.Next(1, 7);
                int Dice3 = R.Next(1, 7);

                //########### wie viele richtige? ###########

                int count = 0;

                if (Dice1 == betNumber)
                    count++;

                if (Dice2 == betNumber)
                    count++;

                if (Dice3 == betNumber)
                    count++;

                //########### Gewinnermittlung ###########

                double win = CalculateWin(count, bet);

                money += win;

                //########### Würfelausgabe ###########

                ShowMovingLine(userParams.Amount, userParams.Symbol);
                Console.WriteLine($"dice no. 1 = {Dice1}");

                ShowMovingLine(userParams.Amount, userParams.Symbol);
                Console.WriteLine($"dice no. 2 = {Dice2}");

                ShowMovingLine(userParams.Amount, userParams.Symbol);
                Console.WriteLine($"dice no. 3 = {Dice3}");

                //########### Mitteilung Gewinn/Verlust ###########
                Console.WriteLine($"=== Result ====");
                if (win > 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"win = {win}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"loss = {win}");
                }
                
                Console.ForegroundColor = ConsoleColor.Black;

                //########### Frage: erneut spielen? ###########

                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("");
                Console.Write("play again (y/n)?");
                play = Console.ReadLine() == "y";

                /*if (Console.ReadLine() == "y")
                    play = true;
                else
                    play = false;*/


            } while (play == true);

            Console.Clear();
            Console.WriteLine($"Your money  = {money}");
            Console.ReadKey();
        }
    }
}
