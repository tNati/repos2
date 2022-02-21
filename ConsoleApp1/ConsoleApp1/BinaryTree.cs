using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class BinaryTree<KeyType, PayloadType>
           where KeyType : IComparable<KeyType>
    {
        Node<KeyType, PayloadType> Root = null;

        public string printConnections()
        {
            StringBuilder builder = new StringBuilder();
            if (Root != null)
            {
                //Root.printConnections(builder);
            }
            return builder.ToString();
        }

        public int Height()
        {
            if (Root != null) return -1;
            else return Node<KeyType, PayloadType>.Height(Root);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            Node<KeyType, PayloadType> node = Root;
            Node<KeyType, PayloadType>.ToString(builder, node);

            return builder.ToString();
        }

        public void Insert(KeyType key,
        PayloadType payload)
        {
            if (Root != null)
                Node<KeyType, PayloadType>.Insert(Root, key, payload);
            else
                Root = new Node<KeyType, PayloadType>(key, payload);
        }

        public IEnumerable<Tuple<KeyType, PayloadType>> InOrderTraversal()
        {
            foreach (Tuple<KeyType, PayloadType> tuple in Node<KeyType, PayloadType>.InOrderTraversal(Root))
            {
                yield return tuple;
            }
        }

        public void InsertAtRoot(KeyType key, PayloadType payload)
        {
            if (Root != null)
            {
                Node<KeyType, PayloadType>.InsertAtRoot(ref Root, key, payload);
            }
            else 
                Insert(key, payload);
        }

        // Lab2 Functions

        public int ComputeNDescendants()
        {
            if (Root != null)
            {
                return Node<KeyType, PayloadType>.ComputeNDescendantsHelper(Root);
            }
            else
                return 0;

        }

        public KeyType Select(int targetRank)
        {
            if (Root != null)
            {
                return Node<KeyType, PayloadType>.Select(Root, targetRank);
            }
            else return Root.Key; 
        }

        public int Rank(KeyType targetKey)
        {
            if (Root != null)
            {
                return Node<KeyType, PayloadType>.Rank(Root, targetKey);
            }
            else throw new InvalidOperationException();
        }

        public IEnumerable<Tuple<KeyType, PayloadType>> Range(KeyType min, KeyType max)
        {
            throw new NotImplementedException();
        }
    }
}
