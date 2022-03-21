using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _07_Exercise.Model
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public int StudentId { get; set; }

        public string Class { get; set; }

        public List<Result> Exam { get; set; }
    }
}
