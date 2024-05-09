using SchoolManagementSystem.View;
using SchoolManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolManagementSystem.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private VMMainWindow viewModel;

        public event EventHandler CanExecuteChanged;
        public UpdateViewCommand(VMMainWindow viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            //throw new NotImplementedException();
            return true;

        }

        public void Execute(object parameter)
        {
            if (parameter is string viewName)
            {
                switch (viewName)
                {
                    case "Student":
                        viewModel.SelectedViewModel = new VMStudent(); // Replace YourStudentUserControl with the actual name of your UserControl
                        break;
                    case "Home":
                        viewModel.SelectedViewModel = new VMHome();
                        break;
                    case "Teacher":
                        viewModel.SelectedViewModel = new VMTeacher();
                        break;
                    case "CEISubjects":
                        viewModel.SelectedViewModel = new VMCEISubjects();
                        break;
                }
                
            }
        }
    }
}
