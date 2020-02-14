using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Program
    {
        public class Person
        {
            public string first_name;
            public string last_name;
            public Person father;

            public Person(string _first_name, string _lastname, Person _father)
            {
                first_name = _first_name;
                last_name = _lastname;
                father = _father;
            }
        }

        public class Element
        {
            public int Key1;
            public Element[] key2;
            public Person User;
        }


        public static void printDepth(Element[] e)
        {
            if (e != null && e.Length > 0) //Code should not crash for null element
            {
                for (int i = 0; i < e.Length; i++)
                {
                    Console.WriteLine("Key" + e[i].Key1 + " " + e[i].Key1);
                    if (e[i].key2  != null  )
                    {
                        
                        Console.WriteLine("Key" + (e[i].Key1 + 1) + " " + e[i].Key1);
                        printDepth(e[i].key2);
                    }
                    else if (e[i].User != null)
                    {
                        printPerson(e[i].User, (e[i].Key1 + 2));
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        public static void printPerson(Person a, int depth)
        {
            if (a != null)
            {
                Console.WriteLine(nameof(a.first_name) + " " + depth);
                Console.WriteLine(nameof(a.last_name) + " " + depth);
                Console.WriteLine(nameof( a.father) + " " + depth);

                if (a.father != null)
                    printPerson(a.father, depth + 1);

                return;
            }
        }


        static void Main(string[] args)
        {
            
            Element a = new Element();

            Person preson_a = new Person("User", "1", null);
            Person preson_b = new Person("User", "1", preson_a);

            a.Key1 = 1;
            a.key2 = new Element[] { new Element(){
                                         Key1 = 2,
                                         key2 = new Element[] { new Element(){
                                                     Key1 = 1,
                                                     User = preson_b
            }}
            }
            };


            Element[] arr = new Element[1] { a};
            printDepth(arr);

        }
    }
}
