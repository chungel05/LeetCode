/*
 * @lc app=leetcode id=2818 lang=csharp
 *
 * [2818] Apply Operations to Maximize Score
 *
 * https://leetcode.com/problems/apply-operations-to-maximize-score/description/
 *
 * algorithms
 * Hard (32.78%)
 * Likes:    346
 * Dislikes: 21
 * Total Accepted:    8.9K
 * Total Submissions: 26.3K
 * Testcase Example:  '[8,3,9,3,8]\n2'
 *
 * You are given an array nums of n positive integers and an integer k.
 * 
 * Initially, you start with a score of 1. You have to maximize your score by
 * applying the following operation at most k times:
 * 
 * 
 * Choose any non-empty subarray nums[l, ..., r] that you haven't chosen
 * previously.
 * Choose an element x of nums[l, ..., r] with the highest prime score. If
 * multiple such elements exist, choose the one with the smallest index.
 * Multiply your score by x.
 * 
 * 
 * Here, nums[l, ..., r] denotes the subarray of nums starting at index l and
 * ending at the index r, both ends being inclusive.
 * 
 * The prime score of an integer x is equal to the number of distinct prime
 * factors of x. For example, the prime score of 300 is 3 since 300 = 2 * 2 * 3
 * * 5 * 5.
 * 
 * Return the maximum possible score after applying at most k operations.
 * 
 * Since the answer may be large, return it modulo 10^9 + 7.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: nums = [8,3,9,3,8], k = 2
 * Output: 81
 * Explanation: To get a score of 81, we can apply the following operations:
 * - Choose subarray nums[2, ..., 2]. nums[2] is the only element in this
 * subarray. Hence, we multiply the score by nums[2]. The score becomes 1 * 9 =
 * 9.
 * - Choose subarray nums[2, ..., 3]. Both nums[2] and nums[3] have a prime
 * score of 1, but nums[2] has the smaller index. Hence, we multiply the score
 * by nums[2]. The score becomes 9 * 9 = 81.
 * It can be proven that 81 is the highest score one can obtain.
 * 
 * Example 2:
 * 
 * 
 * Input: nums = [19,12,14,6,10,18], k = 3
 * Output: 4788
 * Explanation: To get a score of 4788, we can apply the following operations: 
 * - Choose subarray nums[0, ..., 0]. nums[0] is the only element in this
 * subarray. Hence, we multiply the score by nums[0]. The score becomes 1 * 19
 * = 19.
 * - Choose subarray nums[5, ..., 5]. nums[5] is the only element in this
 * subarray. Hence, we multiply the score by nums[5]. The score becomes 19 * 18
 * = 342.
 * - Choose subarray nums[2, ..., 3]. Both nums[2] and nums[3] have a prime
 * score of 2, but nums[2] has the smaller index. Hence, we multipy the score
 * by nums[2]. The score becomes 342 * 14 = 4788.
 * It can be proven that 4788 is the highest score one can obtain.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= nums.length == n <= 10^5
 * 1 <= nums[i] <= 10^5
 * 1 <= k <= min(n * (n + 1) / 2, 10^9)
 * 
 * 
 */
/*
 * Stack Approach
 * Time: O(m log m + n log n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    private int MOD = 1_000_000_007;

    // get all prime score using Sieve of Eratosthenes
    // Time: O(m log m)
    private int[] GetPrimeScoreForMaximumScore(int max)
    {
        int[] primeScore = new int[max + 1];

        for (int i = 2; i <= max; i++)
        {
            if (primeScore[i] != 0)
                continue;

            for (int j = i; j <= max; j += i)
                primeScore[j]++;
        }
        return primeScore;
    }

    private long pow(long x, long n)
    {
        long res = 1;
        while (n > 0)
        {
            if (n % 2 == 1)
            {
                res = res * x % MOD;
            }
            x = x * x % MOD;
            n /= 2;
        }
        return res;
    }

    public int MaximumScore(IList<int> nums, int k)
    {
        int n = nums.Count;
        int max = nums.Max();
        int[] numsArray = nums.ToArray();

        // get all prime score
        int[] primeScore = GetPrimeScoreForMaximumScore(max);

        // find the left dominant and right dominant
        int[] nextDominant = new int[n];
        int[] prevDominant = new int[n];
        Array.Fill(nextDominant, n);
        Array.Fill(prevDominant, -1);

        Stack<(int s, int idx)> stack = new Stack<(int s, int idx)>();

        for (int i = 0; i < n; i++)
        {
            int score = primeScore[nums[i]];
            while (stack.Count > 0 && stack.Peek().s < score)
            {
                int topIndex = stack.Pop().idx;
                nextDominant[topIndex] = i;
            }

            if (stack.Count > 0)
            {
                prevDominant[i] = stack.Peek().idx;
            }

            stack.Push((score, i));
        }

        // construct possible subarray
        long[] numOfSubarrays = new long[n];
        for (int i = 0; i < n; i++)
        {
            numOfSubarrays[i] = (long)(i - prevDominant[i]) * (nextDominant[i] - i);
        }

        // sort numsArray and numOfSubarrays in decreasing order according to numsArray[i]
        Array.Sort(numsArray, numOfSubarrays, Comparer<int>.Create((a, b) => b - a));

        long ans = 1;
        int processingIndex = 0;

        // compute the k most largest nums
        while (k > 0)
        {
            long operations = Math.Min(k, numOfSubarrays[processingIndex]);

            ans = (ans * pow(numsArray[processingIndex], operations)) % MOD;

            processingIndex++;
            k -= (int)operations;
        }

        return (int)ans;
    }
}
// @lc code=end

