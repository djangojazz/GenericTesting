using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFCSharpTesting.Views
{
  /// <summary>
  /// Interaction logic for TabControl.xaml
  /// </summary>
  public partial class OtherControls : UserControl
  {
    public OtherControls()
    {
      InitializeComponent();
      //dataGrid.ItemsSource = Employee.GetEmployees();
    }

    private void Help_Click(object sender, RoutedEventArgs e)
    {
      System.Windows.Forms.MessageBox.Show("This is a help dialog");
    }
  }
}
