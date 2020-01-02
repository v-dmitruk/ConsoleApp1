using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BinaryTreeEventArgs<T, U> : EventArgs where U : IComparable
    {
        public Node<T, U> CurrentNode { get; }

        public string message { get; }

        public BinaryTreeEventArgs (Node<T, U> node, string mes)
            {
            CurrentNode = node;
            message = mes;
            }

        public override string ToString()
        {
            return CurrentNode.ToString() + " " + message;
        }
    }
}
