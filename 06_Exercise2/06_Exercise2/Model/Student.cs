using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _06_Exercise2.Model
{
    class Student : IComparer<Student>
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

        public int Compare(Student x, Student y)
        {
            int result = x.Name.CompareTo(y.Name);
            if (result == 0)
            {
                result = x.StudentId.CompareTo(y.StudentId);
            }
            return result;
        }
    }
}
