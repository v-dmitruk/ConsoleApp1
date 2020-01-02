using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class ShiftedArray<T> : IEnumerable 
    {
        private T[] container;
        public int startingIndex { get; private set; }

        //Constructors
        public ShiftedArray(int start, int size)
        {
            container = new T[size];
            startingIndex = start;
        }
        public ShiftedArray(T[] cont, int start)
        {
            container = new T[cont.Length];
            for (int i = 0; i < cont.Length; i++)
            {
                container[i] = cont[i];
            }
            startingIndex = start;
        }
        public ShiftedArray(T[] cont)
        {
            container = new T[cont.Length];
            for (int i = 0; i < cont.Length; i++)
            {
                container[i] = cont[i];
            }
            startingIndex = 0;
        }

        //Add
        public void Add(T obj)
        {
            T[] result = new T[container.Length+1];
            for (int i = 0; i < container.Length; i++)
            {
                    result[i] = container[i];
            }
            result[container.Length] = obj;
            container = result;
            return;
        }
        //Union
        public ShiftedArray<T> Union(ShiftedArray<T> container2)
        {
            T[] result = new T[container.Length+container2.container.Length];
            for (int i = 0; i < container.Length + container2.container.Length; i++)
                if (i < container.Length)
                result[i] = container[i];
                else
                result[i] = container2[i- container2.container.Length+container2.startingIndex];
            return new ShiftedArray<T>(result, this.startingIndex);
        }
        //DeleteElem
        public void Delete(int index)
        {
            if (index < startingIndex || index >= startingIndex + this.container.Length)
                throw new IndexOutOfRangeException("Index is out of range");
            T[] result = new T[container.Length - 1];
            for (int i = 0; i < container.Length; i++)
            {
                if (i < index - startingIndex)
                    result[i] = container[i];
                if (i > index - startingIndex)
                    result[i - 1] = container[i];
            }
            container = result;
            return;
        }
        public void SetNewStart(int newStartingIndex)
        {
            startingIndex = newStartingIndex;
        }
        public int Lenght()
        {
            return container.Length;
        }

        public T this[int index]
        {
            get
            {
                if (index < startingIndex || index >= startingIndex + this.container.Length)
                    throw new IndexOutOfRangeException("Index is out of range");
                return this.container[index-startingIndex];
            }
            set
            {
                if (index < startingIndex || index > startingIndex + this.container.Length)
                    throw new IndexOutOfRangeException("Index is out of range");
                this.container[index - startingIndex] = value;
            }
        }

        public ArrayEnum<T> GetEnumerator()
        {
            return new ArrayEnum<T>(container);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }

        public class ArrayEnum<T> : IEnumerator<T>
        {
            private T[] container;
            private int position;
            private T currentObj;

            public ArrayEnum(T[] list)
            {
                container = list;
                position = -1;
                currentObj = default(T);
            }

            public bool MoveNext()
            {
                position++;
                return (position < container.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            void IDisposable.Dispose()
            { }

            T IEnumerator<T>.Current
            {
                get
                {
                    return (T)Current;
                }
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return container[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }

    



}
