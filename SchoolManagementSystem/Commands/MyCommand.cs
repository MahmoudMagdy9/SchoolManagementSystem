using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Commands
{
    public class MyCommand
    {
        #region Events
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Constructors
        public MyCommand(Action<object> _execute, Predicate<object> _canexecute)
        {
            ExecuteProp = _execute;
            CanExecuteProp = _canexecute;
        }
        #endregion

        #region Poperties
        //Excecute Property
        public Action<object> ExecuteProp { get; set; }

        //Can Excecutr Property
        public Predicate<object> CanExecuteProp { get; set; }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return CanExecuteProp(parameter);
        }

        public void Execute(object parameter)
        {
            ExecuteProp(parameter);
        }
        #endregion
    }
}
