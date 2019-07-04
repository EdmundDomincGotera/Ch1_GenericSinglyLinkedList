using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person("Cedrick","Cederiosa", new DateTime(year: 2000, month: 9, day: 02));
            var p2 = new Person("Noel", "Maculbe", new DateTime(year: 1999, month: 7, day: 11));

            restart:
            Console.WriteLine(p1);
            Console.WriteLine(p2);


            Console.WriteLine("Select a comparer:");
            Console.WriteLine("Enter 1 to use the default comparer.");
            Console.WriteLine("Enter 2 to use the FirstName comparer.");
            Console.WriteLine("Select a comparer:");
            var input = Console.ReadLine();

            while (input != "1" && input != "2")
            {
                Console.WriteLine("Enter 1 to use the default comparer.");
                Console.WriteLine("Enter 2 to use the FirstName comparer.");
                Console.WriteLine("Select a comparer.");
                input = Console.ReadLine();
            }

            IComparer<Person> comparer;
            if (input == "1")
            {
                comparer = Comparer<Person>.Default;
                var result = comparer.Compare(p1, p2);
                if (result == 0)
                    Console.WriteLine("They have the same age.");
                if (result >= 1)
                    Console.WriteLine($"{p1.FirstName} is older than {p2.FirstName}");
                if (result <= -1)
                    Console.WriteLine($"{p1.FirstName} is younger than {p2.FirstName}");
            }
            if (input == "2")
            {
                comparer = Comparer<Person>.Default;
                var result = comparer.Compare(p1, p2);
                if (result == 0)
                    Console.WriteLine("They have the same lenght of first name.");
                if (result >= 1)
                    Console.WriteLine($"{p1.FirstName.Length} is longer than {p2.FirstName.Length}");
                if (result <= -1)
                    Console.WriteLine($"{p1.FirstName} is shorter than {p2.FirstName}");
            }

            Console.Write("Do you want to continue?");
            var cont = Console.ReadLine();
            if (cont == "y")
            {
                Console.Clear();
                goto restart;
            }


            ComparePersonByAge(p1, p2);

            Console.ReadLine();
            Console.Clear();
            goto restart;
        }

        private static void ComparePersonByAge(Person p1, Person p2)
        {
            var result = Comparer<Person>.Default.Compare(p1, p2);
            if (result == 0)
            {
                Console.WriteLine("They have the same age.");
            }
            if (result >= 1)
            {
                Console.WriteLine($"{ p1.FirstName} is older than {p2.FirstName}");
            }
            if (result <= -1)
            {
                Console.WriteLine($"{ p1.FirstName} is younger than {p2.FirstName}");
            }
        }

        //another comparer for the PErson Class
        //this class compares the lenght of the FirstName of two persons
        
    }

    public class PersonNameLengthComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            if (x.FirstName.Length == y.FirstName.Length) return 0;
            if (x.FirstName.Length > y.FirstName.Length) return 1;
            if (x.FirstName.Length < y.FirstName.Length) return -1;

            return 0;
        }
    }

    public class Person : IComparable<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age => (DateTime.Now - Birthdate).Days / 365;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("------------------\n");
            sb.Append($"{LastName}, {FirstName}\n");

            int months = (int)((Age - (int)Age) * 12);

            sb.Append($"Age: {(int)Age} years and {months} months\n");
            sb.Append("-------------------\n");
            return sb.ToString();

        }
        public Person(string firstName, string lastName, DateTime birthdDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdDate;
        }

        public int CompareTo(Person other)
        {
            if (Age == other.Age) return 0;
            if (Age < other.Age) return -1;
            if (Age > other.Age) return 1;

            return 0;
        }
    }

}
