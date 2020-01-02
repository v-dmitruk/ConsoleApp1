using System;
using System.Collections.Generic;
using System.Text;
using BinaryTreeLibrary;
using Xunit;
using ConsoleApp1;

namespace BinaryTreeLibrary.Tests
{
    public class BinaryTreeTests
    {
        [Fact]
        public void AddNodeToEmptyTreeTestExpectedRoot()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            //Assert
            Assert.Equal("Vasiliy Kekovich", StudentTree.rootNode.data[0]);
        }

        [Fact]
        public void AddNodeToTheRightTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            //Assert
            Assert.Equal("Iggy Pop", StudentTree.rootNode.RightNode.data[0]);
        }

        [Fact]
        public void DeleteNodeFromTheRightTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.DeleteNode(StudentTree.rootNode.RightNode);
            //Assert
            Assert.Null(StudentTree.rootNode.RightNode);
        }

        [Fact]
        public void DeleteSecondNodeFromTheRightTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.DeleteNode(StudentTree.rootNode.RightNode);
            //Assert
            Assert.Equal("Billy Idol", StudentTree.rootNode.RightNode.data[0]);
        }

        [Fact]
        public void DeleteSecondNodeFromTheLeftTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            //Act
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.DeleteNode(StudentTree.rootNode.LeftNode);
            //Assert
            Assert.Equal("Vasiliy Kekovich", StudentTree.rootNode.LeftNode.data[0]);
        }

        [Fact]
        public void FindNodeByIntegerKey()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            //Act
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st1, 1, null, null);
            //Assert
            Assert.Equal("Vasiliy Kekovich", StudentTree.FindByKey(1, null, null).data[0]);
        }

        [Fact]
        public void FindNodeByIntegerKeyNullObjectExpectedException()
        {
            //Arrange
            BinaryTree<object, string> StudentTree = new BinaryTree<object, string>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            //Act
            StudentTree.AddNode(st3, "3", null, null);
            StudentTree.AddNode(st2, "2", null, null);
            StudentTree.AddNode(st1, "1", null, null);
            Action act = () => StudentTree.FindByKey("", null, null);
            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void FindNodeByIntegerKeyNotExsistingObjectExpectedException()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            //Act
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st1, 1, null, null);
            Action act = () => StudentTree.FindByKey(10, null, null);
            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void FindMinNullObjectExpectedException()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            //Act
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st1, 1, null, null);
            Action act = () => StudentTree.FindMin(null);
            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void FindMinObject()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            //Act
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st1, 1, null, null);
            //Assert
            Assert.Equal("Vasiliy Kekovich", StudentTree.FindMin(StudentTree.rootNode).data[0]);
        }

        [Fact]
        public void FindMaxNullObjectExpectedException()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            //Act
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st1, 1, null, null);
            Action act = () => StudentTree.FindMax(null);
            //Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void FindMaxObject()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            //Act
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st1, 1, null, null);
            //Assert
            Assert.Equal("Billy Idol", StudentTree.FindMax(StudentTree.rootNode).data[0]);
        }

        [Fact]
        public void TurnRightTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            string st4 = "Jerry Heil";
            string st5 = "Billie Jean";
            string st6 = "Klaus";
            string st7 = "Britney Spears";
            string st8 = "Kurt Kobein";
            //Act
            StudentTree.AddNode(st3, 1, null, null);
            StudentTree.AddNode(st2, 5, null, null);
            StudentTree.AddNode(st1, 3, null, null);
            StudentTree.AddNode(st4, 7, null, null);
            StudentTree.AddNode(st5, 2, null, null);
            StudentTree.AddNode(st6, 4, null, null);
            StudentTree.AddNode(st7, 6, null, null);
            StudentTree.AddNode(st8, 8, null, null);
            //            1                           1
            //              \                          \
            //               5                          3
            //              /  \           =>          /  \
            //             3    7                     2    5
            //            / \  / \                        / \
            //           2  4  6  8                      4   7
            //                                              / \
            //                                             6   8
            StudentTree.TurnRight(StudentTree.rootNode.RightNode);
            //Assert
            Assert.Equal("Vasiliy Kekovich", StudentTree.rootNode.RightNode.data[0]);
            Assert.Equal("Billie Jean", StudentTree.rootNode.RightNode.LeftNode.data[0]);
            Assert.Equal("Iggy Pop", StudentTree.rootNode.RightNode.RightNode.data[0]);
            Assert.Equal("Klaus", StudentTree.rootNode.RightNode.RightNode.LeftNode.data[0]);
        }

        [Fact]
        public void TurnLeftTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "Vasiliy Kekovich";
            string st2 = "Iggy Pop";
            string st3 = "Billy Idol";
            string st4 = "Jerry Heil";
            string st5 = "Billie Jean";
            string st6 = "Klaus";
            string st7 = "Britney Spears";
            string st8 = "Kurt Kobein";
            //Act
            StudentTree.AddNode(st3, 1, null, null);
            StudentTree.AddNode(st2, 5, null, null);
            StudentTree.AddNode(st1, 3, null, null);
            StudentTree.AddNode(st4, 7, null, null);
            StudentTree.AddNode(st5, 2, null, null);
            StudentTree.AddNode(st6, 4, null, null);
            StudentTree.AddNode(st7, 6, null, null);
            StudentTree.AddNode(st8, 8, null, null);
            //            1                           1
            //              \                          \
            //               5                          7
            //              /  \           =>          /  \
            //             3    7                     5    8
            //            / \  / \                   / \
            //           2  4  6  8                 3   6
            //                                     / \
            //                                    2   4
            StudentTree.TurnLeft(StudentTree.rootNode.RightNode);
            //Assert
            Assert.Equal("Jerry Heil", StudentTree.rootNode.RightNode.data[0]);
            Assert.Equal("Iggy Pop", StudentTree.rootNode.RightNode.LeftNode.data[0]);
            Assert.Equal("Kurt Kobein", StudentTree.rootNode.RightNode.RightNode.data[0]);
            Assert.Equal("Britney Spears", StudentTree.rootNode.RightNode.LeftNode.RightNode.data[0]);
        }
        
        [Fact]
        public void ForwardOrderTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "1";
            string st2 = "2";
            string st3 = "3";
            string st4 = "4";
            string st5 = "5";
            string st6 = "6";
            string st7 = "7";
            string st8 = "8";
            List<Node<object, int>> stlist = new List<Node<object, int>>();
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.AddNode(st5, 5, null, null);
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st7, 7, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st4, 4, null, null);
            StudentTree.AddNode(st6, 6, null, null);
            StudentTree.AddNode(st8, 8, null, null);
            //            1                           
            //              \                          
            //               5                          
            //              /  \                    
            //             3    7            
            //            / \  / \     
            //           2  4  6  8      
            StudentTree.ForwardOrder(StudentTree.rootNode, stlist);
            string result = "";
            foreach (Node<object,int> el in stlist)
            {
                result += el.ToString();
            }
            //Assert
            Assert.Equal("1 5 3 2 4 7 6 8 ", result);
        }

        [Fact]
        public void CenterOrderTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "1";
            string st2 = "2";
            string st3 = "3";
            string st4 = "4";
            string st5 = "5";
            string st6 = "6";
            string st7 = "7";
            string st8 = "8";
            List<Node<object, int>> stlist = new List<Node<object, int>>();
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.AddNode(st5, 5, null, null);
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st7, 7, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st4, 4, null, null);
            StudentTree.AddNode(st6, 6, null, null);
            StudentTree.AddNode(st8, 8, null, null);
            //            1                           
            //              \                          
            //               5                          
            //              /  \                    
            //             3    7            
            //            / \  / \     
            //           2  4  6  8      
            StudentTree.ForwardReverseOrder(StudentTree.rootNode, stlist);
            string result = "";
            foreach (Node<object, int> el in stlist)
            {
                result += el.ToString();
            }
            //Assert
            Assert.Equal("2 4 3 6 8 7 5 1 ", result);
        }

        [Fact]
        public void ReverseOrderTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "1";
            string st2 = "2";
            string st3 = "3";
            string st4 = "4";
            string st5 = "5";
            string st6 = "6";
            string st7 = "7";
            string st8 = "8";
            List<Node<object, int>> stlist = new List<Node<object, int>>();
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.AddNode(st5, 5, null, null);
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st7, 7, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st4, 4, null, null);
            StudentTree.AddNode(st6, 6, null, null);
            StudentTree.AddNode(st8, 8, null, null);
            //            1                           
            //              \                          
            //               5                          
            //              /  \                    
            //             3    7            
            //            / \  / \     
            //           2  4  6  8      
            StudentTree.ReverseOrder(StudentTree.rootNode, stlist);
            string result = "";
            foreach (Node<object, int> el in stlist)
            {
                result += el.ToString();
            }
            //Assert
            Assert.Equal("1 2 3 4 5 6 7 8 ", result);
        }

        [Fact]
        public void PreReverseOrderTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "1";
            string st2 = "2";
            string st3 = "3";
            string st4 = "4";
            string st5 = "5";
            string st6 = "6";
            string st7 = "7";
            string st8 = "8";
            List<Node<object, int>> stlist = new List<Node<object, int>>();
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.AddNode(st5, 5, null, null);
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st7, 7, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st4, 4, null, null);
            StudentTree.AddNode(st6, 6, null, null);
            StudentTree.AddNode(st8, 8, null, null);
            //            1                           
            //              \                          
            //               5                          
            //              /  \                    
            //             3    7            
            //            / \  / \     
            //           2  4  6  8      
            StudentTree.PreReverseOrder(StudentTree.rootNode, stlist);
            string result = "";
            foreach (Node<object, int> el in stlist)
            {
                result += el.ToString();
            }
            //Assert
            Assert.Equal("8 7 6 5 4 3 2 1 ", result);
        }

        [Fact]
        public void PreForwardOrderTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "1";
            string st2 = "2";
            string st3 = "3";
            string st4 = "4";
            string st5 = "5";
            string st6 = "6";
            string st7 = "7";
            string st8 = "8";
            List<Node<object, int>> stlist = new List<Node<object, int>>();
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.AddNode(st5, 5, null, null);
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st7, 7, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st4, 4, null, null);
            StudentTree.AddNode(st6, 6, null, null);
            StudentTree.AddNode(st8, 8, null, null);
            //            1                           
            //              \                          
            //               5                          
            //              /  \                    
            //             3    7            
            //            / \  / \     
            //           2  4  6  8      
            StudentTree.PreForwardOrder(StudentTree.rootNode, stlist);
            string result = "";
            foreach (Node<object, int> el in stlist)
            {
                result += el.ToString();
            }
            //Assert
            Assert.Equal("1 5 7 8 6 3 4 2 ", result);
        }

        [Fact]
        public void PreReverseForwardOrderTest()
        {
            //Arrange
            BinaryTree<object, int> StudentTree = new BinaryTree<object, int>();
            string st1 = "1";
            string st2 = "2";
            string st3 = "3";
            string st4 = "4";
            string st5 = "5";
            string st6 = "6";
            string st7 = "7";
            string st8 = "8";
            List<Node<object, int>> stlist = new List<Node<object, int>>();
            //Act
            StudentTree.AddNode(st1, 1, null, null);
            StudentTree.AddNode(st5, 5, null, null);
            StudentTree.AddNode(st3, 3, null, null);
            StudentTree.AddNode(st7, 7, null, null);
            StudentTree.AddNode(st2, 2, null, null);
            StudentTree.AddNode(st4, 4, null, null);
            StudentTree.AddNode(st6, 6, null, null);
            StudentTree.AddNode(st8, 8, null, null);
            //            1                           
            //              \                          
            //               5                          
            //              /  \                    
            //             3    7            
            //            / \  / \     
            //           2  4  6  8      
            StudentTree.PreForwardReverseOrder(StudentTree.rootNode, stlist);
            string result = "";
            foreach (Node<object, int> el in stlist)
            {
                result += el.ToString();
            }
            //Assert
            Assert.Equal("8 6 7 4 2 3 5 1 ", result);
        }
    }
}
