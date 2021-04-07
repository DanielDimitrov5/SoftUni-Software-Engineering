using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class CustomTuple<T1, T2>
    {
        public CustomTuple(T1 item1, T2 item2)
        {
            this.item1 = item1;
            this.item2 = item2;
        }

        public T1 item1 { get; private set; }
        public T2 item2 { get; private set; }

        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
