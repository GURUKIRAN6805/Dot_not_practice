using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary;

namespace MyConsoleApp
{
     class Program
    {
        static void Main(string[] args)
        {
            {
                MyClass myClass = new MyClass(); // Create an instance of MyClass from the library
                myClass.DisplayMessage(); // Call the method from MyClass

                Console.ReadLine(); // Keep the console window open
            }
        }
    }
}
