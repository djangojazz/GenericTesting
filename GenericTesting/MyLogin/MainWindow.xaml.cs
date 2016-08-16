using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace MyLogin
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      WindowStartupLocation = WindowStartupLocation.CenterScreen;
      InitializeComponent();
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        loginButton.IsEnabled = false;
        BusyIndicator.Visibility = Visibility.Visible;

        var result = await LoginAsync();

        loginButton.Content = result;

        loginButton.IsEnabled = true;
        BusyIndicator.Visibility = Visibility.Hidden;
      }
      catch (Exception)
      {
        loginButton.Content = "Internal Error!";
      }

      // This is the first two ways of doing things with the TPL
      //loginButton.IsEnabled = false;
      //var task = Task.Run(() =>
      //{
      //  Thread.Sleep(2000);

      //  return "Login Successful!";
      //});

      ////version 2
      //task.ConfigureAwait(true)
      //  .GetAwaiter()
      //  .OnCompleted(() =>
      //  {
      //    loginButton.Content = task.Result;
      //    loginButton.IsEnabled = true;
      //  });

      ////// method below is version 1 and cumbersome for finding faults and adjusting as needed to handle
      //  //task.ContinueWith((t) =>
      //  //{
      //  //  if(t.IsFaulted)
      //  //  {
      //  //    Dispatcher.Invoke(() =>
      //  //    {
      //  //      loginButton.Content = "Login Failed!";
      //  //      loginButton.IsEnabled = true;
      //  //    });
      //  //  }
      //  //  Dispatcher.Invoke(() =>
      //  //  {
      //  //    loginButton.Content = t.Result;
      //  //    loginButton.IsEnabled = true;
      //  //  });
      //  //  // Won't work because different thread for UI cannot access the new thread for calling
      //  //  //try
      //  //  //{
      //  //  //  loginButton.IsEnabled = true;
      //  //  //}
      //  //  //catch (Exception ex)
      //  //  //{
      //  //  //}
      //  //});
    }

    private async Task<string> LoginAsync()
    {
      try
      {
        var logingTask = Task.Run(() =>
          {
            Thread.Sleep(2000);

            return "Login Successful!";
          });

        var logTask = Task.Delay(2000);

        var purchaseTask = Task.Delay(1000);

        await Task.WhenAll(logingTask, logTask, purchaseTask);

        return logingTask.Result;
      }
      catch (Exception)
      {
        return "Login Failed!";
      }
    }
  }
}
