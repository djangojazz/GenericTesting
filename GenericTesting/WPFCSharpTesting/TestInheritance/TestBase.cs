using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFCSharpTesting.TestInheritance
{
  public abstract class TestBase : UserControl
  {
    public static readonly DependencyProperty TestProperty = DependencyProperty.Register(nameof(Test), typeof(string), typeof(TestBase), new UIPropertyMetadata(string.Empty));
    public string Test
    {
      get { return Convert.ToString(GetValue(TestProperty)); }
      set { SetValue(TestProperty, value); }
    }

    protected abstract void DoIt();
  }    
}
