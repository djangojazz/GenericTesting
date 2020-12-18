using System;
using System.IO;
using System.Linq;

namespace ConstructorCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var location = @"C:\AyaGit\Applications\Aya.Core.Api\Aya.Core.DTO\AyaNova\BizDev\FacilityClientOverviewDto.cs";
            string s = string.Empty;

            using (var sr = new StreamReader(location))
            {
                s = sr.ReadToEnd();
            }

            var lines = s.Split(Environment.NewLine);

            var hdr = lines.FirstOrDefault(x => x.Contains("public class"));
            hdr = hdr.Substring(hdr.IndexOf("class"));
            hdr = hdr.Substring(hdr.IndexOf(' '));

            var props = lines
                .Where(x => x.Contains("get;"))
                .Take(5)
                .Select((x, i) => new { Ind = i+1, Strings = x.Substring(x.IndexOf("public")).Split(" ")})
                .Select(x => new Line(x.Ind, x.Strings[2], x.Strings[1]))
                .ToList();

            var c = new ConstructorObject(hdr, props);
            Console.WriteLine(c.Name);
            c.Lines.ForEach(x => Console.WriteLine($"{x.Id} {x.Name} {x.Type}"));
        }
    }
}
