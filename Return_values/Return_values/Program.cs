using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Return_values
{
    internal class Program
    {
        static int MyMethod(int x, int y)
        {
            return x+y;
        }
        static void Main(string[] args)
        {
         
            int z = MyMethod(3, 1);
            Console.WriteLine(z);
            Console.ReadLine();
        }
    }
}
