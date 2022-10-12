using System;

namespace GenericArrayCreator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string[] test = ArrayCreator.Create(4, "stanislav");
            int[] ints = ArrayCreator.Create(4, 4);
            double[] doubles = ArrayCreator.Create(4, 4.5);
        }
    }
}
