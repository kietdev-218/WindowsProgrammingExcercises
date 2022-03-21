using _04_Excercisel.Model;
using _04_Excercisel.Repository;
using System;
using System.Collections.Generic;

namespace _04_Excercisel
{
    class Program
    {
        private static List<Student> s_students = new List<Student>();
        private static List<Class> s_classes = new List<Class>();
        static void Main(string[] args)
        {
            IRepository<Class> classRepository = new BaseRepository<Class>(s_classes);
            IRepository<Student> studentRepository = new BaseRepository<Student>(s_students);

            classRepository.Add(new Class("18DTHQA1"));
            classRepository.Add(new Class("18DTHQA2"));

            studentRepository.Add(new Student("Nguyen Van A", 4576));
            studentRepository.Add(new Student("Tran B", 2257));
            studentRepository.Add(new Student("Phan Van C", 9008));

            Console.WriteLine("List all classes");
            foreach (var c in classRepository.GetAll())
            {
                Console.WriteLine(c.Name);
            }

            Console.WriteLine("List all students");
            foreach (var student in studentRepository.GetAll())
            {
                Console.WriteLine(student.Name);
            }
        }
    }
}
