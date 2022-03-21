using System;
using System.Collections.Generic;
using System.Text;

namespace _03_Exercise
{
    class Pet : BaseAnimal
    {
        public Pet()
        {

        }
        private string _Name;
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }
    }
}
