using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCSharpTesting
{
  public sealed class Outer : INotifyPropertyChanged
  {
    private ObservableCollection<Inner> _inners;

    public Outer(List<Inner> innersToSubmit)
    {
      _inners = new ObservableCollection<Inner>();
      _inners.CollectionChanged += ModifyCollectionsBindings;
      _inners.Clear();
      innersToSubmit.ForEach(x => _inners.Add(x));
    }

    private void ModifyCollectionsBindings(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
      if (e?.OldItems != null)
      {
        foreach (var arg in e?.OldItems)
        {
          ((INotifyPropertyChanged)arg).PropertyChanged -= CascadeEvent;
        }
      }

      if (e?.NewItems != null)
      {
        foreach (var arg in e?.NewItems)
        {
          ((INotifyPropertyChanged)arg).PropertyChanged += CascadeEvent;
        }
      }
    }

    private void CascadeEvent(object sender, PropertyChangedEventArgs e)
    {
      OnPropertyChanged(nameof(Inners));
    }

    public ObservableCollection<Inner> Inners { get; }


    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
