using System;
using OOP;

namespace OOP
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //MyClass myClass = new MyClass("Green", 200);
            //myClass.ShowSpeed();
            //myClass.ShowColor();

            //Console.WriteLine("Hi");

            //Car car = new Car();
            //Console.WriteLine(car.Color = "Blue");
            //Console.WriteLine(car.Speed = 200);

            //Honda honda = new Honda();
            //Console.WriteLine(honda.StartCar());

            // Async Test
            Task a = MethodAsync();
            Method2();
            await a;
            
        }

        static async Task MethodAsync()
        {
            Console.WriteLine("Wait 0");
            await Task.Delay(1000);
            Console.WriteLine("Wait 1");
            await Task.Delay(1000);
            Console.WriteLine("Wait 2");
        }

        static void Method2()
        {
            Console.WriteLine("Method 2");
            var i = 0;
            while(i++ < 1e15)
            {
                if (i % 100000000 == 0)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("Method 1");
        }

    }
}