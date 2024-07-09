using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMethod
{
    internal class MyMethod_name_age
    {
        static void MyMethod(string name, int age)
        {
            Console.WriteLine("My name is" + name + " my age is" + age);
        }
        static void main(string[] args)
        {
            MyMethod("sky", 23);
            MyMethod("Guru", 22);
            Console.ReadLine();
        }
    }
}
