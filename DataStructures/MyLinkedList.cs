namespace DataStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MyLinkedList<T> : IEnumerable<T>
    {
        Node<T> Head;

        Node<T> CurrentNode;

        // set arbitary 
        Node<T>[] LinkedList;

        public MyLinkedList()
        {
            LinkedList = new Node<T>[20];
        }

        bool IsFirstAdd = true;

        public void Add(T data)
        {
            if (IsFirstAdd)
            {
                Head = new Node<T>(data);
                // return;

                // set current node to the head
                CurrentNode = Head;
            }

            IsFirstAdd = false;

            // move through the nodes to find last node
            while (CurrentNode.Next != null)
            {
                // if next node is not null, move current to the next node and recheck
                CurrentNode = CurrentNode.Next;
            }

            CurrentNode.Next = new Node<T>(data);
            CurrentNode = CurrentNode.Next;
        }

        public void Remove(T data)
        {

        }

        public void Get(T data)
        {

        }

        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < LinkedList.Length; i++)
            {
                yield return LinkedList[i].Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

    }
}
