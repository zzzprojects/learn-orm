using System;

namespace CSharpTutorialDemo
{
    public class Inheritance
    {
        class Animal
        {
            public string Name { get; set; }

            public Animal(string name)
            {
                Name = name;
            }
            public void PrintName()
            {
                Console.WriteLine(Name);
            }
        }

        class Cat : Animal
        {
            public Cat(string name) : base (name)
            {

            }

            public void Meow()
            {
                Console.WriteLine("Meow!");
            }
        }

        class Dog : Animal
        {
            public Dog(string name) : base(name)
            {

            }

            public void Bark()
            {
                Console.WriteLine("Bark!");
            }
        }

        public static void Example1()
        {
            Cat cat = new Cat("Stanley");
            Dog dog = new Dog("Jackie");

            cat.PrintName();
            cat.Meow();

            dog.PrintName();
            dog.Bark();
        }
    }
}
