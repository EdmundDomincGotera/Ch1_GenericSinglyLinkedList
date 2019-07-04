using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch1_GenericSinglyLinkedList
{
    public partial class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; internal set; }

        public Node(T data)
        {
            Data = data;
        }
    }
}
