using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{   
    class MyQueue<T> : IEnumerable<T>
    {        
        private List<T> Queue;
        private int QueueCount = -1;
        private int DequeueIndex = 0;

        public MyQueue()
        {
            Queue = new List<T>();
        }

        public void Enqueue(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            Queue.Add(value);

            QueueCount++;
        }

        public T Dequeue()
        {                   
            var valueAtBeginning = Queue[DequeueIndex];

            // If using an Array, uncomment next two lines, remove 3rd line
            // Queue[DequeueIndex] = default(T);
            // DequeueIndex++;

            Queue.RemoveAt(DequeueIndex);       

            return valueAtBeginning;
        }

        public T Peek()
        {
            return Queue[DequeueIndex];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Queue.Count; i++)
            {               
                yield return Queue[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
