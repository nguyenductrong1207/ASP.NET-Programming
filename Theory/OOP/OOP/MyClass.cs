using System;
using OOP;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP
{
    class MyClass
    {
        public string Color = "Blue";
        public int MaxSpeed = 200;

        public MyClass(string color, int maxSpeed)
        {
            Color = color;
            MaxSpeed = maxSpeed;
        }

        public void ShowColor()
        {
            Console.WriteLine("My color is: " + Color);
        }

        public void ShowSpeed()
        {
            Console.WriteLine("My speed is " + MaxSpeed + "km/h");
        }


    }
}