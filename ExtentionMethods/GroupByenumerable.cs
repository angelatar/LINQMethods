using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods_NS
{
    public class GroupByenumerable<TSource, TKey> : IEnumerable<IGrouping<TKey, TSource>>
    {
        private IEnumerable<TSource> source;

        private Func<TSource, TKey> keySelector;

        public GroupByenumerable(IEnumerable<TSource> s, Func<TSource, TKey> k)
        {
            this.source = s;
            this.keySelector = k;
        }

        public IEnumerator<IGrouping<TKey, TSource>> GetEnumerator()
        {
            return this.source.ToLookup(keySelector).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
