using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Car
    {
        private string color; // field
        public string Color   // GET/SET method property
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private string Wheel { get; set; } // Short Hand GET/SET method
        public int Speed { get; set; } // Short Hand GET/SET method

        public Car()
        {


        }

        public string Start()
        {
            return "Your car was start...";
        }

    }
}
