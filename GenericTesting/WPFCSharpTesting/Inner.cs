using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCSharpTesting
{
  public sealed class Inner : INotifyPropertyChanged
  {
    private InnerInner _prop;

    public InnerInner Prop
    {
      get { return _prop; }
      set
      {
        if(_prop != null) { UnBind(_prop);  }
        _prop = value;
        if(_prop != null) { Bind(_prop);  }
        OnPropertyChanged(nameof(Prop));
      }
    }

    private void UnBind(InnerInner prop)
    {
      prop.PropertyChanged -= CascadeEvent;
    }

    private void Bind(InnerInner prop)
    {
      prop.PropertyChanged += CascadeEvent;
    }

    private void CascadeEvent(object sender, PropertyChangedEventArgs e)
    {
      OnPropertyChanged(nameof(Prop));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
