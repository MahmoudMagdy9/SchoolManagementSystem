using GalaSoft.MvvmLight.Command;
using SchoolManagementSystem.Commands;
using SchoolManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace SchoolManagementSystem.ViewModel
{
    public class VMMainWindow : VMBase
    {
        private VMBase _selectedViewModel;

        public VMBase SelectedViewModel
        {
            get { return _selectedViewModel; }
            set {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            
            }


        }

        public ICommand UpdateViewCommand { get; set; }


        public VMMainWindow()
        {
            CloseCommand = new RelayCommand(CloseApp);
            UpdateViewCommand = new UpdateViewCommand(this);
        }

        public RelayCommand CloseCommand { get; }

        private void CloseApp()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
