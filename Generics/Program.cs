using System.Linq;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Generics.async;
using Generics.Ado.net;
using Generics.Events;
using Generics.Linq;


namespace Generics
{
    class Program
    {

        #region Generics
        //Generic Type definition
        public class Stack<T>
        {
            int _position;
            private T[] _stackTablbe = new T[100];

            public void Push(T obj)
            {
                _stackTablbe[_position++] = obj;
            }
            public T Pop() { return _stackTablbe[--_position]; }

        }

        class A<T>
        {

        }

        class A<T1, T2>
        {

        }

        class B<T>
        {
            void X()
            {
                Type T = typeof(T);
            }
        }

        /// <summary>
        /// Default typed argumets
        /// </summary>
        public static void Zap<T>(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = default(T);
        }

        /// <summary>
        /// Generic with some restriction
        /// </summary>
        public static void Initialize<T>(T[] array) where T : new()
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = new T();
        }
        #endregion

        #region kowariancja i kontrawariancja
        /// <summary>
        /// Generic whith static value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public class Test<T>
        {
            public static int Count;
        }

        class Animal
        {

        }

        class Beer : Animal
        {

        }

        class Camel : Animal
        {

        }

        public interface IPopable<out T>
        {
            T Pop();
        }

        public interface IPushable<in T>
        {
            void Push(T obj);
        }

        public class Stact2<T> : IPopable<T>, IPushable<T>
        {
            int _position;
            private T[] _stackTablbe = new T[100];

            public void Push(T obj)
            {
                _stackTablbe[_position++] = obj;
            }
            public T Pop() { return _stackTablbe[--_position]; }
        }
        #endregion

        #region Delegates

        delegate int Transformer(int x);

        static int Square(int x)
        {
            return x * x;
        }

        static void Transform(int[] valuesInts, Transformer t)
        {
            for (int i = 0; i < valuesInts.Length; i++)
            {
                valuesInts[i] = t.Invoke(valuesInts[i]);
            }
        }

        ///Generic Delegate
        delegate T Transformer<T>(T x);
        static double Square(double x)
        {
            return x * x;
        }
        static void Transform2<T>(T[] valuesInts, Func<T, T> t)
        {
            for (int i = 0; i < valuesInts.Length; i++)
            {
                valuesInts[i] = t.Invoke(valuesInts[i]);
            }
        }

        static void WriteSmth()
        {
            Console.WriteLine("I am writing function");
        }

        delegate void D1();

        delegate void D2();
        #endregion


        static void Main(string[] args)
        {
            //Generic Type definition
            var nowystos = new Stack<int>();
            nowystos.Push(1);
            nowystos.Push(50);
            Console.WriteLine(nowystos.Pop());

            Type a1 = typeof(A<>);
            Type a2 = typeof(A<,>);
            Type a3 = typeof(A<int, int>);
            Console.WriteLine(a2.GetGenericArguments().Count());

            Console.WriteLine("Generics with static fields");
            Console.WriteLine(++Test<int>.Count);//1
            Console.WriteLine(++Test<int>.Count);//2
            Console.WriteLine(++Test<object>.Count);//1
            Console.WriteLine(++Test<object>.Count);//2

            //Kowariancja z out
            Stact2<Beer> Beeers = new Stact2<Beer>();
            Beeers.Push(new Beer());
            IPopable<Beer> Beers = Beeers;
            IPopable<Animal> Animals = Beers;
            Console.WriteLine(Animals.Pop().GetType().FullName);

            //Kontrawariancja z in
            IPushable<Animal> Animalss = new Stact2<Animal>();
            IPushable<Beer> Beerss = Animalss;
            Beerss.Push(new Beer());
            Console.WriteLine(Beerss.GetType().FullName);

            //Delegates
            int[] valuesInts = { 1, 2, 3 };
            Transform(valuesInts, Square);
            for (int i = 0; i < valuesInts.Length; i++)
            {
                Console.WriteLine(valuesInts[i]);
            }
            Transformer<double> t2 = Square;
            Console.WriteLine(t2.Invoke(3.3));

            int[] valuesInts2 = { 1, 2, 3 };
            Transform2<int>(valuesInts2, Square);
            for (int i = 0; i < valuesInts2.Length; i++)
            {
                Console.WriteLine(valuesInts2[i]);
            }

            Func<double, double> squareFunc = x =>
            {
                return x * x;
            };
            Func<double, double, double> multiplyFunc = (x, y) =>
            {
                return x * y;
            };
            Action<int> actionX = (x) =>
            {
                Console.WriteLine("Acion has fired with value of " + x);
            };

            D1 d1 = WriteSmth;
            D2 d2;
            d2 = new D2(d1);
            d2.Invoke();

            Console.WriteLine(squareFunc(5.5));
            Console.WriteLine(multiplyFunc(5.5, 5.5));

            //Events

            List<Stock> Stocks = new List<Stock>
            {
                new Stock("X1") {Price = 22, },
                new Stock("X2") {Price = 23}
            };
            foreach (var stock in Stocks)
            {
                stock.PriceChanged += StockHasChanged;
            }
            Stocks[0].Price = 2;


            //LING  
            var linqExamples = new LinqExamples();
            var dymicFunctionsExamples = new Generics.dynamic.Dynamic();
            var asyncExamples = new AsyncExamples();
            var adoNetExamples = new AdoNetExample();




            Console.ReadKey();
        }

        static void StockHasChanged(object source,EventArgs e)
        {
            Console.WriteLine("Stock Price has changed");
        }
    }
}
