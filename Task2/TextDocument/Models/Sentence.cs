using System.Collections.Generic;
using Task2.TextDocument.Interfaces;

namespace Task2.TextDocument.Models
{
    public class Sentence
    {
        private readonly List<ISentenceItem> _sentenceItems;
        public List<ISentenceItem> SentenceItems => new List<ISentenceItem>(_sentenceItems);

        public Sentence(List<ISentenceItem> sentenceItems)
        {
            _sentenceItems = sentenceItems ?? new List<ISentenceItem>(0);
        }
    }
}