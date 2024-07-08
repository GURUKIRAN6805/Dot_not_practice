using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMethod
{
    internal class Program
    {
        static void MyMethod()
        {
            Console.WriteLine("I'm method");

        }
        static void Main(string[] args)
        {
            MyMethod();
            MyMethod();
            MyMethod();
            Console.ReadLine();
        }
    }
}
