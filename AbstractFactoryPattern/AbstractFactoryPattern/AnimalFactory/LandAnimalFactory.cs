﻿using AbstractFactoryPattern.ConcreteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern.AnimalFactory
{
     class LandAnimalFactory : AnimalFactory
    {
        public override IAnimal GetAnimal(string animaltype)
        {
            if (animaltype.Equals("Dog"))
            {
                return new Dog();
            }
            else if (animaltype.Equals("Cat"))
                { 
                return new Cat(); 
            }
            
        }
    }
}
