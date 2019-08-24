using System;
using CashMachineApp.Utils;
using Xunit;

namespace CashMachineApp.Tests
{
    public class ArrayUtilsTests
    {

        [Theory]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new[] {1,2,3,4}, new[] {4,3,2,1})]
        [InlineData(new[] {-1,2,-3,4}, new[] {4,2,-1,-3})]
        [InlineData(new[] {20, 50, 10}, new[] {50,20,10})]
        [InlineData(new[] {8,8,8,3,1,2,4,5}, new[] {8,8,8,5,4,3,2,1})]
        public void SortDesc_ValidInputs_ShouldReturn_Expected(int[] input, int[] expected)
        {
            ArrayUtils.SortDesc(input);

            Assert.Equal(expected, input);
        }

        [Fact]
        public void SortDesc_InputIsNull_ShoudThrow_ArgumentNullException()
        {

            var act = new Action(() => ArrayUtils.SortDesc(null));

            Assert.Throws<ArgumentNullException>(act);
        }

        [Theory]
        [InlineData(new[] {1,1,1,3,5,5}, "3x1, 3, 2x5")]
        [InlineData(new[] {1,5}, "1, 5")]
        public void ToDisplayString_ShouldReturn_Expected(int[] input, string expected)
        {
            var res = input.ToDisplayString();

            Assert.Equal(expected, res);
        }
    }
}