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
        public static readonly DependencyProperty BindableSourceProperty = DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, BindableSourcePropertyChanged));

        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var browser = o as WebBrowser;
            if (browser != null)
            {
                var uri = e.NewValue as string;

                File.WriteAllText("temp.htm", uri);
                var fileInfo = new FileInfo("temp.htm");

                if (fileInfo.Exists)
                {
                    browser.Source = new Uri(fileInfo.FullName);
                }
            }
        }

        public static readonly DependencyProperty HtmlProperty = DependencyProperty.RegisterAttached("Html", typeof(string), typeof(WebBrowserUtility), new FrameworkPropertyMetadata(OnHtmlChanged));

        [AttachedPropertyBrowsableForType(typeof(WebBrowser))]
        public static string GetHtml(WebBrowser d) => (string)d.GetValue(HtmlProperty);

        public static void SetHtml(WebBrowser d, string value) => d.SetValue(HtmlProperty, value);

        static void OnHtmlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as WebBrowser).NavigateToString(e.NewValue as string);
    }
}
