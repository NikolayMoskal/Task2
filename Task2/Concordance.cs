using System;
using System.Collections.Generic;
using System.Linq;
using Task2.TextDocument.Models;

namespace Task2
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
            text.Sentences
                .ForEach(x => x.SentenceItems
                    .Where(y => y is Word)
                    .Cast<Word>()
                    .ToList()
                    .ForEach(y => unique.Add(y)));
            new List<Word>(unique)
                .ForEach(delegate(Word word)
                {
                    var entry = new Entry(word);
                    entry.Fill(pages);
                    _entries.Add(entry);
                });
            _entries.Sort(new EntryComparer());
        }

        private class WordEqualityComparer : EqualityComparer<Word>
        {
            public override bool Equals(Word x, Word y)
            {
                return x.Value == y.Value;
            }

            public override int GetHashCode(Word obj)
            {
                return obj.Value.GetHashCode();
            }
        }

        private class EntryComparer : IComparer<Entry>
        {
            public int Compare(Entry x, Entry y)
            {
                return string.Compare(x.Word.Value, y.Word.Value, StringComparison.OrdinalIgnoreCase);
            }
        }

        public class Entry
        {
            private readonly List<int> _lines;
            public Word Word { get; }
            public int Frequency { get; private set; }
            public List<int> Lines => new List<int>(_lines);

            public Entry(Word word)
            {
                Word = word;
                _lines = new List<int>(0);
            }

            public void Fill(List<Page> pages)
            {
                var numLine = 1;
                pages
                    .ForEach(x => x.Lines
                        .ForEach(delegate(Line y)
                        {
                            foreach (var item in y.Items)
                            {
                                if (item.Value == Word.Value)
                                {
                                    Frequency++;
                                    _lines.Add(numLine);
                                    break;
                                }
                            }
                            numLine++;
                        }));
            }
        }
    }
}