using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods_NS
{
    public class OrderByEnumerable<TSource> : IOrderedEnumerable<TSource> 
    {
        private List<TSource> list = new List<TSource>();

        public OrderByEnumerable(List<TSource> l)
        {
            this.list = l;
        }

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            if (descending == true)
                return this.list.OrderByDescending(keySelector);
            return this.list.OrderBy(keySelector);

        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return this.list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.list.GetEnumerator();
        }
    }
}
