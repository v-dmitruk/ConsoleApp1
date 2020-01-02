using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BinaryTree<T, U> where U : IComparable
    {
        public Node<T, U> rootNode { get; set; }

        public delegate void BinaryTreeHandler(string message);
        public event BinaryTreeHandler Notify;


        public event EventHandler<BinaryTreeEventArgs<T, U>> DeletingNode;
        protected virtual void OnDeletingNode(BinaryTreeEventArgs<T, U> e)
        {
            _ = e ?? throw new ArgumentNullException(nameof(e));
            //уязвимо при многопоточности
            DeletingNode?.Invoke(this, e);

            //var2
            //var temp = deleted;
            //temp?.Invoke(this, e);

            //var3
            //Volatile.Read(ref deleted)?.Invoke(this, e);
        }
        public void SimulatingDeletingNode(Node<T, U> node, string mes)
        {
            var e = new BinaryTreeEventArgs<T, U>(node, mes);
            OnDeletingNode(e);
        }

        private int LeftElementCount = 0;
        private int NodeCount = 0;

        //event-обработчики
        private void LeftElementCounter(string message)
        {
            LeftElementCount++;
            Console.WriteLine("There are " + LeftElementCount + " left elements now");
        }
        private void ElementAdder(string message)
        {
            NodeCount++;
            Console.WriteLine("There are " + NodeCount + " elements now");
        }
        private void ElementDeleter(string message)
        {
            NodeCount--;
            Console.WriteLine("There are " + NodeCount + " elements now");
        }
        private void MessageRun(string message)
        {
            Console.WriteLine(message);
        }

        //AddNode
        public void AddNode(T obj, U key, Node<T, U> current, Node<T, U> parent)
        {
            if (current == null && parent != null)
            {
                current = new Node<T, U>(key, obj);
                current.ParentNode = parent;
                if (key.CompareTo(parent.key) > 0)
                {
                    parent.RightNode = current;
                    Notify += ElementAdder;
                    Notify?.Invoke("Element added to the right");
                    Notify -= ElementAdder;
                }
                else
                {
                    parent.LeftNode = current;
                    //Notify += LeftElementCounter;
                    Notify += ElementAdder;
                    Notify?.Invoke("Element added to the left");
                    //Notify -= LeftElementCounter;
                    Notify -= ElementAdder;
                }
                return;
            }

            if (current == null && parent == null)
            {
                if (rootNode == null)
                {
                    rootNode = new Node<T, U>(key, obj);
                    rootNode.ParentNode = null;
                    //Notify += MessageRun;         
                    Notify += ElementAdder;
                    Notify?.Invoke("Element added to the root");
                    Notify -= ElementAdder;
                    return;
                }
                else
                {
                    AddNode(obj, key, rootNode, null);
                    return;
                }
            }          

            if (key.CompareTo(current.key) == 0)
            {
                if (current.data.Contains(obj))
                {
                    throw new ArgumentException("You already have such element in this collection");
                }
                else
                {
                    current.data.Add(obj);
                    Notify?.Invoke("Element added to the existing node");
                    return;
                }
            }
            else
            {
                if (key.CompareTo(current.key) > 0)
                {
                    AddNode(obj, key, current.RightNode, current);
                }
                else
                {
                    AddNode(obj, key, current.LeftNode, current);
                }
            }
        }
        //DeleteNode (consist of 2 methods. 1st takes Key and returns the Node with this Key. 2nd takes node and remove it)
        public void DeleteNode(Node<T,U> node)
        {
            if (node == null)
            {
                return;
            }
            bool NodeSide;
            if (node.ParentNode.LeftNode == node)
            {
                NodeSide = true;
            }
            else
            {
                NodeSide = false;
            }

            if (node.LeftNode == null && node.RightNode == null)
            {
                if (NodeSide)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
                Notify += ElementDeleter;
                Notify?.Invoke("Element deleted");
                Notify -= ElementDeleter;
                OnDeletingNode(new BinaryTreeEventArgs<T, U>(node, "was deleted"));
            }

            else if (node.LeftNode == null)
            {
                if (NodeSide)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }
                node.RightNode.ParentNode = node.ParentNode;
                Notify += ElementDeleter;
                Notify?.Invoke("Element deleted");
                Notify -= ElementDeleter;
                OnDeletingNode(new BinaryTreeEventArgs<T, U>(node, "was deleted"));
            }

            else if (node.RightNode == null)
            {
                if (NodeSide)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
                Notify += ElementDeleter;
                Notify?.Invoke("Element deleted");
                Notify -= ElementDeleter;
                OnDeletingNode(new BinaryTreeEventArgs<T, U>(node, "was deleted"));
            }
            //если оба дочерних присутствуют, 
            //то правый становится на место удаляемого,
            //а левый вставляется в правый
            else
            {
                switch (NodeSide)
                {
                    case true:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        node.LeftNode.ParentNode = FindMin(node.RightNode);
                        FindMin(node.RightNode).LeftNode = node.LeftNode;
                        break;
                    case false:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        node.LeftNode.ParentNode = FindMin(node.RightNode);
                        FindMin(node.RightNode).LeftNode = node.LeftNode;
                        break;
                    //default:
                    //    var bufLeft = node.LeftNode;
                    //    var bufRightLeft = node.RightNode.LeftNode;
                    //    var bufRightRight = node.RightNode.RightNode;
                    //    node.data = node.RightNode.data;
                    //    node.key = node.RightNode.key;
                    //    node.RightNode = bufRightRight;
                    //    node.LeftNode = bufRightLeft;
                    //    foreach (T el in bufLeft.data)
                    //        AddNode(el, bufLeft.key, rootNode, null);
                    //    node.FixHeight(rootNode);
                    //    break;
                }
                Notify += ElementDeleter;
                Notify?.Invoke("Element deleted");
                Notify -= ElementDeleter;
                OnDeletingNode(new BinaryTreeEventArgs<T, U>(node, "was deleted"));
            }
            node.FixHeight(rootNode);
        }
        //FindByKey (Have to return not only the first one element, but ALL the elements with the same key)
        public Node<T, U> FindByKey(U key, Node<T, U> current, Node<T, U> parrent)
        {
            if (key != null)
            {
                if (current == null && parrent == null)
                { current = rootNode; }
                else
                {
                    if (current == null && parrent != null)
                        throw new ArgumentException("There is no such object in this tree");
                }
                if (key.CompareTo(current.key) == 0)
                {
                    return current;
                }
                else
                {
                    if (key.CompareTo(current.key) > 0)
                    {
                        return FindByKey(key, current.RightNode, current);
                    }
                    else
                    {
                        return FindByKey(key, current.LeftNode, current);
                    }
                }
            }
            else
            {
                throw new ArgumentException("You can't search the NULL object");
            }

        }
        //FindMin
        public Node<T, U> FindMin(Node<T, U> current)
        {
            if (current != null)
            {
                if (current.LeftNode == null)
                { return current; }
                else
                {
                    return FindMin(current.LeftNode);
                }
            }
            else
            {
                throw new ArgumentException("You can't search the NULL object");
            }
        }

        //findMax
        public Node<T, U> FindMax(Node<T, U> current)
        {
            if (current != null)
            {
                if (current.RightNode == null)
                { return current; }
                else
                {
                    return FindMax(current.RightNode);
                }
            }
            else
            {
                throw new ArgumentException("You can't search the NULL object");
            }
        }

        //ViewTree
        public void ViewTree(Node<T, U> node)
        {
            if (node != null)
            {
                node.FixHeight(node);
                if (node.height == 1)
                {
                    Console.Write(node.height + " - " + node.key + "\n");
                    return;
                }
                else
                {
                    Console.Write(node.height + " - " + node.key + "\n");
                    ViewTree(node.LeftNode);
                    ViewTree(node.RightNode);
                }
            }
            else
            {
                return;
            }
        }
        public void TreelikePrint(U key)
        {

            Node<T, U> root = FindByKey(key, rootNode, null);
            PrintTree(root, 0);
        }
        private void PrintTree(Node<T, U> startNode, byte side, string separator = "")
        {
            if (startNode != null)
            {
                string nodeSide;
                if (side == 0)
                {
                    nodeSide = "+";
                }
                else
                {
                    if (side == 1)
                        nodeSide = "L";
                    else
                        nodeSide = "R";
                }
                Console.WriteLine($"{separator} [{nodeSide}]- {startNode.key} - {startNode.ToString()}");
                separator += new string(' ', 3);
                PrintTree(startNode.LeftNode, 1, separator);
                PrintTree(startNode.RightNode, 2, separator);
            }
            else
            {
                return;
            }
        }

        //TurnRigh
        public void TurnRight(Node<T, U> node)
        {
            if (node == rootNode)
            {
                rootNode = node.LeftNode;
                node.LeftNode.ParentNode = null;
                node.ParentNode = node.LeftNode;
                Node<T, U> buf2 = node.LeftNode;
                if (buf2.RightNode != null)
                {
                    buf2.RightNode.ParentNode = node;
                    node.LeftNode = buf2.RightNode;
                }
                else
                {
                    node.LeftNode = null;
                }
                buf2.RightNode = node;
                node.FixHeight(rootNode);
                Notify += MessageRun;
 //               Notify?.Invoke("Turned Right " + node.key);
                Notify -= MessageRun;
                return;
            }
            if (node == null)
            {
                return;
            }
            bool NodeSide;
            if (node.ParentNode.LeftNode == node)
            {
                NodeSide = true;
            }
            else
            {
                NodeSide = false;
            }

            if (node.LeftNode == null && node.RightNode == null)
            {
                return;
            }

            
            if (NodeSide)
            {
                node.ParentNode.LeftNode = node.LeftNode;
            }
            else
            {
                node.ParentNode.RightNode = node.LeftNode;
            }
            node.LeftNode.ParentNode = node.ParentNode;
            node.ParentNode = node.LeftNode;
            Node<T, U> buf = node.LeftNode;
            if (buf.RightNode != null)
            {
                buf.RightNode.ParentNode = node;
                node.LeftNode = buf.RightNode;
            }
            else
            {
                node.LeftNode = null;
            }
            buf.RightNode = node;
            node.FixHeight(rootNode);
            Notify += MessageRun;
  //          Notify?.Invoke("Turned Right " + node.key);
            Notify -= MessageRun;
            return;
        }
        //TurnLeft
        public void TurnLeft(Node<T, U> node)
        {
            if (node == rootNode)
            {
                rootNode = node.RightNode;
                node.RightNode.ParentNode = null;
                node.ParentNode = node.RightNode;
                Node<T, U> buf2 = node.RightNode;
                if (buf2.LeftNode != null)
                {
                    buf2.LeftNode.ParentNode = node;
                    node.RightNode = buf2.LeftNode;
                }
                else
                {
                    node.RightNode = null;
                }
                buf2.LeftNode = node;
                node.FixHeight(rootNode);
                Notify += MessageRun;
//                Notify?.Invoke("Turned Left " + node.key);
                Notify -= MessageRun;
                return;
            }
            if (node == null)
            {
                return;
            }
            bool NodeSide;
            if (node.ParentNode.LeftNode == node)
            {
                NodeSide = true;
            }
            else
            {
                NodeSide = false;
            }

            if (node.LeftNode == null && node.RightNode == null)
            {
                return;
            }


            if (NodeSide)
            {
                node.ParentNode.LeftNode = node.RightNode;
            }
            else
            {
                node.ParentNode.RightNode = node.RightNode;
            }
            node.RightNode.ParentNode = node.ParentNode;
            node.ParentNode = node.RightNode;
            Node<T, U> buf = node.RightNode;
            if (buf.LeftNode != null)
            {
                buf.LeftNode.ParentNode = node;
                node.RightNode = buf.LeftNode;
            }
            else
            {
                node.RightNode = null;
            }
            buf.LeftNode = node;
            node.FixHeight(rootNode);
            Notify += MessageRun;
//            Notify?.Invoke("Turned Left " + node.key);
            Notify -= MessageRun;
            return;
        }
        
        //Indexer Order
        //forw
        public void ForwardOrder(Node<T, U> root, List<Node<T, U>> nodes)
        {
            if (nodes == null)
                throw new ArgumentException("Bad container link");
            if (root == null)
            {
                return;
            }
            nodes.Add(root);
            ForwardOrder(root.LeftNode, nodes);
            ForwardOrder(root.RightNode, nodes);
        }
        //reverse
        public void ReverseOrder(Node<T, U> root, List<Node<T, U>> nodes)
        {
            if (nodes == null)
                throw new ArgumentException("Bad container link");
            if (root == null)
            {
                return;
            }
            ReverseOrder(root.LeftNode, nodes);
            nodes.Add(root);
            ReverseOrder(root.RightNode, nodes);
        }
        //forwreverse
        public void ForwardReverseOrder(Node<T, U> root, List<Node<T, U>> nodes)
        {
            if (nodes == null)
                throw new ArgumentException("Bad container link");
            if (root == null)
            {
                return;
            }
            ForwardReverseOrder(root.LeftNode, nodes);
            ForwardReverseOrder(root.RightNode, nodes);
            nodes.Add(root);
        }
        public void PreReverseOrder(Node<T, U> root, List<Node<T, U>> nodes)
        {
            if (nodes == null)
                throw new ArgumentException("Bad container link");
            if (root == null)
            {
                return;
            }
            PreReverseOrder(root.RightNode, nodes);
            nodes.Add(root);
            PreReverseOrder(root.LeftNode, nodes);
        }
        public void PreForwardOrder(Node<T, U> root, List<Node<T, U>> nodes)
        {
            if (nodes == null)
                throw new ArgumentException("Bad container link");
            if (root == null)
            {
                return;
            }
            nodes.Add(root);
            PreForwardOrder(root.RightNode, nodes);
            PreForwardOrder(root.LeftNode, nodes);
        }
        public void PreForwardReverseOrder(Node<T, U> root, List<Node<T, U>> nodes)
        {
            if (nodes == null)
                throw new ArgumentException("Bad container link");
            if (root == null)
            {
                return;
            }
            PreForwardReverseOrder(root.RightNode, nodes);
            PreForwardReverseOrder(root.LeftNode, nodes);
            nodes.Add(root);
        }

        public void BalanceTree(Node<T, U> node)
        {
            while (node.balanceFactor() >= 2 || node.balanceFactor() <= -2)
                BalanceNode(node);
            return;
        }

        private void BalanceNode(Node<T, U> node)
        {

            if (node.balanceFactor() >= 2)
            {
                if (node.LeftNode.balanceFactor() <= -2)
                    TurnLeft(node.LeftNode);
                TurnRight(node);
                return;
            }
            if (node.balanceFactor() <= -2)
            {
                if (node.RightNode.balanceFactor() >= 2)
                    TurnRight(node.RightNode);
                TurnLeft(node);
                return;
            }            
            return;
        }
    }
}
