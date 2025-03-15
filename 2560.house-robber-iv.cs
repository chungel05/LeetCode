/*
 * @lc app=leetcode id=2560 lang=csharp
 *
 * [2560] House Robber IV
 *
 * https://leetcode.com/problems/house-robber-iv/description/
 *
 * algorithms
 * Medium (44.52%)
 * Likes:    997
 * Dislikes: 37
 * Total Accepted:    26.2K
 * Total Submissions: 55.3K
 * Testcase Example:  '[2,3,5,9]\n2'
 *
 * There are several consecutive houses along a street, each of which has some
 * money inside. There is also a robber, who wants to steal money from the
 * homes, but he refuses to steal from adjacent homes.
 * 
 * The capability of the robber is the maximum amount of money he steals from
 * one house of all the houses he robbed.
 * 
 * You are given an integer array nums representing how much money is stashed
 * in each house. More formally, the i^th house from the left has nums[i]
 * dollars.
 * 
 * You are also given an integer k, representing the minimum number of houses
 * the robber will steal from. It is always possible to steal at least k
 * houses.
 * 
 * Return the minimum capability of the robber out of all the possible ways to
 * steal at least k houses.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [2,3,5,9], k = 2
 * Output: 5
 * Explanation: 
 * There are three ways to rob at least 2 houses:
 * - Rob the houses at indices 0 and 2. Capability is max(nums[0], nums[2]) =
 * 5.
 * - Rob the houses at indices 0 and 3. Capability is max(nums[0], nums[3]) =
 * 9.
 * - Rob the houses at indices 1 and 3. Capability is max(nums[1], nums[3]) =
 * 9.
 * Therefore, we return min(5, 9, 9) = 5.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,7,9,3,1], k = 2
 * Output: 2
 * Explanation: There are 7 ways to rob the houses. The way which leads to
 * minimum capability is to rob the house at index 0 and 4. Return max(nums[0],
 * nums[4]) = 2.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length <= 10^5
 * 1 <= nums[i] <= 10^9
 * 1 <= k <= (nums.length + 1)/2
 * 
 * 
 */
/*
 * Binary Search Approach
 * Time: O(n log m) where n = nums.Length and m = maxMoney
 * Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public int MinCapability(int[] nums, int k)
    {
        // find the possible max money can be robbed from house
        int maxMoney = 0;
        for (int i = 0; i < nums.Length; i++)
            maxMoney = Math.Max(maxMoney, nums[i]);

        // Binary Search from range [1, maxMoney]
        // find the min money that can robbed from k houses and money = max(house1, house2, ..., house k)
        int left = 1, right = maxMoney;
        while (left < right)
        {
            // mid = target min money
            int mid = (left + right) / 2;
            // check whether mid can be robbed from k houses
            int j = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                // nums[i] should be <= mid because mid = max(house1, house2, ..., house k)
                if (nums[i] <= mid)
                {
                    // count the possible house
                    j++;
                    // skip adj. house
                    i++;
                }
                if (j >= k)
                    break;
            }

            // if mid can fullfil the conditions, move to smaller target money
            // * mid is possible ans
            if (j >= k)
                right = mid;
            else
                left = mid + 1;
        }
        return left;
    }
}
// @lc code=end

