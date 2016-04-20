using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        #region Fields
        public LinkedListNode<T> head;
        public LinkedListNode<T> tail;
        public int Count { get; internal set; }
        #endregion

        #region Methods
        public void Add(T value)
        {

            LinkedListNode<T> node = new LinkedListNode<T>(value);

            if (head == null)
            {
                head = node;
                tail = node;
            }

            else
            {
                tail.Next = node;
                tail = node;
            }
            Count++;
        }
        public bool Remove(T value)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = head;
            while(current != null)
            {
                if(current.Value.Equals(value))
                {
                    if(previous != null)
                    {
                        previous.Next = current.Next;
                        if(current.Next == null )
                        {
                            tail = previous;
                        }
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;

            }
            return false;
        }

        public bool Contains(T value)
        {
            LinkedListNode<T> current = head;
            while(current!= null)
            {
                if(current.Next.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            Count = 0;
        }
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = head;
            while(current!=null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = head;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
        #endregion
    }
}
