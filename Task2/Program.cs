using System;
using System.Collections.Generic;
using System.IO;
using Task2.Printer;
using Task2.Splitter.Models;
using Task2.TextDocument.Models;

namespace Task2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            using (var reader = new StreamReader(Path.Combine(Environment.CurrentDirectory, @"example.txt")))
            {
                var condordance = new Concordance(new Text(reader.ReadToEnd()));
                condordance.FillConcordance(new WordSplitter());
                condordance.Print(new ConsolePrinter<string, IList<int>>());
            }
        }
    }
}