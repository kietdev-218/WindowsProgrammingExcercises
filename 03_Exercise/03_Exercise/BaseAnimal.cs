using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Exercise
{
    class BaseAnimal : IAnimal
    {     
        private DateTime _DateTime;
        private int _Index;
        public DateTime Brithdate
        {
            get
            {
                return this._DateTime;
            }
            set
            {
                this._DateTime = value;
            }
        }

        public int Move
        {
            get
            {
                return this._Index;
            }
            set
            {
                this._Index = value;
            }
        }

        public virtual void Speak()
        {
            Console.WriteLine("Speak: ");
        }

        public virtual int GetType()
        {
            return -1;
        }
    }
}
