using StudentWebAPI.DataBase;
using StudentWebAPI.Interface;
using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebAPI.Service
{
    public class DbStudentService : IStudentService
    {
        private StudentManagementDB _studentManagementDB;

        public DbStudentService()
        {
            _studentManagementDB = new StudentManagementDB();
        }
        public Student Add(Student student)
        {
            var NewStu = _studentManagementDB.Students.Add(student);
            _studentManagementDB.SaveChanges();
            return NewStu;
        }

        public List<string> GetAllClasses()
        {
            return _studentManagementDB.Students.OrderBy(c => c.Class).Select(c => c.Class).Distinct().ToList();
        }

        public void Remove(int studentId)
        {
            var deletedStudent = _studentManagementDB.Students.FirstOrDefault(s => s.Id == studentId);

            if (deletedStudent != null)
            {
                _studentManagementDB.Students.Remove(deletedStudent);

                _studentManagementDB.SaveChanges();
            }
        }

        public List<Student> SearchStudent(StudentSearchCriteria criteria)
        {
            var result =  _studentManagementDB.Students.Where(s =>
                (string.IsNullOrEmpty(criteria.SearchText) ||
                s.StudentID.ToString().Contains(criteria.SearchText) ||
                s.FirstName.Contains(criteria.SearchText) ||
                s.LastName.Contains(criteria.SearchText) ||
                s.Address.Contains(criteria.SearchText) ||
                s.Email.Contains(criteria.SearchText))
                &&
                (string.IsNullOrEmpty(criteria.ClassName) ||
                s.Class.Contains(criteria.ClassName)
                )
            ).ToList();

            return result;
        }

        public Student Update(Student student)
        {
            _studentManagementDB.Students.AddOrUpdate(student);
            _studentManagementDB.SaveChanges();
            return student;
        }
    }
}
