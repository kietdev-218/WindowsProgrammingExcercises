using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Exercise
{
    class Dog : Pet
    {
        private string _Color;
        public Dog()
        {

        }

        public override void Speak()
        {
            Console.WriteLine("Speak: Go...Go...Go");
        }
        public string Color
        {
            get
            {
                return this._Color;
            }
            set
            {
                this._Color = value;
            }
        }
        public override int GetType()
        {
            return 3;
        }
    }
}
