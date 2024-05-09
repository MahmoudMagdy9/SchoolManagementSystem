using System.ComponentModel;

namespace SchoolManagementSystem.ViewModel
{
    public class VMBase : INotifyPropertyChanged
    {
      
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}