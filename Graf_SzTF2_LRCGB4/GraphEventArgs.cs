using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graf_SzTF2_LRCGB4
{
    class GraphEventArgs<T>
    {
        public T From { get; }
        public T To { get; }


        public GraphEventArgs(T from, T to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
