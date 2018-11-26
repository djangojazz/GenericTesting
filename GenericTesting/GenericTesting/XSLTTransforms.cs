using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Xsl;

namespace GenericTesting
{
    public class XSLTTransforms
    {
        static Assembly _assembly;
        
        private static string GetXSLTransformedData(string xslName, XDocument xmlResponse)
        {
            using (var stream = _assembly.GetManifestResourceStream($"GenericTesting.{xslName}.xsl"))
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
    }
}
