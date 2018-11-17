using System;
using System.IO;
using System.Security;
using Task2.Glossary;

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
            try
            {
                using (var writer = new StreamWriter(_fileName, false))
                {
                    foreach (var t in concordance.Entries)
                    {
                        writer.WriteLine($"{t.Word.Value, -10}{t.Frequency}: {string.Join(",", t.Lines)}");
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine($"Access is denied: {e.Message}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Incorrect names in path: {e.Message}");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Directory not found: {e.Message}");
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine($"Path or file name is too long: {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Incorrect path: {e.Message}");
            }
            catch (SecurityException e)
            {
                Console.WriteLine($"Something error in security: {e.Message}");
            }
        }
    }
}