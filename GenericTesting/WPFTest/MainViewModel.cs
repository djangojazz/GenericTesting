using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string _textEntry;
        private int _currentId = 0;

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

        public ObservableCollection<DataReceived> DataItems { get; } = new ObservableCollection<DataReceived>();

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        public ICommand SearchCommand
        {
            get => new RelayCommand(param =>
            {
                _currentId++;
                var dt = DateTime.Now;
                DataItems.Add(new DataReceived { Id = _currentId, Name = _textEntry, Description = dt.ToString() });
            });
        }
    }
}
