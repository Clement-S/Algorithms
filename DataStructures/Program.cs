﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataStructures
{
    class Program
    {
        static int value { get; set; } = 0;

        static void Main(string[] args)
        {
#if RELEASE
            #region MyMap

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


            TestObject moro = new TestObject()
            {
                age = 23,
                Data = "23 moro"
            };
            TestObject anotherMoro = new TestObject()
            {
                age = 24,
                Data = "24 moro"
            };
            TestObject yetAnotherMoro = new TestObject()
            {
                age = 25,
                Data = "25 moro"
            };
            var NewMap = new MyMap<double, TestObject>();
            NewMap.Put(2.0, moro);
            NewMap.Put(3.5, anotherMoro);
            NewMap.Put(6.34, yetAnotherMoro);

            #endregion

            #region MyLinkedList            

            MyLinkedList<string> myLinkedList = new MyLinkedList<string>();
            myLinkedList.Add("and");
            myLinkedList.Add("what");
            myLinkedList.Add("else");

            foreach (var i in myLinkedList)
            {
                Console.WriteLine(i);
            }

            myLinkedList.Remove("what");

            Console.WriteLine("List after removing values");

            foreach (var i in myLinkedList)
            {
                Console.WriteLine(i);
            }

            myLinkedList.AddFirst("new head");

            Console.WriteLine("List after addding new head value");

            foreach (var i in myLinkedList)
            {
                Console.WriteLine(i);
            }

            var node = myLinkedList.Find("else");
            Console.WriteLine("Value of node is");
            Console.WriteLine(node.Data);

            MyLinkedList<TestObject> myLinkedList2 = new MyLinkedList<TestObject>();
            myLinkedList2.Add(moro);
            myLinkedList2.Add(anotherMoro);
            myLinkedList2.Add(yetAnotherMoro);

            foreach (var i in myLinkedList2)
            {
                Console.WriteLine($"{i.age} , {i.Data}");
            }

            myLinkedList2.Remove(anotherMoro);

            Console.WriteLine("List after removing values");

            foreach (var i in myLinkedList2)
            {
                Console.WriteLine($"{i.age} , {i.Data}");
            }

            myLinkedList2.AddFirst(anotherMoro);

            Console.WriteLine("List after addding new head value");

            foreach (var i in myLinkedList2)
            {
                Console.WriteLine($"{i.age} , {i.Data}");
            }

            var node2 = myLinkedList2.Find(yetAnotherMoro);
            Console.WriteLine("Value of node is");
            Console.WriteLine($"{node2.Data.age} , {node2.Data.Data}");

            #endregion


            #region MyStack
            MyStack<int> myStack = new MyStack<int>();
            myStack.Push(60);
            myStack.Push(750);
            myStack.Push(43);
            myStack.Push(34);

            Console.WriteLine("Stack after pushing values on it");

            foreach (var value in myStack)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
            var firstPopValue = myStack.Pop();
            var secondPopValue = myStack.Pop();

            Console.WriteLine("Stack after popping values");

            foreach (var value in myStack)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine($"first pop value  {firstPopValue}");
            Console.WriteLine();
            Console.WriteLine($"second pop value  {secondPopValue}");

            var peekValue = myStack.Peek();
            Console.WriteLine($"PeekValue  {peekValue}");
            Console.WriteLine();

            Console.WriteLine("Stack after peeking values - should be same as nothing popped");

            foreach (var value in myStack)
            {
                Console.WriteLine(value);
            }

            #endregion

#endif
            #region MyQueue

            //MyQueue<int> myQueue = new MyQueue<int>();
            //myQueue.Enqueue(30);
            //myQueue.Enqueue(74);
            //myQueue.Enqueue(12);
            //myQueue.Enqueue(342);

            var name = "Seyi";
            //name.OutputMe("adedeji", 75);



            //foreach(var value in myQueue)
            //    Console.WriteLine(value);

            // value = 78;
            // Console.WriteLine(value);

            //Console.WriteLine("After Dequeue");

            //myQueue.Dequeue();
            //myQueue.Dequeue();

            //foreach (var value in myQueue)
            //    Console.WriteLine(value);

            //Console.WriteLine();

            //Console.WriteLine($"Peek value is {myQueue.Peek()}");

            //Console.WriteLine("Queue status after peeking");

            //foreach (var value in myQueue)
            //    Console.WriteLine(value);

            #endregion

            #region BinarySearchTree

            var bst = new BinarySearchTree();
            bst.Insert(5);
            bst.Insert(8);
            bst.Insert(2);
            bst.Insert(7);
            bst.Insert(16);

            bst.InOrderTreeTraversal(bst.Root);
            Console.WriteLine($" The root of this tree is {bst.Root.Data}");

            var foundNode = bst.Find(7);

            if (foundNode != null)
                Console.WriteLine("Found node");
            else
            {
                Console.WriteLine("Node doesnt exist");
            }

            bst.Delete(7);
            bst.InOrderTreeTraversal(bst.Root);
            #endregion

            Console.ReadLine();
        }
    }
}
