using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Task2.Builder;
using Task2.Glossary;
using Task2.Printer;
using Task2.Reader;
using Task2.TextDocument.Models;

namespace Task2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var sourceFile = ConfigurationManager.AppSettings["sourceFile"];
            var destinationFile = ConfigurationManager.AppSettings["destinationFile"];

            try
            {
                using (var reader = new StreamReader(sourceFile))
                {
                    var fileReader = new CustomReader(10);
                    var builder = new SentenceBuilder();
                    var sentences = new List<Sentence>(0);
                    var pageBuilder = new PageBuilder(5);
                    while (fileReader.Read(reader) != 0)
                    {
                        while (builder.ExtractSentence(fileReader))
                        {
                            sentences.Add(builder.Build());
                        }
                    }

                    var text = new Text(sentences);
                    var concordance = new Concordance();
                    concordance.Fill(text, pageBuilder.Build(text));

                    IPrinter printer = new FilePrinter(destinationFile);
                    printer.Print(concordance);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"File {e.FileName} is not found: {e.Message}");
            }
        }
    }
}