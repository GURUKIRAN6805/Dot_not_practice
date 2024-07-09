using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMethod_Practice
{
     class Program
    {
        static void MyMethod(string name, int age)
        {
            Console.WriteLine(name + "is" + age);
        }
        static void Main(string[] args)
        {
            MyMethod("sky", 23);
            MyMethod("Guru", 22);
            Console.ReadLine();
        }
    }
}
