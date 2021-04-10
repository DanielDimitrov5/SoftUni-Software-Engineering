using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    class CustomStack<T> : IEnumerable<T>
    {
        private LinkedList<T> stack;

        public int Count { get; set; }
        public CustomStack(params T[] elements)
        {
            stack = new LinkedList<T>(elements);
            Count = stack.Count;
        }

        public void Push(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                stack.AddLast(elements[i]);
                Count++;
            }
        }

        public T Pop()
        {
            T result = stack.Last.Value;

            stack.RemoveLast();
            Count--;

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in stack.Reverse())
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return stack.GetEnumerator();
        }
    }
}
