using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Node<KeyType, PayloadType> where
        KeyType : IComparable<KeyType>
    {
        public Node<KeyType, PayloadType> LeftChild = null;
        public Node<KeyType, PayloadType> RightChild = null;
        public int NDescendants = 0;
        public KeyType Key { get; set; }
        public PayloadType Payload { get; set; }

        public Node(KeyType key, PayloadType payload)
        {
            Key = key;
            Payload = payload;
        }

        public static IEnumerable<Tuple<KeyType, PayloadType>> InOrderTraversal(
            Node<KeyType, PayloadType> root)//, List<Tuple<KeyType, PayloadType>> inOrderList)
        {
            if (root != null)
            {
                //yield return left, then root, then right recursively if its not null
                if (root.LeftChild != null)
                {

                    foreach (Tuple<KeyType, PayloadType> tuple in InOrderTraversal(root.LeftChild))
                    {
                        yield return tuple;
                    }
                }
                yield return new Tuple<KeyType, PayloadType>(root.Key, root.Payload);
                if (root.RightChild != null)
                {
                    foreach (Tuple<KeyType, PayloadType> tuple in InOrderTraversal(root.RightChild))
                    {
                        yield return tuple;
                    }
                }

            }
        }

        public void ToString(StringBuilder builder)
        {
            ToString(builder, this);
        }
        public static void ToString(StringBuilder builder, Node<KeyType, PayloadType> node)
        {

            builder.Append('(');
            if (node != null)
            {
                builder.Append(node.Key);
                if (node.LeftChild == null && node.RightChild == null)
                {
                }
                else
                {
                    builder.Append(' ');
                    ToString(builder, node.LeftChild);
                    builder.Append(' ');
                    ToString(builder, node.RightChild);
                }

            }
            builder.Append(')');
        }
        public static void RotateRight(ref Node<KeyType,
            PayloadType> root)
        {
            if (root.LeftChild != null)
            {
                Node<KeyType, PayloadType> oldRoot = root;
                Node<KeyType, PayloadType> newRoot = root.LeftChild;
                oldRoot.LeftChild = null;

                if (newRoot.RightChild != null)
                {
                    Node<KeyType, PayloadType> oldChild = newRoot.RightChild;
                    oldRoot.LeftChild = oldChild;
                }
                if (oldRoot.Key.CompareTo(newRoot.Key) > 0)
                    newRoot.RightChild = oldRoot;
                else
                    newRoot.LeftChild = oldRoot;
                root = newRoot;
            }
        }

        public static void RotateLeft(ref Node<KeyType,
    PayloadType> root)
        {
            if (root.RightChild != null)
            {
                Node<KeyType, PayloadType> oldRoot = root;
                Node<KeyType, PayloadType> newRoot = root.RightChild;
                oldRoot.RightChild = null;

                if (newRoot.LeftChild != null)
                {
                    Node<KeyType, PayloadType> oldChild = newRoot.LeftChild;
                    oldRoot.RightChild = oldChild;
                }
                if (oldRoot.Key.CompareTo(newRoot.Key) < 0)
                    newRoot.LeftChild = oldRoot;
                else
                    newRoot.RightChild = oldRoot;
                root = newRoot;
            }
        }

        public static void Insert(Node<KeyType, PayloadType> root,
            KeyType key, PayloadType payload)
        {
            if (root.Key.CompareTo(key) < 0)
            {
                if (root.RightChild != null)
                    Insert(root.RightChild, key, payload);
                else
                    root.RightChild = new Node<KeyType, PayloadType>(key, payload);
            }
            else if (root.Key.CompareTo(key) > 0)
            {
                if (root.LeftChild != null)
                    Insert(root.LeftChild, key, payload);
                else
                    root.LeftChild = new Node<KeyType, PayloadType>(key, payload);
            }
            else if (root.Key.CompareTo(key) == 0)
            {
                root.Key = key;
                root.Payload = payload;
            }
        }

        public static void InsertAtRoot(ref Node<KeyType, PayloadType> root,
        KeyType key, PayloadType payload)
        {
            if (root != null)
            {
                if (root.Key.CompareTo(key) > 0 && root.LeftChild != null)
                {

                    InsertAtRoot(ref root.LeftChild, key, payload);
                    RotateRight(ref root);
                }
                else if (root.Key.CompareTo(key) < 0 && root.RightChild != null)
                {
                    InsertAtRoot(ref root.RightChild, key, payload);
                    RotateLeft(ref root);
                }
               
                else
                {
                    if (root.Key.CompareTo(key) > 0)
                    {
                        root.LeftChild = new Node<KeyType, PayloadType>(key, payload);
                        RotateRight(ref root);
                    }
                    else
                    {
                        root.RightChild = new Node<KeyType, PayloadType>(key, payload);
                        RotateLeft(ref root);
                    }

                }
            }
        }

        public static int Height(Node<KeyType, PayloadType> node)
        {
            int returnValue = -1;
            int LeftSide = 0;
            int RightSide = 0;
            if (node != null)
            {
                LeftSide = Height(node.LeftChild);
                RightSide = Height(node.RightChild);

                if (LeftSide > RightSide) returnValue = LeftSide + 1;
                else returnValue = RightSide + 1;

            }
            return returnValue;
        }


        // Lab2 Functions


        public static KeyType MinKey(Node<KeyType, PayloadType> root)
        {
            while (root.LeftChild != null)
            {
                root = root.LeftChild;
            }
            return root.Key;
        }

        public static KeyType MaxKey(Node<KeyType, PayloadType> root)
        {
            while (root.RightChild != null)
            {
                root = root.RightChild;
            }
            return root.Key;
        }
        
        public static void ComputeNDescendants(Node<KeyType, PayloadType> myNode)
        {
            int zero = ComputeNDescendantsHelper(myNode);
        }
        public static int ComputeNDescendantsHelper(Node<KeyType, PayloadType> mynode)
        {
            clearNDesendants(mynode);
            if (mynode.LeftChild != null)
            {
                mynode.NDescendants += 1 + ComputeNDescendantsHelper(mynode.LeftChild);
            }
            if (mynode.RightChild != null)
            {
                mynode.NDescendants += 1 + ComputeNDescendantsHelper(mynode.RightChild);
            }
            return mynode.NDescendants;
        }

        public static void clearNDesendants(Node<KeyType, PayloadType> mynode)
        {
            if (mynode !=null && mynode.NDescendants != 0)
            {
                mynode.NDescendants = 0;
                if (mynode.LeftChild != null && mynode.LeftChild.NDescendants != 0)
                    clearNDesendants(mynode.LeftChild);
                if (mynode.RightChild != null && mynode.RightChild.NDescendants != 0)
                    clearNDesendants(mynode.RightChild);
            }
        }




        public static KeyType Select(Node<KeyType, PayloadType> root, int targetRank)
        {
            int descendants = 0;
            int LeftChildD = 0;
            if (root.LeftChild != null) LeftChildD = root.LeftChild.NDescendants + 1;

            while (root!=null && descendants + LeftChildD == targetRank)
            {
                if (root.LeftChild == null) LeftChildD = 0;
                else LeftChildD = root.LeftChild.NDescendants+1;

                if (root.LeftChild != null && LeftChildD + descendants > targetRank)
                {
                    root = root.LeftChild;
                }
                else if (root.RightChild != null &&
                    descendants + LeftChildD < targetRank)
                {
                    descendants++;
                    if (LeftChildD!=0)  
                        descendants = root.LeftChild.NDescendants + 1 +descendants;
                    root = root.RightChild;
                }
            }
            return root.Key;

        }




        public static int Rank(Node<KeyType, PayloadType> root, KeyType targetKey)
        {
            int descendants = 0;
            int LeftChildD = 0;
            if (root.LeftChild != null) LeftChildD = root.LeftChild.NDescendants + 1;

            while (root!=null && (root.Key).CompareTo(targetKey) != 0)
            {
                if (root.LeftChild == null) LeftChildD = 0;
                else LeftChildD = root.LeftChild.NDescendants + 1;

                if (root.LeftChild != null && (root.Key).CompareTo(targetKey) > 0)
                {
                    root = root.LeftChild;
                }
                else if (root.RightChild != null && root.Key.CompareTo(targetKey) < 0)
                {                                    
                    descendants++;
                    if (LeftChildD != 0)
                        descendants = root.LeftChild.NDescendants + 1 + descendants;
                    root = root.RightChild;
                }

            }

            if (root.LeftChild == null) LeftChildD = 0;
            else LeftChildD = root.LeftChild.NDescendants + 1;

            return descendants+LeftChildD;
            

        }

        public static IEnumerable<Tuple<KeyType, PayloadType>> Range(
            Node<KeyType, PayloadType> root, KeyType min, KeyType max)
        {
            //find min, find max
            // recursively call root from min to max

            //1
            while (root.Key.CompareTo(min)!=0)
            {
                if (root.Key.CompareTo(min) > 0) root = root.LeftChild;
                if (root.Key.CompareTo(max) < 0) root = root.RightChild;
            }

            //2 
            if (root.RightChild != null && root.Key.CompareTo(max)!=0)
            {
                foreach (Tuple<KeyType, PayloadType> tuple in Range(root.RightChild,root.RightChild.Key, max))
                {
                    yield return tuple;
                }
            }

            //
            /*
             * 1
             * while root.key != min
             *      if root.key is bigger than min, go left
             *      if root.key is smaller than min, go right
             * 
             * 2
             * if root.min and root.max are not equal
             *      yield return  root.Key
             *      
             * 3
             * check if if root.right isnt null
             *      Range(root.right, root.key, max)
             * if root.right is null and root.left isnt 
             *      Range(root.Left,root.key,max)
             * dont call function fi both children are null
             * 
             * 4
             * if root.min and root.max are equal
             *      yield return root.key
             */



        }
    }
}
