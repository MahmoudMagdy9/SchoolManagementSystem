using SchoolManagementSystem.Model;
using SchoolManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolManagementSystem.View
{
    /// <summary>
    /// Interaction logic for AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        private readonly VMStudent vMStudent;

        public AddStudent(VMStudent vMStudent)
        {
            InitializeComponent();
            this.vMStudent = vMStudent;
            DataContext = vMStudent;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            if (SubComboBox.SelectedValue != null && GradeCombobox.SelectedValue != null)
            {
                SubjectListBox.Items.Add((SubjectName)SubComboBox.SelectedIndex);
                GradeListBox.Items.Add((GradeName)GradeCombobox.SelectedIndex);
            }
            else { MessageBox.Show("Select Subject & Grade"); }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            int studentId;

            if (!int.TryParse(Id.Text, out studentId))
            {
                MessageBox.Show("Enter Student ID");
            }
            else if (string.IsNullOrEmpty(Name.Text))
            {
                MessageBox.Show("Enter Student Name");
            }
            else if (GenderComboBox.SelectedValue == null)
            {
                MessageBox.Show("Enter Student Gender");
            }
            else if (ClassComboBox.SelectedValue == null)
            {
                MessageBox.Show("Enter Student Class");
            }
            else if (!SubjectListBox.HasItems)
            {
                MessageBox.Show("Enter at least One Subject");
            }
            else
            {

                if (ClassComboBox.SelectedItem is ComboBoxItem selectedClassItem && selectedClassItem.Tag is Classes selectedClass)
                {
                    
                    vMStudent.AddStudent(studentId, Name.Text, (Gender)GenderComboBox.SelectedIndex, Classes.Class2, 
                         new ObservableCollection<Subject>() { new Subject(SubjectName.Cpp, GradeName.A) });

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid selected class");
                }
            }
        }
    }
}
