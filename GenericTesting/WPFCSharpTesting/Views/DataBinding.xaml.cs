using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace WPFCSharpTesting.Views
{
  /// <summary>
  /// Interaction logic for DataBinding.xaml
  /// </summary>
  public partial class DataBinding : UserControl
  {
    private Employee emp;

    public DataBinding()
    {
      InitializeComponent();
      DataContext = Employee.GetEmployee();
      // part 3 binding DataContext = Employee.GetEmployees();
    }
                        
  }
}
