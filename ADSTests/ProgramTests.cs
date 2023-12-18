using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace game.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void MainMenu_WhenInputIs1_CallsGame()
        {
            // Arrange
            var originalConsoleOut = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("1"));

                // Act
                bool result = Program.MainMenu(Console.In, Console.Out);

                // Assert
                Assert.IsTrue(result);
                Assert.IsTrue(sw.ToString().Contains("Game"));
            }

            Console.SetOut(originalConsoleOut);
        }

        [TestMethod]
        public void MainMenu_WhenInputIs4_ReturnsFalse()
        {
            // Arrange
            var originalConsoleOut = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("4"));

                // Act
                bool result = Program.MainMenu(Console.In, Console.Out);

                // Assert
                Assert.IsFalse(result);
            }

            Console.SetOut(originalConsoleOut);
        }

        [TestMethod]
        public void MainMenu_WhenInputIs2_CallsRules()
        {
            // Arrange
            var originalConsoleOut = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("2"));

                // Act
                bool result = Program.MainMenu(Console.In, Console.Out);

                // Preprocess strings to remove escape sequences and normalize whitespaces
                var actualOutput = NormalizeString(RemoveEscapeSequences(sw.ToString()));
                var expectedOutput = NormalizeString(RemoveEscapeSequences(@"
                              La pizza ristorante!
                       Welcome to an Italian restaurant
                 Here we are serving pizzas for our customers
         -----------------------------------------------------------
         If you want to start a day being our new chef type number 1
         -----------------------------------------------------------
         If you want to read game rules type number 2 (better do it)
         -----------------------------------------------------------
         First time user have to read game controls type 3 to read it
         -----------------------------------------------------------
               If you want to exit right now just type number 4      
         -----------------------------------------------------------
    
                              Select an option: 
    
    
         -----------------------------------------------------------
         |1.You can start your game again as many times as you want  |
         |---------------------------------------------------------- |
         |2.You can close your restaurant and re-open restaurant     |
         |-----------------------------------------------------------|
         |3.You have to make a pizza and then serve it to a client   |
         |-----------------------------------------------------------|
         | Max 6 clients if you cant take care of them you will lose |
         |-----------------------------------------------------------|
         |4.You must clear your pallet place                         |
         |-----------------------------------------------------------|
         |Max 10 pallets if you cant clear your place you will lose  |
         |-----------------------------------------------------------|
         |5.You can exit the game                                    |
         -------------------------------------------------------------
         Press Enter to return to main menu").Trim());

                // Log actual and expected output for debugging
                Console.WriteLine($"Actual Output:\n{actualOutput}\n");
                Console.WriteLine($"Expected Output:\n{expectedOutput}\n");

                // Assert
                StringAssert.Contains(expectedOutput.Trim(), actualOutput.Trim());
            }

            Console.SetOut(originalConsoleOut);
        }


        private string RemoveEscapeSequences(string input)
        {
            // Replace escape sequences with an empty string
            return System.Text.RegularExpressions.Regex.Replace(input, @"\x1B\[[0-9;]*[a-zA-Z]", "");
        }

        private string NormalizeString(string input)
        {
            // Normalize whitespaces
            return System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " ");
        }

        [TestMethod]
        public void MainMenu_WhenInputIs3_CallsControls()
        {
            // Arrange
            var originalConsoleOut = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("3"));

                // Act
                bool result = Program.MainMenu(Console.In, Console.Out);

                // Assert
                Assert.IsTrue(result);

                string actualOutput = sw.ToString().Trim();

                // Log the actual and expected output for troubleshooting
                Console.WriteLine("Actual Output:");
                Console.WriteLine(actualOutput);

                // Expected output for the controls section
                string expectedControls = "La pizza ristorante!" +
                    "Welcome to an Italian restaurant" +
                    "Here we are serving pizzas for our customers" +
                    "-----------------------------------------------------------" +
                    "If you want to start a day being our new chef type number 1" +
                    "-----------------------------------------------------------" +
                    "If you want to read game rules type number 2 (better do it)" +
                    "-----------------------------------------------------------" +
                    "First-time users have to read game controls type 3 to read it" +
                    "-----------------------------------------------------------" +
                    "If you want to exit right now just type number 4" +
                    "-----------------------------------------------------------" +
                    "Select an option: [2J" +
                    "    -------------------------------------------------------------" +
                    "    |1. Start game again (Q)                                    |" +
                    "    |---------------------------------------------------------- |" +
                    "    |2. Close your restaurant (ESC) Re-open restaurant (ESC)    |" +
                    "    |-----------------------------------------------------------|" +
                    "    |3. Make pizza and serve pizza                              |" +
                    "    |(Peperoni - P, Chesse - C, Margherita - M, Pancetta - P)   |" +
                    "    |-----------------------------------------------------------|" +
                    "    |4. Clear your pallet place (Spacebar)                      |" +
                    "    |-----------------------------------------------------------|" +
                    "    |5. Exit the game (W)                                       |" +
                    "    -------------------------------------------------------------" +
                    "    Press Enter to return to main menu";

                // Add assertions for key parts of the output
                StringAssert.Contains(expectedControls.Trim(), actualOutput.Trim());
            }

            Console.SetOut(originalConsoleOut);
        }

        [TestMethod]
        public void MainMenu_WhenInputIs8_ReturnsTrue()
        {
            // Arrange
            var originalConsoleOut = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("8"));

                // Act
                bool result = Program.MainMenu(Console.In, Console.Out);

                // Assert
                Assert.IsTrue(result);
            }

            Console.SetOut(originalConsoleOut);
        }

        [TestMethod]
        public void MainMenu_WhenInputIs6_ReturnsTrue()
        {
            // Arrange
            var originalConsoleOut = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("6"));

                // Act
                bool result = Program.MainMenu(Console.In, Console.Out);

                // Assert
                Assert.IsTrue(result);
            }

            Console.SetOut(originalConsoleOut);
        }
    }
}
