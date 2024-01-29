using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace WPFTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        string _firstName;
        string _lastName;
        private int _currentId = 0;

        public MainViewModel() { }
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
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
                GetWebItems();
            });
        }

        public async void GetWebItems()
        {
            using(var client = new HttpClient())
            {
                var builder = new UriBuilder("http://localhost:5200/Test");
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["firstName"] = _firstName;
                query["lastName"] = _lastName;
                builder.Query = query.ToString();
                var response = await client.GetAsync(builder.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = (await response.Content.ReadAsStringAsync()).Trim();
                    var data = JsonConvert.DeserializeObject<IEnumerable<DataReceived>>(jsonData);
                    data.ToList().ForEach(x => DataItems.Add(x)); 
                }
            }

        }
    }
}
