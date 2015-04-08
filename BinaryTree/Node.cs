using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class Node<T>
    {
        private T data;
        private Node<T> lChild;
        private Node<T> rChild;

        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node<T> LChild
        {
            get { return lChild; }
            set { lChild = value; }
        }
        public Node<T> RChild
        {
            get { return rChild; }
            set { rChild = value; }
        }

        public Node(T value)
        {
            data = value;
            lChild = null;
            rChild = null;
        }
        public Node(T value, Node<T> l, Node<T> r)
        {
            data = value;
            lChild = l;
            rChild = r;
        }
    }
}
