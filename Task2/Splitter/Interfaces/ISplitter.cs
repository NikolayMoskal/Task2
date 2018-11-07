using System.Collections.Generic;
using Task2.TextDocument.Models;

namespace Task2.Splitter.Interfaces
{
    public interface ISplitter
    {
        IList<Text> Split(Text source);
    }
}