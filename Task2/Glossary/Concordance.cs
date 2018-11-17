using System;
using System.Collections.Generic;
using System.Linq;
using Task2.TextDocument.Models;

namespace Task2.Glossary
{
    public class Concordance
    {
        private readonly List<Entry> _entries;
        public List<Entry> Entries => new List<Entry>(_entries);

        public Concordance()
        {
            _entries = new List<Entry>(0);
        }

        public void Fill(Text text, List<Page> pages)
        {
            var unique = new HashSet<Word>(new WordEqualityComparer());
            foreach (var x in text.Sentences)
            {
                var words = x.SentenceItems
                    .Where(y => y is Word)
                    .Cast<Word>()
                    .ToList();
                words
                    .ForEach(y => unique.Add(y));
            }
            
            var uniqueList = new List<Word>(unique);
            foreach (var word in uniqueList)
            {
                var entry = new Entry(word);
                entry.Fill(pages);
                _entries.Add(entry);
            }

            _entries.Sort(new EntryComparer());
        }

        private class WordEqualityComparer : EqualityComparer<Word>
        {
            public override bool Equals(Word x, Word y)
            {
                return x?.Value == y?.Value;
            }

            public override int GetHashCode(Word obj)
            {
                return obj == null ? 0 : obj.Value.GetHashCode();
            }
        }

        private class EntryComparer : IComparer<Entry>
        {
            public int Compare(Entry x, Entry y)
            {
                return string.Compare(x?.Word.Value, y?.Word.Value, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}