using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMethod_Practice
{
    internal class country
    {
        static void MyMethod(string country = "Norway")

        {
            Console.WriteLine(country);
        }
        static void main(string[] args)
        {
            MyMethod("India");
            MyMethod("Brazil");
            MyMethod();
            MyMethod("Usa");
            Console.ReadLine();
        }
    }
}
