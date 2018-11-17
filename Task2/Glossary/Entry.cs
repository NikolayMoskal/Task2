using System.Collections.Generic;
using Task2.TextDocument.Models;

namespace Task2.Glossary
{
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