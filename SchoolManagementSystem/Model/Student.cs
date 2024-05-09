using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using SchoolManagementSystem.View;

namespace SchoolManagementSystem.Model
{
    public class Student
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public Classes classes { get; set; }

        private Gender gender;

        public Gender _Gender
        {
            get { return gender; }
            set { gender = value; }
        }


        public ObservableCollection<Subject> Sub { get; set; }

        public ObservableCollection<Subject> Subject { get; set; }


  
    }
}
