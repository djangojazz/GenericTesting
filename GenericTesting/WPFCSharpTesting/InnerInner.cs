using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCSharpTesting
{
  public sealed class InnerInner : INotifyPropertyChanged
  {
    private int _id;

    public int Id
    {
      get { return _id; }
      set
      {
        _id = value;
        OnPropertyChanged(nameof(Id));
      }
    }

    private string _desc;

    public string Desc
    {
      get { return _desc; }
      set
      {
        _desc = value;
        OnPropertyChanged(nameof(Desc));
      }
    }
    
    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
