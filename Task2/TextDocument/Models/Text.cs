using System.Collections.Generic;

namespace Task2.TextDocument.Models
{
    public class Text
    {
        private readonly List<Sentence> _sentences;
        public List<Sentence> Sentences => new List<Sentence>(_sentences);

        public Text(List<Sentence> sentences)
        {
            _sentences = sentences ?? new List<Sentence>(0);
        }
    }
}