using System;
using OOP;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //MyClass myClass = new MyClass("Green", 200);
            //myClass.ShowSpeed();
            //myClass.ShowColor();
            Console.WriteLine("Hi");

            Car car = new Car();
            Console.WriteLine(car.Color = "Blue");
            Console.WriteLine(car.Speed = 200);

            Honda honda = new Honda();
            Console.WriteLine(honda.StartCar());

        }

    }
}