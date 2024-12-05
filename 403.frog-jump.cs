/*
 * @lc app=leetcode id=403 lang=csharp
 *
 * [403] Frog Jump
 *
 * https://leetcode.com/problems/frog-jump/description/
 *
 * algorithms
 * Hard (46.23%)
 * Likes:    5653
 * Dislikes: 257
 * Total Accepted:    282.8K
 * Total Submissions: 610.9K
 * Testcase Example:  '[0,1,3,5,6,8,12,17]'
 *
 * A frog is crossing a river. The river is divided into some number of units,
 * and at each unit, there may or may not exist a stone. The frog can jump on a
 * stone, but it must not jump into the water.
 * 
 * Given a list of stones positions (in units) in sorted ascending order,
 * determine if the frog can cross the river by landing on the last stone.
 * Initially, the frog is on the first stone and assumes the first jump must be
 * 1 unit.
 * 
 * If the frog's last jump was k units, its next jump must be either k - 1, k,
 * or k + 1 units. The frog can only jump in the forward direction.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: stones = [0,1,3,5,6,8,12,17]
 * Output: true
 * Explanation: The frog can jump to the last stone by jumping 1 unit to the
 * 2nd stone, then 2 units to the 3rd stone, then 2 units to the 4th stone,
 * then 3 units to the 6th stone, 4 units to the 7th stone, and 5 units to the
 * 8th stone.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: stones = [0,1,2,3,4,8,9,11]
 * Output: false
 * Explanation: There is no way to jump to the last stone as the gap between
 * the 5th and 6th stone is too large.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 2 <= stones.length <= 2000
 * 0 <= stones[i] <= 2^31 - 1
 * stones[0] == 0
 * stones is sorted in a strictly increasing order.
 * 
 * 
 */
/*
 * DFS top down approach with caching
 * Time: O(n * n), Space: O(n * n) because currPos and steps = n stone position value
 */

// @lc code=start
public partial class Solution
{
    private bool DFSCanCross(HashSet<int> position, int goal, int currPos, int steps, Dictionary<(int, int), bool> dp)
    {
        // if curr position == goal, frog pass through the river
        if (currPos == goal)
            return true;

        if (dp.ContainsKey((currPos, steps)))
            return dp[(currPos, steps)];

        dp[(currPos, steps)] = false;
        // from steps - 1 to steps + 1
        for (int j = steps - 1; j <= steps + 1; j++)
        {
            // steps <= 0 is meaningless
            if (j > 0)
            {
                int nextPos = currPos + j;
                // if next stone position exists, we continue the DFS
                if (position.Contains(nextPos) && DFSCanCross(position, goal, nextPos, j, dp))
                {
                    dp[(currPos, steps)] = true;
                    return true;
                }
            }
        }

        // if 3 of the steps are failed, we go back to prev loop
        return false;
    }

    public bool CanCross(int[] stones)
    {
        // convert stones array to hashset for better search performance
        HashSet<int> position = new HashSet<int>(stones);
        // cache to store [position, steps] value
        Dictionary<(int, int), bool> dp = new Dictionary<(int, int), bool>();
        // Goal = last stone position
        int goal = stones[stones.Length - 1];

        // start from 0 position 0 step
        return DFSCanCross(position, goal, 0, 0, dp);
    }
}
// @lc code=end

