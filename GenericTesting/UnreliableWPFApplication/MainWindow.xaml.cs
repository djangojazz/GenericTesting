﻿using System;
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

namespace UnreliableWPFApplication
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
      var client = new WebClient();

      var data = client.DownloadString("http://www.filipekberg.se/rss/");

      Thread.Sleep(10000);
      RssText.Text = data;
    }

    private void CounterButton_Click(object sender, RoutedEventArgs e)
    {
      CounterText.Text = $"Counter: {count++}";
    }
  }
}
