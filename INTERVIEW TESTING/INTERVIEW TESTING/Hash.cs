using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTERVIEW_TESTING
{
    public class Linkedlist<KeyType> where KeyType: IComparable<KeyType>
    {
        public Linkedlist(KeyType key, Linkedlist<KeyType> nextL =null )
        {
            _key = key;
            if (nextL != null) _next = nextL;
        }
        Linkedlist<KeyType> _root;
        Linkedlist<KeyType> _next;
        KeyType _key;

        void Next (KeyType node)
        {

        }

    }
}
