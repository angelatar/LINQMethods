using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods_NS
{
    public class WhereEnumerable<TSource> : IEnumerable<TSource>
    {
        private readonly Func<TSource, bool> predicate;

        private readonly IEnumerable<TSource> source;


        public WhereEnumerable(IEnumerable<TSource> s,Func<TSource,bool> pred)
        {
            this.predicate = pred;
            this.source = s;
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return new WhereEnumerator<TSource>(this.source, this.predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
