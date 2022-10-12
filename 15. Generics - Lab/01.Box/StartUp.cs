using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BoxOfT
{
    public class StartUp
    {
        public static void Main()
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Add(3);
            Console.WriteLine(box.Remove());
            box.Add(4);
            box.Add(5);
            box.Add(6);
            Console.WriteLine(box.Remove());

        }
    }
}
