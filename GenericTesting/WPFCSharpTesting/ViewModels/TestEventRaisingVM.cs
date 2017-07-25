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
    public delegate void ParameterChange(string parameter);
    public ParameterChange OnParameterChange { get; set; }


    public TestEventRaisingVM()
    {
      Parm = "Test";
    }

    private string _parm;

    public string Parm
    {
      get { return _parm; }
      set
      {
        _parm = value;
        OnPropertyChanged("Parm");
        OnParameterChange?.Invoke(_parm);
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged(String info)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
    }
  }
}
