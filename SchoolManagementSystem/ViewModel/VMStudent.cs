using GalaSoft.MvvmLight.CommandWpf;
using SchoolManagementSystem.Model;
using SchoolManagementSystem.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.Forms.MessageBox;
using Student = SchoolManagementSystem.Model.Student;

namespace SchoolManagementSystem.ViewModel
{
    public class VMStudent : VMBase, INotifyPropertyChanged
    {
        private Student student;

        public ObservableCollection<Student> Students { get; set; }

        public VMStudent()
        {
            student = new Student();

            Students = new ObservableCollection<Student>()
              {
                  new Student()
                  {
                     Id=1, FullName="Mahmoud Magdy" ,Age=24,_Gender=Gender.Male, classes=Classes.Class1 , 
                      Sub =new ObservableCollection<Subject>() {  new Subject(SubjectName.Cpp, GradeName.A) }

                  },
                   new Student()
                  {
                     Id=2, FullName="Mahmoud Awad" ,Age=22,_Gender=Gender.Male, classes=Classes.Class1,
                                           Sub =new ObservableCollection<Subject>() {  new Subject(SubjectName.DataStructure, GradeName.A) }

                  }, new Student()
                  {
                     Id=3, FullName="Mazen Magdy" ,Age=20,_Gender=Gender.Male, classes=Classes.Class3 ,
                                           Sub =new ObservableCollection<Subject>() {  new Subject(SubjectName.Network, GradeName.B) }

                  },
              };

            // Initialize the student object



            //loadStd();
            AddCommand = new RelayCommand(AddData);
            EditCommand = new RelayCommand(EditData);
            RemoveCommand = new RelayCommand(RemoveData);
            SaveCommand = new RelayCommand(SaveData);

        }
        public void AddSubject(SubjectName subjectName, GradeName gradeName)
        {
            // Ensure student.Subject is initialized
            if (student.Subject == null)
            {
                student.Subject = new ObservableCollection<Subject>();
            }

            Subject subject = new Subject(subjectName, gradeName);
            student.Subject.Add(subject);
        }

        public void AddStudent(int id, string name, Gender gender, Classes studentClass, ObservableCollection<Subject> subjects)
        {
            // Assuming student is an instance variable or a parameter passed to this method
            if (student == null)
            {
                // Create a new instance of the Student class if it's not already initialized
                student = new Student();
            }

            // Assuming Subject property is initialized in the Student class constructor or elsewhere

            // Create a new ObservableCollection<Subject> based on the existing subjects in student
            //ObservableCollection<Subject> subjects = new ObservableCollection<Subject>(student.Subject);

            // Create a new student with the provided data and the subjects from the existing student
            Student newStudent = new Student
            {
                Id = id,
                FullName = name,
                _Gender = gender,
                classes = studentClass,
                Sub=subjects
            };

            // Add the new student to the Students collection
            Students.Add(newStudent);
        }
        private void SaveData()
        {
            // check user add or edit
            if (SelectedStd != null)
            {
                // edit
                Student updatedStudent = new Student
                {
                    Id = selectedStd.Id,
                    FullName = selectedStd.FullName,
                    Age = selectedStd.Age,
                    _Gender = selectedStd._Gender,
                    classes = selectedStd.classes,
                    Subject = new ObservableCollection<Subject>(selectedStd.Subject)
                };

                Students.Add(updatedStudent);
            }
            else
            {
                // add
                Student newStudent = new Student
                {
                    Id = student.Id,
                    FullName = student.FullName,
                    Age = student.Age,
                    _Gender = student._Gender,
                    classes = student.classes,
                    Subject = new ObservableCollection<Subject>(student.Subject)
                };

                Students.Add(newStudent);
            }

            loadStd();
        }
        private void loadStd()
        {
            Students.Clear();
            foreach (var st in Students)
            {
                Students.Add(st);
            }
        }

        private void RemoveData()
        {

            if (SelectedStd != null)
            {
                Students.Remove(SelectedStd);
            }
        }


        private Student selectedStd;

        public Student SelectedStd
        {
            get
            {
                return selectedStd;
            }
            set
            {
                if (selectedStd != value)
                {
                    selectedStd = value;
                    OnPropertyChanged(nameof(SelectedStd));
                }
            }
        }

        private void EditData()
        {
            if (SelectedStd != null)
            {
                SetData();
                View.AddStudent addStudent = new View.AddStudent(this);
                addStudent.Show();

            }
            else
            {

                MessageBox.Show("Select Student To Edit");
            }
        }

        private void SetData()
        {
            Student st = new Student
            {
                FullName = selectedStd.FullName,
                _Gender = selectedStd._Gender,
                Age = selectedStd.Age,
                classes = selectedStd.classes,
                Subject = selectedStd.Subject
            };
        }

        private void AddData()
        {
            //clear data
            //ClearData();
            //open add user
            View.AddStudent addStudent = new View.AddStudent(this);
            addStudent.Show();
        }

        private void ClearData()
        {
            Students.Clear();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand RemoveCommand { get; }
        public ICommand SaveCommand { get; }
    }
}
