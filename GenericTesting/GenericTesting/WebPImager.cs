using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ImageProcessor.Plugins.WebP.Imaging.Formats;

namespace GenericTesting.Imaging
{
    public class WebPImager
    {
        public void GenerateWebP()
        {
            var st = new StackFrame(1);
            Console.WriteLine($"{st.GetMethod().DeclaringType.FullName}.{st.GetMethod().Name}");
            Console.WriteLine();

            var encoder = new WebPFormat();
            var fileName = "Testing.jpg";
            var outFileName = "Testing.webp";
            File.Delete(outFileName);

            using (Stream BitmapStream = File.Open(fileName, FileMode.Open))
            {
                Image img = Image.FromStream(BitmapStream);
                encoder.Save(new FileStream(outFileName, FileMode.Create), img, 1);
            }
        }

        public void Runner()
        {
            GenerateWebP();
        }
    }
}
