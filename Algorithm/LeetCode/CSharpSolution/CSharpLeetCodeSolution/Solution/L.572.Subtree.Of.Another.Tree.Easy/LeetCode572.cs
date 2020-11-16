using System;
using System.Collections.Generic;
using System.Text;

namespace Solution
{

    public class TreeNodeLc572
    {
        public int Value;

        public TreeNodeLc572 Left;

        public TreeNodeLc572 Right;

        public TreeNodeLc572(int val, TreeNodeLc572 left = null, TreeNodeLc572 right = null)
        {
            Value = val;
            Left = left;
            Right = right;
        }
    }
    public class LeetCode572
    {
        //Given two non-empty binary trees s and t, check whether tree t has exactly the same structure and node values with a subtree of s.A subtree of s is a tree consists of a node in s and all of this node's descendants. The tree s could also be considered as a subtree of itself.

        //    Example 1:
        //Given tree s:

        //3
        /// \
        //4   5
        /// \
        //1   2

        //Given tree t:

        //4 
        /// \
        //1   2

        //Return true, because t has the same structure and node values with a subtree of s.




        //    Example 2:
        //Given tree s:

        //3
        /// \
        //4   5
        /// \
        //1   2
        ///
        //0

        //Given tree t:

        //4
        /// \
        //1   2

        //Return false. 

        public static bool IsSubTree(TreeNodeLc572 s, TreeNodeLc572 t)
        {
            return Traverse(s, t); 
        }

        private static bool Equals(TreeNodeLc572 x, TreeNodeLc572 y)
        {
            if (x == null && y == null) return true;

            if (x == null || y == null) return false;


            return x.Value == y.Value && Equals(x.Left, y.Left) && Equals(x.Right, y.Right);
        }


        private static bool Traverse(TreeNodeLc572 s, TreeNodeLc572 t)
        {
            return s != null && (Equals(s, t) || Equals(s.Left, t) || Equals(s.Right, t));
        }
    }
}
