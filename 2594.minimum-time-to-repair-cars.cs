/*
 * @lc app=leetcode id=2594 lang=csharp
 *
 * [2594] Minimum Time to Repair Cars
 *
 * https://leetcode.com/problems/minimum-time-to-repair-cars/description/
 *
 * algorithms
 * Medium (45.41%)
 * Likes:    798
 * Dislikes: 48
 * Total Accepted:    45.4K
 * Total Submissions: 83.7K
 * Testcase Example:  '[4,2,3,1]\n10'
 *
 * You are given an integer array ranks representing the ranks of some
 * mechanics. ranksi is the rank of the i^th mechanic. A mechanic with a rank r
 * can repair n cars in r * n^2 minutes.
 * 
 * You are also given an integer cars representing the total number of cars
 * waiting in the garage to be repaired.
 * 
 * Return the minimum time taken to repair all the cars.
 * 
 * Note: All the mechanics can repair the cars simultaneously.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: ranks = [4,2,3,1], cars = 10
 * Output: 16
 * Explanation: 
 * - The first mechanic will repair two cars. The time required is 4 * 2 * 2 =
 * 16 minutes.
 * - The second mechanic will repair two cars. The time required is 2 * 2 * 2 =
 * 8 minutes.
 * - The third mechanic will repair two cars. The time required is 3 * 2 * 2 =
 * 12 minutes.
 * - The fourth mechanic will repair four cars. The time required is 1 * 4 * 4
 * = 16 minutes.
 * It can be proved that the cars cannot be repaired in less than 16
 * minutes.​​​​​
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: ranks = [5,1,8], cars = 6
 * Output: 16
 * Explanation: 
 * - The first mechanic will repair one car. The time required is 5 * 1 * 1 = 5
 * minutes.
 * - The second mechanic will repair four cars. The time required is 1 * 4 * 4
 * = 16 minutes.
 * - The third mechanic will repair one car. The time required is 8 * 1 * 1 = 8
 * minutes.
 * It can be proved that the cars cannot be repaired in less than 16
 * minutes.​​​​​
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= ranks.length <= 10^5
 * 1 <= ranks[i] <= 100
 * 1 <= cars <= 10^6
 * 
 * 
 */
/*
 * Binary Search Approach
 * Time: O(m log(r * n * n)) where m is no. of rank, r is min rank, n is no. of car
 * Space: O(1)
 */

// @lc code=start
public partial class Solution
{
    public long RepairCars(int[] ranks, int cars)
    {
        // find the min rank
        int min = Int32.MaxValue;
        for (int i = 0; i < ranks.Length; i++)
            min = Math.Min(min, ranks[i]);

        // min time: 1, max time: min rank(r) * cars * cars
        long left = 1, right = (long)min * cars * cars;
        // Binary Search to find the possible min time
        while (left < right)
        {
            long mid = (left + right) / 2;
            int k = 0;
            // check the possible repaired cars k
            for (int i = 0; i < ranks.Length; i++)
            {
                // by formula: time = r * k * k => k = sqrt(time / r)
                k += (int)Math.Sqrt(mid / ranks[i]);
                if (k >= cars)
                    break;
            }
            // if mid is possible time, move right to mid
            if (k >= cars)
                right = mid;
            // otherwise move left to mid + 1
            else
                left = mid + 1;
        }
        return left;
    }
}
// @lc code=end

