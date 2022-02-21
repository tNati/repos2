using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void T1_HashTableTest()
        {
            Hashtable example = new Hashtable();
            example.Add("numero: uno", 1);
            example.Add(4, "add");
            example.Add(5, true);
            int i = 0;
            ArrayList arrayList = new ArrayList() { "numero: uno", 1, 4, "add", 5, true };
            foreach (DictionaryEntry tester in example)
            {
                Assert.AreEqual(tester.Key, arrayList[i]);
                i++;
                Assert.AreEqual(tester.Value, arrayList[i]);
                i++;
            }
            arrayList.Add("4");
            arrayList.Add(4);
            example.Add("4", 4);
            Assert.AreEqual(arrayList.Count, example.Count * 2);
            Assert.AreEqual(example["numero: uno"], 1);
            Assert.IsTrue(example.ContainsKey(4));

        }
        [TestMethod]
        public void T2_stringbuilder()
        {
            StringBuilder stringB = new StringBuilder();
            stringB.Append("1g");
            stringB.Append("g");
            Assert.AreEqual(stringB.ToString(), "1gg");
            stringB.Replace("g", "k");
            Assert.AreEqual(stringB.ToString(), "1kk");
            stringB.Clear();
            //does not work for some reason
            stringB.AppendLine("She don't wanna be saved.");

            stringB.Clear();
            stringB.Append("She don't wanna be saved.");
            Assert.AreEqual(stringB.ToString(), "She don't wanna be saved.");


        }
        [TestMethod]
        public void ex1()
        {
            //find unique character :
            //  //= using bool array with 256 size.(starts with 256 false)
            //  store string[n] in an int variable to get the digit
            //  set it true if it paseed it once, and if its already true, return false
            bool isUniqueChars2(String str)
            {
                bool[] char_set = new bool[256];
                //StringBuilder g = new StringBuilder(str);
                for (int i = 0; i < str.Length; i++)
                {
                    int val = str[i];
                    if (char_set[val] && val!=32) return false;
                    char_set[val] = true;
                }
                return true;
            }
            bool unique(string sentence)
            {
                for (int i = 0; i < sentence.Length; i++)
                {
                    for (int z = i+1; z < sentence.Length; z++)
                    {
                        if (sentence[z] == i) return false;
                    }
                }
                return true;
            }

            string checker = "jame n s";
           // bool isUnique20 = isUniqueChars2(checker);
            bool isUnique = unique(checker);
            Assert.IsTrue(isUnique);
            //Assert.IsTrue(isUnique20);

        }
        [TestMethod]
        public void ex2()
        {
            string reverseCString( string cstring)
            {
                //abcd = (a b c d null)
                Stack stack = new Stack();
                int i = 0;
                while (i < cstring.Length)
                {
                    stack.Push(cstring[i]);
                    i++;
                }
                string g = "";
                while (stack.Count!=0)
                {
                    g+=stack.Pop().ToString();
                }
                return g;
           
                
            }

            string tester_string = "abcd";
            string check = reverseCString(tester_string);
            Assert.AreEqual(check, "dcba");

        }

        [TestMethod]
        public void ex3()
        {
            string duplicateEliminator(string sentence)
            {
                char searching, searcher;
                StringBuilder sentenceEditor = new StringBuilder();
                sentenceEditor.Append(sentence);
                for (int i = 0; i < sentenceEditor.Length; i++)
                {
                    searching = sentence[i];
                    for (int z = i+1; z < sentenceEditor.Length; z++)
                    {
                        searcher = sentence[z];
                        if (searcher == searching)
                        {
                            sentenceEditor.Remove(z, 1);
                            i--;
                        }
                        
                    }
                }
                sentence = sentenceEditor.ToString();

                return sentence;
            }


            string sentence1 = "abcbc";
            string sentence2 = duplicateEliminator(sentence1);
            string sentence3 = "abc";
            Assert.AreEqual(sentence2, sentence3);
        }

        [TestMethod]
        public void ex4()
        {
            bool anagram(string word1,string word2)
            {
                int counter;
                if (word1.Length!=word2.Length) return false;

                for (int i=0; i < word1.Length;i++)
                {
                    counter = 0;
                    for (int z=0; z<word1.Length;z++)
                    {
                        if (word1[i] == word2[z])
                            counter++;
                        if (counter>1)
                            return false;
                    }
                    if (counter == 0) return false;
                }
                return true;
            }
            bool f = anagram("string", "rinstg");
            Assert.IsTrue(f);
        }

        [TestMethod]
        public void T_linkedListAndex()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            LinkedListNode<int> newlist = new LinkedListNode<int>(1);
            LinkedListNode<int> h = newlist.Next;
            Assert.AreEqual(h, null);
            int g = newlist.Value;
            Assert.AreEqual(g, 1);
            linkedList.AddFirst(4);
            List<int> list = new List<int>();
            list.Add(6);
            list.Add(4);
            Assert.AreEqual(4,list[1]);
            foreach (int linkedint in linkedList)
                Assert.AreEqual(4, linkedint);
            //void removeDuplicate(LinkedList<int> linkedlist) { }
            list.Sort();
            Assert.AreEqual(4, list[0]);
        }
    }
}
