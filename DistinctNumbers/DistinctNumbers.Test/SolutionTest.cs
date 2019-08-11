using System;
using System.Collections.Generic;
using Xunit;

namespace DistinctNumbers.Test
{
    public class SolutionTest
    {
        [Theory]
        [InlineData(new int[] { },0)]
        [InlineData(new int[] {1000001}, 0)]
        [InlineData(new int[] {-1000001}, 0)]
        [InlineData(new int[] {2,1,1,2,3,1}, 3)]
        [InlineData(new int[] { 2 }, 1)]
        [InlineData(new int[] { 0, 0, 0, 1, 1, 1 }, 2)]
        [InlineData(new int[] { 0, 0, 0, 0, 0, 0 }, 1)]
        [InlineData(new int[] { 1, 1, 1, 2, 3, 1 }, 3)]
        public void solution_AnyValuesGiven_ReturnCorrectResult(int[] A,int expectedResult)
        {
            Solution sol = new Solution();
            int actualResult = sol.solution(A);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(5, new int[] { 1, 2, 3, 4, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [InlineData(0, new int[] { 1, 2, 3, 4, 6 }, new int[] { 0, 1, 2, 3, 4, 6 })]
        [InlineData(7, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [InlineData(3, new int[] { 1, 2, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [InlineData(9, new int[] { 1, 2, 3, 4, 6 }, new int[] { 1, 2, 3, 4, 6, 9 })]
        [InlineData(2, new int[] { 1 }, new int[] { 1, 2 })]
        public void InsertNewNumber_AnySortedArray_InsertNumberInSortedOrder(int newNumber, int[] A, int[] expectedResultArray)
        {
            List<int> convertedArray = new List<int>(A);
            Solution.InsertNewNumber(newNumber, convertedArray);

            Assert.Equal(new List<int>(expectedResultArray), convertedArray);

        }
    }
}
