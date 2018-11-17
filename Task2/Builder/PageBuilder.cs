using System.Collections.Generic;
using System.Linq;
using Task2.TextDocument.Interfaces;
using Task2.TextDocument.Models;

namespace Task2.Builder
{
    public class PageBuilder
    {
        private readonly int _pageSize;

        public PageBuilder(int pageSize)
        {
            _pageSize = pageSize;
        }

        public List<Page> Build(Text text)
        {
            var line = new Line();
            var page = new Page(_pageSize);
            var pages = new List<Page>(0);
            // дописывание целых строк к странице
            text.Sentences
                .ForEach(x => x.SentenceItems
                    .ForEach(delegate (ISentenceItem item)
                    {
                        if (!line.AddItem(item))
                        {
                            return;
                        }

                        if (!page.AddLine(line))
                        {
                            pages.Add(page);
                            page = new Page(_pageSize);
                            page.AddLine(line);
                        }
                        else
                        {
                            line = new Line();
                        }
                    }));
            // дописывание остатка строки к странице
            if (line.Items.Count != 0)
            {
                if (!page.AddLine(line))
                {
                    pages.Add(page);
                    page = new Page(_pageSize);
                    page.AddLine(line);
                }
            }
            // запись последней страницы в список
            pages.Add(page);
            return pages;
        }
    }
}