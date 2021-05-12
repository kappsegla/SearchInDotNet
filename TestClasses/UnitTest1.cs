using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ASimpleTestExampleDoingNothingImportant()
        {
            //Arrange
            int i = 0;
            //Act
            i++;
            //Assert
            Assert.Equal(1, i);
        }

        [Fact]
        public void ErrorWhenReading()
        {
            int[] array = new int[1];

            Assert.Throws<IndexOutOfRangeException>(() => array[1]);
        }
    }
}
