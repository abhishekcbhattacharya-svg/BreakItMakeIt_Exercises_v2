using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakItMakeIt_Exercises.Chapter_01_TDDFundamentals.Intermediate
{
    public class NumberDictionary
    {
        private Dictionary<int,string> units = new Dictionary<int, string>()
        {
            { 0,"zero" },
            { 1,"one"},
            { 2,"two"},
            {3,"three" },
            {4,"four"},
            {5,"five" },
            {6,"six" },
            {7,"seven" },
            {8,"eight" },
            {9,"nine" }
        };
        private Dictionary<int, string> tens = new Dictionary<int, string>()
        {
            { 10,"ten"},
            { 11,"eleven"},
            { 12,"twelve"},
            {13,"thirteen" },
            {14,"fourteen"},
            {15,"fifteen" },
            {16,"sixteen" },
            {17,"seventeen" },
            {18,"eighteen" },
            {19,"nineteen" },
            { 20,"twenty"},
            {30,"thirty" },
            {40,"fourty"},
            {50,"fifty" },
            {60,"sixty" },
            {70,"seventy" },
            {80,"eightty" },
            {90,"ninety" }
        };

        private Dictionary<int, string> lengths = new Dictionary<int, string>() 
        {
            {2,"hundred" },
            {3,"thousand" },
            {6,"million" },
            {9,"trillion" }
        };

        public string Unit(int unit) 
        {
            if (units.TryGetValue(unit,out string? _unit))
            {
                return _unit;
            }
            return string.Empty;
        }

        public string Ten(int ten)
        {
            if (tens.TryGetValue(ten, out string? _unit))
            {
                return _unit;
            }
            return string.Empty;
        }

        public List<int> Lengths(int amount) 
        {
            int _n = (int)Math.Floor(Math.Log10(amount));
            return lengths.Keys.Where(d => d <= _n).OrderBy(d => d).ToList();
        }
    }
}
