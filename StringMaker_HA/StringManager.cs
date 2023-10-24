using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StringMaker_Ha
{
    internal class StringManager
    {
        private string InsertedString;

        public StringManager(string Input)
        {
            InsertedString = Input; // Save "Sunbeam Tiger" into private int
        }

        public string ReverseStack(string Input)
        {
            Stack<char> charStack = new Stack<char>();

            foreach (char c in Input)
            {
                charStack.Push(c); // Push onto the stack
            }

            char[] ReversedChars = new char[Input.Length]; // Popping the chars is what makes it run in reverse So we make a char array for the reverse
            int log = 0;                                   // Add a log counter

            while (charStack.Count > 0)
            {
                ReversedChars[log] = charStack.Pop();
                log++;
            }

            return new string(ReversedChars); // Pop into char array and then displayed
        }

        public string ReverseStack(string Input, bool PreserveCaseLoc) // We overloaded, but I ended up using a few bool variable to check for cases and spaces.
        {
            Stack<char> charStack = new Stack<char>(); // This whole method was copy and paste from the method above and then I start buildinging on it
            bool[] UpperCheck = new bool[Input.Length]; // TO get the requested result
            bool isSpaceBeforeUpper = PreserveCaseLoc; // Bool Starts false, this only really works for Sunbeam Tiger, don't think it could handle more than two words.
            bool isFirstCharUpperCase = char.IsUpper(Input[0]); // This ensures that when the first letter is upper case, the first will always be upper case.

            // Push all characters onto the stack and determine their uppercase status
            for (int i = 0; i < Input.Length; i++)
            {
                char c = Input[i];
                UpperCheck[i] = char.IsUpper(c);
                if (i > 0 && Input[i - 1] == ' ')
                {
                    isSpaceBeforeUpper = true; // If there is a space before an uppercase letter
                }
                charStack.Push(char.ToLower(c));
            }

            int stackSize = charStack.Count; // Recocunt the size of the char stack, but really I just want a new variable to not confuse myself
            char[] reversedArray = new char[stackSize]; // An array to store the reverse stalk

            for (int i = 0; i < stackSize; i++)
            {
                char poppedChar = charStack.Pop();

                if (UpperCheck[i] == true && isFirstCharUpperCase == true) //If there was a upper case and the first letter was upper case
                {
                    reversedArray[i] = char.ToUpper(poppedChar);
                    isFirstCharUpperCase = false;
                }
                else if (isSpaceBeforeUpper == true && reversedArray[i - 1] == ' ') // If there as a upper case before the reverse and if there's a space the next letter is uppercase
                {
                    reversedArray[i] = char.ToUpper(poppedChar);

                }
                else
                {
                    reversedArray[i] = poppedChar;
                }
            }

            string reversedPre = new string(reversedArray); // put the array into a varible for display

            return reversedPre;
        }

        public bool Symmetric(string Input)
        {
            string reversed = ReverseStack(Input); // Check if the string is symmetric (case-sensitive)
            return Input.Equals(reversed);
        }



        public override string ToString()
        {
            if (string.IsNullOrEmpty(InsertedString)) // If it was null or empty returns a -1
            {
                return "Negative One";
            }

            int sum = 0;

            foreach (char c in InsertedString) // for each, we capture the value and added to total sum
            {
                sum += (int)c;
            }
            return ConWords(sum); //conver to words for display
        }



        public override bool Equals(object obj)
        {
            if (obj is string)
            {
                return InsertedString.Equals(obj);
            }

            return false;
        }



        private string ConWords(int num)
        {
            string[] units = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            string result = "";

            while (num > 0)

            {
                int digit = num % 10;
                result = units[digit] + " " + result;
                num /= 10;
            }

            return result.Trim();
        }
    }
}