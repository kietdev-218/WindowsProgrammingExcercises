using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06_Exercise1.Model
{
    class Student : IComparable<Student>
    {
        public Student()
        {
        }

        public Student(string name, int id)
        {
            Name = name;
            StudentId = id;
        }

        public string Name { get; set; }

        public int StudentId { get; set; }

        public int CompareTo(Student other)
        {
            int result = StudentId.CompareTo(other.StudentId);
            if (result == 0)
            {
                result = Name.CompareTo(other.Name);
            }
            return result;
        }
    }
}
