using System;
using System.IO;
using System.Security;
using NLog;
using Task2.Glossary;

namespace Task2.Printer
{
    public class FilePrinter : IPrinter
    {
        private readonly string _fileName;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
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
                        writer.WriteLine($"{t.Word.Value, -20}{t.Frequency}: {string.Join(",", t.Lines)}");
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Logger.Error($"Access is denied: {e.Message}");
            }
            catch (ArgumentException e)
            {
                Logger.Error($"Incorrect names in path: {e.Message}");
            }
            catch (DirectoryNotFoundException e)
            {
                Logger.Error($"Directory not found: {e.Message}");
            }
            catch (PathTooLongException e)
            {
                Logger.Error($"Path or file name is too long: {e.Message}");
            }
            catch (IOException e)
            {
                Logger.Error($"Incorrect path: {e.Message}");
            }
            catch (SecurityException e)
            {
                Logger.Error($"Something error in security: {e.Message}");
            }
        }
    }
}