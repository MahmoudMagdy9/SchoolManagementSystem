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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SchoolManagementSystem.View
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        int first, second;
        char op;
        public Calculator()
        {
            InitializeComponent();
        }
        private void Operator_Click(object sender, RoutedEventArgs e)
        {

            Button btn = (Button)sender;
            op = btn.Content.ToString()[0];
            first = int.Parse(txtresult.Text);
            txtresult.Clear();
        }
        private void HandleOperator(char operatorChar)
        {
            first = int.Parse(txtresult.Text);
            op = operatorChar;
            txtresult.Clear();
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            HandleOperator('/');

        }
        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            HandleOperator('-');

        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            HandleOperator('+');

        }
        private void Multi_Click(object sender, RoutedEventArgs e)
        {
            HandleOperator('*');

        }
        private int Factorial(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);

            }
        }
        private void CalculateResult()
        {
            int result = 0;
            // Existing calculation logic...
            txtresult.Text = result.ToString();

        }

        private void Factorial_Click(object sender, RoutedEventArgs e)
        {
            int result=0;
            op = '!';
            if (int.TryParse(txtresult.Text, out int inputValue))
            {
                if (inputValue >= 0)
                {
                    result = Factorial(inputValue);
                    txtresult.Text = result.ToString();
                }
                else
                {
                    MessageBox.Show("Factorial is undefined for negative numbers", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid input for factorial. Please enter a non-negative integer.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                second = int.Parse(txtresult.Text);
                CalculateResult();
                int result = 0;
                if (op=='+')
                {
                    result = first + second;

                }
                else if (op == '-')
                {
                    result = first - second;

                }
                else if (op == '*')
                {
                    result = first * second;

                }
                else if (op == '/')
                {
                    try
                    {
                        if (second == 0)
                        {
                            txtresult.Text = "Cannot divide"+"\n by zero";
                            return;
                        }
                        else
                        {
                            result = first / second;
                        }
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (op == '!')
                {
                    // Handle factorial operation
                    if (first >= 0)
                    {
                        result = Factorial(first);
                        return;

                    }
                    else
                    {
                        MessageBox.Show("Factorial is undefined for negative numbers", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return; // Exit the method to avoid further processing
                    }
                }
                if (txtresult.Text =="0")
                {
                    txtresult.Clear();

                }
                txtresult.Text = result.ToString();
            }

            catch (FormatException)

            {
                MessageBox.Show("Invalid input", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void AppendToTextBox(string value)
        {
            txtresult.Text += value;
        }

        private void dot_click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox(".");
        }
        private void zero_click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox("0");
        }


        private void nine_click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox("9");
        }
        private void eight_click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox("8");
        }

        private void seven_click(object sender, RoutedEventArgs e)
        {

            AppendToTextBox("7");
        }
        private void six_click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox("6");
        }
        private void five_Click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox("5");
        }
        private void four_Click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox("4");
        }
        private void three_Click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox("3");
        }
        private void two_Click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox("2");
        }



        private void one_Click(object sender, RoutedEventArgs e)
        {
            AppendToTextBox("1");
        }
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            first = second = 0;
            op = '\0';
            txtresult.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clearEntry_Click(object sender, RoutedEventArgs e)
        {
            txtresult.Clear();
        }
        private void ClearOne_Click(object sender, RoutedEventArgs e)
        {
            if (txtresult.Text.Length > 0)
            {
                txtresult.Text = txtresult.Text.Substring(0, txtresult.Text.Length - 1);
            }
        }

    }
}
