using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace WPFCSharpTesting
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _text;
        private DateTime _testDate;
        private string _html;
        private Assembly _assembly;

        public string HTML
        {
            get => _html; 
            set
            {
                _html = value;
                OnPropertyChanged(nameof(HTML));
            }
        }

        public ICommand PrintPreview { get; }

        //TestEventRaisingVM TestVM { get; set; } = new TestEventRaisingVM("Test Input");
        public MainWindowViewModel()
        {
            _assembly = Assembly.GetAssembly(this.GetType());
            //Clipboard.SetDataObject("Test");
            //var text = Clipboard.GetData(DataFormats.Text);
            TestDate = new DateTime(2018, 4, 1, 13, 22, 11);
            using (var stream = _assembly.GetManifestResourceStream($"WPFCSharpTesting.SegmentTerrainRptNew.xml"))
            using (var reader = new StreamReader(stream))
            {
                var file = reader.ReadToEnd();
                var xdoc = XDocument.Parse(file);
                HTML = $"<htm><head><style>h3 {{color: red; }}</style></head><body><h3>ERROR!<h3></body></htm>";
                //GetXSLTransformedData("SegmentTerrainRpt", xdoc);
            }

            PrintPreview = new DelegateCommand(x =>
            {
                var wb = new System.Windows.Forms.WebBrowser { DocumentText = _html };
                wb.DocumentCompleted += ((sender, args) =>
                {
                    wb.ShowPrintDialog();
                    wb.Dispose();
                });
            });
        }

        //private void PrintHelpPage()
        //{
        //    // Create a WebBrowser instance. 
        //    WebBrowser webBrowserForPrinting = new WebBrowser();

        //    // Add an event handler that prints the document after it loads.
        //    webBrowserForPrinting.DocumentCompleted +=
        //        new WebBrowserDocumentCompletedEventHandler(PrintDocument);

        //    // Set the Url property to load the document.
        //    webBrowserForPrinting.Url = new Uri(@"\\myshare\help.html");
        //}

        //private void PrintDocument(object sender,
        //    WebBrowserDocumentCompletedEventArgs e)
        //{
        //    // Print the document now that it is fully loaded.
        //    ((WebBrowser)sender).Print();

        //    // Dispose the WebBrowser now that the task is complete. 
        //    ((WebBrowser)sender).Dispose();
        //}

        //public void ShowPrintPreviewDialog(object o)
        //{
        //    _host = o as System.Windows.Forms.Integration.WindowsFormsHost;
        //    _wb = new WebBrowser();
        //    _wb.DocumentCompleted += wb_DocumentCompletedForPreview;
        //    TurnFooterOff();
        //    if (_textOnly)
        //        _wb.DocumentText = _planText;
        //    else
        //        _wb.Url = new Uri(_uri);
        //}

        //private void wb_DocumentCompletedForPreview(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    _host.Child = _wb;
        //    _wb.ShowPrintPreviewDialog();
        //    _host.Child = null;
        //    _host = null;
        //}

        private string GetXSLTransformedData(string xslName, XDocument xmlResponse)
        {
            using (var stream = _assembly.GetManifestResourceStream($"WPFCSharpTesting.{xslName}.xsl"))
            using (var xmlReader = new XmlTextReader(stream))
            {
                var xslt = new XslCompiledTransform();
                xslt.Load(xmlReader);
                using (var stm = new MemoryStream())
                {
                    xslt.Transform(xmlResponse.CreateReader(), null, stm);
                    stm.Position = 0;
                    using (var sr = new StreamReader(stm))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        ObservableCollection<UserControl> Components { get; } = new ObservableCollection<UserControl>();

        private void TestEventRaisingVM_OnParameterChange(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show("Hello from parent");
        }

        public DateTime TestDate
        {
            get => _testDate;
            set
            {
                _testDate = value;
                OnPropertyChanged(nameof(TestDate));
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        private ObservableCollection<tePerson> _people;

        public ObservableCollection<tePerson> People
        {
            get { return _people; }
            set
            {
                _people = value;
                OnPropertyChanged(nameof(People));
            }
        }

        private readonly List<tePerson> _allPeople;




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        DelegateCommand _CommandGetFirstName;

        public ICommand CommandGetFirstName
        {
            get
            {
                if (_CommandGetFirstName == null)
                {
                    _CommandGetFirstName = new DelegateCommand(param => this.CommandGetByFirstNameExecute());
                }
                return _CommandGetFirstName;
            }
        }

        private void CommandGetByFirstNameExecute()
        {
            var newitems = _allPeople.Exists(x => x.FirstName == Text) ? _allPeople.Where(x => x.FirstName == Text)?.ToList() : _allPeople;
            People = new ObservableCollection<tePerson>(newitems);
        }
    }
}
