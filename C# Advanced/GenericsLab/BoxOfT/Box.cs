using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        Stack<T> stack;

        public Box()
        {
            stack = new Stack<T>();
        }

        public int Count { get { return stack.Count; } }

        public void Add(T element)
        {
            stack.Push(element);
        }

        public T Remove()
        {
            T returnedElement = stack.Pop();
            return returnedElement;
        }
    }
}
