using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVToJson
{
    class Program
    {
        private static readonly string _alphas = "abcdefghijklmnopqrstuvwxyz";
        private static List<string> _firstLines = null;
        
        static void Main(string[] args)
        {
            #region Checking
            if (args.Length != 2)
            {
                Console.WriteLine("You must have two arguments: 1. A file location 2. A bool if the first row has headers");
                return;
            }

            var locale = args[0];

            if(!File.Exists(locale))
            {
                Console.WriteLine($"The location you gave {locale} does not exist, please give a location that exists");
                return;
            }

            if(!bool.TryParse(args[1], out bool headerHasRows))
            {
                Console.WriteLine($"The argument you gave of {args[1]} is not a boolean value.  Just use true or false to indicate if the header has descriptors");
                return;
            }

            #endregion

            var lines = GetFileDataRows(locale);
            _firstLines = lines.First().Split(",").Select(x => $"[{x}]").ToList();
            (var sb, var columnCount) = GetAlphaJsonAndCount(lines, headerHasRows);
            //(new StringBuilder("Some Data"), 12); //GetAlphaJsonAndCount(lines, true);
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Select *");
            sb.AppendLine("From OPENJSON(@Import)");
            sb.AppendLine("\tWith");
            sb.AppendLine("\t(");
            for (int i = 0; i < columnCount; i++)
            {
                sb.Append("\t");
                var lineStart = i == 0 ? "\t" : ",\t";
                sb.Append($"{lineStart}{GetHeaderIfNeeded(headerHasRows, i)} VARCHAR(256) '$.{_alphas[i]}'{Environment.NewLine}");
            }
            sb.AppendLine("\t)");

            Console.WriteLine(sb.ToString());
        }


        private static List<string> GetFileDataRows(string location)
        {
            using (var sr = new StreamReader(location))
            {
                var s = sr.ReadToEnd();
                return s.Trim().Split(Environment.NewLine).ToList();
            }
        }

        private static (StringBuilder sb, int columnCount) GetAlphaJsonAndCount(List<string> lines, bool firstLineHasData)
        {
            var sb = new StringBuilder(string.Empty);
            var colCount = 0;

            lines.Skip(firstLineHasData ? 1 : 0).ToList().ForEach(x =>
            {
                sb.Append("{");
                var items = x.Split(",");
                for (int i = 0; i < items.Count(); i++)
                {
                    if (i == 0)
                        colCount = items.Count();

                    sb.Append($"\"{_alphas[i]}\":\"{items[i].Replace("\"", string.Empty)}\",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append($"}},");
            });

            sb = sb.Remove(sb.Length - 1, 1);
            sb.Replace("-", ",").Replace("'", "''");
            sb.Append("]'");

            return (sb = new StringBuilder("Declare @Import Varchar(max) = '[" + sb), colCount);
        }

        private static string GetHeaderIfNeeded(bool headerHasRows, int i) => headerHasRows ? _firstLines[i] : _alphas[i].ToString();
    }
}
