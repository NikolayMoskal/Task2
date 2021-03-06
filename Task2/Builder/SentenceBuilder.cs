using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Task2.Reader;
using Task2.TextDocument.Interfaces;
using Task2.TextDocument.Models;

namespace Task2.Builder
{
    public class SentenceBuilder
    {
        private string _source;

        private int FindSentence(string source)
        {
            var match = new Regex(@"[.!?]+").Match(source);
            if (match.Success)
            {
                return match.Index + 1;
            }

            return 0;
        }
        
        public bool ExtractSentence(CustomReader reader)
        {
            var match = FindSentence(reader.Accumulator);
            if (match > 0)
            {
                _source = reader.Accumulator.Substring(0, match);
                reader.Reduce(0, match);
                return true;
            }

            return false;
        }
        
        public Sentence Build()
        {
            var builder = new StringBuilder(_source);
            var results = new List<ISentenceItem>(0);
            var patterns = new Dictionary<string, Func<string, ISentenceItem>>
            {
                {@"^[\w\-']+", x => new Word(x)},
                {@"^ +", x => new Separator(x)},
                {@"^[^\w \-']+", x => new PunctuationSign(x)}
            };

            while (builder.Length > 0)
            {
                foreach (var pattern in patterns)
                {
                    var result = new Regex(pattern.Key).Match(builder.ToString());
                    if (!string.IsNullOrEmpty(result.Value))
                    {
                        var createItem = pattern.Value;
                        results.Add(createItem(result.Value));
                        builder.Remove(result.Index, result.Length);
                    }
                }
            }
            return new Sentence(results);
        }
    }
}