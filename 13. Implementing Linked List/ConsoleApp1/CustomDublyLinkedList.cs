using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomDublyLinkedList
    {
        private Node head;
        private Node tail;

        public CustomDublyLinkedList()
        {

        }

        public CustomDublyLinkedList(int[] inputArray)
        {
            FromArray(inputArray);    
        }

        public CustomDublyLinkedList(List<int> inputList)
        {
            FromList(inputList);
        }

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                head = tail = new Node(element);
            }
            else
            {
                Node newHead = new Node(element);
                newHead.Next = head;
                head.Previous = newHead;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                head = tail = new Node(element);
            }
            else
            {
                Node newTail = new Node(element);
                newTail.Previous = tail;
                tail.Next = newTail;
                tail = newTail;
            }

            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int firstElement = head.Value;
            head = head.Next;

            if (head.Previous != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }

            Count--;

            return firstElement;

        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            int lastElement = tail.Value;
            tail = tail.Previous;

            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }

            Count--;

            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int counter = 0;
            Node currentNode = head;

            while (currentNode != null)
            {
                array[counter++] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return array;
        }

        private void FromArray(int[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                AddLast(input[i]);
            }
        }

        private void FromList(List<int> input)
        {
            for (int i = 0; i < input.Count; i++)
            {
                AddLast(input[i]);
            }
        }
    }

    internal class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}
