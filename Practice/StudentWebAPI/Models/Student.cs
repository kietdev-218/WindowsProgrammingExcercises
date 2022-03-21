using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWebAPI.Models
{
    [Table("Student")]
    public class Student
    {
        private int _Id;
        private int _StudentID;
        private string _FirstName;
        private string _LastName;
        private DateTime _Birthdate;
        private string _Gender;
        private string _Address;
        private string _Email;
        private string _Class;

        [Key]
        public int Id { get => _Id; set => _Id = value; }
        public int StudentID { get => _StudentID; set => _StudentID = value; }
        public string FirstName { get => _FirstName; set => _FirstName = value; }
        public string LastName { get => _LastName; set => _LastName = value; }
        public DateTime Birthdate { get => _Birthdate; set => _Birthdate = value; }
        public string Gender { get => _Gender; set => _Gender = value; }
        public string Address { get => _Address; set => _Address = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Class { get => _Class; set => _Class = value; }

        public override string ToString()
        {
            return FirstName + LastName;
        }
    }
}
