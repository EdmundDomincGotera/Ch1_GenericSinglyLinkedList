using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch1_SinglyLinkedList_1
{
    class Node
    {
        public string Data { get; set; }
        public Node Next { get; internal set; }

        public Node(string data)
        {
            Data = data;
        }
    }
}
