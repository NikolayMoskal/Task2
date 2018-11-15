using System.Collections.Generic;

namespace Task2.TextDocument.Models
{
    public class Page
    {
        private readonly List<Line> _lines;
        private readonly int _pageSize;
        public List<Line> Lines => new List<Line>(_lines);

        public Page(int pageSize)
        {
            _pageSize = pageSize;
            _lines = new List<Line>(0);
        }

        public bool AddLine(Line line)
        {
            if (_lines.Count >= _pageSize) return false;
            _lines.Add(line);
            return true;
        }
    }
}