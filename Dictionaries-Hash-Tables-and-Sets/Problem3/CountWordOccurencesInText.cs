﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Problem3
{
    class CountWordOccurencesInText
    {
        static IDictionary<T, int> Occurrence<T>(IEnumerable<T> elements)
        {
            return elements.GroupBy(el => el).ToDictionary(group => group.Key, group => group.Count());
        }


        static void Main(string[] args)
        {

       
            using (var input = new StreamReader("input.txt"))
            {
                var words = new List<string>();

                for (string line = null; (line = input.ReadLine()) != null;)
                {
                    var currentWords = Regex.Matches(line, @"\w+").Cast<Match>().Select(match => match.Value).ToArray();
                    words.AddRange(currentWords.Select(word => word.ToLower()));
                }

                Console.WriteLine(string.Join(" ", Occurrence(words)));
            }
        }



    }
    }

