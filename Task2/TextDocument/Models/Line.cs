using System.Collections.Generic;
using Task2.TextDocument.Interfaces;

namespace Task2.TextDocument.Models
{
    public class Line
    {
        private readonly List<ISentenceItem> _items;
        public List<ISentenceItem> Items => new List<ISentenceItem>(_items);

        public Line()
        {
            _items = new List<ISentenceItem>(0);
        }

        public bool AddItem(ISentenceItem item)
        {
            _items.Add(item);
            return item.Value.Equals("\r\n");
        }
    }
}