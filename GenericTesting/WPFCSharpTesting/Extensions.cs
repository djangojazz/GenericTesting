using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFCSharpTesting
{
  public static class Extensions
  {
    public static void OnLoadedOnce(
    this UserControl control,
    RoutedEventHandler onLoaded)
    {
      if (control == null || onLoaded == null)
      {
        throw new ArgumentNullException();
      }

      RoutedEventHandler wrappedOnLoaded = null;
      wrappedOnLoaded = delegate (object sender, RoutedEventArgs e)
      {
        control.Loaded -= wrappedOnLoaded;
        onLoaded(sender, e);
      };
      control.Loaded += wrappedOnLoaded;
    }
  }
}
