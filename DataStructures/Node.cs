namespace DataStructures
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Node<T>
    {
        public Node(T data)
        {
            Data = data;
        }

        public T Data;

        public Node<T> Next;



    }
}
