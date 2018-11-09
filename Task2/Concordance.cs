using System.Collections.Generic;
using System.Linq;
using Task2.Printer;
using Task2.Splitter.Interfaces;
using Task2.TextDocument.Models;

namespace Task2
{
    public class Concordance : IPrintable<string, IList<int>>
    {
        private readonly Text _text;
        private IDictionary<string, IList<int>> Dictionary { get; }
        
        public Concordance(Text text)
        {
            _text = text;
            Dictionary = new Dictionary<string, IList<int>>();
        }

        private IList<Text> CollectWords(ISplitter splitter)
        {
            return splitter.Split(_text);
        }

        private IList<int> CollectFrequency(IList<Text> list, Text item)
        {
            return new List<int>(0)
            {
                list
                    .Count(x => x.Source.Equals(item.Source))
            };
        }

        public void FillConcordance(ISplitter splitter)
        {
            var list = CollectWords(splitter);
            list
                .ToList()
                .ForEach(item => Dictionary.Add(item.Source, CollectFrequency(list, item)));
        }

        public void Print(IPrinter<string, IList<int>> printer)
        {
            printer.Print(Dictionary);
        }
    }
}