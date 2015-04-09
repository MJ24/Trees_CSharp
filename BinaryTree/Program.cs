using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<string> tree = GetStrTree();
            tree.PreOrder();
            tree.InOrder();
            tree.PostOrder();

            Console.WriteLine("树的高度为：{0}", tree.GetHeight(tree.Head));
            Console.WriteLine("树的叶节点数为：{0}", tree.GetLeafsNum(tree.Head));
            Node<string> c = tree.GetNodeByValue(tree.Head, "C");
            Console.WriteLine("节点'C'的左右子节点分别为：'{0}' , '{1}'", c.LChild.Data, c.RChild.Data);
            Console.ReadLine();
        }

        private static BinaryTree<string> GetStrTree()
        {
            BinaryTree<string> tree = new BinaryTree<string>();
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
