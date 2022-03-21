using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _03_Exercise
{
    class Monkey : BaseAnimal
    {
        public Monkey()
        {

        }

        public override void Speak()
        {
            Console.WriteLine("Speak: ooh...ooh...ooh");
        }
        public void Climb()
        {
            Console.WriteLine("Monkey can climb");
        }

        public override int GetType()
        {
            return 1;
        }
    }
}
 