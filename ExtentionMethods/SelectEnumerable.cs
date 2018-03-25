using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods_NS
{
    public class SelectEnumerable<TSource, TResult> : IEnumerable<TResult>
    {
        private readonly Func<TSource, TResult> selector;

        private readonly IEnumerable<TSource> source;

        public SelectEnumerable(IEnumerable<TSource> source, Func<TSource, TResult> select)
        {
            this.source = source;
            this.selector = select;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            return new SelectEnumerator<TSource, TResult>(this.source, this.selector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
