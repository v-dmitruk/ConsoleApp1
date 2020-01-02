using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Node<T, U> : ICloneable where U : IComparable
    {
        public List<T> data = new List<T>();
        public U key;
        public short height { get; private set; }
        //public short balance { get; private set; }
            
        public Node()
        {

        }
        public Node(U key, T obj)
        {
            if (obj != null && key != null)
            {                
                this.data.Add(obj);
                this.key = key;
                this.LeftNode = null;
                this.RightNode = null;
                height = 1;
            }
            else
            {
                throw new ArgumentException("You are trying to create empty node");
            }
        }

        public Node<T, U> LeftNode;
        public Node<T, U> RightNode;
        public Node<T, U> ParentNode;

        public override string ToString()
        {
            if (this.data.Count == 0)
                return null;
            string result = "";
            foreach (T el in data)
            {
                result += el.ToString() + " ";
            }
            //result += this.height;
            return result;
        }
        public short Height(Node<T, U> node)
        {
            if (node == null)
                return 0;
            else
            {
                return node.height;
            }
        }
        public void FixHeight(Node<T, U> node)
        {
            if (node != null)
            {
                if (node.LeftNode != null || node.RightNode != null)
                {
                    FixHeight(node.LeftNode);
                    short leftHeight = Height(node.LeftNode);
                    FixHeight(node.RightNode);
                    short rightHeight = Height(node.RightNode);

                    if (leftHeight >= rightHeight)
                    {
                        node.height = (short)(leftHeight + 1);
                    }
                    else
                    {
                        node.height = (short)(rightHeight + 1);
                    }
                }
                else
                {
                    node.height = 1;
                }
            }
            else
            {
                return;
            }
        }

        public int balanceFactor()
        {
            if (LeftNode == null && RightNode == null)
            {
                return 0;
            }
            this.FixHeight(this);
            if (LeftNode == null)
            {
                return (-RightNode.Height(RightNode));
            }
                if (RightNode == null)
                { return LeftNode.Height(LeftNode); }

            return LeftNode.Height(LeftNode) - RightNode.Height(RightNode);
        }
        public object Clone()
        {
            Node<T, U> clone = new Node<T, U>();
            clone.data = this.data;
            clone.key = this.key;
            clone.height = this.height;
            clone.LeftNode = this.LeftNode;
            clone.RightNode = this.RightNode;
            clone.ParentNode = this.ParentNode;
            return clone;
        }

        
    }
}
