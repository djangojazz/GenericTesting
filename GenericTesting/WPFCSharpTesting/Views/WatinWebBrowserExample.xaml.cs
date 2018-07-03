using mshtml;
using System.Windows.Controls;

namespace WPFCSharpTesting.Views
{
    /// <summary>
    /// Interaction logic for WatinWebBrowserExample.xaml
    /// </summary>
    public partial class WatinWebBrowserExample : UserControl
    {
        private HTMLDocumentEvents2_Event _docEvent;

        public WatinWebBrowserExample()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            Wb.Navigate("http://google.com");
            Wb.LoadCompleted += ((sender, args) =>
            {
                if (_docEvent != null)
                {
                    _docEvent.oncontextmenu -= x =>
                    {
                        WbShowContextMenu();
                        return false;
                    };
                }
                if (Wb.Document != null)
                {
                    _docEvent = (HTMLDocumentEvents2_Event)Wb.Document;
                    _docEvent.oncontextmenu += x =>
                    {
                        WbShowContextMenu();
                        return false;
                    };
                }
            });
        }


        public void WbShowContextMenu()
        {
            if (!(FindResource("MnuCustom") is ContextMenu cm)) return;
            cm.PlacementTarget = Wb;
            cm.IsOpen = true;
        }
    }
}
