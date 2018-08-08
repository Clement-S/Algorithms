using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class TreeNode
    {
        public int Data;

        public TreeNode LeftNode;

        public TreeNode RightNode;
    
        public TreeNode(int data)
        {
            Data = data;
            LeftNode = null;
            RightNode = null;
        }
    }
}
