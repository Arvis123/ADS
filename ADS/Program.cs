using game;
using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 29);

            while (ShowMainMenu()) { }
        }

        private static bool ShowMainMenu()
        {
            Console.Clear();
            PrintWelcomeMessage();
            PrintMenuOptions();

            string userInput = GetUserInput();
            return ProcessUserInput(userInput);
        }

        private static void PrintWelcomeMessage()
        {
            Console.WriteLine("\n\n                          La pizza ristorante!");
            Console.WriteLine("                   Welcome to an Italian restaurant");
            Console.WriteLine("             Here we are serving pizzas for our customers");
        }

        public static void PrintMenuOptions()
        {
            Console.WriteLine("     -----------------------------------------------------------");
            Console.WriteLine("     1. Start a day as a new chef");
            Console.WriteLine("     -----------------------------------------------------------");
            Console.WriteLine("     2. Read game rules (better do it)");
            Console.WriteLine("     -----------------------------------------------------------");
            Console.WriteLine("     3. Read game controls for first-time users");
            Console.WriteLine("     -----------------------------------------------------------");
            Console.WriteLine("     4. Exit");
            Console.Write("\r\n                          Select an option: ");
        }

        private static string GetUserInput()
        {
            return Console.ReadLine();
        }

        private static bool ProcessUserInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    new GameLogic().StartGame();
                    return true;
                case "2":
                    GameLogic.Rules();
                    return true;
                case "3":
                    GameLogic.Rules();
                    return true;
                case "4":
                    return false;
                default:
                    DisplayInvalidOptionMessage();
                    return true;
            }
        }

        private static void DisplayInvalidOptionMessage()
        {
            Console.WriteLine("Invalid option. Please try again.");
        }
    }
}