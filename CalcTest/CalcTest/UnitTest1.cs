using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalcTest
{
    [TestClass]
    public class CalcTest 
    {
        [TestMethod]
        public void TestSum()
        {
            // Arrange
            var test = new CalcLibrary.Calc();

            // Act
            var result1 = test.Sum(1, 2); 
            var result2 = test.Sum(1, 0);
            var result3 = test.Sum(1, -2);
            var result4 = test.Sum(2, 2);
            var result5 = test.Sum(1, 4);

            // Assert
            Assert.AreEqual(result1, 3); 
            Assert.AreEqual(result2, 1);
            Assert.AreEqual(result3, -1);
            Assert.AreEqual(result4, 4);
            Assert.AreEqual(result5, 5);
        }
    }
}
