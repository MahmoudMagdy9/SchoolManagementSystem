using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.ViewModel
{
    public class VMCalculator : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _calctxt;

        public string calctxt
        {
            get { return _calctxt; }
            set { SetProperty(ref _calctxt, value); }

        }

        private void SetProperty(ref string calctxt, string value)
        {
            throw new NotImplementedException();
        }

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private string _KeyPressed;

        public string KeyPressed
        {
            get { return _KeyPressed; }
            set { _KeyPressed = value; OnPropertyChanged("KeyPressed"); }
        }
        private string _buttonPressed;

        public string buttonPressed
        {
            get { return _buttonPressed; }
            set { _buttonPressed = value; }
        }
        void UpdateEnterKeysOnGui()
        {
            string temp = "";
            for (int i = 0; i < Enteredkeys.Count; i++)
                temp += Enteredkeys[i];
            KeyPressed = temp;
        }
        private string Entered_Number;

        public string _Entered_Number
        {
            get { return Entered_Number; }
            set { Entered_Number = value; OnPropertyChanged("Entered_Number"); }
        }


        List<string> Enteredkeys;
        bool FunctionPressed = false;
        public string PreviousEnterKey = "";

        bool PressButton(string pressedBttn)
        {
            if (pressedBttn == "0" || pressedBttn == "1" || pressedBttn == "2" || pressedBttn == "3" ||
                pressedBttn == "4" || pressedBttn == "5" || pressedBttn == "6" || pressedBttn == "7" ||
                pressedBttn == "8" || pressedBttn == "9" || pressedBttn == ".")
            {
                Enteredkeys.Add(pressedBttn);
                UpdateEnterKeysOnGui();

                Enteredkeys.Add(pressedBttn);

                PreviousEnterKey = pressedBttn;

                if (FunctionPressed)
                {
                    Entered_Number = "0";
                    FunctionPressed = false;
                }

                if (Entered_Number == "0")
                    Entered_Number = pressedBttn;
                else
                    Entered_Number += pressedBttn;


                return false;
            }
            return true;

        }
    }
}
