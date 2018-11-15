using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Task2.Printer;
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
            text.Sentences
                .ForEach(x => x.SentenceItems
                    .Where(y => y is Word)
                    .Cast<Word>()
                    .ToList()
                    .ForEach(delegate(Word word)
                    {
                        var entry = new Entry(word);
                        entry.Fill(text, pages);
                        _entries.Add(entry);
                    }));
            _entries.Sort(new EntryComparer());
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

            public void Fill(Text text, List<Page> pages)
            {
                text.Sentences
                    .ForEach(x => Frequency += x.SentenceItems
                        .Count(y => y.Value.Equals(Word.Value)));
                pages
                    .ForEach(delegate(Page page)
                    {
                        for (var index = 0; index < page.Lines.Count; index++)
                        {
                            if (page.Lines[index].Items.Contains(Word))
                            {
                                _lines.Add(index + 1);
                            }
                        }
                    });
            }
        }
    }
}