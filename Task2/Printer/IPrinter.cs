using System;
using System.Collections;
using System.Collections.Generic;

namespace Task2.Printer
{
    public interface IPrinter<TKey, TValue> where TValue : IList<int>
    {
        void Print(IDictionary<TKey, TValue> collection);
    }
}