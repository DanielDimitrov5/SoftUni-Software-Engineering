using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoubleLinkedList
{
    class DoubleLinkedList
    {
        private int count;
        private bool reversed = false;

        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void AddHead(Node node)
        {
            count++;

            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }
            node.Next = Head;
            Head.Previous = node;
            Head = node;
        }

        public void AddTail(Node node)

        {
            count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                count++;
                return;
            }

            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public Node RemoveHead()
        {
            if (Head == null)
            {
                return null;
            }

            Node nodeToReturn = Head;

            count--;

            if (Head.Next != null)
            {
                Head = Head.Next;
                Head.Previous = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }

            return nodeToReturn;
        }

        public Node RemoveTail()
        {
            if (Tail == null)
            {
                return null;
            }

            Node nodeToReturn = Tail;

            count--;

            if (Tail.Previous != null)
            {
                Tail = Tail.Previous;
                Tail.Next = null;
            }
            else
            {
                Head = null;
                Tail = null;
            }

            return nodeToReturn;
        }

        public void Foreach(Action<Node> action)
        {
            Node current = Head;

            while (current != null)
            {
                action(current);

                if (reversed)
                {
                    current = current.Previous;
                }
                else
                {
                    current = current.Next;
                }
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[count];

            int index = 0;

            Foreach(x =>
            {
                array[index++] = x.Value;
            });

            return array;
        }

        //Reverse not fully functional
        public void Reverse()
        {
            Node temp = Head;
            Head = Tail;
            Tail = temp;

            reversed = !reversed;
        }
    }
}
