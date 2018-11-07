using System.Collections.Generic;
using Task2.TextDocument.Models;

namespace Task2.Printer
{
    public interface IPrintable<TKey, TValue> where TValue : IList<int>
    {
        void Print(IPrinter<TKey, TValue> printer);
    }
}