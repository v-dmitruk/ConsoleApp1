using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ConsolePrint <T, U> where U : IComparable
    {
        public ConsolePrint ()
        {

        }

        public ConsolePrint(BinaryTree<T, U> binaryTree)
        {
            binaryTree.DeletingNode += bTDeletingNode;
        }

        public void bTDeletingNode(object sender, BinaryTreeEventArgs<T, U> e)
        {
            Print(e.ToString());
        }

        public void Print (string st)
        {
            Console.WriteLine(st);
        }
    }
}
