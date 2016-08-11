using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace ReliableWPFApplication
{
  public partial class MainWindow : Window
  {
    private int count = 1;
    public MainWindow()
    {
      WindowStartupLocation = WindowStartupLocation.CenterOwner;
      InitializeComponent();
    }

    private void RssButton_Click(object sender, RoutedEventArgs e)
    {
      BusyIndicator.Visibility = Visibility.Visible;

      RssButton.IsEnabled = false;

      var client = new WebClient();
      
      client.DownloadStringAsync(new Uri("http://www.filipekberg.se/rss/"));
      client.DownloadStringCompleted += Client_DownloadStringCompleted;
    }

    private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
      RssText.Text = e.Result;
      BusyIndicator.Visibility = Visibility.Hidden;
      RssButton.IsEnabled = true;
    }

    private void CounterButton_Click(object sender, RoutedEventArgs e)
    {
      CounterText.Text = $"Counter: {count++}";
    }
  }
}
