using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPFCSharpTesting
{
    public static class WebBrowserUtility
    {
        public static readonly DependencyProperty UriSourceProperty = DependencyProperty.RegisterAttached("UriSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, UriSourcePropertyChanged));

        public static string GetUriSource(DependencyObject obj) => (string)obj.GetValue(UriSourceProperty);

        public static void SetUriSource(DependencyObject obj, string value) => obj.SetValue(UriSourceProperty, value);

        public static void UriSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as WebBrowser).Source = new Uri(e.NewValue as string);

        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached("Html", typeof(string), typeof(WebBrowserUtility), new FrameworkPropertyMetadata(OnHtmlChanged));
        
        public static string GetHtml(WebBrowser d) => (string)d.GetValue(HtmlProperty);

        public static void SetHtml(WebBrowser d, string value) => d.SetValue(HtmlProperty, value);

        static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as WebBrowser).NavigateToString(e.NewValue as string);
    }
}
