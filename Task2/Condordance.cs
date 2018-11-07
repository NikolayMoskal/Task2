using System.Collections.Generic;
using System.Linq;
using Task2.Printer;
using Task2.Splitter.Interfaces;
using Task2.TextDocument.Models;

namespace Task2
{
    public class Condordance : IPrintable<string, IList<int>>
    {
        private readonly Text _text;
        public IDictionary<string, IList<int>> Dictionary { get; }
        
        public Condordance(Text text)
        {
            _text = text;
            Dictionary = new Dictionary<string, IList<int>>();
        }

        private IList<Text> CollectWords(ISplitter splitter)
        {
            return splitter.Split(_text);
        }

        private IList<int> CollectFrequency(IList<Text> list)
        {
            var frequencies = new List<int>(0);
            list
                .ToList()
                .ForEach(item => frequencies.Add(list
                    .Count(x => x.Source.Equals(item.Source))));
            return frequencies;
        }

        public void FillConcordance(ISplitter splitter)
        {
            var list = CollectWords(splitter);
            list
                .ToList()
                .ForEach(item => Dictionary.Add(item.Source, CollectFrequency(list)));
        }

        public void Print(IPrinter<string, IList<int>> printer)
        {
            printer.Print(Dictionary);
        }
    }
}