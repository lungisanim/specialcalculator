using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecialCalculator;

namespace StringCalculator.Tests
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Test_Add_EmptyString_ReturnsZero()
        {
            // Arrange
            string input = "";

            // Act
            int result = Program.Add(input);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Test_Add_SingleNumber_ReturnsNumber()
        {
            // Arrange
            string input = "1";

            // Act
            int result = Program.Add(input);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Test_Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            string input = "1,2";

            // Act
            int result = Program.Add(input);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_Add_NewLinesBetweenNumbers_ReturnsSum()
        {
            // Arrange
            string input = "1\n2,3";

            // Act
            int result = Program.Add(input);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Test_Add_ChangeDelimiter_ReturnsSum()
        {
            // Arrange
            string input = "//;\n1;2";

            // Act
            int result = Program.Add(input);

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Test_Add_IgnoreNumbersGreaterThan1000_ReturnsSum()
        {
            // Arrange
            string input = "2,1001";

            // Act
            int result = Program.Add(input);

            // Assert
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception), "Negatives not allowed: -1, -3")]
        public void Test_Add_NegativeNumbers_ThrowsException()
        {
            // Arrange
            string input = "-1,2,-3,4";

            // Act and Assert
            int result = Program.Add(input);
        }
    }
}
