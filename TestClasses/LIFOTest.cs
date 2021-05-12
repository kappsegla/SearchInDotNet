using ConsoleApp2.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class LIFOTest
    {
        LIFO lifo = new LIFO();

        [Fact]
        public void CreatedLIFOIsEmpty()
        {
            var actual = lifo.IsEmpty();

            Assert.True(actual);
        }

        [Fact]
        public void AfterPushingIsEmtpyIsFalse()
        {

            lifo.Push(1);

            var actual = lifo.IsEmpty();

            Assert.False(actual);
        }

        [Fact]
        public void PushingTwoItemsReturnsSizeTwo()
        {
            lifo.Push(1);
            lifo.Push(2);

            Assert.Equal(2, lifo.Size());
        }

        [Fact]
        public void PushingOneItemReturnsSizeOne()
        {
            lifo.Push(1);

            Assert.Equal(1, lifo.Size());
        }

        [Fact]
        public void PushingItemsThenPopShouldReturnInLIFOOrder()
        {
            lifo.Push(1);
            lifo.Push(2);

            Assert.Equal(2, lifo.Pop());
            Assert.Equal(1, lifo.Pop());
        }






    }
}
