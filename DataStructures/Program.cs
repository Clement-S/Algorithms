using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyMapTesting

            var myMap = new MyMap<string, int>();

            myMap.Put("Seyi", 1);
            myMap.Put("Clement", 2);
            myMap.Put("Adedeji", 3);

            TraceSource traceSource = new TraceSource("myTraceSource", SourceLevels.All);
            traceSource.TraceInformation("Tracing application..");
            traceSource.TraceEvent(TraceEventType.Critical, 0, "Critical trace");
            traceSource.TraceData(TraceEventType.Information, 1, new object[] { "a", "b", "c" });
            traceSource.Flush();
            traceSource.Close();


            Console.WriteLine();
            Console.WriteLine("test");


            Console.WriteLine("All keys without removing");
            var allKeys = myMap.GetKeys();

            foreach (var key in allKeys)
                Console.WriteLine(key);

            Console.WriteLine("Keys and Values");
            Console.WriteLine($"Seyis no: {myMap.Get("Seyi")}");
            Console.WriteLine($"CLements no: {myMap.Get("Clement")}");
            Console.WriteLine($"Adedeji no: {myMap.Get("Adedeji")}");

            Console.WriteLine();
            Console.WriteLine("All keys after removing \n");
            myMap.Remove("Adedeji");

            var keys = myMap.GetKeys();

            foreach (var key in keys)
                Console.WriteLine(key);

            Console.WriteLine($"Adedeji no: {myMap.Get("Adedeji")}");


            Moro moro = new Moro()
            {
                age = 23,
                Data = "23 moro"
            };
            Moro anotherMoro = new Moro()
            {
                age = 24,
                Data = "24 moro"
            };
            Moro yetAnotherMoro = new Moro()
            {
                age = 25,
                Data = "25 moro"
            };
            var NewMap = new MyMap<double, Moro>();
            NewMap.Put(2.0, moro);
            NewMap.Put(3.5, anotherMoro);
            NewMap.Put(6.34, yetAnotherMoro);

            #endregion

            #region MyLinkedList            

            MyLinkedList<int> linkedList = new MyLinkedList<int>();
            linkedList.Add(4);
            linkedList.Add(6);

            #endregion
            Console.ReadLine();
        }
    }

    class Moro
    {
        public int age;
        public string Data;
    }


}
