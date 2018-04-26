using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class MyStack<T>:IEnumerable<T>
    {        
        private List<T> Stack;
        private int StackCount = -1;

        public MyStack()
        {
            Stack = new List<T>();
        }

        public void Push(T value)
        {
            if (value == null)
                throw new ArgumentNullException();

            Stack.Add(value);

            StackCount++;
        }

        public T Pop()
        {
            var lastAdded = Stack[StackCount];

            Stack[StackCount] = default(T);

            StackCount--;

            return lastAdded;
        }

        public T Peek()
        {
            return Stack[StackCount];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = (StackCount); i >= 0; i--)
            {
                yield return Stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
