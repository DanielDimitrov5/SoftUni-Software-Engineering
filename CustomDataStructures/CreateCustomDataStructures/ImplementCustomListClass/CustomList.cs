using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementCustomListClass
{
    public class CustomList : IEnumerable
    {
        private const int initialCapacity = 2;
        private int[] items;

        public CustomList()
        {
            items = new int[initialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
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

        public void Add(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = element;
            Count++;
        }

        public void Insert(int index, int element)
        {
            if (Count <= index || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count == items.Length)
            {
                Resize();
            }

            int[] copy = new int[Count];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            for (int i = 0; i < Count; i++)
            {
                if (i < index)
                {
                    continue;
                }

                items[i + 1] = copy[i];

            }
            Count++;
            items[index] = element;
        }

        public int RemoveAt(int index)
        {
            if (Count <= index || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int elementToReturn = items[index];

            items[index] = default(int);

            Shift(index);

            Count--;

            if (items.Length / 4 >= Count)
            {
                Shrink();
            }
            return elementToReturn;
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

        private void Shift(int index)
        {
            for (int i = index; i < items.Length - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }

        public bool Contains(int element)
        {
            foreach (var item in items)
            {
                if (item == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (secondIndex >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        public void Reverse()
        {
            int[] reversed = new int[Count];

            int index = 0;

            for (int i = Count - 1; i >= 0; i--)
            {
                reversed[i] = items[index++];
            }

            items = reversed;
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

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }
    }
}
