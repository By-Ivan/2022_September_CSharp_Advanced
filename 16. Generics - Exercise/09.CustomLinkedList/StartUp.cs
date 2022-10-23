using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<int> ints = new CustomDoublyLinkedList<int>();

            ints.AddLast(1);
            ints.AddLast(2);
            ints.AddLast(3);

            CustomDoublyLinkedList<string> str = new CustomDoublyLinkedList<string>();

            str.AddLast("Gosho");
            str.AddLast("Pesho");
            str.AddLast("Sasho");
            str.AddLast("Manol");
        }
    }
}
