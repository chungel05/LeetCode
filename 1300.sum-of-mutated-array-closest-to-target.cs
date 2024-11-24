/*
 * @lc app=leetcode id=1300 lang=csharp
 *
 * [1300] Sum of Mutated Array Closest to Target
 *
 * https://leetcode.com/problems/sum-of-mutated-array-closest-to-target/description/
 *
 * algorithms
 * Medium (44.85%)
 * Likes:    1153
 * Dislikes: 149
 * Total Accepted:    41.1K
 * Total Submissions: 91.4K
 * Testcase Example:  '[4,9,3]\n10'
 *
 * Given an integer array arr and a target value target, return the integer
 * value such that when we change all the integers larger than value in the
 * given array to be equal to value, the sum of the array gets as close as
 * possible (in absolute difference) to target.
 * 
 * In case of a tie, return the minimum such integer.
 * 
 * Notice that the answer is not neccesarilly a number from arr.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: arr = [4,9,3], target = 10
 * Output: 3
 * Explanation: When using 3 arr converts to [3, 3, 3] which sums 9 and that's
 * the optimal answer.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: arr = [2,3,5], target = 10
 * Output: 5
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: arr = [60864,25176,27249,21296,20204], target = 56803
 * Output: 11361
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= arr.length <= 10^4
 * 1 <= arr[i], target <= 10^5
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    private int BSFindBestValue(int[] arr, int x)
    {
        // Binary search to find the smallest index which arr[index] greater or equal to x
        int left = 0, right = arr.Length - 1;
        while (left < right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] >= x)
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }

    public int FindBestValue(int[] arr, int target)
    {
        Array.Sort(arr);
        int[] prefixSum = new int[arr.Length + 1];
        int maxValue = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            prefixSum[i + 1] = prefixSum[i] + arr[i];
            maxValue = Math.Max(maxValue, arr[i]);
        }

        int res = 0, minDiff = Int32.MaxValue;

        // start from 0 to max Value of whole arr
        // because there maybe whole arr smaller than average value: target / arr.Length
        // we need to get the max value of arr
        for (int i = 0; i <= maxValue; i++)
        {
            int index = BSFindBestValue(arr, i);

            // prefixSum[index] = sum from 0 to index - 1
            // arr.Length - index = remaining elements * i
            // total Sum - target
            // We need to use abs becasuse total sum may smaller than target
            int diff = Math.Abs(prefixSum[index] + (arr.Length - index) * i - target);
            if (minDiff > diff)
            {
                minDiff = diff;
                res = i;
            }
        }
        return res;
    }
}
// @lc code=end

