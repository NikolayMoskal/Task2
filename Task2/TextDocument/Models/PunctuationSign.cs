using System.Collections.Generic;
using System.Text.RegularExpressions;
using Task2.TextDocument.Interfaces;

namespace Task2.TextDocument.Models
{
    public class PunctuationSign : ISentenceItem
    {
        public string Value { get; }

        public PunctuationSign(string value)
        {
            Value = value;
        }
    }
}