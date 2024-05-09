using SchoolManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime;
using System.Runtime.InteropServices;
using SchoolManagementSystem.View;
using CEISubjects = SchoolManagementSystem.View.CEISubjects;

namespace SchoolManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //DataContext = new VMCalculator();
            InitializeComponent();
            DataContext = new VMMainWindow();

        }
        [DllImport("user32.dll")]

        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnMaxmize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {

                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }


        }
        private void btnMinmize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();
            //student.Show();
        }
        private void teacher_Click(object sender, RoutedEventArgs e)
        {
            Teacher teacher = new Teacher();
            //teacher.Show();
        }
        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            Calculator calculator = new Calculator();
            calculator.Show();
        }

        private void Subject_Click(object sender, RoutedEventArgs e)
        {
            CEISubjects ceiSubjects = new CEISubjects();
        }
        //private void Home_Click(object sender, RoutedEventArgs e)
        //{
        //    Home home = new Home();
        //    home.Show();
        //}
    }
}
