/*
 * @lc app=leetcode id=1095 lang=csharp
 *
 * [1095] Find in Mountain Array
 *
 * https://leetcode.com/problems/find-in-mountain-array/description/
 *
 * algorithms
 * Hard (40.23%)
 * Likes:    3316
 * Dislikes: 134
 * Total Accepted:    150.5K
 * Total Submissions: 374.4K
 * Testcase Example:  '[1,2,3,4,5,3,1]\n3'
 *
 * (This problem is an interactive problem.)
 * 
 * You may recall that an array arr is a mountain array if and only if:
 * 
 * 
 * arr.length >= 3
 * There exists some i with 0 < i < arr.length - 1 such that:
 * 
 * arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
 * arr[i] > arr[i + 1] > ... > arr[arr.length - 1]
 * 
 * 
 * 
 * 
 * Given a mountain array mountainArr, return the minimum index such that
 * mountainArr.get(index) == target. If such an index does not exist, return
 * -1.
 * 
 * You cannot access the mountain array directly. You may only access the array
 * using a MountainArray interface:
 * 
 * 
 * MountainArray.get(k) returns the element of the array at index k
 * (0-indexed).
 * MountainArray.length() returns the length of the array.
 * 
 * 
 * Submissions making more than 100 calls to MountainArray.get will be judged
 * Wrong Answer. Also, any solutions that attempt to circumvent the judge will
 * result in disqualification.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: mountainArr = [1,2,3,4,5,3,1], target = 3
 * Output: 2
 * Explanation: 3 exists in the array, at index=2 and index=5. Return the
 * minimum index, which is 2.
 * 
 * Example 2:
 * 
 * 
 * Input: mountainArr = [0,1,2,4,2,1], target = 3
 * Output: -1
 * Explanation: 3 does not exist in the array, so we return -1.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 3 <= mountainArr.length() <= 10^4
 * 0 <= target <= 10^9
 * 0 <= mountainArr.get(index) <= 10^9
 * 
 * 
 */

// @lc code=start
/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

partial class Solution
{
    private int FindPeakInMountainArray(int left, int right, MountainArray mountainArr)
    {
        // Binary Search to find the peak element
        while (left < right)
        {
            int mid = (left + right) / 2;


            // if mid + 1 < mid means that it is decending, so mid maybe the peak element
            if (mountainArr.Get(mid) > mountainArr.Get(mid + 1))
                right = mid;
            else
                // if mid + 1 >= mid means that it is ascending, mid + 1 maybe the peak element
                left = mid + 1;
        }
        return left;
    }

    private int BSInMountainArray(int left, int right, int target, MountainArray mountainArr, bool direction)
    {
        // Binary Search to find the target
        while (left <= right)
        {
            int mid = (left + right) / 2;
            int midValue = mountainArr.Get(mid);
            if (midValue == target)
                return mid;

            // if direction = true, it is ascending
            // if direction = false, it is decending
            if ((midValue > target) == direction)
                right = mid - 1;
            else
                left = mid + 1;
        }
        return -1;
    }

    public int FindInMountainArray(int target, MountainArray mountainArr)
    {
        int n = mountainArr.Length();

        int peak = FindPeakInMountainArray(0, n - 1, mountainArr);
        int res = BSInMountainArray(0, peak, target, mountainArr, true);
        if (res != -1)
            return res;
        else
            return BSInMountainArray(peak, n - 1, target, mountainArr, false);
    }
}
// @lc code=end

