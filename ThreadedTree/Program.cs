using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadedTree<string> tree = GetStrTree();
            tree.PreOrder();
            //tree.InOrder();
            Console.ReadLine();
        }

        private static ThreadedTree<string> GetStrTree()
        {
            ThreadedTree<string> tree = new ThreadedTree<string>();
            Node<string> g = new Node<string>("G");
            Node<string> h = new Node<string>("H");
            Node<string> d = new Node<string>("D", g, h);
            Node<string> b = new Node<string>("B", d, null);

            Node<string> i = new Node<string>("I");
            Node<string> e = new Node<string>("E", null, i);
            Node<string> f = new Node<string>("F");
            Node<string> c = new Node<string>("C", e, f);

            tree.Head = new Node<string>("A", b, c);
            return tree;
        }
    }
}
