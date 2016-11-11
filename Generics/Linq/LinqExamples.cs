using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Generics.Linq
{
    public class LinqExamples
    {
        public LinqExamples()
        {
            Console.Clear();
            string[] names = new string[]
            {
                "Arek", "Ala","Gosia"
            };

            IEnumerable<string> filteredNames = names.Where(l => l.Length >= 4);
            foreach (var filteredName in filteredNames)
            {
                Console.Write(filteredName +"|");
            }
            Console.WriteLine("");

            IEnumerable<string> NamesToUpperCase = names.Select(n => n.ToUpper());
            foreach (var uppernames in NamesToUpperCase)
            {
                Console.Write(uppernames +"|");
            }
            Console.WriteLine();

            var query = names.Select(n => new
            {
                Name = n,
                Length = n.Length
            });
            foreach (var row in query)
            {
                Console.Write(row.Name +" - " +row.Length+"|");
            }
            Console.WriteLine();

            //Take skip
            int[] numbersInts = new int[] {1,2,3,4,5,6,7,8,9,10};
            foreach (var numbers in numbersInts.Skip(3))
            {
                Console.Write(numbers +",");
            }
            Console.WriteLine();

            foreach (var numbers in numbersInts.Take(2))
            {
                Console.Write(numbers + ",");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("First- " + numbersInts.First());
            Console.WriteLine("Last- " + numbersInts.Last());
            Console.WriteLine("ElementAt- " + numbersInts.ElementAt(1));
            Console.WriteLine("First n % 2 == 0 - " + numbersInts.First(n=>n%2==0));
            Console.WriteLine("Count - " + numbersInts.Count());
            Console.WriteLine("Min - " + numbersInts.Min());
            Console.WriteLine("Max - " + numbersInts.Max());
            Console.WriteLine("Avg - " + numbersInts.Average());

            //Kwantyfikatory, Containts, Any, All + SequenceEqual
            Console.WriteLine();
            Console.WriteLine("Has some number like 9 - " + numbersInts.Contains(9));
            Console.WriteLine("Has more than zero elements - " + numbersInts.Any());
            Console.WriteLine("Has odd number - " + numbersInts.Any(n=>n%2==1));
            Console.WriteLine("Has all odd numbers - " + numbersInts.All(n=>n%2==1));
            Console.WriteLine("Is the same sequence like 1,2,3,4,5,6,7,8,9 -" + numbersInts.SequenceEqual(new int[] {1,2,3,4,5,6,7,8,9}));

            //Operatory zbiorow Concat-dodaje jedna sekwencje do drugie, Union-to samo ale bez powtorze, Intersect-część wspólna, Except-rożnica zbiorów
            Console.WriteLine();
            var seq1 = new int[] {1,2,3};
            var seq2 = new int[] {3,4,5};

            Console.WriteLine("Concat");
            foreach (var num in seq1.Concat(seq2))
            {
                Console.Write(num+"|");
            }
            Console.WriteLine();

            Console.WriteLine("Union");
            foreach (var num in seq1.Union(seq2))
            {
                Console.Write(num + "|");
            }
            Console.WriteLine();

            Console.WriteLine("Interect");
            foreach (var num in seq1.Intersect(seq2))
            {
                Console.Write(num + "|");
            }
            Console.WriteLine();

            Console.WriteLine("Exept");
            foreach (var num in seq1.Except(seq2))
            {
                Console.Write(num + "|");
            }
            Console.WriteLine();
            Console.WriteLine();

            //Opożnione wykonanie - Lazy execuion
            Console.WriteLine("Lazy execution");
            var numbers2 = new List<int> {1};
            IEnumerable<int> quert2 = numbers2.Select(n => n*10); // jesli dodam np ToArray to wykonanie nastąpi odrazu
            numbers2.Add(2);
            foreach (var num in quert2)
            {
                Console.Write(num + "|");
            }
            Console.WriteLine();
            Console.WriteLine();

            //WYRAŻENIA KASKADOWE I ZAPYTANIOWE
            string[] names3 = {"Arek","Ala","Ola","Gosia", "Daniel", "Jerzy"};
            foreach (var name in names3.Where(n=>n.Contains("e")).OrderBy(n =>n.Length).Select(n=>n.ToUpper()))//kaskadowo
            {
                Console.Write(name + "|");
            }
            Console.WriteLine();
            //to co wyzej tylko przez zapytanie
            foreach (var name in (from n in names3
                                  where n.Contains("e")
                                  orderby n.Length
                                  select n.ToUpper()))
            {
                Console.Write(name + "|");
            }
            Console.WriteLine();
            Console.WriteLine();

            //mix
            foreach (var name in (from n in names3
                                  where n.Length==names3.Min(n2=>n2.Length)
                                  orderby n.Length
                                  select n))
            {
                Console.Write(name + "|");
            }
            Console.WriteLine();
            Console.WriteLine();

            //let, ilosc liter imion bez liczenia samogolosek jest wieksza niz 2
            Console.WriteLine("ilosc liter imion bez liczenia samogolosek jest wieksza niz 2");
            foreach (var name in (from n in names3
                                  let vowelless = Regex.Replace(n, "[aąeęioóiy]", "")
                                  where vowelless.Length>2
                                  orderby vowelless
                                  select n + " - " + vowelless))
            {
                Console.Write(name + "|");
            }
            Console.WriteLine();
            //to samo tylko kaskadowo
            foreach (var name in names3.Select(n => new {n=n,vowelles = Regex.Replace(n,"[aąeęioóuy]","")}).Where(n=>n.vowelles.Length>2).OrderBy(n=>n.vowelles).Select(n=>(n.n + " - " + n.vowelles)))
            {
                Console.Write(name + "|");
            }
        }
    }
}
