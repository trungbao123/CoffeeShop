using System;
using System.Collections.Generic;
using System.Linq;

namespace RazorSample
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(IEnumerable<T> items, int pageIndex, int pageSize, int count)
        {
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            PageIndex = pageIndex;
            this.AddRange(items);
        }
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public bool HasNext
        {
            get { return PageIndex < TotalPage; }
        }
        public bool HasPrevious
        {
            get { return PageIndex > 1; }
        }

        public static PaginatedList<T> Create(IEnumerable<T> source, int pageIndex, int pageSize)
        {
            int count = source.Count();

            var items = source.Skip((pageIndex - 1) * pageSize)
                             .Take(pageSize);

            return new PaginatedList<T>(items, pageIndex, pageSize, count);
        }
    }
}