using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCSharpTesting
{
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    private string _text;

    public string Text
    {
      get { return _text; }
      set
      {
        _text = value;
        OnPropertyChanged(nameof(Text));
      }
    }

    public MainWindowViewModel()
    {
      Text = "hello";
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(String info)
    {
      if (PropertyChanged != null)
      {
        PropertyChanged(this, new PropertyChangedEventArgs(info));
      }
    }
  }
}
