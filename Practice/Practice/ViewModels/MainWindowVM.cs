using Practice.Command;
using Practice.Interface;
using Practice.Models;
using Practice.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Practice.ViewModels
{
    class MainWindowVM : BaseVM
    {
        private string _ContentSearchBox;
        private string _ClassSelected;

        #region get/set
        public string ContentSearchBox
        {
            get => _ContentSearchBox;
            set
            {
                _ContentSearchBox = value;
                OnPropertyChanged(nameof(ContentSearchBox));
            }
        }
        public string ClassSelected
        {
            get => _ClassSelected; set
            {
                _ClassSelected = value;
                OnPropertyChanged(nameof(ClassSelected));
            }
        }

        public IStudentService StudentService { get; set; }

        public ObservableCollection<Student> StudentList { get; set; }

        public ObservableCollection<string> ClassList { get; set; }

        public Student StudentSelected { get; set; }

        #endregion

        public MainWindowVM()
        {
            ButtonSearch = new RelayCommand(parameter => Search(), parameter => !string.IsNullOrEmpty(ContentSearchBox) || !string.IsNullOrEmpty(ClassSelected));
            ButtonReset = new RelayCommand(parameter => Reset());
            MenuAdd = new RelayCommand(parameter => AddMN());
            MenuDelete = new RelayCommand(parameter => DeleteMN(), parameter => StudentSelected != null);
            MenuUpdate = new RelayCommand(parameter => UpdateMN(), parameter => StudentSelected != null);

            StudentService = new StudentWebService();
            StudentList = new ObservableCollection<Student>(StudentService.SearchStudent(new StudentSearchCriteria()));
            ClassList = new ObservableCollection<string>(StudentService.GetAllClasses());

        }

        public void ShowData(string ContentSearch = null, string ClassN = null)
        {
            StudentList.Clear();
            var result = StudentService.SearchStudent(new StudentSearchCriteria { SearchText = ContentSearch, ClassName = ClassN });
            foreach (var item in result)
            {
                StudentList.Add(item);
            }
        }

        #region command
        #region menu add
        public ICommand MenuAdd { get; set; }
        public void AddMN()
        {
            Window window = new NewStudent();
            window.ShowDialog();
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
        #region menu update
        public ICommand MenuUpdate { get; set; }
        public void UpdateMN()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to update the students that you have selected?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.OK:
                    var data = new NewStudentVM
                    {
                        StudentID = StudentSelected.StudentID,
                        FirstName = StudentSelected.FirstName,
                        LastName = StudentSelected.LastName,
                        Birthdate = StudentSelected.Birthdate,
                        Gender = SetGender(StudentSelected.Gender),
                        Address = StudentSelected.Address,
                        Email = StudentSelected.Email,
                        Class = StudentSelected.Class,
                        CheckStudent = StudentSelected
                    };
                    Window window = new NewStudent { DataContext = data };
                    window.ShowDialog();
                    ShowData(ContentSearchBox, ClassSelected);
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }            
        }
        #endregion
        #region menu delete
        public ICommand MenuDelete { get; set; }
        public void DeleteMN()
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete the students that you have selected?", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            switch (result)
            {
                case MessageBoxResult.OK:
                    StudentService.Remove(StudentSelected.Id);
                    ShowData(ContentSearchBox, ClassSelected);
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }
        #endregion
        #region button reset
        public ICommand ButtonReset { get; set; }
        public void Reset()
        {
            ContentSearchBox = null;
            ClassSelected = null;
            ShowData();

        }
        #endregion
        #region Button Search
        public ICommand ButtonSearch { get; set; }
        public void Search()
        {
            StudentList.Clear();
            ShowData(ContentSearchBox, ClassSelected);
        }
        #endregion
        #endregion
    }
}
