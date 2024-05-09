using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Model
{
    public class Subject
    {

        public SubjectName subjectName { get; set; }
        public GradeName Grade { get; set; }

        public Subject(SubjectName s, GradeName g) { subjectName = s; Grade = g; }

        public ICollection<Student> Student { get; set; } = new HashSet<Student>();


    }
}
