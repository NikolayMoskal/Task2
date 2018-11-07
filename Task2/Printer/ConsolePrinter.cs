using System;
using System.Collections;
using System.Collections.Generic;
using Task2.TextDocument.Models;

namespace Task2.Printer
{
    public class ConsolePrinter<TKey, TValue> : IPrinter<TKey, TValue> where TValue : IList<int>
    {
        public void Print(IDictionary<TKey, TValue> source)
        {
            foreach (var t in source)
            {
                Console.WriteLine("{0}\t\t\t\t\t{1}: {2}", t.Key, t.Value.Count, string.Join(",", t.Value));
            }
        }
    }
}