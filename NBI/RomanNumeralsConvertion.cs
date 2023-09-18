using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBI
{
    internal class RomanNumeralsConvertion
    {
        public string Convertion(int given)
        {
            string romanResult = string.Empty;
            string[] romanLetters = {
                                        "M",
                                        "CM",
                                        "D",
                                        "CD",
                                        "C",
                                        "XC",
                                        "L",
                                        "XL",
                                        "X",
                                        "IX",
                                        "V",
                                        "IV",
                                        "I"
                                    };
            int[] numbers = {
                                1000,
                                900,
                                500,
                                400,
                                100,
                                90,
                                50,
                                40,
                                10,
                                9,
                                5,
                                4,
                                1
                            };
            int i = 0;
            while (given != 0)
            {
                try
                {
                    if (given >= numbers[i])
                    {
                        given -= numbers[i];
                        romanResult += romanLetters[i];
                    }
                    else
                    {
                        i++;
                    }
                }
                catch(Exception ex)
                {
                    return romanResult += "Invalid";                    
                }                
            }
            return romanResult;
        }
    }
}
