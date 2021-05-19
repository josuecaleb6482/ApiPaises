using System;
using System.Collections.Generic;
using System.Linq;

namespace Paises.Paging
{
    public class PagedList <T>:List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HastPrevius { get; set; }
        public bool HasNext { get; set; }
        public PagedList(List<T> items, int pageNumber, int count, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> GetPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber-1)* pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber,pageSize);
        }
    }
}