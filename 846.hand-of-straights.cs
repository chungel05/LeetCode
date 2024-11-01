/*
 * @lc app=leetcode id=846 lang=csharp
 *
 * [846] Hand of Straights
 *
 * https://leetcode.com/problems/hand-of-straights/description/
 *
 * algorithms
 * Medium (56.79%)
 * Likes:    3334
 * Dislikes: 259
 * Total Accepted:    330.7K
 * Total Submissions: 582.3K
 * Testcase Example:  '[1,2,3,6,2,3,4,7,8]\n3'
 *
 * Alice has some number of cards and she wants to rearrange the cards into
 * groups so that each group is of size groupSize, and consists of groupSize
 * consecutive cards.
 * 
 * Given an integer array hand where hand[i] is the value written on the i^th
 * card and an integer groupSize, return true if she can rearrange the cards,
 * or false otherwise.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: hand = [1,2,3,6,2,3,4,7,8], groupSize = 3
 * Output: true
 * Explanation: Alice's hand can be rearranged as [1,2,3],[2,3,4],[6,7,8]
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: hand = [1,2,3,4,5], groupSize = 4
 * Output: false
 * Explanation: Alice's hand can not be rearranged into groups of 4.
 * 
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= hand.length <= 10^4
 * 0 <= hand[i] <= 10^9
 * 1 <= groupSize <= hand.length
 * 
 * 
 * 
 * Note: This question is the same as 1296:
 * https://leetcode.com/problems/divide-array-in-sets-of-k-consecutive-numbers/
 * 
 */

// @lc code=start
using System.Diagnostics.Tracing;

public partial class Solution
{
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        if (hand.Length % groupSize != 0)
            return false;

        Dictionary<int, int> count = new Dictionary<int, int>();
        for (int i = 0; i < hand.Length; i++)
        {
            if (!count.ContainsKey(hand[i]))
                count.Add(hand[i], 0);
            count[hand[i]]++;
        }

        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
        foreach (var num in count)
        {
            minHeap.Enqueue(num.Key, num.Key);
        }

        while (minHeap.Count > 0)
        {
            int currNum = minHeap.Peek();
            for (int i = currNum; i < currNum + groupSize; i++)
            {
                if (!count.ContainsKey(i) || count[i] == 0)
                    return false;

                count[i]--;
                if (count[i] == 0)
                {
                    if (i != minHeap.Peek())
                        return false;
                    minHeap.Dequeue();
                }
            }
        }
        return true;
    }
}
// @lc code=end

