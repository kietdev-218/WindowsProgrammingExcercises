using _06_Exercise2.Model;
using System;
using System.Collections.Generic;

namespace _06_Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            static int GetStudenID()
            {
                Console.Write("Student ID: ");
                int studentID = Int32.Parse(Console.ReadLine());
                return studentID;
            }
            static string GetName()
            {
                Console.Write("What is student name: ");
                string name = Console.ReadLine();
                return name;
            }

            List<Student> listStudent = new List<Student>();
            int numOflist;
            Console.Write("Num Of Student: ");
            numOflist = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOflist; i++)
            {
                Console.WriteLine($"---------- Student {i} ----------");
                Student student = new Student();
                student.StudentId = GetStudenID();
                student.Name = GetName();
                listStudent.Add(student);
            }

            //show list student
            Console.WriteLine($"\n---------- Student ----------");
            foreach (Student item in listStudent)
            {
                Console.WriteLine($"Student ID: {item.StudentId}");
                Console.WriteLine($"Student Name: {item.Name}");
            }

            listStudent.Sort(new Student().Compare);

            //show list student is sorted
            Console.WriteLine($"\n---------- Student is sorted----------");
            foreach (Student item in listStudent)
            {
                Console.WriteLine($"Student ID: {item.StudentId}");
                Console.WriteLine($"Student Name: {item.Name}");
            }
        }
    }
}
