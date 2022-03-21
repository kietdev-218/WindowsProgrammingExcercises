using Practice.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice.Interface
{
    public interface IStudentService
    {
        List<Student> SearchStudent(StudentSearchCriteria criteria);

        List<string> GetAllClasses();

        Student Add(Student student);

        Student Update(Student student);

        void Remove(int studentId);

    }
}
