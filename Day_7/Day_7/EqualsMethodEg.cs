using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Day_7.IName;

namespace Day_7
{
    class EqualsMethodEg
    {
        public enum Direction { East, West, North, South };
        public static void Main()
        {
            // Equality operator with value types
            int number1 = 10;
            int number2 = 10;
            Console.WriteLine($"Number 1 == Number2 : {number1 == number2}");
            Console.WriteLine($"Number1.Equals(Number2) : {number1.Equals(number2)}");
            Console.WriteLine("--------------------");

            Direction d1 = Direction.East;
            Direction d2 = Direction.East;
            Console.WriteLine(d1 == d2);
            Console.WriteLine(d1.Equals(d2));
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

            // Call function for reference types
            Equality_With_ReferenceTypes();

            Console.Read();
        }

        public static void Equality_With_ReferenceTypes()
        {
            Customers c1 = new Customers();
            c1.FirstName = "Raviteja";
            c1.LastName = "Booraga";
            Customers c2 = c1;
            Console.WriteLine($"C1 == C2 : {c1 == c2} {c1.GetHashCode()} and {c2.GetHashCode()}");
            Console.WriteLine($"C1.Equals(C2) : {c1.Equals(c2)}");
            Console.WriteLine("--------------------");

            c2 = new Customers();
            c2.FirstName = "Raviteja";
            c2.LastName = "Booraga";

            Console.WriteLine($"C1 == C2 : {c1 == c2} {c1.GetHashCode()} and {c2.GetHashCode()}");
            Console.WriteLine($"C1.Equals(C2) : {c1.Equals(c2)}");
        }
    }

    public class Customers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


}
