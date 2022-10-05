using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person(19);
            Person person3 = new Person("Jose", 43);

            Console.WriteLine($"Name: {person1.Name}\nAge: {person1.Age}");
            Console.WriteLine($"Name: {person2.Name}\nAge: {person2.Age}");
            Console.WriteLine($"Name: {person3.Name}\nAge: {person3.Age}");
        }
    }
}
