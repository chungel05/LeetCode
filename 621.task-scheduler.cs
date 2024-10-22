/*
 * @lc app=leetcode id=621 lang=csharp
 *
 * [621] Task Scheduler
 *
 * https://leetcode.com/problems/task-scheduler/description/
 *
 * algorithms
 * Medium (60.43%)
 * Likes:    10669
 * Dislikes: 2098
 * Total Accepted:    691.4K
 * Total Submissions: 1.1M
 * Testcase Example:  '["A","A","A","B","B","B"]\n2'
 *
 * You are given an array of CPU tasks, each labeled with a letter from A to Z,
 * and a number n. Each CPU interval can be idle or allow the completion of one
 * task. Tasks can be completed in any order, but there's a constraint: there
 * has to be a gap of at least n intervals between two tasks with the same
 * label.
 * 
 * Return the minimum number of CPU intervals required to complete all
 * tasks.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: tasks = ["A","A","A","B","B","B"], n = 2
 * 
 * Output: 8
 * 
 * Explanation: A possible sequence is: A -> B -> idle -> A -> B -> idle -> A
 * -> B.
 * 
 * After completing task A, you must wait two intervals before doing A again.
 * The same applies to task B. In the 3^rd interval, neither A nor B can be
 * done, so you idle. By the 4^th interval, you can do A again as 2 intervals
 * have passed.
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: tasks = ["A","C","A","B","D","B"], n = 1
 * 
 * Output: 6
 * 
 * Explanation: A possible sequence is: A -> B -> C -> D -> A -> B.
 * 
 * With a cooling interval of 1, you can repeat a task after just one other
 * task.
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: tasks = ["A","A","A", "B","B","B"], n = 3
 * 
 * Output: 10
 * 
 * Explanation: A possible sequence is: A -> B -> idle -> idle -> A -> B ->
 * idle -> idle -> A -> B.
 * 
 * There are only two types of tasks, A and B, which need to be separated by 3
 * intervals. This leads to idling twice between repetitions of these
 * tasks.
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= tasks.length <= 10^4
 * tasks[i] is an uppercase English letter.
 * 0 <= n <= 100
 * 
 * 
 */

// @lc code=start
using System.Diagnostics;

public partial class Solution
{
    public int LeastInterval(char[] tasks, int n)
    {
        Dictionary<char, int> occurrence = new Dictionary<char, int>();
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        for (int i = 0; i < tasks.Length; i++)
        {
            if (!occurrence.ContainsKey(tasks[i]))
                occurrence[tasks[i]] = 0;
            occurrence[tasks[i]]++;
        }

        foreach (var tmp in occurrence)
            maxHeap.Enqueue(tmp.Value, -tmp.Value);

        int time = 0;
        Queue<int[]> q = new Queue<int[]>();
        while (maxHeap.Count > 0 || q.Count > 0)
        {
            if (q.Count > 0 && q.Peek()[1] <= time)
            {
                int[] tmp = q.Dequeue();
                maxHeap.Enqueue(tmp[0], -tmp[0]);
            }
            if (maxHeap.Count > 0)
            {
                int taskOccurrence = maxHeap.Dequeue() - 1;
                if (taskOccurrence > 0)
                    q.Enqueue(new int[] { taskOccurrence, time + n + 1 });
            }

            time++;
        }
        return time;
    }
}
// @lc code=end

