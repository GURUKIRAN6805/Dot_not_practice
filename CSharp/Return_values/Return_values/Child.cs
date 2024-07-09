using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Return_values
{
    internal class Child
    {
        static void MyMethod(string child1, string child2, string child3)
        {
            Console.WriteLine(child1);
        }
        static void main(string[] args)
        {
            MyMethod(child1: "sky", child2: "guru", child3: "jhon");
            Console.ReadLine();
        }
    }
}
