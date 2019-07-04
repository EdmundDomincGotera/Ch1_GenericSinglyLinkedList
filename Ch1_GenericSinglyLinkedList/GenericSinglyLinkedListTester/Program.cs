using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch1_GenericSinglyLinkedList;
using ComparerSample;

namespace GenericSinglyLinkedListTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var sl = new SinglyLinkedList<Person>();

            var p1 = new Person("Cedrick", "Cederiosa", new DateTime(year: 2000, month: 9, day: 02));
            var p2 = new Person("Noel", "Maculbe", new DateTime(year: 1999, month: 7, day: 11));
            var p3 = new Person("Brenn", "Hong", new DateTime(year: 1998, month: 12, day: 22));
            var p4 = new Person("Johan", "Fernandez", new DateTime(year: 1999, month: 8, day: 16));

            sl.AddToTail(p1);
            sl.AddToTail(p2);
            sl.AddToTail(p3);
            sl.AddToTail(p4);

            foreach (var person in sl)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("Using SearchForPosition using the default comparer");
            var resultingPosition = sl.SearchForPosition(p4);
            Console.WriteLine($"Found at position {resultingPosition}");

            Console.WriteLine("Using SearchForPosition using PersonNameLenghtComparer");
            var comparer = new PersonNameLengthComparer();
            resultingPosition = sl.SearchForPosition(p2, comparer);
            Console.WriteLine($"found at position {resultingPosition}");

            Console.ReadLine();
        }
    }

    public class FirstPlusLastNameLengthComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int len1 = x.FirstName.Length + x.LastName.Length;
            int len2 = y.FirstName.Length + y.LastName.Length;
            if (len1 == len2) return 0;
            if (len1 > len2) return 1;
            if (len1 < len2) return -1;

            return 0;
        }
    }
}
