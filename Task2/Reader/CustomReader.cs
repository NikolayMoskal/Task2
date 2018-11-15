using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task2.Reader
{
    public class CustomReader
    {
        private static readonly StringBuilder Buffer = new StringBuilder(0);
        private readonly int _blockSize;
        public static string Accumulator => Buffer.ToString();
        
        public CustomReader(int blockSize)
        {
            _blockSize = blockSize > 0 ? blockSize : 1;
        }

        public int Read(StreamReader reader)
        {
            var count = 0;
            try
            {
                var buffer = new char[_blockSize];
                count = reader.ReadBlock(buffer, 0, _blockSize);
                Buffer.Append(buffer.Take(count).ToArray());
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("The reader is not present");
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine("The reader is already closed");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            return count;
        }

        public static void Reduce(int start, int length)
        {
            Buffer.Remove(start, length);
        }
    }
}