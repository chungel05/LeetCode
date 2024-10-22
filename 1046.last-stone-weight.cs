/*
 * @lc app=leetcode id=1046 lang=csharp
 *
 * [1046] Last Stone Weight
 *
 * https://leetcode.com/problems/last-stone-weight/description/
 *
 * algorithms
 * Easy (65.64%)
 * Likes:    6105
 * Dislikes: 133
 * Total Accepted:    680.2K
 * Total Submissions: 1M
 * Testcase Example:  '[2,7,4,1,8,1]'
 *
 * You are given an array of integers stones where stones[i] is the weight of
 * the i^th stone.
 * 
 * We are playing a game with the stones. On each turn, we choose the heaviest
 * two stones and smash them together. Suppose the heaviest two stones have
 * weights x and y with x <= y. The result of this smash is:
 * 
 * 
 * If x == y, both stones are destroyed, and
 * If x != y, the stone of weight x is destroyed, and the stone of weight y has
 * new weight y - x.
 * 
 * 
 * At the end of the game, there is at most one stone left.
 * 
 * Return the weight of the last remaining stone. If there are no stones left,
 * return 0.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: stones = [2,7,4,1,8,1]
 * Output: 1
 * Explanation: 
 * We combine 7 and 8 to get 1 so the array converts to [2,4,1,1,1] then,
 * we combine 2 and 4 to get 2 so the array converts to [2,1,1,1] then,
 * we combine 2 and 1 to get 1 so the array converts to [1,1,1] then,
 * we combine 1 and 1 to get 0 so the array converts to [1] then that's the
 * value of the last stone.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: stones = [1]
 * Output: 1
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= stones.length <= 30
 * 1 <= stones[i] <= 1000
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        for (int i = 0; i < stones.Length; i++)
        {
            maxHeap.Enqueue(stones[i], -stones[i]);
        }

        while (maxHeap.Count > 1)
        {
            int first = maxHeap.Dequeue();
            int second = maxHeap.Dequeue();
            maxHeap.Enqueue(first - second, -(first - second));
        }

        return maxHeap.Dequeue();
    }
}
// @lc code=end

