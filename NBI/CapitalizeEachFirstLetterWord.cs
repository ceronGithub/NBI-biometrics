using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBI
{
    internal class CapitalizeEachFirstLetterWord
    {
        public string CapitalizeFirstLetterOfTheWord(string textbox)
        {
            string wordText = textbox;
            string convert = string.Join(" ", wordText.Split(' ').ToList().ConvertAll(word => word.Substring(0, 1).ToUpper() + word.Substring(1)));
            return convert;
        }
    }
}
