using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class TreeNode<T>
    {
        T Data;

        TreeNode<T> LeftNode;

        TreeNode<T> RightNode;
    
        public TreeNode(T data)
        {
            Data = data;
            LeftNode = null;
            RightNode = null;
        }
    }
}
