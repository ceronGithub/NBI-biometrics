using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NBI
{
    internal class RegexFieldChecker
    {
        CapitalizeEachFirstLetterWord capitalizeEachFirstLetterWord = new CapitalizeEachFirstLetterWord();

        Regex IntContaines = new Regex("^-?\\d*(\\.\\d+)?$");
        Regex checkConsecutiveSpecialCharacters = new Regex("[^\\w!\\s]{2,}");
        Regex checkIfTextboxContainsTripleSameAlphabet = new Regex("\\b([a-zA-Z0-9])\\1\\1+\\b");
        Regex checkIfTextboxContainsSpecialCharacter = new Regex("[^a-zA-Z0-9]+");
        Regex customizeOneCheckIfFirstStringIsSpaceOrSpecialChar = new Regex(@"^([\W]|\s)");
        Regex customizeTwoCheckIfLastStringIsSpaceOrSpecialChar = new Regex(@"([\W]$|\s$)");
        //Regex allowDashOnly = new Regex(@"/^[\w-]+$/");
        Regex allowDashOnly = new Regex(@"^[\w-\w]*$");
        Regex allowDashSemicolonOnly = new Regex(@"^[\w-:\w]*$");
        public string NameFieldChecker(string textbox)
        {
            //checks if 2 or more consecutive special characters...
            if (checkConsecutiveSpecialCharacters.IsMatch(textbox))
            {
                return "reset";
                //textBoxFname.PlaceholderText = "Please Input First Name";
            }
            //checks if textbox consist of 1 string only
            else if (textbox.Length == 1)
            {
                return "reset";
            }
            //checks first string, if special char, remove
            else if (customizeOneCheckIfFirstStringIsSpaceOrSpecialChar.IsMatch(textbox))
            {
                //remove the first char, if special char...                
                textbox = textbox.Remove(0, 1);
                //convert the firstletter of the word...
                string converted = capitalizeEachFirstLetterWord.CapitalizeFirstLetterOfTheWord(textbox);
                return converted;
            }
            //checks last string, if special char, remove
            else if (customizeTwoCheckIfLastStringIsSpaceOrSpecialChar.IsMatch(textbox))
            {                
                textbox = textbox.Remove(textbox.Length - 1, 1);
                //convert the firstletter of the word...
                string converted = capitalizeEachFirstLetterWord.CapitalizeFirstLetterOfTheWord(textbox);
                return converted;
            }
            //checks if string consist of numbers.
            else if (IntContaines.IsMatch(textbox))
            {
                return "reset";
            }
            //checks if string consist of triple same letters.
            else if (checkIfTextboxContainsTripleSameAlphabet.IsMatch(textbox))
            {
                return "reset";
            }
            //check if field consist of only numbers.
            else if (IntContaines.IsMatch(textbox))
            {
                return "reset";
            }
            //allow dash only inbetween words
            else if(allowDashOnly.IsMatch(textbox))
            {
                string converted = capitalizeEachFirstLetterWord.CapitalizeFirstLetterOfTheWord(textbox);
                return converted;
            }
            //return reset if inbetween words are not dash
            else if(!(allowDashOnly.IsMatch(textbox)))
            {
                return "reset";
            }
            else
            {
                string converted = capitalizeEachFirstLetterWord.CapitalizeFirstLetterOfTheWord(textbox);
                return converted;
            }            
        }

        public string AddressFieldChecker(string textbox)
        {
            //checks if 2 or more consecutive special characters...
            if (checkConsecutiveSpecialCharacters.IsMatch(textbox))
            {
                return "reset";
                //textBoxFname.PlaceholderText = "Please Input First Name";
            }
            //checks if textbox consist of 1 string only
            else if (textbox.Length == 1)
            {
                return "reset";
            }
            //checks first string, if special char, remove
            else if (customizeOneCheckIfFirstStringIsSpaceOrSpecialChar.IsMatch(textbox))
            {
                //remove the first char, if special char...                
                textbox = textbox.Remove(0, 1);
                //convert the firstletter of the word...
                string converted = capitalizeEachFirstLetterWord.CapitalizeFirstLetterOfTheWord(textbox);
                return converted;
            }
            //checks last string, if special char, remove
            else if (customizeTwoCheckIfLastStringIsSpaceOrSpecialChar.IsMatch(textbox))
            {
                textbox = textbox.Remove(textbox.Length - 1, 1);
                //convert the firstletter of the word...
                string converted = capitalizeEachFirstLetterWord.CapitalizeFirstLetterOfTheWord(textbox);
                return converted;
            }
            //checks if string consist of numbers.
            else if (IntContaines.IsMatch(textbox))
            {
                return "reset";
            }
            //checks if string consist of triple same letters.
            else if (checkIfTextboxContainsTripleSameAlphabet.IsMatch(textbox))
            {
                return "reset";
            }
            //check if field consist of only numbers.
            else if (IntContaines.IsMatch(textbox))
            {
                return "reset";
            }
            //allow dash only inbetween words
            else if (allowDashSemicolonOnly.IsMatch(textbox))
            {
                string converted = capitalizeEachFirstLetterWord.CapitalizeFirstLetterOfTheWord(textbox);
                return converted;
            }
            //return reset if inbetween words are not dash
            else if (!(allowDashSemicolonOnly.IsMatch(textbox)))
            {
                return "reset";
            }
            else
            {
                string converted = capitalizeEachFirstLetterWord.CapitalizeFirstLetterOfTheWord(textbox);
                return converted;
            }
        }
    }
}
