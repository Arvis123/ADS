using System;
using System.Collections;
using System.Threading;
using Game;

namespace game
{
    public class GameLogic
    {
        private readonly Queue orders = new Queue();
        private readonly Stack dishes = new Stack();
        private int palletCount, score, g, k, p;
        private readonly string[] meal = { "Pizza", "Pasta", "Salad" };

        public void StartGame()
        {
            while (true)
            {
                int mIndex = new Random().Next(meal.Length);
                g++;

                Console.Clear();
                PrintUI();
                ProcessClientOrder(mIndex);
                PrintOrders();

                if (orders.Count == 7 || palletCount == 10)
                    HandleGameOver();

                ProcessKeyPress();
            }
        }

        private void PrintUI()
        {
            Console.WriteLine($"                                       score: {score}          {dishes.Count}  ________\n" +
                              "_______________________________________________________________________\n" +
                              "|To Close and re-open restaurant press ESC                            |\n" +
                              "|To Start game again press Q                                          |\n" +
                              "|To make and serve pizza press P or M or C                            |\n" +
                              "|To clean your dishes press SPACEBAR                                  |\n" +
                              "|To exit the game press W                                             |\n" +
                              "|____________________________________________________________________ |\n" +
                              "______________________________________________________________________\n" +
                              "|       |Take order|         ____________        |           |       |\n" +
                              "|              O            | Pizza oven |       |           |       |\n" +
                              "|                           |____________|               O           |\n" +
                              "|                              O       O                             |\n" +
                              "|____________________________________________________________________|\n" +
                              "~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~\n" +
                              "                                                     |__DISHWASHER__|\n" +
                              "~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~");
        }

        private void ProcessClientOrder(int mIndex)
        {
            orders.Enqueue($"{meal[mIndex]}O{g}  ");
            Thread.Sleep(2000);
        }

        private void PrintOrders()
        {
            foreach (var obj in orders)
            {
                Console.Write(obj);
                k++;
            }
            Console.WriteLine("\n______________________________________________________________________");
        }

        private void ProcessKeyPress()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.Spacebar: ClearDishes(); break;
                    case ConsoleKey.C:
                    case ConsoleKey.P:
                    case ConsoleKey.V:
                    case ConsoleKey.M: ServePizza(cki.Key.ToString()); break;
                    case ConsoleKey.Escape: Program.PrintMenuOptions(); break;
                    case ConsoleKey.Q: StartGame(); break;
                    case ConsoleKey.W: Environment.Exit(0); break;
                }
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

        private void HandleGameOver()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n                                Game Over" +
                              $"\n                       Final score: {score}");
            Console.ReadLine();
            Environment.Exit(0);
        }

        public static void Rules()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n     -----------------------------------------------------------" +
                              "\n     |1.You can start your game again as many times as you want  |" +
                              "\n     |---------------------------------------------------------- |" +
                              "\n     |2.You can close your restaurant and re-open restaurant     |" +
                              "\n     |-----------------------------------------------------------|" +
                              "\n     |3.You have to make a pizza and then serve it to a client   |" +
                              "\n     |-----------------------------------------------------------|" +
                              "\n     | Max 6 clients if you cant take care of them you will lose |" +
                              "\n     |-----------------------------------------------------------|" +
                              "\n     |4.You must clear your pallet place                         |" +
                              "\n     |-----------------------------------------------------------|" +
                              "\n     |Max 10 pallets if you cant clear your place you will lose  |" +
                              "\n     |-----------------------------------------------------------|" +
                              "\n     |5.You can exit the game                                    |" +
                              "\n     -------------------------------------------------------------" +
                              "\n     Press Enter to return to the main menu");
            if (Console.ReadLine() == "") return;
        }
    }
}
