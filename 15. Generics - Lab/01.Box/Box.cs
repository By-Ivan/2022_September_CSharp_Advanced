using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private const int initialArraySize = 2;

        private T[] elements;

        public Box()
        {
            elements = new T[initialArraySize];
        }

        //public Box(T[] elements)
        //{
        //    this.elements = new T[elements.Length];
        //    this.elements = elements;
        //    Count = elements.Length;
        //}

        //public Box(List<T> elements)
        //{
        //    this.elements = new T[elements.Count];
        //    this.elements = elements.ToArray();
        //    Count = elements.Count;
        //}

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
    }
}
