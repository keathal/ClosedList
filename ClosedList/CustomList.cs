using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosedList
{
    public class CustomList<T> : IClosedList<T> 
    {
        private T[] _contents = new T[8];
        private int _count;
        public T this[int index]
        {
            get
            {
                return _contents[index];
            }
            set
            {
                _contents[index] = value;
            }
        }

        public T Head => this[0];

        public T Current { get; private set; }

        public T Previous { get; private set; }

        public T Next { get; private set; }


        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public event EventHandler<T> HeadReached;

        public CustomList()
        {
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(T item)
        {
            this[Count] = item;
            if (Count == 0)
            {
                Current = Head;
            }
            else if (Count == 1)
            {
                Next = item;
            }
            _count++;
        }

        public void Clear()
        {
            _count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(_contents[i], arrayIndex++);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_contents[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index > Count -1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if ((_count + 1 <= _contents.Length) && (index < Count) && (index >= 0))
            {
                _count++;

                if (_contents[index].Equals(Current))
                {
                    Previous = item;
                }
                else if (_contents[index].Equals(Next))
                {
                    Next = item;
                }
                for (int i = Count - 1; i > index; i--)
                {
                    _contents[i] = _contents[i - 1];
                }
                _contents[index] = item;
            }
        }

        public void MoveBack(int step = 1)
        {
            for (int i = 0; i < step; i++)
            {
                if (!Current.Equals(Head))
                {
                    int index = IndexOf(Current);
                    Next = Current;
                    Current = Previous;

                    if (Current.Equals(Head))
                    {
                        HeadReached?.Invoke(this, Head);
                        Previous = default(T);
                    }
                    else 
                    {
                        Previous = _contents[index - 2];
                    }
                }
                else break;
            }
        }

        public void MoveNext(int step = 1)
        {
            for (int i = 0; i < step; i++)
            {
                int index = IndexOf(Current);
                if (index < Count - 1)
                {
                    Previous = Current;
                    Current = Next;
                    if (index + 2 < Count)
                    {
                        Next = _contents[index + 2];
                    }
                    else
                    {
                        Next = default(T);
                    }
                }
                else break;
            }
        }

        public bool Remove(T item)
        {
            if (Contains(item))
            {
                RemoveAt(IndexOf(item));
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index > Count - 1 || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            if ((index >= 0) && (index < Count))
            {
                if (_contents[index].Equals(Previous))
                {
                    Next = Current;
                    Current = Previous;
                    if (index - 1 >= 0)
                    {
                        Previous = _contents[index - 1];
                    }
                    Previous = default(T);
                }
                else if (_contents[index].Equals(Current))
                {
                    Current = Next;
                    Next = _contents[index + 1];
                }
                else if (_contents[index].Equals(Next))
                {
                    if (index + 1 < Count - 1)
                    {
                        Next = _contents[index + 1];
                    }
                    else
                    {
                        Next = default(T);
                    }
                }
                for (int i = index; i < Count - 1; i++)
                {
                    _contents[i] = _contents[i + 1];
                }
                _count--;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
