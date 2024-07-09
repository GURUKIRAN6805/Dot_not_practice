using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animalfactory;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal animal = null;
             AnimalFactory.AnimalFactory = null;
        }
    }
}
