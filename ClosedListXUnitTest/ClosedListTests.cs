using System;
using Xunit;
using ClosedList;

namespace ClosedListXUnitTest
{
    public class ClosedListTests
    {
        [Fact]
        public void UpdateCount()
        {
            var customList = new CustomList<int>();

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);

            Assert.Equal(3, customList.Count);
        }

        [Fact]
        public void UpdateAfterInsert()
        {
            var customList = new CustomList<int>();

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);
            customList.Insert(1, 10);

            Assert.Equal(10, customList[1]);
        }

        [Fact]
        public void OutOfRangeInsert()
        {
            var customList = new CustomList<int>();

            Assert.Throws<IndexOutOfRangeException>(() => customList.Insert(10, 5));
        }

        [Fact]
        public void IndexOf()
        {
            var customList = new CustomList<int>();

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);

            Assert.Equal(2, customList.IndexOf(1));
        }

        [Fact]
        public void IndexOfNotExisting()
        {
            var customList = new CustomList<int>();

            Assert.Equal(-1, customList.IndexOf(1));
        }

        [Fact]
        public void UpdateAfterRemove()
        {
            var customList = new CustomList<int>();

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);
            customList.Remove(5);

            Assert.Equal(2, customList.Count);
        }

        [Fact]
        public void UpdateAfterRemoveAt()
        {
            var customList = new CustomList<int>();

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);
            customList.RemoveAt(1);

            Assert.Equal(1, customList[1]);
        }

        [Fact]
        public void OutOfRangeRemoveAt()
        {
            var customList = new CustomList<int>();

            Assert.Throws<IndexOutOfRangeException> (() => customList.RemoveAt(10));
        }

        [Fact]
        public void Contains()
        {
            var customList = new CustomList<int>();

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);

            Assert.True(customList.Contains(5));
            Assert.False(customList.Contains(10));
        }

        [Fact]
        public void CopyTo()
        {
            var customList = new CustomList<int>();
            int[] newArray = new int[8];

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);
            customList.CopyTo(newArray, 0);

            Assert.Equal(5, newArray[1]);
        }

        [Fact]
        public void MoveNext()
        {
            var customList = new CustomList<int>();

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);
            customList.Add(15);
            customList.MoveNext();
            customList.MoveNext();

            Assert.Equal(1, customList.Current);
            Assert.Equal(5, customList.Previous);
            Assert.Equal(15, customList.Next);
        }



        [Fact]
        public void MoveNextAndBack()
        {
            var customList = new CustomList<int>();

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);
            customList.Add(15);
            customList.MoveNext();
            Assert.Equal(5, customList.Current);
            Assert.Equal(4, customList.Previous);
            Assert.Equal(1, customList.Next);
            customList.MoveNext();
            Assert.Equal(1, customList.Current);
            Assert.Equal(5, customList.Previous);
            Assert.Equal(15, customList.Next);
            customList.MoveBack();

            Assert.Equal(5, customList.Current);
            Assert.Equal(4, customList.Previous);
            Assert.Equal(1, customList.Next);
        }

        [Fact]
        public void HeadReachedOnce()
        {
            int eventCount = 0;
            var customList = new CustomList<int>();
            customList.HeadReached += (customList, e) => { eventCount++; };

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);
            customList.Add(15);
            customList.MoveNext();
            customList.MoveBack();

            Assert.Equal(1, eventCount);
        }

        [Fact]
        public void HeadReachedTwice()
        {
            int eventCount = 0;
            var customList = new CustomList<int>();
            customList.HeadReached += (customList, e) => { eventCount++; };

            customList.Add(4);
            customList.Add(5);
            customList.Add(1);
            customList.Add(15);
            customList.MoveNext();
            customList.MoveBack(2);
            customList.MoveNext(2);

            Assert.Equal(1, customList.Next);
            Assert.Equal(2, eventCount);
        }

    }
}
