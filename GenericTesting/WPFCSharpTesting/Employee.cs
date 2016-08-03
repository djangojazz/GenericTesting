using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFCSharpTesting
{
  public class Employee : INotifyPropertyChanged
  {
    private DateTime _startDate;

    public DateTime StartDate
    {
      get { return _startDate; }
      set
      {
        _startDate = value;
        OnPropertyChanged();
      }
    }

    private string _name;

    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
        OnPropertyChanged();
      }
    }

    private string _title;

    public string Title
    {
      get { return _title; }
      set
      {
        _title = value;
        OnPropertyChanged();
      }
    }

    public static Employee GetEmployee()
    {
      return new Employee { Name = "Brett", Title = "Developer", StartDate = new DateTime(2016, 1, 1) };
    }

    public static ObservableCollection<Employee> GetEmployees()
    {
      return new ObservableCollection<Employee>
      {
        new Employee { Name = "Washington", Title = "President 1" },
        new Employee { Name = "Adams", Title = "President 2" },
        new Employee { Name = "Jefferson", Title = "President 3" },
        new Employee { Name = "Madison", Title = "President 4" },
        new Employee { Name = "Monroe", Title = "President 5" }
      };
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string caller = "")
    {
      if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(caller));
    }
  }
}
