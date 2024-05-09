using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public decimal Salary { get; set; }

        private Gender gender;

        public Gender _Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public Classes classes { get; set; }

        public String Subject { get; set; }



    }
}
