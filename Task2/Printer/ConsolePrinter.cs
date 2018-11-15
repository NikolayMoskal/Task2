using System;
using System.Collections;
using System.Collections.Generic;
using Task2.TextDocument.Models;

namespace Task2.Printer
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(Concordance concordance)
        {
            foreach (var t in concordance.Entries)
            {
                Console.WriteLine("{0}\t\t\t{1}: {2}", t.Word.Value, t.Frequency, string.Join(",", t.Lines));
            }
        }
    }
}