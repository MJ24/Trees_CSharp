using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadedTree
{
    public enum OrderType
    {
        Pre,
        In,
        Post
    }

    public class ThreadedTree<T>
    {
        private Node<T> head;
        private static Node<T> preNode = null;

        public Node<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public ThreadedTree()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        private void PrintOrderByFirst(Node<T> first, OrderType orderType)
        {
            if (IsEmpty())
            {
                Console.WriteLine("线索二叉树为空！");
            }
            else
            {
                while (first != null)
                {
                    Console.Write(first.Data);
                    first = GetNextNode(first, orderType);
                }
                Console.WriteLine();
            }
        }

        //线索化后根据当前节点获取下一个节点的方法，根据线性化时排序的类型不同而不同
        private Node<T> GetNextNode(Node<T> currentNode, OrderType orderType)
        {
            //如果currentNode的右儿子存的就是下一个，那么直接返回右儿子
            //如果是最后一个节点了(右儿子为空)，那next就返回null
            if (currentNode.RTag == 1 || currentNode.RChild == null)
            {
                currentNode = currentNode.RChild;
            }
            else
            {
                //否则的话根据OrderType求下一个
                switch (orderType)
                {
                    //先序遍历中当前节点的下一个节点不是左儿子就是右儿子
                    //左儿子存在则是左儿子，否则右
                    case OrderType.Pre:
                        if (currentNode.LTag == 0)
                        {
                            currentNode = currentNode.LChild;
                        }
                        else
                        {
                            currentNode = currentNode.RChild;
                        }
                        break;
                    //中序遍历中当前节点的下一个节点是其右子树的最左节点
                    case OrderType.In:
                        currentNode = currentNode.RChild;
                        while (currentNode.LTag == 0)
                        {
                            currentNode = currentNode.LChild;
                        }
                        break;
                    case OrderType.Post:
                        //按前驱找？
                        break;
                }
            }
            return currentNode;
        }

        public void PreOrder()
        {
            preNode = new Node<T>(default(T));
            preNode.LTag = 1;
            preNode.RTag = 1;
            PreThreading(head);
            PrintOrderByFirst(head, OrderType.Pre);
        }
        //前序遍历并线索化
        private void PreThreading(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                //当前节点和pre节点的线索化
                if (currentNode.LChild == null)
                {
                    currentNode.LTag = 1;
                    currentNode.LChild = preNode;
                }
                else
                {
                    currentNode.LTag = 0;
                }
                if (preNode.RChild == null)
                {
                    preNode.RTag = 1;
                    preNode.RChild = currentNode;
                }
                else
                {
                    preNode.RTag = 0;
                }
                preNode = currentNode;

                //递归遍历并线索化左子树
                if (currentNode.LTag == 0)
                {
                    PreThreading(currentNode.LChild);
                }
                //递归遍历并线索化右子树
                if (currentNode.RTag == 0)
                {
                    PreThreading(currentNode.RChild);
                }
            }
        }

        public void InOrder()
        {
            preNode = new Node<T>(default(T));
            preNode.LTag = 1;
            preNode.RTag = 1;
            InThreading(head);
            Node<T> first = head;
            while (first.LTag == 0)
            {
                first = first.LChild;
            }
            PrintOrderByFirst(first, OrderType.In);
        }
        //中序遍历并线索化
        private void InThreading(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                //递归遍历并线索化左子树
                if (currentNode.LTag == 0)
                {
                    InThreading(currentNode.LChild);
                }

                //当前节点和pre节点的线索化
                if (currentNode.LChild == null)
                {
                    currentNode.LTag = 1;
                    currentNode.LChild = preNode;
                }
                else
                {
                    currentNode.LTag = 0;
                }
                if (preNode.RChild == null)
                {
                    preNode.RTag = 1;
                    preNode.RChild = currentNode;
                }
                else
                {
                    preNode.RTag = 0;
                }
                preNode = currentNode;

                //递归遍历并线索化右子树
                if (currentNode.RTag == 0)
                {
                    InThreading(currentNode.RChild);
                }
            }
        }

        public void PostOrder()
        {
            preNode = new Node<T>(default(T));
            preNode.LTag = 1;
            preNode.RTag = 1;
            PostThreading(head);
            Node<T> first = head;
            while (first.LTag == 0)
            {
                first = first.LChild;
            }
            PrintOrderByFirst(first, OrderType.Post);
        }
        //后序遍历并线索化
        private void PostThreading(Node<T> currentNode)
        {
            if (currentNode != null)
            {
                //递归遍历并线索化左子树
                if (currentNode.LTag == 0)
                {
                    PostThreading(currentNode.LChild);
                }
                //递归遍历并线索化右子树
                if (currentNode.RTag == 0)
                {
                    PostThreading(currentNode.RChild);
                }

                //当前节点和pre节点的线索化
                if (currentNode.LChild == null)
                {
                    currentNode.LTag = 1;
                    currentNode.LChild = preNode;
                }
                else
                {
                    currentNode.LTag = 0;
                }
                if (preNode.RChild == null)
                {
                    preNode.RTag = 1;
                    preNode.RChild = currentNode;
                }
                else
                {
                    preNode.RTag = 0;
                }
                preNode = currentNode;
            }
        }
    }
}
