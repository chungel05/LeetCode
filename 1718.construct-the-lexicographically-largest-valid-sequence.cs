/*
 * @lc app=leetcode id=1718 lang=csharp
 *
 * [1718] Construct the Lexicographically Largest Valid Sequence
 *
 * https://leetcode.com/problems/construct-the-lexicographically-largest-valid-sequence/description/
 *
 * algorithms
 * Medium (54.32%)
 * Likes:    590
 * Dislikes: 57
 * Total Accepted:    15.9K
 * Total Submissions: 29K
 * Testcase Example:  '3'
 *
 * Given an integer n, find a sequence that satisfies all of the
 * following:
 * 
 * 
 * The integer 1 occurs once in the sequence.
 * Each integer between 2 and n occurs twice in the sequence.
 * For every integer i between 2 and n, the distance between the two
 * occurrences of i is exactly i.
 * 
 * 
 * The distance between two numbers on the sequence, a[i] and a[j], is the
 * absolute difference of their indices, |j - i|.
 * 
 * Return the lexicographically largest sequence. It is guaranteed that under
 * the given constraints, there is always a solution. 
 * 
 * A sequence a is lexicographically larger than a sequence b (of the same
 * length) if in the first position where a and b differ, sequence a has a
 * number greater than the corresponding number in b. For example, [0,1,9,0] is
 * lexicographically larger than [0,1,5,6] because the first position they
 * differ is at the third number, and 9 is greater than 5.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: n = 3
 * Output: [3,1,2,3,2]
 * Explanation: [2,3,2,1,3] is also a valid sequence, but [3,1,2,3,2] is the
 * lexicographically largest valid sequence.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: n = 5
 * Output: [5,3,1,4,3,5,2,4,2]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= n <= 20
 * 
 * 
 */
/*
 * DFS Approach
 * Time: O(n!), Space: O(2n - 1) => O(n)
 */

// @lc code=start
public partial class Solution
{
    // start index i from 0 to end of seq
    // for each index i, try to input num from n to 1,
    // if it fails the condition, return false
    // otherwise, it is the ans
    private bool DFSConstructDistancedSequence(int n, int[] currSeq, int i, bool[] used)
    {
        // base case: i at the end of seq, all nums already placed at seq, return true
        if (i == currSeq.Length)
            return true;

        // if index i already had num, move to next index
        if (currSeq[i] != 0)
            return DFSConstructDistancedSequence(n, currSeq, i + 1, used);

        // try to input num from n to 1 into currSeq[i]
        for (int j = n; j > 0; j--)
        {
            // if j is used, continue to next num
            if (used[j])
                continue;

            int dist = j == 1 ? 0 : j;

            // if it is out of range or value exists in currSeq, try next num
            if (i + dist >= currSeq.Length || currSeq[i + dist] != 0)
                continue;

            // mark as used and input num
            used[j] = true;
            currSeq[i] = j;
            currSeq[i + dist] = j;

            // check for correctness of current choice
            if (DFSConstructDistancedSequence(n, currSeq, i + 1, used))
                return true;

            // if it fails condition, reset the seq and try next num
            used[j] = false;
            currSeq[i] = 0;
            currSeq[i + dist] = 0;
        }
        // if all the nums cannot fit into index i, return false to indicate that it fails condition
        return false;
    }


    public int[] ConstructDistancedSequence(int n)
    {
        // initialized used array and ans array
        bool[] used = new bool[n + 1];
        int[] ans = new int[2 * n - 1];
        DFSConstructDistancedSequence(n, ans, 0, used);

        return ans;
    }
}
// @lc code=end

