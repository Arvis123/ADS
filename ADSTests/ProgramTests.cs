using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace game.Tests
{
    [TestClass]
    public class ProgramTests
    {
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
        public void MainMenu_WhenInputIsInvalid_ReturnsTrue()
        {
            // Arrange
            var originalConsoleOut = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("invalid input"));

                // Act
                bool result = Program.MainMenu(Console.In, Console.Out);

                // Assert
                Assert.IsTrue(result);
            }

            Console.SetOut(originalConsoleOut);
        }

        [TestMethod]
        public void MainMenu_WhenEnterPressed_ReturnsTrue()
        {
            // Arrange
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(Environment.NewLine))
                {
                    // Act
                    bool result = Program.MainMenu(sr, sw);

                    // Assert
                    Assert.IsTrue(result);
                }
            }
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

        [TestMethod]
        public void MainMenu_WhenInputIs7_ReturnsTrue()
        {
            // Arrange
            var originalConsoleOut = Console.Out;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("7"));

                // Act
                bool result = Program.MainMenu(Console.In, Console.Out);

                // Assert
                Assert.IsTrue(result);
            }

            Console.SetOut(originalConsoleOut);
        }
    }
}
