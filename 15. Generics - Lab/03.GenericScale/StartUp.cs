using System;
using System.Collections.Generic;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> scale1 = new EqualityScale<int>(1, 1);
            EqualityScale<int> scale2 = new EqualityScale<int>(1, 2);
            EqualityScale<string> scale3 = new EqualityScale<string>("Gosho", "Gosho");
            EqualityScale<string> scale4 = new EqualityScale<string>("Gosho", "Pesho");

            bool result1 = scale1.AreEqual();
            bool result2 = scale2.AreEqual();
            bool result3 = scale3.AreEqual();
            bool result4 = scale4.AreEqual();
            bool result5 = scale4.AreEqual();
        }
    }
}
