using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Generics.async
{
    public class AsyncExamples
    {
        int ComplexCalculation()
        {
            Console.WriteLine("Calculating Has started");
            double x = 2;
            for (int i = 1; i < 100000000; i++)
            {
                x += Math.Sqrt(x)/i;
            }
            return (int) x;
        }
        Task<int> ComplexCalculationAsync()
        {
            return Task.Run(() => ComplexCalculation());
        }
        public AsyncExamples()
        {
            Task<int> task = ComplexCalculationAsync();
            var awaiter = task.GetAwaiter();

            awaiter.OnCompleted(() =>
                {
                    int result = awaiter.GetResult();
                    Console.WriteLine(result);
                }
                );

             Action action = async () =>
             {
                 int result2 = await ComplexCalculationAsync();
                 Console.WriteLine(result2);
             };
            action();

            string strTemp = "12345";
            IEnumerable<char> strEnumerable = strTemp.Reverse();
            foreach (var character in strEnumerable)
            {
                Console.Write(character);
            }
            //strTemp.Reverse();

            Console.WriteLine();
            Console.WriteLine(strTemp.Reverse());

            string words = "raz dwa trzy cztery piec";
            Console.WriteLine(String.Join(" ",words.Reverse().Split(' ').Select(x => new string(x.Reverse().ToArray()))));
        }
    }

    public static class StringHelper
    {
        public static string Reverse(this string strValue)
        {
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < strValue.Length; i++)
            {
                temp.Append(strValue[strValue.Length - i - 1]);
            }
            return temp.ToString();
        }
    }
}
