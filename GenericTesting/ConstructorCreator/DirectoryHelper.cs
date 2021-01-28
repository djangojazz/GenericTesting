using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorCreator
{
    internal static class DirectoryHelper
    {
        internal static void NesterFinder(string directory)
        {
            var source = new DirectoryInfo(directory);
            var files = source.GetFiles("*.cs", SearchOption.AllDirectories).ToList();

            StringBuilder sb = new StringBuilder();
            files.AsParallel().ForAll(f =>
            {
                using (var sr = new StreamReader(f.FullName))
                {
                    string s = string.Empty;
                    s = sr.ReadToEnd();
                    var lines = s.Split(Environment.NewLine);

                    var hdr = lines.FirstOrDefault(x => x.Contains("public class"));
                    if (hdr != null)
                    {
                        hdr = hdr.Substring(hdr.IndexOf("public class"));
                        var name = hdr.Substring(hdr.IndexOf(' ')).Trim();
                        if (name.Contains(":"))
                            name = name.Substring(0, name.IndexOf(":")).Trim();

                        var subclassLines = lines.Where(x => x.Contains($"       public class"));
                        if (subclassLines.Any())
                        {
                            sb.AppendLine($"FILE: {name}");
                            sb.AppendLine();
                            subclassLines.ToList().ForEach(x => sb.AppendLine(x));
                            sb.ToString();
                        }
                    }
                }
            });

            using (var sw = new StreamWriter(@"C:\\Temp\Nested.txt"))
                sw.Write(sb.ToString());
        }

        internal static DirectoryInfo MakeOrCreateDirectory(string directory)
        {
            //Make or check directory
            var target = new DirectoryInfo(directory);
            if (!target.Exists)
                target.Create();
            else
                Console.WriteLine("Already exists");

            return target;
        }

        internal static void CreateConstruction(string location, string target)
        {
            using (var sr = new StreamReader(location))
            {
                string s = string.Empty;
                s = sr.ReadToEnd();
                var c = new ConstructorObject(s);
                c.MakeAFile(target);
            }
        }

        internal static void CreateConstruction(DirectoryInfo source, string target)
        {
            var files = source.GetFiles("*.cs", SearchOption.AllDirectories).ToList();
            files.AsParallel().ForAll(f =>
            {
                using (var sr = new StreamReader(f.FullName))
                {
                    string s = string.Empty;
                    s = sr.ReadToEnd();
                    var c = new ConstructorObject(s);
                    c.MakeAFile(target);
                }
            });
        }
    }
}
