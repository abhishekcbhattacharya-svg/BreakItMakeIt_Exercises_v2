using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_01_TDDFundamentals.Intermediate
{
    public class NumberToWords
    {
        private readonly NumberDictionary _numberDictionary;
        public NumberToWords(NumberDictionary numberDictionary)
        {
            _numberDictionary = numberDictionary;
        }

        public string ConvertToWord(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
