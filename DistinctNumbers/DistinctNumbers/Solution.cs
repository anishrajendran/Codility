using System;
using System.Collections.Generic;

namespace DistinctNumbers
{
    public class Solution
    {
        /// <summary>
        /// Method to find the distinct numbers
        /// </summary>
        /// <param name="A">Input Array</param>
        /// <returns>number of distinct elements in Array</returns>
        public int solution(int[] A)
        {
            int distinctValuesCount = 0;
            int length = A.Length;
            List<int> distinctNumbers = new List<int>();

            /// Check if length within allowed limits 
            if (length == 0 || length > 100000) return 0;

            for (int i = 0; i < length; i++)
            {
                /// Check if the number is within allowed limit
                if (A[i] > 1000000 || A[i] < -1000000) return 0;

                /// Search if number exists in distinct Numbers list, insert if it does not exist
                if (Array.BinarySearch(distinctNumbers.ToArray(), A[i]) >= 0)
                    continue;
                else
                {
                    InsertNewNumber(A[i], distinctNumbers);
                    distinctValuesCount++;
                }
            }

            return distinctValuesCount;
        }

        /// <summary>
        /// Insert new element to existing sorted list of distinct numbers 
        /// </summary>
        /// <param name="newNumber">New number to be inserted</param>
        /// <param name="distinctNumbers">List of distinct numbers</param>
        public static void InsertNewNumber(int newNumber, List<int> distinctNumbers)
        {
            int distinctLength = distinctNumbers.Count;
            if (distinctLength == 0)
            {
                distinctNumbers.Add(newNumber);
            }

            /// Do binary search to find the index of the list to insert new element
            int low = 0, high = distinctLength - 1, len = distinctLength, mid = 0;
            while (len > 2)
            {
                mid = len / 2;
                if (newNumber > distinctNumbers[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
                len = high - low + 1;
            }

            /// Insert number based on the order of the number
            if (newNumber > distinctNumbers[low])
            {
                if (newNumber > distinctNumbers[high]) distinctNumbers.Insert(high + 1, newNumber);
                else distinctNumbers.Insert(high, newNumber);
            }
            else
            {
                distinctNumbers.Insert(low, newNumber);
            }
        }
    }
}
