using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core31
{
    public static class TranslatorHelper
    {
        public static IDictionary<string, int> CultureKeys { get; } = new Dictionary<string, int>
        {
            {"zh-Hans",4},
            {"cs-CZ",1029},
            {"da-DK",1030},
            {"de-DE",1031},
            {"en-US",1033},
            {"fr-FR",1036},
            {"it-IT",1040},
            {"ja-JP",1041},
            {"ko-KR",1042},
            {"nl-NL",1043},
            {"nb-NO",1044},
            {"pl-PL",1045},
            {"pt-BR",1046},
            {"ru-RU",1049},
            {"hr-HR",1050},
            {"sk-SK",1051},
            {"sv-SE",1053},
            {"th-TH",1054},
            {"tr-TR",1055},
            {"id-ID",1057},
            {"sl-SI",1060},
            {"es-ES",3082},
            {"fr-CA",3084},
            {"zh-Hant",31748}
        };

        public static void GetFilesInDirectory(string location)
        {
            //var d = new Dictionary<int, Dictionary<string, string>>();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DECLARE @Temp TABLE");
            sb.AppendLine("(");
            sb.AppendLine("     CultureIdentifier   INT");
            sb.AppendLine(",    CultureName         NVARCHAR(8)");
            sb.AppendLine(",    CategoryName        NVARCHAR(256)");
            sb.AppendLine(",    CategoryValue       NVARCHAR(1024)");
            sb.AppendLine(")");
            sb.AppendLine();
            sb.AppendLine("INSERT INTO @Temp(CultureIdentifier, CultureName, CategoryName, CategoryValue) VALUES");

            foreach (var file in new DirectoryInfo(location).GetFiles("*.json"))
            {
                var subFile = file.Name.Substring(file.Name.IndexOf(".")+1, file.Name.LastIndexOf(".")-file.Name.IndexOf(".")-1);

                CultureKeys.TryGetValue(subFile, out int cultureId);

                if (cultureId > 0)
                {
                    var contents = File.ReadAllText(file.FullName);
                    var items = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(contents);
                    items.ToList().ForEach(x =>
                    {
                        sb.AppendLine($"({cultureId.ToString()},N'{subFile}',N'{x.Key}',N'{x.Value}'),");
                    });
                }
            }

            using (var sw = new StreamWriter($"{location}\\results.txt"))
            {
                sw.Write(sb.ToString());
            }
        }
    }
}
