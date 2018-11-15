using Task2.TextDocument.Interfaces;

namespace Task2.TextDocument.Models
{
    public class Word : ISentenceItem
    {
        public string Value { get; }
        
        public Word(string value)
        {
            Value = value;
        }
    }
}