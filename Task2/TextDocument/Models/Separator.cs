using System;
using Task2.TextDocument.Interfaces;

namespace Task2.TextDocument.Models
{
    public class Separator : ISentenceItem
    {
        public string Value { get; }

        public Separator(string value)
        {
            Value = value;
        }
    }
}