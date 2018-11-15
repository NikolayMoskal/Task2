using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using Task2.Builder;
using Task2.Printer;
using Task2.Reader;
using Task2.TextDocument.Models;

namespace Task2
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var fileName = ConfigurationManager.AppSettings["sourceFile"];
            using (var reader = new StreamReader(fileName))
            {
                var fileReader = new CustomReader(blockSize: 10);
                var builder = new SentenceBuilder();
                var sentences = new List<Sentence>(0);
                var pageBuilder = new PageBuilder(pageSize: 5);
                while (fileReader.Read(reader) != 0)
                {
                    while (builder.HasSentence(CustomReader.Accumulator))
                    {
                        sentences.Add(builder.Build());
                    }
                }
                var text = new Text(sentences);
                var concordance = new Concordance();
                concordance.Fill(text, pageBuilder.Build(text));
                IPrinter printer = new ConsolePrinter();
                printer.Print(concordance);
            }
        }
    }
}