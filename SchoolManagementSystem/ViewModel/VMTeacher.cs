using GalaSoft.MvvmLight.Command;
using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SchoolManagementSystem.ViewModel
{
    public class VMTeacher : VMBase, INotifyPropertyChanged
    {


        public ObservableCollection<Teacher> Teacheres { get; set; }

        public VMTeacher()
        {
            Teacheres = new ObservableCollection<Teacher>()
              {
                  new Teacher()
                  {
                     Id=1, Name="Eng.Ahmed Mohey" , Salary=20000,_Gender=Gender.Male, classes=Classes.Class1 , Subject = "C++"
                  },
                   new Teacher()
                  {
                     Id=2, Name="Eng.Ahmed Adel" , Salary=40000,_Gender=Gender.Male, classes=Classes.Class1 , Subject = "Sql Server"
                  }, new Teacher()
                  {
                     Id=3, Name="Eng.Mahmoud ouf" , Salary=20000,_Gender=Gender.Male, classes=Classes.Class3 , Subject = "OOP"
                  }, new Teacher()
                  {
                     Id=3, Name="Eng.Ahmed Gamel" , Salary=20000,_Gender=Gender.Male, classes=Classes.Class3 , Subject = "Revit API"
                  }, new Teacher()
                  {
                     Id=3, Name="Dr.Adly" , Salary=20000,_Gender=Gender.Male, classes=Classes.Class3 , Subject = "Network"
                  },
              };

            
            //loadStd();
            AddCommand = new RelayCommand(AddData);
            EditCommand = new RelayCommand(EditData);
            RemoveCommand = new RelayCommand(RemoveData);
            SaveCommand = new RelayCommand(SaveData);

        }

        private void SaveData()
        {


        }

        private void loadStd()
        {
            //Teacheres.Clear();
            foreach (var t in Teacheres)
            {
                Teacheres.Add(t);
            }
        }

        private void RemoveData()
        {

            if (selectedTchr != null)
            {
                Teacheres.Remove(selectedTchr);
            }
        }


        private Teacher selectedTchr;

        public Teacher SelectedTchr
        {
            get
            {
                return selectedTchr;
            }
            set
            {
                if (selectedTchr != value)
                {
                    selectedTchr = value;
                    OnPropertyChanged(nameof(selectedTchr));
                }
            }
        }

        private void EditData()
        {
            if (selectedTchr != null)
            {
                //SetData();
                //View.AddStudent addStudent = new View.AddStudent(this);
                //addStudent.Show();

            }
            else
            {

                MessageBox.Show("Select Student To Edit");
            }
        }

        private void SetData()
        {
            Teacher t = new Teacher
            {
                Id = selectedTchr.Id,
                Name = selectedTchr.Name,
                _Gender = selectedTchr._Gender,
                Salary = selectedTchr.Salary,
                classes = selectedTchr.classes,
                Subject = selectedTchr.Subject
            };
        }

        private void AddData()
        {

            Teacheres.Add(new Teacher());

        }

        private void ClearData()
        {
            Teacheres.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand SaveCommand { get; }
    }

}
