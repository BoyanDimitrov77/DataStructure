using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rm.Trie;
using System.IO;
using System.Text.RegularExpressions;

namespace Problem3
{
    class Program
    {
        public static List<string> getWord()
        {
            using (var input=new StreamReader("input.txt"))
            {

                List<string> words = new List<string>();
                for(string line= null; (line = input.ReadLine()) != null;)
                {
                    var currentWord = Regex.Matches(line, @"[A-Za-z]+").Cast<Match>().Select(match => match.Value).ToArray();
                    words.AddRange(currentWord.Select(word=>word.ToLower()));

                }

                return words;
            }

            
        }


        static void Main(string[] args)
        {


            var words = getWord();
            var trie = TrieFactory.CreateTrie();

            foreach (var item in words)
            {
                trie.AddWord(item);

            }

            Console.WriteLine();

            foreach (var word in words)
            {
                Console.WriteLine("{0}--->{1}",word,trie.WordCount(word));
            }
        
        }
    }
}
