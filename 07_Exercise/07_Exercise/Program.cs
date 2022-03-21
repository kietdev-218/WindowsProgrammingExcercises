using _07_Exercise.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace _07_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Dataset));
            StreamReader file = new StreamReader(@"D:\Users\KLK\OneDrive\Documents\GitHub\WindowsProgrammingExcercises\07_Exercise\07_Exercise\student_sample_data.xml");

            var data = (Dataset)reader.Deserialize(file);
            file.Close();

            //ListData(data.Students, s => $"{s.FirstName} {s.LastName}");      
            //ListClassA1(data);                                                
            //StatisticGender(data);                                            
            //StatisticClass(data);                                             
            //StatisticCity(data);                                                          
            //CalculateGPA(data);                                                    
            //HighestGPA(data);                                                 
            //RepeatSubject(data);                                                
            //BestOfEachSubject(data);                                               
            //WorstOfEachSubject(data);                                          
            //AverageScoreEachSubject(data);                                    
            //FindGoodStudent(data);                                            
            Console.ReadLine();
        }

        private static void ListData<T>(IEnumerable<T> data, Func<T, string> selector)
        {
            foreach (var s in data.ToList())
            {
                Console.WriteLine(selector.Invoke(s));
            }
        }

        private static void ListClassA1(Dataset data)
        {
            var classA1 = data.Students.Where(s => s.Class == "18DTHQA1");
            var resOrder = classA1.OrderBy(s => s.FirstName);
            foreach (var c in resOrder)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName} - {c.Id} ");
            }
        }

        private static void StatisticGender(Dataset data)
        {
            var gender = data.Students.GroupBy(s => s.Gender, s => s.Id,
                                                (k, v) => new { Gender = k, Number = v.Count() });
            foreach (var g in gender)
            {
                Console.WriteLine($"{g.Gender} : {g.Number}");
            }
        }
        
        private static void StatisticClass(Dataset data)
        {
            var sclass = data.Students.GroupBy(s => s.Class, s => s.Id,
                                                (k, v) => new { Class = k, Number = v.Count() });
            foreach (var c in sclass)
            {
                Console.WriteLine($"{c.Class} : {c.Number}");
            }
        }

        private static void StatisticCity(Dataset data)
        {
            var city = data.Students.GroupBy(s => s.City, s => s.Id,
                                                (k, v) => new { City = k, Number = v.Count() });
            foreach (var c in city)
            {
                Console.WriteLine($"{c.City} : {c.Number}");
            }
        }

        private static void CalculateGPA(Dataset data)
        {
            var gpaData = data.Students.Select(s => new { Name = $"{s.FirstName} {s.LastName}", Gpa = s.Exam.Average(e => e.Score) });
            foreach (var g in gpaData)
            {
                Console.WriteLine($"{g.Name} : {g.Gpa}");
            }
        }

        private static void HighestGPA(Dataset data)
        {
            var gpaData = data.Students.Select(s => new { Name = $"{s.FirstName} {s.LastName}", Gpa = s.Exam.Average(e => e.Score) });
            var maxGPA = gpaData.Where(s => s.Gpa == gpaData.Max(m => m.Gpa));
            foreach (var m in maxGPA)
            {
                Console.WriteLine($"{m.Name} : {m.Gpa}");
            }
        }

        private static void RepeatSubject(Dataset data)
        {
            var rs = data.Students.Where(s => s.Exam.Any(x => x.Score < 5));
            foreach (var r in rs)
            {
                Console.WriteLine($"{r.FirstName} {r.LastName}");
            }
        }

        private static void BestOfEachSubject(Dataset data)
        {
            var allSubject = data.Students.SelectMany(a => a.Exam);
            var GroupSubject = allSubject.GroupBy(a => a.Subject);
            foreach (var g in GroupSubject)
            {
                Console.WriteLine($"\n{g.Key}:");
                double maxScore = allSubject.Max(m => m.Score);
                var BestStudentEachSubject = data.Students.Where(s => s.Exam.Any(e => e.Subject == g.Key && e.Score == maxScore));
                foreach (var s in BestStudentEachSubject)
                {
                    Console.WriteLine($"\t{s.FirstName} {s.LastName}: {maxScore}");
                }
            }

        }

        private static void WorstOfEachSubject(Dataset data)
        {
            var allSubject = data.Students.SelectMany(a => a.Exam);
            var GroupSubject = allSubject.GroupBy(a => a.Subject);
            foreach (var g in GroupSubject)
            {
                Console.WriteLine($"\n{g.Key}:");
                double minScore = allSubject.Min(m => m.Score);
                var BestStudentEachSubject = data.Students.Where(s => s.Exam.Any(e => e.Subject == g.Key && e.Score == minScore));
                foreach (var s in BestStudentEachSubject)
                {
                    Console.WriteLine($"\t{s.FirstName} {s.LastName}: {minScore}");
                }
            }

        }

        private static void AverageScoreEachSubject(Dataset data)
        {
            var allSubject = data.Students.SelectMany(a => a.Exam);
            var GroupSubject = allSubject.GroupBy(a => a.Subject);
            foreach (var g in GroupSubject)
            {
                var avg = allSubject.Where(a => a.Subject == g.Key);
                double avgscore = avg.Average(a => a.Score);
                Console.WriteLine($"{g.Key}: {Math.Round(avgscore, 1)}");
            }
        }

        private static void FindGoodStudent(Dataset data)
        {
            var NotBadStudent = data.Students.Where(s => s.Exam.All(e => e.Score > 5));
            var GoodStudent = NotBadStudent.Where(s => s.Exam.Average(e => e.Score) > 7);
            foreach (var g in GoodStudent)
            {
                Console.WriteLine($"{g.FirstName} {g.LastName}");
            }
        }
    }
}
