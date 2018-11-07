using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Task2.Splitter.Interfaces;
using Task2.TextDocument.Models;

namespace Task2.Splitter.Models
{
    public class SentenceSplitter : ISplitter
    {
        public IList<Text> Split(Text source)
        {
            IList<Text> results = new List<Text>(0);
            new Regex(@"[\.\?!]")
                .Split(source.Source)
                .ToList()
                .ForEach(x => results.Add(new Sentence(x.Trim())));
            return results;
        }
    }
}