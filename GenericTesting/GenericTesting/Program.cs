using System;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Xml;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Xml.Xsl;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace GenericTesting
{

    class Program
    {
        static void Main(String[] args)
        {
            var encoder = new ImageProcessor.Plugins.WebP.Imaging.Formats.WebPFormat();
            var fileName = "Testing.jpg";
            var outFileName = "Testing.webp";
            File.Delete(outFileName);

            using (Stream BitmapStream = File.Open(fileName, FileMode.Open))
            {
                Image img = Image.FromStream(BitmapStream);
                encoder.Save(new FileStream(outFileName, FileMode.Create), img, 1);
            }
        }
    }
}
