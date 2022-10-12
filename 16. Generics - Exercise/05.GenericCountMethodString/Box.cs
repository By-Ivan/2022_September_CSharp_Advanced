using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class Box<T> where T : IComparable
    {
        private const int initialArraySize = 2;

        private T[] elements;

        public Box()
        {
            elements = new T[initialArraySize];
        }

        public int Count { get; private set; } = 0;

        public T this[int index]
        {
            get
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return elements[index];
            }
            set
            {
                if (index >= Count)
                {
                    throw new IndexOutOfRangeException();
                }
                elements[index] = value;
            }
        }

        public void Add(T element)
        {
            if (Count == elements.Length)
            {
                Resize();
            }

            elements[Count++] = element;
        }

        public T Remove()
        {
            if (Count == 0)
            {
                throw new ArgumentException("No elements.");
            }

            T element = elements[--Count];

            elements[Count] = default(T);

            if (Count <= elements.Length / 4)
            {
                Shrink();
            }

            return element;

        }

        public void SwapElements(int index1, int index2)
        {
            if (index1 >=0 && index1 < Count && index2 >= 0 && index2 < Count)
            {
                T temp = elements[index1];
                elements[index1] = elements[index2];
                elements[index2] = temp;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int ComparisonByValue(T value)
        {
            int count = 0;

            for (int i = 0; i < Count; i++)
            {
                if (elements[i].CompareTo(value) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        private void Shrink()
        {
            T[] copy = new T[this.elements.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = this.elements[i];
            }

            this.elements = copy;
        }

        private void Resize()
        {
            T[] copy = new T[this.elements.Length * 2];

            for (int i = 0; i < this.elements.Length; i++)
            {
                copy[i] = this.elements[i];
            }

            this.elements = copy;
        }

        public override string ToString()
        {
            string[] output = new string[Count];

            for (int i = 0; i < Count; i++)
            {
                output[i] = $"{elements[i].GetType()}: {elements[i]}";
            }
            return String.Join('\n', output);
        }
    }
}
