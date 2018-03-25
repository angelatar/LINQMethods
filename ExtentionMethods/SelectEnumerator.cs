using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethods_NS
{
    public class SelectEnumerator<TSource, TResult> : IEnumerator<TResult>
    {
        private readonly IEnumerable<TSource> source;

        private TSource current;

        private readonly Func<TSource, TResult> selector;

        private  IEnumerator<TSource> customEnumerator ;

        private int index;

        public SelectEnumerator(IEnumerable<TSource> source, Func<TSource, TResult> select)
        {
            this.selector = select;
            this.source = source;
            this.current = default(TSource);
            this.customEnumerator = this.source.GetEnumerator();
            index = -1;
        }

        public TResult Current
        {
            get
            {
                return this.selector(this.current);
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            this.index++;
            if(this.customEnumerator.MoveNext())    
                this.current = this.customEnumerator.Current;
            return this.index < this.source.Count();
        }

        public void Reset()
        {
            this.current = default(TSource);
            this.index = -1;
            this.customEnumerator = this.source.GetEnumerator();
        }
    }
}
