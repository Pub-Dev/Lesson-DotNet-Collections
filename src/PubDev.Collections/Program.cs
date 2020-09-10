using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PubDev.Collections
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.Title = "Pub Dev - Entedendo Coleções";

            Enumerable_WithoutForeach();
            Enumerable_WithForeach();

            Collection_Count();
            Collection_Add();
            Collection_Contains();
            Collection_CopyTo();
            Collection_Remove();
            Collection_Clear();

            List_Index();
            List_IndexOf();
            List_Insert();
            List_RemoveAt();

            Enumerable_vs_Collection_Count();
            Enumerable_vs_List();

            Console.ReadKey();
        }

        #region .: Enumerable :.

        private static void Enumerable_WithoutForeach()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var enumerableItems = items.Where(x => x > 0);

            using var item = enumerableItems.GetEnumerator();

            while (item.MoveNext())
            {
                Console.WriteLine(item.Current);
            }
        }

        private static void Enumerable_WithForeach()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var enumerableItems = items.Where(x => x > 0);

            foreach (var item in enumerableItems)
            {
                Console.WriteLine(item);
            }
        }

        #endregion .: Enumerable :.

        #region .: Collection :.

        private static void Collection_Count()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ICollection<int> collectionItems = items;

            Console.WriteLine($"Total de Items {collectionItems.Count}");
        }

        private static void Collection_Add()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ICollection<int> collectionItems = items.ToList();

            Console.WriteLine($"Total de Items {collectionItems.Count}");

            collectionItems.Add(11);

            Console.WriteLine($"Total de Items {collectionItems.Count}");
        }

        private static void Collection_Contains()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ICollection<int> collectionItems = items;

            Console.WriteLine($"Contem 12 = {collectionItems.Contains(12)}");
        }

        private static void Collection_CopyTo()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ICollection<int> collectionItems = items;

            var collectionItemsCopy = new int[collectionItems.Count + 10];

            collectionItems.CopyTo(collectionItemsCopy, 8);
        }

        private static void Collection_Remove()
        {
            var items = new List<int>() { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ICollection<int> collectionItems = items;

            collectionItems.Remove(1);

            Console.WriteLine($"Total de Items {collectionItems.Count}");
        }

        private static void Collection_Clear()
        {
            var items = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            ICollection<int> collectionItems = items;

            Console.WriteLine($"Total de Items {collectionItems.Count}");

            collectionItems.Clear();

            Console.WriteLine($"Total de Items {collectionItems.Count}");
        }

        #endregion .: Collection :.

        #region .: List :.

        private static void List_Index()
        {
            IList<int> items = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine($"items indice de 2 = {items[2]}");
        }

        private static void List_IndexOf()
        {
            IList<int> items = new List<int>() { 1, 2, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine($"items indice de 2 = {items.IndexOf(2)}");
        }

        private static void List_Insert()
        {
            IList<int> items = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            items.Insert(0, 10);

            Console.WriteLine(string.Join('-', items));
        }

        private static void List_RemoveAt()
        {
            IList<int> items = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            items.RemoveAt(8);

            Console.WriteLine(string.Join('-', items));
        }

        #endregion .: List :.

        #region .: Comparacoes :.

        private static void Enumerable_vs_Collection_Count()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IEnumerable<int> enumerable = items.Select(x => x);
            ICollection<int> collection = items;

            var stopWatch = new Stopwatch();

            stopWatch.Start();

            for (long i = 0; i < 10_000_000; i++)
            {
                var count = enumerable.Count();
            }

            Console.WriteLine($"enumerable - total = {stopWatch.ElapsedMilliseconds}");

            stopWatch.Restart();

            for (long i = 0; i < 10_000_000; i++)
            {
                var count = collection.Count;
            }

            Console.WriteLine($"collection - total = {stopWatch.ElapsedMilliseconds}");

            stopWatch.Stop();
        }

        private static void Enumerable_vs_List()
        {
            var items = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            IList<int> numerosParesLista = items.Where(NumeroPar).ToList();

            if (numerosParesLista.Count > 5)
            {
                Console.WriteLine("List - Existem mais de 5 numeros pares");
            }

            if (numerosParesLista.Count > 10)
            {
                Console.WriteLine("List - Existem mais de 10 numeros pares");
            }

            var numerosPares = items.Where(NumeroPar);

            if (numerosPares.Count() > 5)
            {
                Console.WriteLine("List - Existem mais de 5 numeros pares");
            }

            if (numerosPares.Count() > 10)
            {
                Console.WriteLine("List - Existem mais de 10 numeros pares");
            }
        }

        private static bool NumeroPar(int numero)
        {
            Console.WriteLine($"Verificando se o numero - {numero} é par");

            return numero % 2 == 0;
        }

        #endregion .: Comparacoes :.
    }
}