using StudentWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebAPI.DataBase
{
    public class StudentManagementDB : DbContext
    {
        public StudentManagementDB() : base("Server=LAPTOP-FR2VKP2\\SQLEXPRESS;Database=StudentManagementDb;Trusted_Connection=True;")
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
