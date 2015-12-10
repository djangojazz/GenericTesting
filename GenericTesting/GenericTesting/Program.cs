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
        static void Main(string[] args)
        {
            var appointmentDate = "2013-06-13T00:00:00";
            var pstTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

            var pstDate = pstTimeZone.ConvertDateFromTimeZoneToUTCElseDefaultUTCNow(appointmentDate);
            Console.WriteLine(pstDate);

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
