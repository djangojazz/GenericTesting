using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
    public sealed class StringBoxingAndUnboxingToADictionary
    {
        public Dictionary<string, List<string>> DictionaryBoxingMulti { get; set; }
        public Dictionary<string, string> DictionaryBoxing { get; set; }
        
        public StringBoxingAndUnboxingToADictionary()
        {
            DictionaryBoxingMulti = new Dictionary< string, List < string >>
            {
                { "Person", new List<string> { "John", "Jenny", "Robert" }},
                { "Order", new List<string> { "A", "B", "C" }},
                { "Address", new List<string> { "123 Somewhere", "456 Somewhere Else", "789 Yet again" }},
            };

            DictionaryBoxing = new Dictionary<string, string>
            {
                {"Person", "John"},
                {"Order", "A"},
                {"Address", "123 Somewhere"},
            };
        }

        public string ReturnAStringFromADictionary(Dictionary<string, List<string>> dictionary, string containerDesignation = "\"", string delimeter = ",")
        {
            StringBuilder sb = new StringBuilder();

            var firstKeyName = dictionary.FirstOrDefault().Key;
            var countsOfRows = dictionary.Where(x => x.Key == firstKeyName).SelectMany(y => y.Value).Count();

            sb.AppendLine(dictionary.Keys.Select(x => $"{containerDesignation}{x}{containerDesignation}").Aggregate((x, y) => x + delimeter + y));

            for (int i = 0; i < countsOfRows; i++)
            {
                foreach (var key in dictionary.Keys)
                {
                    var start = (key == firstKeyName) ? containerDesignation : $",{containerDesignation}";
                    var val = dictionary.SingleOrDefault(x => x.Key == key).Value[i];
                    sb.Append(start + val + containerDesignation);
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public string ReturnAStringFromADictionary(Dictionary<string, string> dictionary, string containerDesignation = "\"", string delimeter = ",")
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(dictionary.Keys.Select(x => $"{containerDesignation}{x}{containerDesignation}").Aggregate((x, y) => x + delimeter + y));
            sb.AppendLine(dictionary.Values.Select(x => $"{containerDesignation}{x}{containerDesignation}").Aggregate((x, y) => x + delimeter + y));

            return sb.ToString();
        }
    }
}
