/*
 * @lc app=leetcode id=179 lang=csharp
 *
 * [179] Largest Number
 *
 * https://leetcode.com/problems/largest-number/description/
 *
 * algorithms
 * Medium (40.09%)
 * Likes:    8913
 * Dislikes: 748
 * Total Accepted:    659.7K
 * Total Submissions: 1.6M
 * Testcase Example:  '[10,2]'
 *
 * Given a list of non-negative integers nums, arrange them such that they form
 * the largest number and return it.
 * 
 * Since the result may be very large, so you need to return a string instead
 * of an integer.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [10,2]
 * Output: "210"
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [3,30,34,5,9]
 * Output: "9534330"
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 100
 * 0 <= nums[i] <= 10^9
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public bool LargestNumberCompare(string s1, string s2)
    {
        // directly concat 2 string and compare which one is larger
        string s1s2 = string.Join("", [s1, s2]);
        string s2s1 = string.Join("", [s2, s1]);

        for (int i = 0; i < s1s2.Length; i++)
        {
            if (s1s2[i] - '0' > s2s1[i] - '0')
                return true;
            else if (s1s2[i] - '0' < s2s1[i] - '0')
                return false;
        }
        return true;
    }

    public void MergeLargestNumber(string[] arr, string[] left, string[] right)
    {
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            // if larger, add first
            if (LargestNumberCompare(left[i], right[j]))
                arr[k++] = left[i++];
            else
                arr[k++] = right[j++];
        }

        // add remaining string
        while (i < left.Length)
            arr[k++] = left[i++];

        while (j < right.Length)
            arr[k++] = right[j++];
    }

    public void SortLargestNumber(string[] arr)
    {
        // base case
        if (arr.Length <= 1) return;

        int mid = arr.Length / 2;
        string[] left = new string[mid];
        string[] right = new string[arr.Length - mid];

        for (int i = 0; i < mid; i++)
        {
            left[i] = arr[i];
        }

        for (int i = mid; i < arr.Length; i++)
        {
            right[i - mid] = arr[i];
        }

        SortLargestNumber(left);
        SortLargestNumber(right);
        MergeLargestNumber(arr, left, right);
    }

    public string LargestNumber(int[] nums)
    {
        if (nums.Length <= 1)
            return nums[0].ToString();

        string[] res = nums.Select(x => x.ToString()).ToArray();

        SortLargestNumber(res);

        string r = string.Join("", res);
        //Edge case: if leading char is 0, then it must be "0"
        return r[0] == '0' ? "0" : r;
    }
}
// @lc code=end

