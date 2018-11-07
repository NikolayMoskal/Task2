using System.Collections.Generic;
using Task2.TextDocument.Enums;

namespace Task2.TextDocument.Models
{
    public class Sentence : Text
    {
        public IList<Word> Words { get; }

        public Sentence(string source) : base(source)
        {
        }

        public Sentence(string source, IList<Word> words) : this(source)
        {
            Words = words ?? new List<Word>(0);
        }
    }
}