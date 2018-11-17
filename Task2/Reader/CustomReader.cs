using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task2.Reader
{
    public class CustomReader
    {
        private readonly StringBuilder _buffer;
        private readonly int _blockSize;
        public string Accumulator => _buffer.ToString();

        public CustomReader(int blockSize)
        {
            if (blockSize < 0)
            {
                throw new ArgumentException("Incorrect buffer size. Expected at least 1.");
            }
            _buffer = new StringBuilder(0);
            _blockSize = blockSize;
        }

        public int Read(StreamReader reader)
        {
            var count = 0;
            try
            {
                var buffer = new char[_blockSize];
                count = reader.ReadBlock(buffer, 0, _blockSize);
                _buffer.Append(buffer.Take(count).ToArray());
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"The reader is not present: {e.Message}");
            }
            catch (ObjectDisposedException e)
            {
                Console.WriteLine($"The {e.ObjectName} reader is already closed: {e.Message}");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return count;
        }

        public void Reduce(int start, int length)
        {
            _buffer.Remove(start, length);
        }
    }
}