using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head;

        private ListNode<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            ListNode<T> newHead = new ListNode<T>(element);

            if (Count == 0)
            {
                head = tail = newHead;
            }
            else
            {
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            ListNode<T> newTail = new ListNode<T>(element);

            if (Count == 0)
            {
                head = tail = newTail;
            }
            else
            {
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = head.Value;

            head = head.NextNode;

            if (head != null)
            {
                head.PreviousNode = null;
            }
            else
            {
                tail = null;
            }
            Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = tail.Value;

            tail = tail.PreviousNode;

            if (tail != null)
            {
                tail.NextNode = null;
            }
            else
            {
                head = null;
            }
            Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var current = head;

            while (current != null)
            {
                action(current.Value);
                current = current.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            var node = head;

            for (int i = 0; i < Count; i++)
            {
                array[i] = node.Value;
                node = node.NextNode;
            }

            return array;
        }
    }
}