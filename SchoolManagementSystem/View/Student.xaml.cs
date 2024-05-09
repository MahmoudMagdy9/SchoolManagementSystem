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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace SchoolManagementSystem.View
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : System.Windows.Controls.UserControl
    {
        public static VMStudent VM = new VMStudent();
        public Student()
        {
            InitializeComponent();

            this.DataContext = VM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void OnDataGridPrinting(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                // sizing of the element.
                stdDataGrid.Measure(pageSize);
                stdDataGrid.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(stdDataGrid, "Title");
            }
        }
    }

}
