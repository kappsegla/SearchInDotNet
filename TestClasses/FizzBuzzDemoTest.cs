using ConsoleApp2.Examples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class FizzBuzzDemoTest
    {
        FizzBuzzDemo fbdemo = new FizzBuzzDemo();

        [Fact]
        public void CallingFizzBuzzWithOneReturnsOne()
        {
            var result = fbdemo.FizzBuzz(1);

            Assert.Equal("1", result);
        }


        [Fact]
        public void CallingFizzBuzzWithTwoReturnsTwo()
        {
            var result = fbdemo.FizzBuzz(2);

            Assert.Equal("2", result);
        }

        [Fact]
        public void CallingFizzBuzzWithThreeReturnsFizz()
        {
            var result = fbdemo.FizzBuzz(3);

            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData(4, "4")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        //[MemberData(nameof(FizzBuzzDemoTest.TestData))]
        public void CallingFizzBuzzWithValueReturnsExpected(int value, string expected)
        {
            var result = fbdemo.FizzBuzz(value);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> TestData()
        {
            return Data;
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]{4, "4"},
                new object[]{5, "Buzz"}
            };



    }
}
