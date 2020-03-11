using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core31
{
    public static class TranslatorHelper
    {
        public static IDictionary<string, int> CultureKeys { get; } = new Dictionary<string, int>
        {
            {"zh-Hans",4},
            {"cs-CZ",1029},
            //{"da-DK",1030},
            //{"de-DE",1031},
            //{"en-US",1033},
            //{"fr-FR",1036},
            //{"it-IT",1040},
            //{"ja-JP",1041},
            //{"ko-KR",1042},
            //{"nl-NL",1043},
            //{"nb-NO",1044},
            //{"pl-PL",1045},
            //{"pt-BR",1046},
            //{"ru-RU",1049},
            //{"hr-HR",1050},
            //{"sk-SK",1051},
            //{"sv-SE",1053},
            //{"th-TH",1054},
            //{"tr-TR",1055},
            //{"id-ID",1057},
            //{"sl-SI",1060},
            //{"es-ES",3082},
            //{"fr-CA",3084},
            //{"zh-Hant",31748}
        };

        public static void GetFilesInDirectory(string location)
        {
            var d = new Dictionary<int, Dictionary<string, string>>();
            foreach(var file in new DirectoryInfo(location).GetFiles())
            {
                var subFile = file.Name.Substring(file.Name.IndexOf(".")+1, file.Name.LastIndexOf(".")-file.Name.IndexOf(".")-1);


                CultureKeys.TryGetValue(subFile, out int cultureId);

                if (cultureId > 0)
                {
                    var contents = File.ReadAllText(file.FullName);
                    Console.WriteLine(contents);

                }
            }
            
        }
    }
}
