// Khai Ha
// IT113
// I used a few array and bool to keep track of were the cases where and that was the biggest thing. Since the input might not always be Sunbeam Tiger.
// I had it to were it would go through the input and if there is a uppercase after a space, which indicates another world. The word that's right after
// the space would be upper case. I also make sure after it was all run, I make sure all the letters would be pop as lower case.

namespace StringMaker_Ha
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringManager stringManager = new StringManager("Sunbeam Tiger");

            Console.WriteLine("1. Reverse of string: " + stringManager.ReverseStack("Sunbeam Tiger"));
            Console.WriteLine("2. ToString: " + stringManager.ToString());
            Console.WriteLine("3. Reverse a string with preserved casing: " + stringManager.ReverseStack("Sunbeam Tiger", false));
            Console.WriteLine("4. Equality Check: " + stringManager.Equals("Sunbeam Tiger"));
            Console.WriteLine("5. Symmetric check for 'ABBA': " + stringManager.Symmetric("ABBA"));
            Console.WriteLine("6. Symmetric check for 'ABA': " + stringManager.Symmetric("ABA"));
            Console.WriteLine("7. Symmetric check for 'ABba': " + stringManager.Symmetric("ABba"));


        }
    }
}