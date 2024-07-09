using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_5
{
    class ConstructorTypes
    {
        int var1;
        public ConstructorTypes()
        {
            var1 = 6;
            Console.WriteLine("called thru 2nd constructor" + var1);
        }
        public ConstructorTypes(int x) : this()
        {
            Console.WriteLine("This is 2nd Constructor");
        }
        public ConstructorTypes(int a, string s, double d) : this(25)
        {
            Console.WriteLine(a + " " + s + " " + d);
        }
        static void Main(string[] args)
        {
            ConstructorTypes ct = new ConstructorTypes(5, "Hello", 5.5);
            Console.Read();
        }

    }

    public class Dog
    {
        public string Name;
        public int Age;

        protected Dog()
        {
            Console.WriteLine("We are constructing Dog..");
        }
    }
    public class Germansheperd : Dog
    {

        public double fiestyfactor;
        public Germansheperd(string name, int age, double ff)
        {
            //implicity invokes the construtor in the base class
            Console.WriteLine(string name, int age, double ff)
        }
    }

}


