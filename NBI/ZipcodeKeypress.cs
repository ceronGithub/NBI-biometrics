using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBI
{
    internal class ZipcodeKeypress
    {
        public string zipcodeLogic(string textbox)
        {
            int value = 0;            
            if(int.TryParse(textbox, out value))
            {
                if (textbox.Length == 1)
                {
                    return textbox = "-----" + value;
                    textbox = "";
                }
                else if (textbox.Length == 2)
                {
                    return textbox = "----" + value;
                    textbox = "";
                }
                else if (textbox.Length == 3)
                {
                    return textbox = "---" + value;
                    textbox = "";
                }
                else if (textbox.Length == 4)
                {
                    return textbox = "--" + value;
                    textbox = "";
                }
                else if (textbox.Length == 5)
                {
                    return textbox = "-" + value;
                    textbox = "";
                }
                else if (textbox.Length > 6)
                {
                    return textbox = "reset";
                    textbox = "";
                }
            }                
            return textbox;
        }
    }
}
