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
            var dicsl = StringBoxingAndUnboxingToADictionary.DictionaryBoxing;
            var str = dicsl.ReturnAStringFromADictionary();
            var dic = str.ReturnADictionaryFromAString();

            var dicsm = StringBoxingAndUnboxingToADictionary.DictionaryBoxingMulti;
            var strm = dicsm.ReturnAStringFromADictionary();
            var dicm = strm.ReturnAMultiLineDictionaryFromAString();
            
            Console.ReadLine();
        }
    }
}
