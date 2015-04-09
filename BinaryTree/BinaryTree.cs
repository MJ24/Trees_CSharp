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

        //递归按值查找对应节点
        public Node<T> GetNodeByValue(Node<T> root, T value)
        {
            Node<T> node = root;
            if (node == null)
            {
                return null;
            }
            if (node.Data.Equals(value))
            {
                return node;
            }
            Node<T> result = null;
            if (node.LChild != null)
            {
                result = GetNodeByValue(node.LChild, value);
            }
            if (result == null && node.RChild != null)
            {
                result = GetNodeByValue(node.RChild, value);
            }
            return result;
        }

        //递归求树或子树的叶子节点总数
        public int GetLeafsNum(Node<T> root)
        {
            int num = 0;
            if (root == null)
            {
                num = 0;
            }
            else if (root.LChild == null && root.RChild == null)
            {
                num = 1;
            }
            else//否则递归求左右子树叶节点树之和
            {
                num = GetLeafsNum(root.LChild) + GetLeafsNum(root.RChild);
            }
            return num;
        }

        //递归求树或子树的高度
        public int GetHeight(Node<T> root)
        {
            int height = 0;
            if (root == null)
            {
                height = 0;
            }
            else if (root.LChild == null && root.RChild == null)
            {
                height = 1;
            }
            else//否则递归求左右子树中较高的height，+1即为本树高
            {
                int lHeight = 0;
                int rHeight = 0;
                if (root.LChild != null)
                {
                    lHeight = GetHeight(root.LChild);
                }
                if (root.RChild != null)
                {
                    rHeight = GetHeight(root.RChild);
                }
                height = (lHeight > rHeight ? lHeight : rHeight) + 1;
            }
            return height;
        }
    }
}
