using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch1_SinglyLinkedList_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sl = new SinglyLinkedList();

            //sl.AddToTail(data:"A");
            //sl.AddToTail(data: "B");
            try
            {
                sl.AddToTail(data: "A");
                sl.AddToTail(data: "B");
                sl.AddToTail(data: "C");
                sl.AddToTail(data: "D");
                sl.AddToTail(data: "F");
                sl.AddToTail(data: "G");

                sl.InsertAt(data: "E", position: 4);
                PrintNodes(sl);
                //var x = sl.Search("B");
                //x.Next = new Node(data: "D");
                //string dataToSearch = "C";
                ////PrintNodes(sl);
                //var result = sl.Search(dataToSearch);

                //Console.WriteLine(result.Data);
                //var tmp = sl.Head;
                //do
                //{
                //    Console.WriteLine(tmp.Data);
                //    tmp = tmp.Next;
                //}
                //while (tmp != sl.Tail);

                //Console.WriteLine(sl.Tail.Data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
        static void PrintNodes(SinglyLinkedList sl)
        {
            var tmp = sl.Head;
            while (tmp != sl.Tail)
            {
                Console.WriteLine(tmp.Data);
                tmp = tmp.Next;
            }
            Console.WriteLine(tmp.Data);
        }
    }
}
