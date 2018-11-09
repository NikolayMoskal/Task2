using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Task2.Splitter.Interfaces;
using Task2.TextDocument.Models;

namespace Task2.Splitter.Models
{
    public class WordSplitter : ISplitter
    {
        public IList<Text> Split(Text source)
        {
            var results = new List<Text>(0);
            var tempList = new List<string>(0);
            new Regex(@"[\.\?! ,]")
                .Split(source.Source)
                .Where(x => !string.IsNullOrEmpty(x))
                .ToList()
                .ForEach(x => tempList.Add(x.ToLower()));
            tempList.Sort();
            tempList
                .ForEach(x => results.Add(new Word(x)));
            return results;
        }
    }
}