using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebAPI.Interface
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
