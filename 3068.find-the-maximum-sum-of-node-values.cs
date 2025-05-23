/*
 * @lc app=leetcode id=3068 lang=csharp
 *
 * [3068] Find the Maximum Sum of Node Values
 *
 * https://leetcode.com/problems/find-the-maximum-sum-of-node-values/description/
 *
 * algorithms
 * Hard (66.66%)
 * Likes:    693
 * Dislikes: 99
 * Total Accepted:    82.5K
 * Total Submissions: 124.2K
 * Testcase Example:  '[1,2,1]\n3\n[[0,1],[0,2]]'
 *
 * There exists an undirected tree with n nodes numbered 0 to n - 1. You are
 * given a 0-indexed 2D integer array edges of length n - 1, where edges[i] =
 * [ui, vi] indicates that there is an edge between nodes ui and vi in the
 * tree. You are also given a positive integer k, and a 0-indexed array of
 * non-negative integers nums of length n, where nums[i] represents the value
 * of the node numbered i.
 * 
 * Alice wants the sum of values of tree nodes to be maximum, for which Alice
 * can perform the following operation any number of times (including zero) on
 * the tree:
 * 
 * 
 * Choose any edge [u, v] connecting the nodes u and v, and update their values
 * as follows:
 * 
 * 
 * nums[u] = nums[u] XOR k
 * nums[v] = nums[v] XOR k
 * 
 * 
 * 
 * 
 * Return the maximum possible sum of the values Alice can achieve by
 * performing the operation any number of times.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [1,2,1], k = 3, edges = [[0,1],[0,2]]
 * Output: 6
 * Explanation: Alice can achieve the maximum sum of 6 using a single
 * operation:
 * - Choose the edge [0,2]. nums[0] and nums[2] become: 1 XOR 3 = 2, and the
 * array nums becomes: [1,2,1] -> [2,2,2].
 * The total sum of values is 2 + 2 + 2 = 6.
 * It can be shown that 6 is the maximum achievable sum of values.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [2,3], k = 7, edges = [[0,1]]
 * Output: 9
 * Explanation: Alice can achieve the maximum sum of 9 using a single
 * operation:
 * - Choose the edge [0,1]. nums[0] becomes: 2 XOR 7 = 5 and nums[1] become: 3
 * XOR 7 = 4, and the array nums becomes: [2,3] -> [5,4].
 * The total sum of values is 5 + 4 = 9.
 * It can be shown that 9 is the maximum achievable sum of values.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: nums = [7,7,7,7,7,7], k = 3, edges = [[0,1],[0,2],[0,3],[0,4],[0,5]]
 * Output: 42
 * Explanation: The maximum achievable sum is 42 which can be achieved by Alice
 * performing no operations.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= n == nums.length <= 2 * 10^4
 * 1 <= k <= 10^9
 * 0 <= nums[i] <= 10^9
 * edges.length == n - 1
 * edges[i].length == 2
 * 0 <= edges[i][0], edges[i][1] <= n - 1
 * The input is generated such that edges represent a valid tree.
 * 
 * 
 */
/*
 * DP Bottom-up Approach
 * Time: O(n), Space: O(2n) => O(n)
 */

// @lc code=start
public partial class Solution
{
    // for every pair [u, v], it can be fliped no matter what is the nodes between
    // and after a chain of operation, the no. of nodes fliped must be even
    // i.e. 1 - 0 - 2, no matter how we flip, only 2 of them can be fliped
    // i.e. 3 - 1 - 0 - 2, we can flip 2 or 4 or no flip (no matter flip [0, 1] or [2, 3])
    // so, Odd operation is middle stage which is invalid, only even operation is valid
    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        // dp with 2 state, even = 1 or odd = 0
        long[][] dp = new long[nums.Length + 1][];
        for (int i = 0; i <= nums.Length; i++)
        {
            dp[i] = new long[2];
            Array.Fill(dp[i], -1);
        }

        // base case: even = 0, odd = invalid = minValue
        dp[nums.Length][1] = 0;
        dp[nums.Length][0] = Int32.MinValue;

        // loop from the end to 0
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            // for each state
            for (int isEven = 0; isEven <= 1; isEven++)
            {
                // 2 cases:
                // 1: no flip = nums[i] + dp[i + 1] with same state
                // 2: flip = (nums[i] ^ k) + dp[i + 1] with different state because once we flip, the prev node will also flip
                long noflip = nums[i] + dp[i + 1][isEven];
                long flip = (nums[i] ^ k) + dp[i + 1][isEven ^ 1];
                // get the max sum
                dp[i][isEven] = Math.Max(noflip, flip);
            }
        }

        // ans is dp[0] with even operation which is valid state
        return dp[0][1];
    }

    // DP Top-down Approach
    // Time: O(n), Space: O(2n) => O(n)
    /* private long DFSMaximumValueSum(int[] nums, int k, int i, int isEven, long[][] dp)
    {
        if (i == nums.Length)
            return isEven == 1 ? 0 : Int32.MinValue;

        if (dp[i][isEven] != -1)
            return dp[i][isEven];

        long noflip = nums[i] + DFSMaximumValueSum(nums, k, i + 1, isEven, dp);
        long flip = (nums[i] ^ k) + DFSMaximumValueSum(nums, k, i + 1, isEven ^ 1, dp);
        return dp[i][isEven] = Math.Max(noflip, flip);
    }

    public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        long[][] dp = new long[nums.Length][];
        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = new long[2];
            Array.Fill(dp[i], -1);
        }

        return DFSMaximumValueSum(nums, k, 0, 1, dp);
    } */

    // Greedy Approach
    // Time: O(n), Space: O(1)
    /* public long MaximumValueSum(int[] nums, int k, int[][] edges)
    {
        long sum = 0;
        int flipCount = 0, minPos = Int32.MaxValue, maxNeg = Int32.MinValue;

        // Pair the delta
        for (int i = 0; i < nums.Length; i++)
        {
            int delta = (nums[i] ^ k) - nums[i];
            sum += nums[i];

            if (delta > 0)
            {
                sum += delta;
                flipCount++;
                minPos = Math.Min(minPos, delta);
            }
            else
            {
                maxNeg = Math.Max(maxNeg, delta);
            }
        }

        // if pair is even, then it is ans
        if ((flipCount & 1) == 0)
            return sum;

        // otherwise, it need to sum - minPos if minPos + maxNeg <= 0
        // or sum + maxNeg if minPos + maxNeg > 0
        return Math.Max(sum - minPos, sum + maxNeg);
    } */
}
// @lc code=end

