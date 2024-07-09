using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMethod
{
    internal class MyMethod_name
    {

        static void MyMethod(string name)
        {
            Console.WriteLine(name);
        }

        static void Main(String[] args)
        {
            MyMethod("jhon");
            MyMethod("abcd");
            MyMethod("efgh");
            Console.ReadLine();
        }
    }
}
