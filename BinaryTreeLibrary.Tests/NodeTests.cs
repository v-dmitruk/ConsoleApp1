using System;
using System.Collections.Generic;
using System.Text;
using BinaryTreeLibrary;
using Xunit;

namespace BinaryTreeLibrary.Tests
{
    public class NodeTests
    {
        [Fact]
        public void NodeOneAsObjectToString()
        {
            //Arrange            
            ConsoleApp1.Node<int, int> node = new ConsoleApp1.Node<int, int>(1, 2);
            //Act
            string result = node.ToString();
            //Assert
            Assert.Equal("2 ", result);
        }

        [Fact]
        public void NodeNullAsObjectToStringExpectedAsException()
        {
            //Arrange            
            ConsoleApp1.Node<int, int> node = new ConsoleApp1.Node<int, int>();
            //Act
            string result = node.ToString();
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void NodeNullAsObjectHeightExpectedAsZero()
        {
            //Arrange            
            ConsoleApp1.Node<int, int> node = new ConsoleApp1.Node<int, int>();
            //Act
            short result = node.Height(node);
            //Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void NodeFiveAsObjectHeightExpectedOne()
        {
            //Arrange            
            ConsoleApp1.Node<int, int> node = new ConsoleApp1.Node<int, int>(1, 5);
            //Act
            short result = node.Height(node);
            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void NodeObjectHelloAsObjectToStringExpectedHello()
        {
            //Arrange            
            ConsoleApp1.Node<object, int> node = new ConsoleApp1.Node<object, int>(1, "Hello");
            //Act
            string result = node.ToString();
            //Assert
            Assert.Equal("Hello ", result);
        }


        [Fact]
        public void NodeFixHeightExpextedTwo()
        {
            //Arrange            
            ConsoleApp1.Node<object, int> node = new ConsoleApp1.Node<object, int>(1, "Hello");
            ConsoleApp1.Node<object, int> leftnode = new ConsoleApp1.Node<object, int>(3, "Hello1");
            ConsoleApp1.Node<object, int> rightnode = new ConsoleApp1.Node<object, int>(5, "Hello2");
            node.LeftNode = leftnode;
            node.RightNode = rightnode;
            //Act
            node.FixHeight(node);
            //Assert
            Assert.Equal(2, node.Height(node));
        }

        [Fact]
        public void NodeBalanceFactorExpextedZero()
        {
            //Arrange            
            ConsoleApp1.Node<object, int> node = new ConsoleApp1.Node<object, int>(1, "Hello");
            ConsoleApp1.Node<object, int> leftnode = new ConsoleApp1.Node<object, int>(3, "Hello1");
            ConsoleApp1.Node<object, int> rightnode = new ConsoleApp1.Node<object, int>(5, "Hello2");
            node.LeftNode = leftnode;
            node.RightNode = rightnode;
            //Act
            //node.FixHeight(node);
            //Assert
            Assert.Equal(0, node.balanceFactor());
        }

        [Fact]
        public void NodeBalanceFactorExpextedTwo()
        {
            //Arrange            
            ConsoleApp1.Node<object, int> node = new ConsoleApp1.Node<object, int>(1, "Hello");
            ConsoleApp1.Node<object, int> leftnode = new ConsoleApp1.Node<object, int>(3, "Hello1");
            ConsoleApp1.Node<object, int> rightnode = new ConsoleApp1.Node<object, int>(5, "Hello2");
            node.LeftNode = leftnode;
            leftnode.RightNode = rightnode;
            //Act
            node.FixHeight(node);
            //Assert
            Assert.Equal(2, node.balanceFactor());
        }
    }
}
