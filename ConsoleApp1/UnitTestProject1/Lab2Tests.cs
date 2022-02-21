using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class Lab2Tests
    {
        private const int lab2_millisecondTimeout = 2000;

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        // Find the largest key in the tree.
        public void U00_findMax()
        {
            Node<string, int> root = new Node<string, int>("N", 0);
            Assert.AreEqual("N", Node<string, int>.MaxKey(root));

            Node<string, int>.Insert(root, "I", 2);
            Assert.AreEqual("N", Node<string, int>.MaxKey(root));

            Node<string, int>.Insert(root, "R", 5);
            Assert.AreEqual("R", Node<string, int>.MaxKey(root));

            Node<string, int>.Insert(root, "U", 3);
            Node<string, int>.MaxKey(root);
            Assert.AreEqual("U", Node<string, int>.MaxKey(root));

            Node<string, int>.Insert(root, "E", 4);
            Assert.AreEqual("U", Node<string, int>.MaxKey(root));

            Node<string, int>.Insert(root, "S", 6);
            Assert.AreEqual("U", Node<string, int>.MaxKey(root));

            Node<string, int>.Insert(root, "T", 7);
            Assert.AreEqual("U", Node<string, int>.MaxKey(root));

            Node<string, int>.Insert(root, "O", 9);
            Assert.AreEqual("U", Node<string, int>.MaxKey(root));

            Node<string, int>.Insert(root, "V", 8);
            Assert.AreEqual("V", Node<string, int>.MaxKey(root));

            Node<string, int>.Insert(root, "Y", 8);
            Assert.AreEqual("Y", Node<string, int>.MaxKey(root));
        }

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        // Find the smallest key in the tree.
        public void U01_findMin()
        {
            Node<string, int> root = new Node<string, int>("U", 0);
            Assert.AreEqual("U", Node<string, int>.MinKey(root));
            Node<string, int>.Insert(root, "N", 1);
            Assert.AreEqual("N", Node<string, int>.MinKey(root));
            Node<string, int>.Insert(root, "I", 2);
            Assert.AreEqual("I", Node<string, int>.MinKey(root));
            Node<string, int>.Insert(root, "V", 3);
            Assert.AreEqual("I", Node<string, int>.MinKey(root));
            Node<string, int>.Insert(root, "E", 4);
            Assert.AreEqual("E", Node<string, int>.MinKey(root));
            Node<string, int>.Insert(root, "R", 5);
            Assert.AreEqual("E", Node<string, int>.MinKey(root));
            Node<string, int>.Insert(root, "S", 6);
            Assert.AreEqual("E", Node<string, int>.MinKey(root));
            Node<string, int>.Insert(root, "T", 7);
            Assert.AreEqual("E", Node<string, int>.MinKey(root));
            Node<string, int>.Insert(root, "Y", 8);
            Assert.AreEqual("E", Node<string, int>.MinKey(root));
            Node<string, int>.Insert(root, "O", 9);
            Assert.AreEqual("E", Node<string, int>.MinKey(root));
        }

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        // Create a new Node property called NDescendants
        // Set the NDescendants property for every node in the tree
        // where NDescendants is the number of nodes below the node in the tree.
        public void U02_computeNDescendantsJustRoot()
        {
            // Set the NDescendants property of every node in a tree.
            Node<string, int> node = new Node<string, int>("U", 10);
            Node<string, int>.ComputeNDescendants(node);
            Assert.AreEqual(0, node.NDescendants);
        }

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        public void U03_computeNDescendantsTwoChildNodes()
        {
            Node<string, int> node = new Node<string, int>("U", 10);
            Node<string, int>.Insert(node, "N", 10);
            Node<string, int>.Insert(node, "V", 10);
            Node<string, int>.Insert(node, "A", 10);
            Node<string, int>.ComputeNDescendants(node);
            Assert.AreEqual(3, node.NDescendants);
            Assert.AreEqual(1, node.LeftChild.NDescendants);
        }

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        public void U04_computeNDescendantsLargerTree()
        {
            Node<string, int> root = new Node<string, int>("U", 0);
            Node<string, int>.InsertAtRoot(ref root, "N", 1);
            Node<string, int>.InsertAtRoot(ref root, "I", 2);
            Node<string, int>.InsertAtRoot(ref root, "V", 3);
            Node<string, int>.InsertAtRoot(ref root, "E", 4);
            Node<string, int>.InsertAtRoot(ref root, "R", 5);
            Node<string, int>.InsertAtRoot(ref root, "S", 6);
            Node<string, int>.InsertAtRoot(ref root, "T", 7);
            Node<string, int>.InsertAtRoot(ref root, "Y", 8);
            Node<string, int>.InsertAtRoot(ref root, "O", 9);
            Node<string, int>.ComputeNDescendants(root);
            Assert.AreEqual(9, root.NDescendants);
        }

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        public void U05_computerNDescendantsBST()
        {
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            tree.InsertAtRoot("U", 0);
            tree.InsertAtRoot("N", 1);
            tree.InsertAtRoot("I", 2);
            tree.InsertAtRoot("V", 3);
            tree.InsertAtRoot("E", 4);
            tree.InsertAtRoot("R", 5);
            tree.InsertAtRoot("S", 6);
            tree.InsertAtRoot("T", 7);
            tree.InsertAtRoot("Y", 8);
            tree.InsertAtRoot("O", 9);
            tree.ComputeNDescendants();
            Assert.AreEqual(9, tree.ComputeNDescendants());
        }

        
        [TestMethod]//, Timeout(lab2_millisecondTimeout)]
        public void U06_selectTest()
        {
 
            // The "rank" of a key is the number of keys in the collection
            // that are < it.
            // Select(i) finds the node with rank i.
            Node<string, int> root = new Node<string, int>("U", 0);
            Node<string, int>.InsertAtRoot(ref root, "N", 1);
            Node<string, int>.InsertAtRoot(ref root, "I", 2);
            Node<string, int>.InsertAtRoot(ref root, "V", 3);
            Node<string, int>.InsertAtRoot(ref root, "E", 4);
            Node<string, int>.InsertAtRoot(ref root, "R", 5);
            Node<string, int>.InsertAtRoot(ref root, "S", 6);
            Node<string, int>.InsertAtRoot(ref root, "T", 7);
            Node<string, int>.InsertAtRoot(ref root, "Y", 8);
            Node<string, int>.InsertAtRoot(ref root, "O", 9);
            Node<string, int>.ComputeNDescendants(root);
            //Console.WriteLine(root.ToString());
            Assert.AreEqual("O", Node<string, int>.Select(root, 3));
            Assert.AreEqual("E", Node<string, int>.Select(root, 0));
            Assert.AreEqual("I", Node<string, int>.Select(root, 1));
            Assert.AreEqual("N", Node<string, int>.Select(root, 2));
            Assert.AreEqual("R", Node<string, int>.Select(root, 4));
            Assert.AreEqual("S", Node<string, int>.Select(root, 5));
            Assert.AreEqual("T", Node<string, int>.Select(root, 6));
            Assert.AreEqual("U", Node<string, int>.Select(root, 7));
            Assert.AreEqual("V", Node<string, int>.Select(root, 8));
            Assert.AreEqual("Y", Node<string, int>.Select(root, 9));
        }

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        public void U07_selectTestBST()
        {
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            tree.InsertAtRoot("U", 0);
            tree.InsertAtRoot("N", 1);
            tree.InsertAtRoot("I", 2);
            tree.InsertAtRoot("V", 3);
            tree.InsertAtRoot("E", 4);
            tree.InsertAtRoot("R", 5);
            tree.InsertAtRoot("S", 6);
            tree.InsertAtRoot("T", 7);
            tree.InsertAtRoot("Y", 8);
            tree.InsertAtRoot("O", 9);
            tree.ComputeNDescendants();
            Assert.AreEqual("O", tree.Select(3));
            Assert.AreEqual("E", tree.Select(0));
            Assert.AreEqual("I", tree.Select(1));
            Assert.AreEqual("N", tree.Select(2));
            Assert.AreEqual("R", tree.Select(4));
            Assert.AreEqual("S", tree.Select(5));
            Assert.AreEqual("T", tree.Select(6));
            Assert.AreEqual("U", tree.Select(7));
            Assert.AreEqual("V", tree.Select(8));
            Assert.AreEqual("Y", tree.Select(9));
        }

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        public void U08_rankTest()
        {
            // The "rank" of a key is the number of keys in the collection
            // that are < it.
            // Select(i) finds the node with rank i.
            // Rank(key) finds the rank of the node with Key=key
            Node<string, int> root = new Node<string, int>("U", 0);
            Node<string, int>.InsertAtRoot(ref root, "N", 1);
            Node<string, int>.InsertAtRoot(ref root, "I", 2);
            Node<string, int>.InsertAtRoot(ref root, "V", 3);
            Node<string, int>.InsertAtRoot(ref root, "E", 4);
            Node<string, int>.InsertAtRoot(ref root, "R", 5);
            Node<string, int>.InsertAtRoot(ref root, "S", 6);
            Node<string, int>.InsertAtRoot(ref root, "T", 7);
            Node<string, int>.InsertAtRoot(ref root, "Y", 8);
            Node<string, int>.InsertAtRoot(ref root, "O", 9);
            Node<string, int>.ComputeNDescendants(root);
            Assert.AreEqual(3, Node<string, int>.Rank(root, "O"));
            Assert.AreEqual(0, Node<string, int>.Rank(root, "E"));
            Assert.AreEqual(1, Node<string, int>.Rank(root, "I"));
            Assert.AreEqual(2, Node<string, int>.Rank(root, "N"));
            Assert.AreEqual(4, Node<string, int>.Rank(root, "R"));
            Assert.AreEqual(5, Node<string, int>.Rank(root, "S"));
            Assert.AreEqual(6, Node<string, int>.Rank(root, "T"));
            Assert.AreEqual(7, Node<string, int>.Rank(root, "U"));
            Assert.AreEqual(8, Node<string, int>.Rank(root, "V"));
            Assert.AreEqual(9, Node<string, int>.Rank(root, "Y"));
        }

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        public void U09_rankTestBST()
        {
            // The "rank" of a key is the number of keys in the collection
            // that are < it.
            // Select(i) finds the node with rank i.
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            tree.InsertAtRoot("U", 0);
            tree.InsertAtRoot("N", 1);
            tree.InsertAtRoot("I", 2);
            tree.InsertAtRoot("V", 3);
            tree.InsertAtRoot("E", 4);
            tree.InsertAtRoot("R", 5);
            tree.InsertAtRoot("S", 6);
            tree.InsertAtRoot("T", 7);
            tree.InsertAtRoot("Y", 8);
            tree.InsertAtRoot("O", 9);
            tree.ComputeNDescendants();

            Assert.AreEqual(3, tree.Rank("O"));
            Assert.AreEqual(0, tree.Rank("E"));
            Assert.AreEqual(1, tree.Rank("I"));
            Assert.AreEqual(2, tree.Rank("N"));
            Assert.AreEqual(4, tree.Rank("R"));
            Assert.AreEqual(5, tree.Rank("S"));
            Assert.AreEqual(6, tree.Rank("T"));
            Assert.AreEqual(7, tree.Rank("U"));
            Assert.AreEqual(8, tree.Rank("V"));
            Assert.AreEqual(9, tree.Rank("Y"));
        }

        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        public void U10_rangeTest()
        {
            Node<string, int> root = new Node<string, int>("U", 0);
            Node<string, int>.InsertAtRoot(ref root, "N", 1);
            Node<string, int>.InsertAtRoot(ref root, "I", 2);
            Node<string, int>.InsertAtRoot(ref root, "V", 3);
            Node<string, int>.InsertAtRoot(ref root, "E", 4);
            Node<string, int>.InsertAtRoot(ref root, "R", 5);
            Node<string, int>.InsertAtRoot(ref root, "S", 6);
            Node<string, int>.InsertAtRoot(ref root, "T", 7);
            Node<string, int>.InsertAtRoot(ref root, "Y", 8);
            Node<string, int>.InsertAtRoot(ref root, "O", 9);
            string[] firstResults = { "E", "I", "N", "O" };
            int i = 0;
            foreach (Tuple<string, int> inRange in
                Node<string, int>.Range(root, "E", "O"))
            {
                Assert.AreEqual(firstResults[i++], inRange.Item1);
            }

            string[] secondResults = { "T", "U", "V" };
            i = 0;
            foreach (Tuple<string, int> inRange in
                Node<string, int>.Range(root, "T", "V"))
            {
                Assert.AreEqual(secondResults[i++], inRange.Item1);
            }

            string[] thirdResult = { "S" };
            i = 0;
            foreach (Tuple<string, int> inRange in
                Node<string, int>.Range(root, "S", "S"))
            {
                Assert.AreEqual(thirdResult[i++], inRange.Item1);
            }
        }


        
        [TestMethod, Timeout(lab2_millisecondTimeout)]
        public void U11_rangeTestBST()
        {
            BinaryTree<string, int> tree = new BinaryTree<string, int>();
            tree.InsertAtRoot("U", 0);
            tree.InsertAtRoot("N", 1);
            tree.InsertAtRoot("I", 2);
            tree.InsertAtRoot("V", 3);
            tree.InsertAtRoot("E", 4);
            tree.InsertAtRoot("R", 5);
            tree.InsertAtRoot("S", 6);
            tree.InsertAtRoot("T", 7);
            tree.InsertAtRoot("Y", 8);
            tree.InsertAtRoot("O", 9);
            string[] firstResults = { "E", "I", "N", "O" };
            int i = 0;
            foreach (Tuple<string, int> inRange in
                tree.Range("E", "O"))
            {
                Assert.AreEqual(firstResults[i++], inRange);
            }

            string[] secondResults = { "T", "U", "V" };
            i = 0;
            foreach (Tuple<string, int> inRange in
                tree.Range("T", "V"))
            {
                Assert.AreEqual(secondResults[i++], inRange);
            }

            string[] thirdResult = { "S" };
            i = 0;
            foreach (Tuple<string, int> inRange in
                tree.Range("S", "S"))
            {
                Assert.AreEqual(thirdResult[i++], inRange);
            }
        }
    }
}
