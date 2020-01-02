using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ShiftedArrayLibrary;
using ConsoleApp1;

namespace ShiftedArrayLibrary.Tests
{
    public class ShiftedArrayTests
    {
        [Fact]
        public void AddIntegerONETestExpectedONE()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(0, 0);
            //Act
            array.Add(i);
            //Assert
            Assert.Equal(1, array[0]);
        }

        [Fact]
        public void ArrayIndexerIntegerONETestExpectedONE()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(0, 1);
            //Act
            array[0] = i;
            //Assert
            Assert.Equal(1, array[0]);
        }

        [Fact]
        public void ShiftedMinusONEArrayIndexerIntegerONETestExpectedONE()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            //Assert
            Assert.Equal(1, array[-1]);
        }

        [Fact]
        public void ShiftedMinusONEArrayIndexerIntegerONETestExceptionExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            Action act = () => array[0].ToString();
            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Fact]
        public void ShiftedMinusONEArrayTryingToChangeUnexsistingElementTestExceptionExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            Action act = () => array[0]=i;
            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Fact]
        public void ShiftedMinusONEArrayTryingToAddSecondElementTestTreeExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            //Assert
            Assert.Equal(3, array[0]);
        }

        [Fact]
        public void ShiftedMinusONEArrayTryingToDeleteSecondElementTestOneExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Delete(0);
            //Assert
            Assert.Equal(1, array[-1]);
        }

        [Fact]
        public void ShiftedMinusONEArrayTryingToDeleteSecondElementTestExceptionExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Delete(0);
            Action act = () => array[0] = i;
            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }


        [Fact]
        public void ShiftedMinusONEArrayTryingToDeleteSecondElementTestThirdElementExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Add(1900);
            array.Delete(0);
            //Assert
            Assert.Equal(1900, array[0]);
        }


        [Fact]
        public void ShiftedMinusONEArrayTryingToSetNewStartTestThirdElementExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Add(1900);
            array.SetNewStart(20);
            //Assert
            Assert.Equal(1900, array[22]);
        }

        [Fact]
        public void ShiftedMinusONEArrayTryingToSetNewStartTestExceptionExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Add(1900);
            array.SetNewStart(20);
            Action act = () => array[0] = i;
            //Assert
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        [Fact]
        public void ShiftedMinusONEArrayThreeElementsLenght()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Add(1900);
            //Assert
            Assert.Equal(3, array.Lenght());
        }

        //Union
        [Fact]
        public void ShiftedMinusONEArrayUnionWithShiftedMinusTwoArrayLenghtAndFirstElementOneExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            ShiftedArray<int> array1 = new ShiftedArray<int>(-2, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Add(1900);
            array1.Add(100);
            array1.Add(203);
            array1.Add(1901);
            ShiftedArray<int> array2 = array.Union(array1);
            Action act = () => array2[6] = i;
            //Assert
            Assert.Equal(1, array2[-1]);
            Assert.Equal(6, array2.Lenght());
            Assert.Throws<IndexOutOfRangeException>(act);
        }

        //Enumerator
        [Fact]
        public void ForeachShiftedArrayTestSumm10Expected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Add(6);
            int summ = 0;
            foreach (int el in array)
            {
                summ += el;
            }
            //Assert
            Assert.Equal(10, summ);
        }

        [Fact]
        public void EnumeratorShiftedArrayTestMoveNextElementTHREEExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Add(6);
            IEnumerator<int> kek = array.GetEnumerator();
            kek.MoveNext();
            kek.MoveNext();
            //Assert
            Assert.Equal(3, kek.Current);
        }

        [Fact]
        public void EnumeratorShiftedArrayTestResetElementONExpected()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Add(6);
            IEnumerator<int> kek = array.GetEnumerator();
            kek.MoveNext();
            kek.MoveNext();
            kek.MoveNext();
            kek.Reset();
            kek.MoveNext();
            //Assert
            Assert.Equal(1, kek.Current);
        }

        [Fact]
        public void EnumeratorShiftedArrayExceptionExpectedAfterReset()
        {
            //Arrange
            int i = 1;
            ShiftedArray<int> array = new ShiftedArray<int>(-1, 0);
            //Act
            array.Add(i);
            array.Add(3);
            array.Add(6);
            IEnumerator<int> kek = array.GetEnumerator();
            kek.MoveNext();
            kek.MoveNext();
            kek.MoveNext();
            kek.Reset();
            Action act = () => i = kek.Current;
            //Assert
            Assert.Throws<InvalidOperationException>(act);
        }
    }
}
