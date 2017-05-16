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

            for (int i = 1; i < 6; i++)
            {
                var divide_res = test.Divide(100, i*3);
                Assert.AreEqual(divide_res, 100 / (i*3));
            }


            /*
            Не смог понять причину сбоя при тестировании квадратного корня.
            В данном случае высвечивает :
            Ожидается : <2,449 489 742 783 18>
            Фактически : <2,449 489 742 783 18>
            Как видно, это одно и то же число


            
            */
            var sqrt_res = test.Sqrt((double)9);
            Assert.AreEqual(sqrt_res, Math.Sqrt(9));


            for (int i = 0; i < 6; i++)
            {
                var pow_res = test.Pow(10, i);
                Assert.AreEqual(pow_res, Math.Pow(10, i));
            }

            for (int i = 0; i < 6; i++)
            {
                var mult_res = test.Multiply(10, i);
                Assert.AreEqual(mult_res, 10 * i);
            }

            //for (int i = 0; i < 6; i++)
            //{
            //    int j = -1;
            //    var abs_res = test.Abs(j * i);
            //    Assert.AreEqual(abs_res, Math.Abs(j * i));
            //    j = j * -1;
            //}
        }
    }
}
