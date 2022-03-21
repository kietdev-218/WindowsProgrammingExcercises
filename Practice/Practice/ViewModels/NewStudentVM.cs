using Practice.Command;
using Practice.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Practice.ViewModels
{
    class NewStudentVM : MainWindowVM, IDataErrorInfo
    {
        private int _StudentID;
        private string _FirstName;
        private string _LastName;
        private DateTime _Birthdate = DateTime.Now;
        private bool _Gender;
        private string _Address;
        private string _Email;
        private string _class;

        #region Get/Set
        public int StudentID { get => _StudentID; set { _StudentID = value; OnPropertyChanged(nameof(StudentID)); } }
        public string FirstName { get => _FirstName; set { _FirstName = value; OnPropertyChanged(nameof(FirstName)); } }
        public string LastName { get => _LastName; set { _LastName = value; OnPropertyChanged(nameof(LastName)); } }
        public DateTime Birthdate { get => _Birthdate; set { _Birthdate = value; OnPropertyChanged(nameof(Birthdate)); } }
        public bool Gender { get => _Gender; set { _Gender = value; OnPropertyChanged(nameof(Gender)); } }
        public string Address { get => _Address; set { _Address = value; OnPropertyChanged(nameof(Address)); } }
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(nameof(Email)); } }
        public string Class { get => _class; set { _class = value; OnPropertyChanged(nameof(Class)); } }
        public Student CheckStudent { get; set; }
        #endregion

        public NewStudentVM()
        {
            ButtonSave = new RelayCommand(o => Save(), o => !(StudentID <= 0)
             && !string.IsNullOrEmpty(FirstName)
             && !string.IsNullOrEmpty(LastName)
             && !(Birthdate > DateTime.Now));
        }

        #region gender convert
        public string GetGender(bool Check)
        {
            if (Check)
            {
                return "Male";
            }
            return "Female";
        }

        public bool SetGender(string Gen)
        {
            if (Gen.Contains("Male"))
            {
                return true;
            }
            return false;
        }
        #endregion


        #region Bao Do
        public string this[string columnName]
        {
            get
            {
                string result = string.Empty;
                #region Student ID box
                if (nameof(StudentID) == columnName)
                {
                    if (StudentID <= 0)
                    {
                        result = "Student ID is mandatory & not Negaive and Different";
                    }
                }
                #endregion

                #region First Name box
                if (nameof(FirstName) == columnName)
                {
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        result = "First Name is mandatory";
                    }
                }
                #endregion

                #region Last Name box
                if (nameof(LastName) == columnName)
                {
                    if (string.IsNullOrEmpty(LastName))
                    {
                        result = "Last Name is mandatory";
                    }
                }
                #endregion

                #region Birthdate box
                if (nameof(Birthdate) == columnName)
                {
                    if (Birthdate > DateTime.Now)
                    {
                        result = "Please select day is less than date now";
                    }
                }
                #endregion

                return result;
            }
        }
        public string Error => throw new NotImplementedException();
        #endregion

        #region Command
        public ICommand ButtonSave { get; set; }
        public void Save()
        {
            if (CheckStudent == null)
            {
                Student NewStu = new Student
                {
                    StudentID = StudentID,
                    FirstName = FirstName,
                    LastName = LastName,
                    Birthdate = Birthdate,
                    Gender = GetGender(Gender),
                    Address = Address,
                    Email = Email,
                    Class = Class,
                };
                StudentService.Add(NewStu);
            }
            else
            {
                CheckStudent.StudentID = StudentID;
                CheckStudent.FirstName = FirstName;
                CheckStudent.LastName = LastName;
                CheckStudent.Birthdate = Birthdate;
                CheckStudent.Gender = GetGender(Gender);
                CheckStudent.Address = Address;
                CheckStudent.Email = Email;
                CheckStudent.Class = Class;
                StudentService.Update(CheckStudent);
            }            
        }

        public ICommand ButtonCancel { get; set; }
        public void Cancel()
        {
            
        }
        #endregion
    }
}
