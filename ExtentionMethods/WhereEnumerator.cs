using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods_NS
{
    public class WhereEnumerator<TSource> : IEnumerator<TSource>
    {
        private readonly IEnumerable<TSource> source;

        private TSource current;

        private readonly Func<TSource, bool> predicate;

        private IEnumerator<TSource> customEnumerator;


        public WhereEnumerator(IEnumerable<TSource> source,Func<TSource,bool> pred)
        {
            this.source = source;
            this.predicate = pred;
            this.current = default(TSource);
            this.customEnumerator = this.source.GetEnumerator();
        }

        public TSource Current
        {
            get
            {
                return this.current;                
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
            while (this.customEnumerator.MoveNext())
            {
                if (this.predicate(this.customEnumerator.Current))
                {
                    this.current = this.customEnumerator.Current;
                    return true;
                }
            }
            return false;
        }

        public void Reset()
        {
            this.current = default(TSource);
            this.customEnumerator = this.source.GetEnumerator();
        }
    }
}
