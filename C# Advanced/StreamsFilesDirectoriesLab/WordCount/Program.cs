using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = new StreamReader("../../../words.txt").ReadToEnd().ToLower().Split();

            Dictionary<string, int> wordCount = words.ToDictionary(x => x, y => 0);

            var reader = new StreamReader("../../../input.txt");

            string[] input = Regex.Split(reader.ReadToEnd(), @"\W+");

            foreach (var word in input)
            {
                if (wordCount.ContainsKey(word.ToLower()))
                {
                    wordCount[word.ToLower()]++;
                }
            }

            var writer = new StreamWriter("../../../output.txt");

            using (writer)
            {
                foreach (var word in wordCount.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
