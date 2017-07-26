using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFCSharpTesting.ViewModels
{
  public class TestEventRaisingVM: INotifyPropertyChanged
  {
    public TestEventRaisingVM(string input)
    {
      Parm = input;
    }

    private string _parm;

    public string Parm
    {
      get { return _parm; }
      set
      {
        _parm = value;
        MessageBox.Show("Changed");
        OnPropertyChanged("Parm");
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(String info)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }
  }
}
