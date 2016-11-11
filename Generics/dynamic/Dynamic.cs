using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.dynamic
{
    class Dynamic
    {
        static void Foo(int x)
        {
            Console.WriteLine("1");
        }

        static void Foo(string y)
        {
            Console.WriteLine("2");
        }

        public Dynamic()
        {
            dynamic x = "troolol";
            dynamic y = 2;
            Foo(y);
            Foo(x);

            // test czy dam rade ^^
            using (var str = new StreamWriter("plik.txt"))
            {
                
                str.WriteLine("trolololo");
                str.WriteLine("trolololo");
                str.WriteLine("trolololo");
                str.WriteLine("trolololo");
                str.WriteLine("trolololo");
                str.Close();
            }
            using (var str = new StreamReader("plik.txt"))
            {
                List<string> linesList = new List<string>();

                while (!str.EndOfStream)
                {
                    linesList.Add(str.ReadLine());
                }
                foreach (var line in linesList)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
