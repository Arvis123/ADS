using System;
using System.Collections;
using System.Threading;
using System.IO;

namespace game

{
    public class Program
    {
        public static void ClearConsole()
        {
            Console.Clear();
        }

        public static void Main(string[] args)
        {
            Console.SetWindowSize(70, 29);

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(Console.In, Console.Out);
            }


        }

        public static void PrintStack(Stack s)
        {
            Stack temp = new Stack();
            while (s.Count != 0)
            {
                temp.Push(s.Peek());
                s.Pop();
            }

            while (temp.Count != 0)
            {
                string t = (string)temp.Peek();
                Console.Write("|                                                    |  " + t + " ");
                temp.Pop();

                // To restore contents of
                // the original stack.
                s.Push(t);
                Console.WriteLine();
            }
        }

        public static bool MainMenu(TextReader reader, TextWriter writer)
        {
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine("                          La pizza ristorante!");
            writer.WriteLine("                   Welcome to an Italian restaurant");
            writer.WriteLine("             Here we are serving pizzas for our customers");
            writer.WriteLine("     -----------------------------------------------------------");
            writer.WriteLine("     If you want to start a day being our new chef type number 1");
            writer.WriteLine("     -----------------------------------------------------------");
            writer.WriteLine("     If you want to read game rules type number 2 (better do it)");
            writer.WriteLine("     -----------------------------------------------------------");
            writer.WriteLine("     Fist time user have to read game controls type 3 to read it");
            writer.WriteLine("     -----------------------------------------------------------");
            writer.WriteLine("           If you want to exit right now just type number 4      ");
            writer.WriteLine("     -----------------------------------------------------------");
            writer.Write("\r\n                          Select an option: ");

            switch (reader.ReadLine())
            {
                case "1":
                    Game(writer);
                    return true;
                case "2":
                    Rules(writer);
                    return true;
                case "3":
                    Controls(writer);
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }

        public static void Rules(TextWriter writer)
        {
            ClearConsole(writer);

            ClearConsole();
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine("     -----------------------------------------------------------");
            writer.WriteLine("     |1.You can start your game again as many times as you want  |");
            writer.WriteLine("     |---------------------------------------------------------- |");
            writer.WriteLine("     |2.You can close your restaurant and re-open restaurant     |");
            writer.WriteLine("     |-----------------------------------------------------------|");
            writer.WriteLine("     |3.You have to make a pizza and then serve it to a client   |");
            writer.WriteLine("     |-----------------------------------------------------------|");
            writer.WriteLine("     | Max 6 clients if you cant take care of them you will lose |");
            writer.WriteLine("     |-----------------------------------------------------------|");
            writer.WriteLine("     |4.You must clear your pallet place                         |");
            writer.WriteLine("     |-----------------------------------------------------------|");
            writer.WriteLine("     |Max 10 pallets if you cant clear your place you will lose  |");
            writer.WriteLine("     |-----------------------------------------------------------|");
            writer.WriteLine("     |5.You can exit the game                                    |");
            writer.WriteLine("     -------------------------------------------------------------");
            writer.WriteLine("     Press Enter to return to main menu");
            if (Console.ReadLine() is "")
            {
                return;
            }
        }

        public static void ClearConsole(TextWriter writer)
        {
            if (Console.Out == writer)
            {
                Console.Clear();
            }
        }

        public static void Controls(TextWriter writer)
        {
            ClearConsole(writer);

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




        public static void Game(TextWriter writer)
        {
            Queue q = new Queue();
            int k = 0;

            Stack s = new Stack();
            string l = "__________  |";
            int p = 0;

            Random rnd = new Random();
            string[] meal = { "Peperoni", "Chesse", "Margherita", "Pancetta" };
            int g = 0;
            ConsoleKeyInfo cki;
            Console.TreatControlCAsInput = true;
            int score = 0;
            bool game = true;
            while (game)
            {
                int mIndex = rnd.Next(meal.Length);
                g++;

                ClearConsole();
                writer.WriteLine("                                       score:" + score + "          " + s.Count + "  ________");
                writer.WriteLine("_______________________________________________________________________");
                writer.WriteLine("|To Close and re-open restaurant press ESC                            |");
                writer.WriteLine("|To Start game again press Q                                          |");
                writer.WriteLine("|To make and serve pizza press P or M or C                            |");
                writer.WriteLine("|To clean your dishes press SPACEBAR                                  |");
                writer.WriteLine("|To exit the game press W                                             |");
                writer.WriteLine("|____________________________________________________________________ |");

                q.Enqueue(meal[mIndex] + "O" + g + "  ");

                foreach (Object obj in q)
                {
                    writer.Write(obj);
                    k++;
                }
                writer.WriteLine("");
                writer.WriteLine("______________________________________________________________________");
                writer.WriteLine("|       |Take order|         ____________        |           |       |");
                writer.WriteLine("|              O            | Pizza oven |       |           |       |");
                writer.WriteLine("|                           |____________|               O           |");
                writer.WriteLine("|                              O       O                             |");
                writer.WriteLine("|____________________________________________________________________|");
                writer.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
                writer.WriteLine("                                                     |__DISHWASHER__|");
                PrintStack(s);
                writer.WriteLine("~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");

                if (q.Count == 7)
                {
                    q.Clear();
                    ClearConsole();
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("                                GameOver");
                    writer.WriteLine("                       Final score: " + score);
                    Console.ReadLine();
                    break;

                }

                Thread.Sleep(2000);
                if (p == 10)
                {
                    s.Clear();
                    ClearConsole();
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("                                GameOver");
                    writer.WriteLine("                       Final score: " + score);
                    Console.ReadLine();
                    break;
                }

                while (Console.KeyAvailable)
                {
                    cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Spacebar)
                    {
                        //Console.Clear();
                        s.Clear();
                        p = 0;
                    }
                    if (cki.Key == ConsoleKey.C)
                    {
                        s.Push(l);
                        p++;
                        q.Dequeue();
                        score += 20;
                    }
                    if (cki.Key == ConsoleKey.P)
                    {
                        s.Push(l);
                        p++;
                        q.Dequeue();
                        score += 20;
                    }
                    if (cki.Key == ConsoleKey.V)
                    {
                        s.Push(l);
                        p++;
                        q.Dequeue();
                        score += 20;
                    }
                    if (cki.Key == ConsoleKey.M)
                    {
                        s.Push(l);
                        p++;
                        q.Dequeue();
                        score += 20;
                    }
                    if (cki.Key == ConsoleKey.Escape)
                    {
                        Meniu(writer);
                    }
                    if (cki.Key == ConsoleKey.Q)
                    {
                        Game(writer);
                    }
                    if (cki.Key == ConsoleKey.W)
                    {
                        game = false;
                    }
                }
            }



            s.Clear();
            ClearConsole();
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine("");
            writer.WriteLine("                                GameOver");
            writer.WriteLine("                       Final score: " + score);
            game = false;


        }
        public static bool Meniu(TextWriter writer)
        {
            ClearConsole();
            writer.WriteLine("You closed your restaurant select what you are gonna do next");
            writer.WriteLine("1. Re-open restaurant");

            switch (Console.ReadLine())
            {
                case "1":
                    return true;
                default:
                    return true;
            }
        }
    }
}
