using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Exercise
{
    interface IAnimal
    {
        DateTime Brithdate { get; set; }
        int Move { get; set; }
        void Speak();
        int GetType();
    }
}
