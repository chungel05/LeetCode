/*
 * @lc app=leetcode id=2551 lang=csharp
 *
 * [2551] Put Marbles in Bags
 *
 * https://leetcode.com/problems/put-marbles-in-bags/description/
 *
 * algorithms
 * Hard (66.45%)
 * Likes:    2074
 * Dislikes: 89
 * Total Accepted:    61K
 * Total Submissions: 92.6K
 * Testcase Example:  '[1,3,5,1]\n2'
 *
 * You have k bags. You are given a 0-indexed integer array weights where
 * weights[i] is the weight of the i^th marble. You are also given the integer
 * k.
 * 
 * Divide the marbles into the k bags according to the following rules:
 * 
 * 
 * No bag is empty.
 * If the i^th marble and j^th marble are in a bag, then all marbles with an
 * index between the i^th and j^th indices should also be in that same bag.
 * If a bag consists of all the marbles with an index from i to j inclusively,
 * then the cost of the bag is weights[i] + weights[j].
 * 
 * 
 * The score after distributing the marbles is the sum of the costs of all the
 * k bags.
 * 
 * Return the difference between the maximum and minimum scores among marble
 * distributions.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: weights = [1,3,5,1], k = 2
 * Output: 4
 * Explanation: 
 * The distribution [1],[3,5,1] results in the minimal score of (1+1) + (3+1) =
 * 6. 
 * The distribution [1,3],[5,1], results in the maximal score of (1+3) + (5+1)
 * = 10. 
 * Thus, we return their difference 10 - 6 = 4.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: weights = [1, 3], k = 2
 * Output: 0
 * Explanation: The only distribution possible is [1],[3]. 
 * Since both the maximal and minimal score are the same, we return 0.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= k <= weights.length <= 10^5
 * 1 <= weights[i] <= 10^9
 * 
 * 
 */
/*
 * Sorting Approach (Greedy)
 * Time: O(n log n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    // consider the min score: which is weights[0] + (k - 1) min pair of boundary + weights[n - 1]
    // consider the max score: which is weights[0] + (k - 1) max pair of boundary + weights[n - 1]
    // ans = max - min = (k - 1) max pair of boundary - (k - 1) min pair of boundary
    public long PutMarbles(int[] weights, int k)
    {
        int n = weights.Length;
        // find all the pair weight, each pair will be possible boundary
        long[] pairWeights = new long[n - 1];
        for (int i = 1; i < n; i++)
        {
            pairWeights[i - 1] = weights[i - 1] + weights[i];
        }

        // sort the pair weights
        Array.Sort(pairWeights);
        // compute the max - min
        long ans = 0;
        for (int i = 0; i < k - 1; i++)
        {
            ans += pairWeights[n - 2 - i] - pairWeights[i];
        }
        return ans;
    }
}
// @lc code=end

