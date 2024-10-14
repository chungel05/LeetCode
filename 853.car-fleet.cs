/*
 * @lc app=leetcode id=853 lang=csharp
 *
 * [853] Car Fleet
 *
 * https://leetcode.com/problems/car-fleet/description/
 *
 * algorithms
 * Medium (52.06%)
 * Likes:    3653
 * Dislikes: 1026
 * Total Accepted:    305.2K
 * Total Submissions: 585.8K
 * Testcase Example:  '12\n[10,8,0,5,3]\n[2,4,1,1,3]'
 *
 * There are n cars at given miles away from the starting mile 0, traveling to
 * reach the mile target.
 * 
 * You are given two integer array position and speed, both of length n, where
 * position[i] is the starting mile of the i^th car and speed[i] is the speed
 * of the i^th car in miles per hour.
 * 
 * A car cannot pass another car, but it can catch up and then travel next to
 * it at the speed of the slower car.
 * 
 * A car fleet is a car or cars driving next to each other. The speed of the
 * car fleet is the minimum speed of any car in the fleet.
 * 
 * If a car catches up to a car fleet at the mile target, it will still be
 * considered as part of the car fleet.
 * 
 * Return the number of car fleets that will arrive at the destination.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: target = 12, position = [10,8,0,5,3], speed = [2,4,1,1,3]
 * 
 * Output: 3
 * 
 * Explanation:
 * 
 * 
 * The cars starting at 10 (speed 2) and 8 (speed 4) become a fleet, meeting
 * each other at 12. The fleet forms at target.
 * The car starting at 0 (speed 1) does not catch up to any other car, so it is
 * a fleet by itself.
 * The cars starting at 5 (speed 1) and 3 (speed 3) become a fleet, meeting
 * each other at 6. The fleet moves at speed 1 until it reaches target.
 * 
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: target = 10, position = [3], speed = [3]
 * 
 * Output: 1
 * 
 * Explanation:
 * There is only one car, hence there is only one fleet.
 * 
 * Example 3:
 * 
 * 
 * Input: target = 100, position = [0,2,4], speed = [4,2,1]
 * 
 * Output: 1
 * 
 * Explanation:
 * 
 * 
 * The cars starting at 0 (speed 4) and 2 (speed 2) become a fleet, meeting
 * each other at 4. The car starting at 4 (speed 1) travels to 5.
 * Then, the fleet at 4 (speed 2) and the car at position 5 (speed 1) become
 * one fleet, meeting each other at 6. The fleet moves at speed 1 until it
 * reaches target.
 * 
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * n == position.length == speed.length
 * 1 <= n <= 10^5
 * 0 < target <= 10^6
 * 0 <= position[i] < target
 * All the values of position are unique.
 * 0 < speed[i] <= 10^6
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        double[][] pairs = new double[position.Length][];

        for (int i = 0; i < position.Length; i++)
        {
            pairs[i] = new double[] { position[i], (double)(target - position[i]) / speed[i] };
        }

        Array.Sort(pairs, (a, b) => b[0].CompareTo(a[0]));
        int count = 1;

        for (int i = 1; i < pairs.Length; i++)
        {
            if (pairs[i][1] <= pairs[i - 1][1])
                pairs[i][1] = pairs[i - 1][1];
            else
                count++;
        }
        return count;
    }
}
// @lc code=end

