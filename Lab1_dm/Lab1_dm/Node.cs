using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_dm
{
    public class Node<KeyType, PayloadType> where
        KeyType : IComparable<KeyType>
    {
        public Node<KeyType, PayloadType> LeftChild = null;
        public Node<KeyType, PayloadType> RightChild = null;
        public KeyType Key { get; set; }
        public PayloadType Payload { get; set; }

        public Node(KeyType key, PayloadType payload)
        {
            Key = key;
            Payload = payload;
        }

        public static IEnumerable<Tuple<KeyType, PayloadType>> InOrderTraversal(
            Node<KeyType, PayloadType> root)
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
            // Convert a node to a string using the following format
            // (nodekey (leftSubtree) (rightSubtree))
            // use () for null trees, but not when both children are null

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
                    ToString(builder,node.LeftChild);
                    builder.Append(' ');
                    ToString(builder, node.RightChild);
                }
                
            }
            builder.Append(')');
        }

        public static void RotateRight(ref Node<KeyType,PayloadType> root)
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

        public static void RotateLeft(ref Node<KeyType, PayloadType> root)
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
                if (oldRoot.Key.CompareTo(newRoot.Key)<0)
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

        static public int Height(Node<KeyType, PayloadType> node)
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

    }
}
