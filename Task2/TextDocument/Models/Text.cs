using System.Collections.Generic;

namespace Task2.TextDocument.Models
{
    public class Text
    {
        public IList<Sentence> Sentences { get; }
        public string Source { get; }

        public Text(string source)
        {
            Source = source;
        }

        public Text(string source, IList<Sentence> sentences) : this(source)
        {
            Sentences = sentences ?? new List<Sentence>(0);
        }
    }
}