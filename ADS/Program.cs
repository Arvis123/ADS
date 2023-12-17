// Program.cs
using System;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(70, 29);

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("                          La pizza ristorante!");
            Console.WriteLine("                   Welcome to an Italian restaurant");
            Console.WriteLine("             Here we are serving pizzas for our customers");
            Console.WriteLine("     -----------------------------------------------------------");
            Console.WriteLine("     If you want to start a day being our new chef type number 1");
            Console.WriteLine("     -----------------------------------------------------------");
            Console.WriteLine("     If you want to read game rules type number 2 (better do it)");
            Console.WriteLine("     -----------------------------------------------------------");
            Console.WriteLine("     Fist time user have to read game controls type 3 to read it");
            Console.WriteLine("     -----------------------------------------------------------");
            Console.WriteLine("           If you want to exit right now just type number 4      ");
            Console.WriteLine("     -----------------------------------------------------------");
            Console.Write("\r\n                          Select an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    new GameLogic().StartGame();
                    return true;
                case "2":
                    GameLogic.Rules();
                    return true;
                case "3":
                    GameLogic.Controls();
                    return true;
                case "4":
                    return false;
                default:
                    return true;
            }
        }
    }
}
