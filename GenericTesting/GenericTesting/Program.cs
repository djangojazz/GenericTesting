using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GenericTesting
{
    class Program
    {
        static List<POCO> GetPOCOs()
        {
            return new List<POCO>
            {
                new POCO { Id = 1, Name = "John", Description = "basic" },
                new POCO { Id = 2, Name = "Jane", Description = "more" },
                new POCO { Id = 3, Name = "Joey", Description = "advanced" }
            };
        }
        
        static void Main(string[] args)
        {
            var pocos = GetPOCOs();
            var ints = new[] { 1, 3 };

            var exists = pocos.All(x => ints.Contains(x.Id));
            Console.WriteLine(exists);

            //var inputString = "Person,Item" + Environment.NewLine + "John,A" + Environment.NewLine + "Jane,B";
            //var items = inputString.ReturnAMultiLineDictionaryFromAString();

            //var appointmentDate = "2013-06-13";
            //var pstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

            //var pstDate = pstTimeZone.ConvertDateFromTimeZoneToUTCElseDefaultUTCNow(appointmentDate);
            //Console.WriteLine(pstDate);

            //var dicsl = StringBoxingAndUnboxingToADictionary.DictionaryBoxing;
            //var str = dicsl.ReturnAStringFromADictionary();
            //var dic = str.ReturnADictionaryFromAString();

            //var dicsm = StringBoxingAndUnboxingToADictionary.DictionaryBoxingMulti;
            //var strm = dicsm.ReturnAStringFromADictionary();
            //var dicm = strm.ReturnAMultiLineDictionaryFromAString();

            Console.ReadLine();
        }
    }
}
