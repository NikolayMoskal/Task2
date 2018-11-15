using System.IO;

namespace Task2.Printer
{
    public class FilePrinter : IPrinter
    {
        private readonly string _fileName;
        
        public FilePrinter(string fileName)
        {
            _fileName = fileName;
        }

        public void Print(Concordance concordance)
        {
            using (var writer = new StreamWriter(_fileName, false))
            {
                foreach (var t in concordance.Entries)
                {
                    writer.WriteLine("{0}\t\t\t{1}: {2}", t.Word.Value, t.Frequency, string.Join(",", t.Lines));
                }
            }
        }
    }
}