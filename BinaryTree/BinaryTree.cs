using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        private Node<T> head;

        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public BinaryTree()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void PreOrder()
        {
            if (IsEmpty())
            {
                Console.WriteLine("二叉树为空！");
            }
            else
            {
                PreOrderThis(head);
                Console.WriteLine();
            }
        }
        private void PreOrderThis(Node<T> head)
        {
            if (head != null)
            {
                Console.Write(head.Data);
                PreOrderThis(head.LChild);
                PreOrderThis(head.RChild);
            }
        }

        public void InOrder()
        {
            if (IsEmpty())
            {
                Console.WriteLine("二叉树为空！");
            }
            else
            {
                InOrderThis(head);
                Console.WriteLine();
            }
        }
        private void InOrderThis(Node<T> head)
        {
            if (head != null)
            {
                InOrderThis(head.LChild);
                Console.Write(head.Data);
                InOrderThis(head.RChild);
            }
        }

        public void PostOrder()
        {
            if (IsEmpty())
            {
                Console.WriteLine("二叉树为空！");
            }
            else
            {
                PostOrderThis(head);
                Console.WriteLine();
            }
        }
        private void PostOrderThis(Node<T> head)
        {
            if (head != null)
            {
                PostOrderThis(head.LChild);
                PostOrderThis(head.RChild);
                Console.Write(head.Data);
            }
        }
    }
}
