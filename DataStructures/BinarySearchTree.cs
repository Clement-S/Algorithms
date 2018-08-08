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

        }

        /// <summary>
        /// Finds the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Find(int data)
        {

        }

        /// <summary>
        /// Traverses the Tree.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Traverse(int data)
        {

        }
    }
}
