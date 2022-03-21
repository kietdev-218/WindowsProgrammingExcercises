using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Exercise
{
    class Cat : Pet
    {
        public Cat()
        {

        }

        public override void Speak()
        {
            Console.WriteLine("Speak: Meo...Meo...Meo");
        }
        public void Jump()
        {
            Console.WriteLine("Cat can jump");
        }
        public override int GetType()
        {
            return 2;
        }
    }
}
