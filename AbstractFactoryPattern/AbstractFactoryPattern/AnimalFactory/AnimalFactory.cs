using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AnimalFactory
{
    public class AnimalFactory
    {
        public abstract IAnimal GetAnimal(string animaltype);
        public static AnimalFactory GetAnimalFactory(string Factorytype)
        {
            if(Factorytype.Equals("Land"))
            {
                return new LandAnimalFactory();
            }
            else if(Factorytype.Equals())
            {
                
            }
        }
    }
}
