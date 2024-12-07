/*
 * @lc app=leetcode id=752 lang=csharp
 *
 * [752] Open the Lock
 *
 * https://leetcode.com/problems/open-the-lock/description/
 *
 * algorithms
 * Medium (60.41%)
 * Likes:    4841
 * Dislikes: 222
 * Total Accepted:    338.1K
 * Total Submissions: 559.2K
 * Testcase Example:  '["0201","0101","0102","1212","2002"]\n"0202"'
 *
 * You have a lock in front of you with 4 circular wheels. Each wheel has 10
 * slots: '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'. The wheels can
 * rotate freely and wrap around: for example we can turn '9' to be '0', or '0'
 * to be '9'. Each move consists of turning one wheel one slot.
 * 
 * The lock initially starts at '0000', a string representing the state of the
 * 4 wheels.
 * 
 * You are given a list of deadends dead ends, meaning if the lock displays any
 * of these codes, the wheels of the lock will stop turning and you will be
 * unable to open it.
 * 
 * Given a target representing the value of the wheels that will unlock the
 * lock, return the minimum total number of turns required to open the lock, or
 * -1 if it is impossible.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: deadends = ["0201","0101","0102","1212","2002"], target = "0202"
 * Output: 6
 * Explanation: 
 * A sequence of valid moves would be "0000" -> "1000" -> "1100" -> "1200" ->
 * "1201" -> "1202" -> "0202".
 * Note that a sequence like "0000" -> "0001" -> "0002" -> "0102" -> "0202"
 * would be invalid,
 * because the wheels of the lock become stuck after the display becomes the
 * dead end "0102".
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: deadends = ["8888"], target = "0009"
 * Output: 1
 * Explanation: We can turn the last wheel in reverse to move from "0000" ->
 * "0009".
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: deadends = ["8887","8889","8878","8898","8788","8988","7888","9888"],
 * target = "8888"
 * Output: -1
 * Explanation: We cannot reach the target without getting stuck.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= deadends.length <= 500
 * deadends[i].length == 4
 * target.length == 4
 * target will not be in the list deadends.
 * target and deadends[i] consist of digits only.
 * 
 * 
 */

// @lc code=start
public partial class Solution
{
    public int OpenLock(string[] deadends, string target)
    {
        // Convert string[] to HashSet for better search performance
        HashSet<string> deadendSet = new HashSet<string>(deadends);
        HashSet<string> visited = new HashSet<string>();
        Queue<string> q = new Queue<string>();

        int count = 0;
        // edge case: deadends contains start combination "0000", we will not process
        if (!deadendSet.Contains("0000"))
        {
            q.Enqueue("0000");
            visited.Add("0000");
        }

        while (q.Count > 0)
        {
            for (int i = q.Count; i > 0; i--)
            {
                string curr = q.Dequeue();

                // if we found the target, return the current level; "0000" is level 0
                if (curr == target)
                    return count;

                // create combination, there are 4 digits, 8 cases
                char[] chs = curr.ToCharArray();
                for (int j = 0; j < 4; j++)
                {
                    char old = chs[j];

                    // digit + 1 case
                    chs[j] = old == '9' ? '0' : (char)(old + 1);
                    string newNum = new string(chs);
                    if (!deadendSet.Contains(newNum) && !visited.Contains(newNum))
                    {
                        q.Enqueue(newNum);
                        visited.Add(newNum);
                    }

                    // digit - 1 case
                    chs[j] = old == '0' ? '9' : (char)(old - 1);
                    newNum = new string(chs);
                    if (!deadendSet.Contains(newNum) && !visited.Contains(newNum))
                    {
                        q.Enqueue(newNum);
                        visited.Add(newNum);
                    }

                    // reset to old char
                    chs[j] = old;
                }
            }
            count++;
        }

        return -1;
    }
}
// @lc code=end

