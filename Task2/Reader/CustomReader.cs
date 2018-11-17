using System;
using System.IO;
using System.Linq;
using System.Text;
using NLog;

namespace Task2.Reader
{
    public class CustomReader
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly StringBuilder _buffer;
        private readonly int _blockSize;
        public string Accumulator => _buffer.ToString();

        public CustomReader(int blockSize)
        {
            if (blockSize < 0)
            {
                throw new ArgumentException($"Incorrect buffer size: {blockSize}. Expected at least 1.");
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
                Logger.Error($"The reader is not present: {e.Message}");
            }
            catch (ObjectDisposedException e)
            {
                Logger.Error($"The {e.ObjectName} reader is already closed: {e.Message}");
            }
            catch (IOException e)
            {
                Logger.Error($"Error while reading file: {e.Message}");
            }

            return count;
        }

        public void Reduce(int start, int length)
        {
            _buffer.Remove(start, length);
        }
    }
}