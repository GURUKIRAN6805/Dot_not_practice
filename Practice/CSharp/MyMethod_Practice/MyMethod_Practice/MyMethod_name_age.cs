using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMethod_Practice
{
    internal class MyMethod_name_age
    {
        static void MyMethod(string name)
        {
            Console.WriteLine(name + "Infinite");
        }
        static void main(string[] args)
        {
            MyMethod("sky");
            MyMethod("Guru");
            Console.ReadLine();
        }
    }
}
