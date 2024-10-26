/*
 * @lc app=leetcode id=210 lang=csharp
 *
 * [210] Course Schedule II
 *
 * https://leetcode.com/problems/course-schedule-ii/description/
 *
 * algorithms
 * Medium (51.63%)
 * Likes:    10957
 * Dislikes: 352
 * Total Accepted:    1.2M
 * Total Submissions: 2.3M
 * Testcase Example:  '2\n[[1,0]]'
 *
 * There are a total of numCourses courses you have to take, labeled from 0 to
 * numCourses - 1. You are given an array prerequisites where prerequisites[i]
 * = [ai, bi] indicates that you must take course bi first if you want to take
 * course ai.
 * 
 * 
 * For example, the pair [0, 1], indicates that to take course 0 you have to
 * first take course 1.
 * 
 * 
 * Return the ordering of courses you should take to finish all courses. If
 * there are many valid answers, return any of them. If it is impossible to
 * finish all courses, return an empty array.
 * 
 * 
 * Example 1:
 * 
 * 
 * Input: numCourses = 2, prerequisites = [[1,0]]
 * Output: [0,1]
 * Explanation: There are a total of 2 courses to take. To take course 1 you
 * should have finished course 0. So the correct course order is [0,1].
 * 
 * 
 * Example 2:
 * 
 * 
 * Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
 * Output: [0,2,1,3]
 * Explanation: There are a total of 4 courses to take. To take course 3 you
 * should have finished both courses 1 and 2. Both courses 1 and 2 should be
 * taken after you finished course 0.
 * So one correct course order is [0,1,2,3]. Another correct ordering is
 * [0,2,1,3].
 * 
 * 
 * Example 3:
 * 
 * 
 * Input: numCourses = 1, prerequisites = []
 * Output: [0]
 * 
 * 
 * 
 * Constraints:
 * 
 * 
 * 1 <= numCourses <= 2000
 * 0 <= prerequisites.length <= numCourses * (numCourses - 1)
 * prerequisites[i].length == 2
 * 0 <= ai, bi < numCourses
 * ai != bi
 * All the pairs [ai, bi] are distinct.
 * 
 * 
 */
/*
* BFS implementation
* Traversal all nodes in each level and push adj nodes to queue if their prerequisites are completed
*/

// @lc code=start
public partial class Solution
{
    public int[] FindOrder(int numCourses, int[][] prerequisites)
    {
        List<int> res = new List<int>();
        List<int>[] course = new List<int>[numCourses];
        Dictionary<int, int> count = new Dictionary<int, int>();
        Queue<int> q = new Queue<int>();

        for (int i = 0; i < numCourses; i++)
        {
            course[i] = new List<int>();
            count[i] = 0;
        }

        foreach (int[] prereq in prerequisites)
        {
            course[prereq[1]].Add(prereq[0]);
            count[prereq[0]]++;
        }

        for (int i = 0; i < numCourses; i++)
        {
            if (count[i] == 0)
                q.Enqueue(i);
        }

        while (q.Count > 0)
        {
            var node = q.Dequeue();
            res.Add(node);
            foreach (int c in course[node])
            {
                count[c]--;
                if (count[c] == 0)
                    q.Enqueue(c);
            }
        }

        if (count.Sum(x => x.Value) == 0)
            return res.ToArray();
        else
            return new int[] { };
    }
}
// @lc code=end

