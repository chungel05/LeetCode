/*
 * @lc app=leetcode id=781 lang=csharp
 *
 * [781] Rabbits in Forest
 *
 * https://leetcode.com/problems/rabbits-in-forest/description/
 *
 * algorithms
 * Medium (52.95%)
 * Likes:    1508
 * Dislikes: 717
 * Total Accepted:    78.7K
 * Total Submissions: 146.4K
 * Testcase Example:  '[1,1,2]'
 *
 * There is a forest with an unknown number of rabbits. We asked n rabbits "How
 * many rabbits have the same color as you?" and collected the answers in an
 * integer array answers where answers[i] is the answer of the i^th rabbit.
 * 
 * Given the array answers, return the minimum number of rabbits that could be
 * in the forest.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: answers = [1,1,2]
 * Output: 5
 * Explanation:
 * The two rabbits that answered "1" could both be the same color, say red.
 * The rabbit that answered "2" can't be red or the answers would be
 * inconsistent.
 * Say the rabbit that answered "2" was blue.
 * Then there should be 2 other blue rabbits in the forest that didn't answer
 * into the array.
 * The smallest possible number of rabbits in the forest is therefore 5: 3 that
 * answered plus 2 that didn't.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: answers = [10,10,10]
 * Output: 11
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= answers.length <= 1000
 * 0 <= answers[i] < 1000
 * 
 * 
 */
/*
 * Hash Table Approach
 * Time: O(n), Space: O(n)
 */

// @lc code=start
public partial class Solution
{
    public int NumRabbits(int[] answers)
    {
        // dictionary to count the occurrences
        Dictionary<int, int> dict = new Dictionary<int, int>();
        int res = 0;
        for (int i = 0; i < answers.Length; i++)
        {
            // if answers[i] == 0, it means only 1 rabbit
            if (answers[i] == 0)
                res += 1;
            else
            {
                // if answers[i] does not exist in dict, so it is new seq
                // if dict[answers[i]] == answers[i], it pair with correct rabbits, so start another new seq
                if (!dict.ContainsKey(answers[i]) || dict[answers[i]] == answers[i])
                {
                    // everytime start new seq, add answers[i] + 1 to result
                    res += answers[i] + 1;
                    // reset the pair count
                    dict[answers[i]] = 0;
                }
                // increment the pair count
                else
                    dict[answers[i]]++;
            }
        }
        return res;
    }

    // Sorting Approach
    // Time: O(n log n), Space: O(n)
    /* public int NumRabbits(int[] answers)
    {
        Array.Sort(answers);
        int pair = 0;
        int res = 0;
        for (int i = 0; i < answers.Length; i++)
        {
            if (i > 0 && answers[i] != answers[i - 1] || pair == 0)
            {
                res += answers[i] + 1;
                pair = answers[i];
            }
            else
            {
                pair--;
            }
        }
        return res;
    } */
}
// @lc code=end

