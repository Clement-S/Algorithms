using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class BinarySearchTree
    {
        public TreeNode Root;

        /// <summary>
        /// Inserts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Insert(int data)
        {
            Root = InsertNode(Root, data);

            // Iterative implementation
            // var Current = Root;
            // var newNode = new TreeNode(data);

            //while (true)
            //{
            //    if (data < Current.Data)
            //    {
            //        if (Current.LeftNode == null)
            //        {
            //            Current.LeftNode = newNode;
            //            return;
            //        }

            //        Current = Current.LeftNode;
            //    }
            //    else
            //    {
            //        if (Current.RightNode == null)
            //        {
            //            Current.RightNode = newNode;
            //            return;
            //        }

            //        Current = Current.RightNode;
            //    }
            //}

        }

        /// <summary>
        /// Inserts the node.
        /// </summary>
        /// <param name="newNode">The new node.</param>
        /// <param name="data">The data.</param>
        public TreeNode InsertNode(TreeNode node, int data)
        {
            if (node == null)
            {
                return new TreeNode(data);
            }

            if (data < node.Data)
            {
                node.LeftNode = InsertNode(node.LeftNode, data);
            }
            else
            {
                node.RightNode = InsertNode(node.RightNode, data);
            }

            return node;
        }

        /// <summary>
        /// Deletes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Delete(int data)
        {
            Root = DeleteNode(Root, data);
        }

        /// <summary>
        /// Deletes the node.
        /// </summary>
        /// <param name="current">The root.</param>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        private TreeNode DeleteNode(TreeNode current, int data)
        {
            if (current == null) return current;

            // if this node holds contains the data, then it should be deleted
            if (current.Data == data)
            {
                // If the node has no children then delete and return null to the tree
                if (current.LeftNode == null && current.RightNode == null)
                {
                    return null;
                }

                // If the node has one child
                if (current.LeftNode == null)
                    return current.RightNode;
                if (current.RightNode == null)
                    return current.LeftNode;

                // node with two children, find the smallest value on the right subtree and use to replace the node
                int smallestValue = findSmallestValue(current);
                current.Data = smallestValue;
                current.RightNode = DeleteNode(current.RightNode, smallestValue);
                return current;                
            }

            if (data < current.Data)
            {
                current.LeftNode =  DeleteNode(current.LeftNode, data);
            }
            else
            {
                current.RightNode = DeleteNode(current.RightNode, data);
            }

            return current;
        }

        /// <summary>
        /// Finds the smallest value.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <returns></returns>
        public int findSmallestValue(TreeNode current)
        {
            return current.LeftNode == null ? current.Data : findSmallestValue(current.LeftNode);
        }

        /// <summary>
        /// Finds the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public TreeNode Find(int data)
        {
            if (Root == null)
                throw new ArgumentNullException("Empty Tree!! Can't be traversed");

            var foundNode = FindNode(Root, data);

            return foundNode;
        }


        /// <summary>
        /// Traverses the tree from the given node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="data">The data.</param>
        private TreeNode FindNode(TreeNode node, int data)
        {
            if (data == node.Data)
            {
                return node;
            }

            if (data < node.Data)
            {
                return FindNode(node.LeftNode, data);
            }
            else
            {
                return FindNode(node.RightNode, data);
            }
        }

        /// <summary>
        /// Displays the contents of the tree.
        /// </summary>
        /// <param name="root">The root.</param>
        public void InOrderTreeTraversal(TreeNode root)
        {
            if (root != null)
            {
                InOrderTreeTraversal(root.LeftNode);
                Console.WriteLine(" " + root.Data);
                InOrderTreeTraversal(root.RightNode);
            }
        }
    }
}
