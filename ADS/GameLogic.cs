// GameLogic.cs
using System;
using System.Collections;
using System.Threading;

namespace game
{
    public class GameLogic
    {
        private Queue orders;
        private Stack dishes;
        private int palletCount;
        private int score;

        public GameLogic()
        {
            orders = new Queue();
            dishes = new Stack();
            palletCount = 0;
            score = 0;
        }

        public void StartGame()
        {
            while (true)
            {
                int mIndex = new Random().Next(meal.Length);
                g++;

                Console.Clear();
                Console.WriteLine("                                       score:" + score + "          " + dishes.Count + "  ________");
                Console.WriteLine("_______________________________________________________________________");
                Console.WriteLine("|To Close and re-open restaurant press ESC                            |");
                Console.WriteLine("|To Start game again press Q                                          |");
                Console.WriteLine("|To make and serve pizza press P or M or C                            |");
                Console.WriteLine("|To clean your dishes press SPACEBAR                                  |");
                Console.WriteLine("|To exit the game press W                                             |");
                Console.WriteLine("|____________________________________________________________________ |");

                orders.Enqueue(meal[mIndex] + "O" + g + "  ");

                foreach (Object obj in orders)
                {
                    Console.Write(obj);
                    k++;
                }
                Console.WriteLine("");
                Console.WriteLine("______________________________________________________________________");
                Console.WriteLine("|       |Take order|         ____________        |           |       |");
                Console.WriteLine("|              O            | Pizza oven |       |           |       |");
                Console.WriteLine("|                           |____________|               O           |");
                Console.WriteLine("|                              O       O                             |");
                Console.WriteLine("|____________________________________________________________________|");
                Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
                Console.WriteLine("                                                     |__DISHWASHER__|");
                PrintDishes();
                Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");

                if (orders.Count == 7)
                {
                    orders.Clear();
                    GameOver();
                }

                Thread.Sleep(2000);
                if (palletCount == 10)
                {
                    ClearDishes();
                    GameOver();
                }

                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Spacebar)
                    {
                        ClearDishes();
                    }
                    if (cki.Key == ConsoleKey.C || cki.Key == ConsoleKey.P || cki.Key == ConsoleKey.V || cki.Key == ConsoleKey.M)
                    {
                        ServePizza(cki.Key.ToString());
                    }
                    if (cki.Key == ConsoleKey.Escape)
                    {
                        Meniu();
                    }
                    if (cki.Key == ConsoleKey.Q)
                    {
                        StartGame();
                    }
                    if (cki.Key == ConsoleKey.W)
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void PrintDishes()
        {
            foreach (Object obj in dishes)
            {
                Console.Write(obj);
                p++;
            }
        }

        private void ClearDishes()
        {
            dishes.Clear();
            palletCount = 0;
        }

        private void ServePizza(string pizzaType)
        {
            dishes.Push("__________  |");
            palletCount++;
            orders.Dequeue();
            score += 20;
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                                Game Over");
            Console.WriteLine("                       Final score: " + score);
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static void Rules()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("     -----------------------------------------------------------");
            Console.WriteLine("     |1.You can start your game again as many times as you want  |");
            Console.WriteLine("     |---------------------------------------------------------- |");
            Console.WriteLine("     |2.You can close your restaurant and re-open restaurant     |");
            Console.WriteLine("     |-----------------------------------------------------------|");
            Console.WriteLine("     |3.You have to make a pizza and then serve it to a client   |");
            Console.WriteLine("     |-----------------------------------------------------------|");
            Console.WriteLine("     | Max 6 clients if you cant take care of them you will lose |");
            Console.WriteLine("     |-----------------------------------------------------------|");
            Console.WriteLine("     |4.You must clear your pallet place                         |");
            Console.WriteLine("     |-----------------------------------------------------------|");
            Console.WriteLine("     |Max 10 pallets if you cant clear your place you will lose  |");
            Console.WriteLine("     |-----------------------------------------------------------|");
            Console.WriteLine("     |5.You can exit the game                                    |");
            Console.WriteLine("     -------------------------------------------------------------");
            Console.WriteLine("     Press Enter to return to main menu");
            if (Console.ReadLine() is "")
            {
                return;
            }
        }
        public static void Controls()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("    -------------------------------------------------------------");
            Console.WriteLine("    |1. Start game again (Q)                                    |");
            Console.WriteLine("    |---------------------------------------------------------- |");
            Console.WriteLine("    |2. Close your restaurant (ESC) Re-open restaurant (ESC)    |");
            Console.WriteLine("    |-----------------------------------------------------------|");
            Console.WriteLine("    |3. Make pizza and serve pizza                              |");
            Console.WriteLine("    |(Peperoni - P, Chesse - C, Margherita - M, Pancetta - P)   |");
            Console.WriteLine("    |-----------------------------------------------------------|");
            Console.WriteLine("    |4. Clear your pallet place (Spacebar)                      |");
            Console.WriteLine("    |-----------------------------------------------------------|");
            Console.WriteLine("    |5. Exit the game (W)                                       |");
            Console.WriteLine("    -------------------------------------------------------------");
            Console.WriteLine("    Press Enter to return to main menu");
            if (Console.ReadLine() is "")
            {
                return;
            }
        }
    }
}