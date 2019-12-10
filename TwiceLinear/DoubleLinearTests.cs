using System;
using NUnit.Framework;

namespace TwiceLinear
{
    [TestFixture]
    public static class DoubleLinearTests 
    {
        private static void testing(int actual, int expected) 
        {
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public static void test1() 
        {
            Console.WriteLine("Fixed Tests DblLinear");
            testing(DoubleLinear.DblLinear(10), 22);
            testing(DoubleLinear.DblLinear(20), 57);
            testing(DoubleLinear.DblLinear(30), 91);
            testing(DoubleLinear.DblLinear(50), 175);
            testing(DoubleLinear.DblLinear(150), 335146);
        }
    }
}