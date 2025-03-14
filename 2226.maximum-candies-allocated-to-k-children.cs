/*
 * @lc app=leetcode id=2226 lang=csharp
 *
 * [2226] Maximum Candies Allocated to K Children
 *
 * https://leetcode.com/problems/maximum-candies-allocated-to-k-children/description/
 *
 * algorithms
 * Medium (38.49%)
 * Likes:    1209
 * Dislikes: 42
 * Total Accepted:    53.8K
 * Total Submissions: 136.1K
 * Testcase Example:  '[5,8,6]\n3'
 *
 * You are given a 0-indexed integer array candies. Each element in the array
 * denotes a pile of candies of size candies[i]. You can divide each pile into
 * any number of sub piles, but you cannot merge two piles together.
 * 
 * You are also given an integer k. You should allocate piles of candies to k
 * children such that each child gets the same number of candies. Each child
 * can be allocated candies from only one pile of candies and some piles of
 * candies may go unused.
 * 
 * Return the maximum number of candies each child can get.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: candies = [5,8,6], k = 3
 * Output: 5
 * Explanation: We can divide candies[1] into 2 piles of size 5 and 3, and
 * candies[2] into 2 piles of size 5 and 1. We now have five piles of candies
 * of sizes 5, 5, 3, 5, and 1. We can allocate the 3 piles of size 5 to 3
 * children. It can be proven that each child cannot receive more than 5
 * candies.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: candies = [2,5], k = 11
 * Output: 0
 * Explanation: There are 11 children but only 7 candies in total, so it is
 * impossible to ensure each child receives at least one candy. Thus, each
 * child gets no candy and the answer is 0.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= candies.length <= 10^5
 * 1 <= candies[i] <= 10^7
 * 1 <= k <= 10^12
 * 
 * 
 */
/*
 * Binary Search Approach
 * Time: O(n log m) where m is max candies[i], Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    private bool CheckMaximumCandies(int[] candies, long k, int mid)
    {
        long piles = 0;
        for (int i = 0; i < candies.Length; i++)
        {
            piles += candies[i] / mid;
            if (piles >= k)
                return true;
        }

        return false;
    }

    public int MaximumCandies(int[] candies, long k)
    {
        // find the max no. candies
        int max = 0;
        for (int i = 0; i < candies.Length; i++)
            max = Math.Max(max, candies[i]);

        // Binary Search
        // since the ans is left - 1, so lower bound is 1 and higher bound is max + 1
        int left = 1, right = max + 1;
        while (left < right)
        {
            int mid = (left + right) / 2;
            // if it cannot fulfill the condition, move mid to mid
            if (!CheckMaximumCandies(candies, k, mid))
                right = mid;
            // if it can fulfill the condition, move left to mid + 1
            else
                left = mid + 1;
        }
        // ans will be left - 1
        return left - 1;
    }
}
// @lc code=end

