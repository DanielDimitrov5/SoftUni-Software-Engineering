using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStackClass
{
    class CustomStack
    {
        private const int capacity = 4;
        private int[] items;

        public CustomStack()
        {
            items = new int[capacity];
        }

        public int Count { get; set; }

        public void Push(int element)
        {
            if (items.Length == Count)
            {
                Resize();
            }

            items[Count] = element;
            Count++;
        }

        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public int Pop()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            int toReturn = items[Count - 1];
            items[Count - 1] = default(int);
            Count--;

            if (items.Length / 4 >= Count)
            {
                Shrink();
            }

            return toReturn;
        }
        private void Shrink()
        {
            int[] copy = items;

            for (int i = 0; i < items.Length / 2; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }

        public int Peek()
        {
            if (items.Length == 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return items[Count - 1];
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < items.Length; i++)
            {
                action(items[i]);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                sb.Append(items[i] + " ");
            }

            return sb.ToString().Trim();
        }
    }
}
