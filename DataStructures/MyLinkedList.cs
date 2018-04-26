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
        private Node<T> Head;

        private Node<T> CurrentNode;       

        public void Add(T data)
        {
            // create new node for incoming data
            Node<T> newNode = new Node<T>(data);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            // set current node to the head
            CurrentNode = Head;

            // move through the nodes to find last node
            while (CurrentNode.Next != null)
            {
                // if next node is not null, move current Node to the next Node and recheck
                CurrentNode = CurrentNode.Next;
            }

            CurrentNode.Next = new Node<T>(data);           
        }

        public void AddFirst(T data)
        {
            Node<T> newNode = new Node<T>(data)
            {
                Next = Head
            };
            Head = newNode;
        }

        public void Remove(T data)
        {
            if(Head.Data.Equals(data))
            {
                Head = Head.Next;
                return;
            }

            CurrentNode = Head;

            // move through the nodes 
            while (CurrentNode.Next != null)
            {
                // check the next node if it equals the data
                if(CurrentNode.Next.Data.Equals(data))
                {                    
                    CurrentNode.Next = CurrentNode.Next.Next;
                    return;
                }

                // if next node is not null, move current Node to the next Node and recheck
                CurrentNode = CurrentNode.Next;
            }
        }

        public Node<T> Find(T searchValue)
        {
            // Begin search from the First node
            Node<T> searchNode = Head;

            while(searchNode != null )
            {
                if(searchNode.Data.Equals(searchValue))
                {
                    return searchNode;
                }
                else
                {
                    searchNode = searchNode.Next;
                }                
            }

            return null;
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> searchNode = Head;

            while (searchNode != null)
            {
                yield return searchNode.Data;

                searchNode = searchNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }        
    }
}
