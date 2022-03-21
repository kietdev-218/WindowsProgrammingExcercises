using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Excercisel.Model
{
    public class Student
    {
        public Student(string name, int id)
        {
            Name = name;
            StudentId = id;
        }

        public string Name { get; set; }

        public int StudentId { get; set; }
    }
}
