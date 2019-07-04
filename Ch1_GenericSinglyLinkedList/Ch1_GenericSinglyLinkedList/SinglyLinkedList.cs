using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch1_GenericSinglyLinkedList
{
    public class SinglyLinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            if (Head == null) yield break;
            var tmp = Head;
            while (tmp != Tail)
            {
                yield return tmp.Data;
                tmp = tmp.Next;
            }
            yield return Tail.Data;
        }
        public Node<T> Search(T dataToSearch, IComparer<T> comparer = null)
        {
            if (Head == null)
                return null;
            var tmp = Head;
            while (tmp.Next != Tail)
            {
                if (Comparer<T>.Default.Compare(tmp.Data, dataToSearch) == 0)
                //tmp.Data == dataToSearch)
                {
                    return tmp;
                }
                tmp = tmp.Next;
            }
            if (Comparer<T>.Default.Compare(Tail.Data, dataToSearch) == 0)
                //Tail.Data == dataToSearch)
                return Tail;
            return null;
        }
        public int SearchForPosition(T dataToSearch, IComparer<T> comparer = null)
        {
            if (comparer == null) comparer = Comparer<T>.Default;

            if (Head == null) return -1;

            int position = 0;
            var tmp = Head;
            while (tmp != Tail)
            {
                position++;
                if (Comparer<T>.Default.Compare(tmp.Data, dataToSearch) == 0)
                //tmp.Data == dataToSearch)
                {
                    return position;
                }
                tmp = tmp.Next;
            }
            if (Comparer<T>.Default.Compare(Tail.Data, dataToSearch) == 0)
            //Tail.Data == dataToSearch)
            {
                return ++position;
            }
            return -1;
        }

        public void AddToHead(T data)
        {
            var x = new Node<T>(data);
            Count++;
            if (Head == null)
            {
                Head = x;
                Tail = x;
            }
            var tmp = Head;
            Head = x;
            x.Next = tmp;
        }
        public void AddToTail(T data)
        {
            var x = new Node<T>(data);
            Count++;
            if (Head == null)
            {
                Head = x;
                Tail = x;
                return;
            }
            Tail.Next = x;
            Tail = x;
        }
        public void RemoveFromHead()
        {
            if (Head == null)
                throw new Exception(message: "Linked list is empty.");
            Count--;
            //if linked list has only one node
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
                return;
            }

            //if linked list has more than two or more nodes
            Head = Head.Next;

        }
        public void RemoveFromTail()
        {
            if (Head == null)
                throw new Exception(message: "Linked list is empty.");
            Count--;
            //if linked list has only one node
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
                return;
            }

            //if linked list has more than two or more nodes
            var tmp = Head;
            while (tmp.Next != Tail)
            {
                tmp = tmp.Next;
            }
            Tail = tmp;
            Tail.Next = null;
            tmp = null;
        }
        //public int SearchForPosition(string dataToSearch)
        //{
        //    if (Head == null) return -1;

        //    int position = 0
        //}
        public void InsertAt(T data, int position)
        {
            if (position < 0)
                throw new InvalidOperationException(message: "Position must be positive.");
            if (position == 0)
            {
                AddToHead(data);
                return;
            }
            if (position == Count)
            {
                AddToTail(data);
                return;
            }

            // insert in between

            if (position > 0 && position < Count)
            {
                var newNode = new Node<T>(data);
                var prev = Head;
                var next = Head;

                int pos1 = 0;
                var tmp = Head;
                while (tmp != Tail)
                {
                    if (pos1 == position - 1)
                        prev = tmp;
                    tmp = tmp.Next;
                    pos1++;
                }
                pos1 = 0;

                if (position + 1 == Count) next = Tail;
                else
                {
                    tmp = Head;
                    while (tmp != Tail)
                    {
                        if (pos1 == position)
                            next = tmp;
                        tmp = tmp.Next;
                        pos1++;
                    }
                }

                prev.Next = newNode;
                newNode.Next = next;
            }
            Count++;
        }
    }
}
