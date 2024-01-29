using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string _textEntry;

        public MainViewModel() 
        {
            TextEntry = "Setup";
        }

        public string TextEntry
        {
            get => _textEntry;
            set
            {
                _textEntry = value;
                OnPropertyChanged(nameof(TextEntry));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
