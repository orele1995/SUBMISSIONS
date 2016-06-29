using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence");
            String sentence = Console.ReadLine();
            sentence = sentence.Trim();
            while ( sentence != "")
            {
                string[] words = sentence.Split();
                Console.WriteLine("There are " + words.Length + " words in the sentence");
         
                Console.WriteLine("reversed: ");
                Array.Reverse(words);
                printWords(words);

                Console.WriteLine("sorted: ");
                Array.Sort(words);
                printWords(words);


                Console.WriteLine("Enter a sentence");
                sentence = Console.ReadLine();
            }
        }

        private static void printWords(string[] words)
        {
            foreach (String w in words)
            {
                Console.WriteLine(w + " ");
            }
        }
    }
}
