﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
    public static class StringBoxingAndUnboxingToADictionary
    {
        public static Dictionary<string, List<string>> DictionaryBoxingMulti { get; set; }
        public static Dictionary<string, string> DictionaryBoxing { get; set; }
        
        static StringBoxingAndUnboxingToADictionary()
        {
            DictionaryBoxingMulti = new Dictionary< string, List < string >>
            {
                { "Person", new List<string> { "John", "Jenny", "Robert" }},
                { "Order", new List<string> { "A", "B", "" }},
                { "Address", new List<string> { "123 Somewhere", "456 Somewhere Else", "789 Yet again" }},
            };

            DictionaryBoxing = new Dictionary<string, string>
            {
                {"Person", "John"},
                {"Order", "A"},
                {"Address", "123 Somewhere"},
            };
        }

        public static string ReturnAStringFromADictionary(this Dictionary<string, List<string>> dictionary, string containerDesignation = "\"", string delimeter = ",")
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

        public static string ReturnAStringFromADictionary(this Dictionary<string, string> dictionary, string containerDesignation = "\"", string delimeter = ",")
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(dictionary.Keys.Select(x => $"{containerDesignation}{x}{containerDesignation}").Aggregate((x, y) => x + delimeter + y));
            sb.AppendLine(dictionary.Values.Select(x => $"{containerDesignation}{x}{containerDesignation}").Aggregate((x, y) => x + delimeter + y));

            return sb.ToString();
        }

        public static Dictionary<string, List<string>> ReturnAMultiLineDictionaryFromAString(this string inputString, string splitter = null, string delimeter = ",")
        {
            if (splitter == null)
                splitter = Environment.NewLine;

            var items = inputString.Split(new[] { splitter }, StringSplitOptions.RemoveEmptyEntries);

            var dictionary = new Dictionary<string, List<string>>();
            var listing = new List<Tuple<int, int, string>>();

            for (int i = 0; i < items.Length; i++)
            {
                var cols = items[i].Split(new[] { delimeter }, StringSplitOptions.None);
                for (int j = 0; j < cols.Length; j++)
                {
                    listing.Add(new Tuple<int, int, string>(i, j, cols[j]));
                }
            }

            foreach (var col in listing.Select(x => x.Item2).Distinct())
            {
                var header = string.Empty;
                var lines = new List<string>();

                foreach (var row in listing.Select(x => x.Item1).Distinct())
                {
                    if (row == 0)
                    {
                        header = listing.FirstOrDefault(x => x.Item1 == row && x.Item2 == col)?.Item3 ?? string.Empty;
                    }
                    else
                    {
                        lines.Add(listing.FirstOrDefault(x => x.Item1 == row && x.Item2 == col)?.Item3 ?? string.Empty);
                    }
                }

                dictionary.Add(header, lines.Distinct().ToList());
            }

            return dictionary;
        }

        public static Dictionary<string, string> ReturnADictionaryFromAString(this string inputString, string splitter = null, string delimeter = ",")
        {
            if (splitter == null)
                splitter = Environment.NewLine;

            var items = inputString.Split(new[] { splitter }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Split(new [] { delimeter }, StringSplitOptions.None).ToList()).ToList();
            var cols = (items[0]).Count;
            var lines = items.Count;

            var dictionary = new Dictionary<string, string>();

            for (int i = 0; i < cols; i++)
            {
                string header = string.Empty;
                string line = string.Empty;

                for (int j = 0; j < lines; j++)
                {                    
                    if (j == 0)
                        header = (items[j])[i];
                    else
                    {
                        line = (items[j])[i];
                    }
                }

                dictionary.Add(header, line);
            }
            
            return dictionary;
        }
    }
}
