using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethod
{
    public class Box<T>
        where T : IComparable
    {
        public Box(T type)
        {
            this.type = type;
        }

        public T type { get; set; }

        public override string ToString()
        {
            return $"{type.GetType()}: {type}";
        }
    }
}
