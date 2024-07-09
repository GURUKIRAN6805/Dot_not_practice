using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_11
{
    class PersonDetails
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }


        {
          
        class Persons
        {
            public int Age;
            public PersonDetails pd; //compostiom

            public Persons(int age, string fn, string ln)
            {
                Age = age;
                pd = new PersonDetails(fn, ln);
            }

            //Shallow copy

            public object ShallowCopy()
            {
                return this.MemberwiseClone();
            }

            //deep copy

            public Persons DeepCopy()
            {
                Persons dcopy = new Persons(this.Age, pd.FirstName, pd.Lastname);
                return dcopy;
            }
        }
    }
    class Deep_ShallowCopy
    {
        public static void main()
        {
           Persons p1 = new Persons(22, "Keshava", "T");

            Persons p2 = (Persons) p1.ShallowCopy();
            Console.WriteLine($"The FirstName is {p1.pd.FirstName}, and LastName is {p1.pd.LastName}, and age is {p1.pd.age}");
            Console.WriteLine("----------");
            Console.WriteLine($"The FirstName is {p2.pd.FirstName}, and LastName is {p2.pd.LastName}, and age is {p2.pd.age}");

            p2.pd.FirstName = "Adikeshava";
            p2.pd.LastName = "S";

            Console.WriteLine(p1.pd.FirstName);
            Console.WriteLine(p2.pd.FirstName);

            Console.WriteLine("------Deep copy--------");
            Console.WriteLine($"The FirstName is {p1.pd.FirstName}, and LastName is {p1.pd.LastName}, and age is {p1.pd.age}");
            Console.WriteLine($"The FirstName is {p3.pd.FirstName}, and LastName is {p3.pd.LastName}, and age is {p3.pd.age}");
            Console.WriteLine("----------------");
            p3.pd.LastName = "Thummala";
            Console.WriteLine (p1.pd.LastName + " " + p1.pd.LastName);
            Console.WriteLine(p3.pd.LastName + " " + p1.pd.LastName);

            p1.Age = 30;
            Console.WriteLine("P1's Age after Change : " + p1.Age);

        }
    }
}
